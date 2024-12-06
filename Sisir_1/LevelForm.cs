using Sisir_1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sisir_1
{

    public partial class LevelForm : Form
    {
        private EmployeeForm? employeeForm;
        private int currentId = 0;

        public LevelForm(EmployeeForm form)
        {
            this.employeeForm = form;
            InitializeComponent();
        }
        public LevelForm()
        {
            InitializeComponent();
        }
        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(coefficient.Text))
            {
                return false;
            }
            return true;

        }

        private void ShowInputs()
        {

            panel1.Visible = true;
            dataGridView1.Visible = false;
            add.Enabled = false;
            edit.Enabled = false;
            delete.Enabled = false;
            if (currentId != 0)
            {
                using (var context = new HrDepartmentContext())
                {
                    var record = context.Levels.SingleOrDefault(s => s.Id == currentId);
                    name.Text = record.Name;
                    coefficient.Text = record.Coefficient.ToString();
                }
            }
        }

        private void ShowTable()
        {
            panel1.Visible = false;
            dataGridView1.Visible = true;
            add.Enabled = true;
            edit.Enabled = true;
            delete.Enabled = true;
            FillTable();
        }

        private void FillTable()
        {
            using (var context = new HrDepartmentContext())
            {
                // Получаем все продукты из базы данных
                var levels = context.Levels.OrderBy(e => e.Id).ToList();

                // Привязываем список продуктов к DataGridView
                dataGridView1.DataSource = levels;
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;

            dataGridView1.Columns[1].Width = 195;
            dataGridView1.Columns[2].Width = 102;
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Коэффициент";

            dataGridView1.ClearSelection();
        }

        private void ClearInputs()
        {
            name.Text = "";
            coefficient.Text = "";
        }

        private void add_Click(object sender, EventArgs e)
        {
            ShowInputs();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            int? id = null;
            if (Validate())
            {
                using (var context = new HrDepartmentContext())
                {
                    if (currentId != 0)
                    {
                        // Режим редактирования
                        var recordToUpdate = context.Levels.SingleOrDefault(s => s.Id == currentId);

                        if (recordToUpdate != null)
                        {
                            recordToUpdate.Name = name.Text;
                            recordToUpdate.Coefficient = decimal.Parse(coefficient.Text);
                            context.SaveChanges();
                            id = recordToUpdate.Id;

                        }
                        else
                        {
                            MessageBox.Show("Запись не найдена для редактирования.");
                        }
                    }
                    else
                    {
                        var level = new Level { Name = name.Text, Coefficient = decimal.Parse(coefficient.Text) };

                        // Добавляем новый навык в таблицу Skills
                        context.Levels.Add(level);

                        // Сохраняем изменения в базе данных
                        context.SaveChanges();
                        id = level.Id;

                    }
                }
                currentId = 0;
                ClearInputs();
                ShowTable();
                if (employeeForm != null)
                {
                    employeeForm.UpdateLevelsCombobox(id);
                }
            }
            else
            {
                MessageBox.Show("Вы заполнили не все обязательные поля формы!", "Ошибка");
            }

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            currentId = 0;
            ClearInputs();
            ShowTable();
        }

        private void LevelForm_Load(object sender, EventArgs e)
        {
            FillTable();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int levelId = Convert.ToInt32(selectedRow.Cells[0].Value);
                using (var context = new HrDepartmentContext())
                {

                    var levelToDelete = context.Levels.SingleOrDefault(s => s.Id == levelId);

                    if (levelToDelete != null)
                    {

                        context.Levels.Remove(levelToDelete);
                        context.SaveChanges();
                    }
                }
                if (employeeForm != null)
                {
                    employeeForm.UpdateLevelsCombobox();
                }
                FillTable();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                currentId = Convert.ToInt32(selectedRow.Cells[0].Value);
                ShowInputs();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для изменения.");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (employeeForm != null && e.RowIndex >= 0)
            {
                // Получаем текущую строку
                var row = dataGridView1.Rows[e.RowIndex];

                // Предполагаем, что ID хранится в колонке с именем "Id"
                var idValue = row.Cells["Id"].Value;

                if (idValue != null)
                {
                    int id = Convert.ToInt32(idValue);
                    employeeForm.UpdateLevelsCombobox(id);
                    this.Close();
                    // Здесь можно выполнить любое действие с этим ID
                }
            }
        }
    }
}
