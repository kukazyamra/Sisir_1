using Sisir_1.Data;
using System.Windows.Forms;

namespace Sisir_1
{
    public partial class SkillForm : Form
    {
        private int currentId = 0;

        public SkillForm()
        {
            InitializeComponent();
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
                    var record = context.Skills.SingleOrDefault(s => s.Id == currentId);
                    name.Text = record.Name;
                }
            }
        }
        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(name.Text))
            {
                return false;
            }
            return true;

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
        private void ClearInputs()
        {
            name.Text = "";
        }
        private void ok_Click_1(object sender, EventArgs e)
        {
            if (Validate())
            {
                using (var context = new HrDepartmentContext())
                {
                    if (currentId != 0)
                    {
                        // Режим редактирования
                        var recordToUpdate = context.Skills.SingleOrDefault(s => s.Id == currentId);

                        if (recordToUpdate != null)
                        {
                            recordToUpdate.Name = name.Text;
                            context.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Запись не найдена для редактирования.");
                        }
                    }
                    else
                    {
                        var skill = new Skill { Name = name.Text };

                        // Добавляем новый навык в таблицу Skills
                        context.Skills.Add(skill);

                        // Сохраняем изменения в базе данных
                        context.SaveChanges();
                    }
                }
                currentId = 0;
                ClearInputs();
                ShowTable();
            }
            else
            {
                MessageBox.Show("Вы заполнили не все обязательные поля формы!", "Ошибка");
            }
            
        }

        private void cancel_Click_1(object sender, EventArgs e)
        {
            currentId = 0;
            ClearInputs();
            ShowTable();
        }
        private void FillTable()
        {
            // Инициализируем контекст
            using (var context = new HrDepartmentContext())
            {
                // Получаем все продукты из базы данных
                var products = context.Skills.ToList();

                // Привязываем список продуктов к DataGridView
                dataGridView1.DataSource = products;
            }
            dataGridView1.Columns[0].Visible = false; // Скрываем второй столбец
            dataGridView1.Columns[2].Visible = false; // Скрываем второй столбец
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.ClearSelection();
        }
        private void SkillForm_Load(object sender, EventArgs e)
        {
            FillTable();

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int skillId = Convert.ToInt32(selectedRow.Cells[0].Value);
                using (var context = new HrDepartmentContext())
                {

                    var skillToDelete = context.Skills.SingleOrDefault(s => s.Id == skillId);

                    if (skillToDelete != null)
                    {

                        context.Skills.Remove(skillToDelete);
                        context.SaveChanges();
                    }
                }
                MessageBox.Show("Объект успешно удален.");
                FillTable();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            ShowInputs();
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
    }
}
