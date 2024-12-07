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
    public partial class PositionForm : Form
    {
        private int currentId = 0;
        private EmployeeForm? employeeForm;
        public PositionForm(EmployeeForm form)
        {
            this.employeeForm = form;
            InitializeComponent();
        }
        public PositionForm()
        {
            InitializeComponent();
        }
        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(salary.Text))
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
                    var record = context.Positions.SingleOrDefault(s => s.Id == currentId);
                    name.Text = record.Name;
                    salary.Text = record.Salary.ToString();
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
                var positions = context.Positions.OrderBy(e => e.Id).ToList();

                // Привязываем список продуктов к DataGridView
                dataGridView1.DataSource = positions;
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;

            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 78;
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Заработная плата";

            dataGridView1.ClearSelection();
        }
        private void ClearInputs()
        {
            name.Text = "";
            salary.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ShowInputs();
        }


        private void cancel_Click_1(object sender, EventArgs e)
        {
            currentId = 0;
            ClearInputs();
            ShowTable();
        }

        private void ok_Click_1(object sender, EventArgs e)
        {

            if (Validate())
            {
                int? id = null;
                using (var context = new HrDepartmentContext())
                {
                    if (currentId != 0)
                    {
                        // Режим редактирования
                        var recordToUpdate = context.Positions.SingleOrDefault(s => s.Id == currentId);

                        if (recordToUpdate != null)
                        {
                            recordToUpdate.Name = name.Text;
                            recordToUpdate.Salary = decimal.Parse(salary.Text);
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
                        var position = new Position { Name = name.Text, Salary = decimal.Parse(salary.Text) };

                        // Добавляем новый навык в таблицу Skills
                        context.Positions.Add(position);

                        // Сохраняем изменения в базе данных
                        context.SaveChanges();
                        id = position.Id;
                    }
                }
                currentId = 0;
                ClearInputs();
                ShowTable();
                if (employeeForm != null)
                {
                    employeeForm.UpdatePositionsCombobox(id);
                }
            }
            else
            {
                MessageBox.Show("Вы заполнили не все обязательные поля формы!", "Ошибка");
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

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int positionId = Convert.ToInt32(selectedRow.Cells[0].Value);
                using (var context = new HrDepartmentContext())
                {

                    var positionToDelete = context.Positions.SingleOrDefault(s => s.Id == positionId);

                    if (positionToDelete != null)
                    {
                        try
                        {
                            context.Positions.Remove(positionToDelete);
                            context.SaveChanges();
                        }
                        catch
                        {
                            MessageBox.Show("Данную должность невозможно удалить, так как есть сотрудники с этой должностью", "Ошибка");
                        }
                        
                    }
                }

                if (employeeForm != null)
                {
                    employeeForm.UpdatePositionsCombobox();
                }
                FillTable();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
            }
        }

        private void PositionForm_Load(object sender, EventArgs e)
        {
            FillTable();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (employeeForm!=null && e.RowIndex >= 0)
            {
                // Получаем текущую строку
                var row = dataGridView1.Rows[e.RowIndex];

                // Предполагаем, что ID хранится в колонке с именем "Id"
                var idValue = row.Cells["Id"].Value;

                if (idValue != null)
                {
                    int id = Convert.ToInt32(idValue);
                    employeeForm.UpdatePositionsCombobox(id);
                    this.Close();

                    // Здесь можно выполнить любое действие с этим ID
                }
            }
        }
    }
}