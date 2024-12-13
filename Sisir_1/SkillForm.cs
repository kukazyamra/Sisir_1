using Sisir_1.Data;
using Sisir_1.Reports;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sisir_1
{
    public partial class SkillForm : Form
    {
        private int currentId = 0;

        private EmployeeForm? employeeForm;
        private SkillReport? skillReportForm;
        public SkillForm()
        {
            InitializeComponent();
        }
        public SkillForm(SkillReport form)
        {
            this.skillReportForm = form;
            InitializeComponent();
        }
        public SkillForm(EmployeeForm form)
        {
            this.employeeForm = form;
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
                if (employeeForm != null)
                {
                    employeeForm.UpdateSkills();
                }
                if (skillReportForm != null)
                {
                    skillReportForm.UpdateSkills();
                }
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
                var products = context.Skills.OrderBy(e => e.Id).ToList();

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
                        try
                        {
                            context.Skills.Remove(skillToDelete);
                            context.SaveChanges();
                            if (employeeForm != null)
                            {
                                employeeForm.UpdateSkills();
                               
                            }
                            if (skillReportForm != null)
                            {
                                skillReportForm.UpdateSkills();
                               
                            }
                            FillTable();
                        }
                        catch
                        {
                            MessageBox.Show("Данный навык невозможно удалить, так как он присвоен некоторым сотрудникам", "Ошибка");
                        }
                    }
                }
                
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

       

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (employeeForm != null)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                // Предполагаем, что ID хранится в колонке с именем "Id"
                var idValue = row.Cells["Id"].Value;

                if (idValue != null)
                {
                    int id = Convert.ToInt32(idValue);
                    var form = new Skill_level(employeeForm, id);
                    this.Close();
                    form.Show();
                }

            }
            if (skillReportForm != null)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                // Предполагаем, что ID хранится в колонке с именем "Id"
                var idValue = row.Cells["Id"].Value;

                if (idValue != null)
                {
                    int id = Convert.ToInt32(idValue);
                    try
                    {
                        if (skillReportForm.temporarySkills.IndexOf(id) == -1)
                        {
                            using (var context = new HrDepartmentContext())
                            {
                                if (context.Skills.Find(id) != null)
                                {
                                    skillReportForm.temporarySkills.Add(id);
                                    skillReportForm.UpdateSkills();
                                    this.Close();
                                }
                            }
                                
                                
                        }
                        else MessageBox.Show("Вы уже добавили этот навык", "Ошибка");
                        
                    }
                    catch (InvalidOperationException)
                    {
                        MessageBox.Show("Не удалось добавить навык. \nВозможно, вы закрыли форму добавления сотрудников?", "Ошибка");
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("Вы уже добавли этот навык.", "Ошибка");
                    }
                }
            }
        }
    }
}
