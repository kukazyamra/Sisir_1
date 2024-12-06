using Microsoft.EntityFrameworkCore;
using Sisir_1.Data;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Sisir_1
{
    public partial class ProjectForm : Form
    {
        private int currentId = 0;
        List<int> temporaryTeam;
        private void ClearInputs()
        {
            name.Text = string.Empty;
            description.Text = string.Empty;
            responsible_id.SelectedIndex = -1;
            start_date_fact.Value = DateTime.Today;
            start_date_plan.Value = DateTime.Today;
            finish_date_fact.Value = DateTime.Today;
            finish_date_fact.Value = DateTime.Today;
            creation_date.Value = DateTime.Today;
        }


        public void FillTable()
        {
            using (var context = new HrDepartmentContext())
            {
                var projects = context.Projects
                // Жадно загружаем уровни
                .Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.Description,
                    e.CreationDate,
                    e.StartDatePlan,
                    e.StartDateFact,
                    e.EndDateFact,
                    e.EndDatePlan
                })
                .OrderBy(e => e.Id)
                .ToList();
                dataGridView1.DataSource = projects;
                dataGridView1.Columns[0].Visible = false; // Скрываем первый столбец
                dataGridView1.Columns["Name"].HeaderText = "Название"; // Название проекта
                dataGridView1.Columns["Description"].HeaderText = "Описание"; // Описание проекта
                dataGridView1.Columns["CreationDate"].HeaderText = "Дата создания"; // Дата создания
                dataGridView1.Columns["StartDatePlan"].HeaderText = "Дата начала (план)"; // Плановая дата начала
                dataGridView1.Columns["StartDateFact"].HeaderText = "Данача начала (факт)"; // Фактическая дата начала
                dataGridView1.Columns["EndDatePlan"].HeaderText = "Дата завершения (план)"; // Плановая дата окончания
                dataGridView1.Columns["EndDateFact"].HeaderText = "Дата завершения (факт)"; // Фактическая дата окончания

            }


            dataGridView1.ClearSelection();

        }

        private void ShowInputs(int? id = null)
        {
            panel1.Visible = true;
            dataGridView1.Visible = false;
            add.Enabled = false;
            edit.Enabled = false;
            delete.Enabled = false;
            UpdateResponsibleCombobox();
            temporaryTeam = new List<int>();
            UpdateTeam();
            if (currentId != 0)
            {

            }
            //ДОБАВИТЬ ДЛЯ РЕДАКТИРОВАНИЯ
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
        private bool Validate()
        {
            return true;
        }
        public ProjectForm()
        {
            InitializeComponent();
        }
        public void UpdateTeam()
        {

        }
        public void UpdateResponsibleCombobox(int? id = null)
        {
            using (var context = new HrDepartmentContext())
            {
                var employees = context.Employees.ToList();
                responsible_id.Items.Clear();

                // Добавляем пустой элемент в начало ComboBox

                // Добавляем элементы из базы данных в ComboBox
                foreach (var employee in employees)
                {
                    responsible_id.Items.Add(employee);
                }

                // Устанавливаем отображаемое значение (то, что увидит пользователь)
                responsible_id.DisplayMember = "ToString";
                // Устанавливаем значение, которое будет храниться при выборе (например, ID)
                responsible_id.ValueMember = "Id";
                if (id.HasValue)
                {
                    foreach (var item in responsible_id.Items)
                    {
                        if (item is Level level && level.Id == id.Value)
                        {
                            responsible_id.SelectedItem = item;
                            break;
                        }
                    }
                }
                else
                {
                    responsible_id.SelectedIndex = -1; // Сброс выделения, если id не передан
                }

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ShowInputs();
        }




        private void ok_Click_1(object sender, EventArgs e)
        {
            if (Validate())
            {
                using (var context = new HrDepartmentContext())
                {
                    if (currentId != 0)
                    {
                    //    var recordToUpdate = context.Employees.SingleOrDefault(s => s.Id == currentId);

                    //    if (recordToUpdate != null)
                    //    {
                    //        recordToUpdate.Surname = surname.Text;                // Фамилия из TextBox
                    //        recordToUpdate.Name = name.Text;               // Имя из TextBox
                    //        recordToUpdate.Patronymic = patronymic.Text == "" ? null : patronymic.Text;         // Отчество из TextBox
                    //        recordToUpdate.Birthdate = DateOnly.FromDateTime(birthday.Value); // Дата рождения из DateTimePicker
                    //        recordToUpdate.PassportSeries = series.Text; // Серия паспорта
                    //        recordToUpdate.PassportNumber = number.Text; // Номер паспорта
                    //        recordToUpdate.IssuedBy = issued_by.Text;          // Кем выдан
                    //        recordToUpdate.IssueDate = DateOnly.FromDateTime(issue_date.Value); // Дата выдачи паспорта
                    //        recordToUpdate.RegistrationAddress = reegistration_address.Text; // Адрес регистрации
                    //        recordToUpdate.ResidenceAddress = residential_address.Text;       // Адрес проживания
                    //        recordToUpdate.Phone = phone.Text;                   // Телефон
                    //        recordToUpdate.Email = email.Text == "" ? null : email.Text;           // Email
                    //        recordToUpdate.Telegram = telegram.Text == "" ? null : telegram.Text;            // Telegram

                    //        // Получаем выбранные значения из ComboBox
                    //        recordToUpdate.PositionId = ((Position)position_id.SelectedItem).Id; // ID должности
                    //        recordToUpdate.LevelId = ((Level)level_id.SelectedItem)?.Id;
                    //        if (recordToUpdate.LevelId == 0)
                    //        {
                    //            recordToUpdate.LevelId = null;
                    //        }
                    //        var employeeSkills = context.EmployeeSkills
                    //            .Where(es => es.EmployeeId == recordToUpdate.Id)
                    //            .ToList();

                    //        // Удаляем все записи из таблицы EmployeeSkill, соответствующие данному сотруднику
                    //        context.EmployeeSkills.RemoveRange(employeeSkills);

                    //        // Сохраняем изменения в базе данных
                    //        context.SaveChanges();

                    //        foreach (var skill in temporarySkills)
                    //        {
                    //            var employeeSkill = new EmployeeSkill
                    //            {
                    //                EmployeeId = recordToUpdate.Id,
                    //                SkillId = skill.Key,
                    //                SkillLevel = skill.Value
                    //            };
                    //            context.EmployeeSkills.Add(employeeSkill);
                    //            context.SaveChanges();
                    //        }

                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Запись не найдена для редактирования.");
                    //    }
                    }
                    else
                    {
                        var project = new Project
                        {
                           
                            Name = name.Text,
                            Description = description.Text,
                            CreationDate = DateOnly.FromDateTime(creation_date.Value),
                            StartDatePlan = DateOnly.FromDateTime(start_date_plan.Value),
                            EndDatePlan = DateOnly.FromDateTime(finish_date_plan.Value),
                             // ID уровня (может быть null)
                        };
                        context.Projects.Add(project);
                        context.SaveChanges();
                        //foreach (var skill in temporarySkills)
                        //{
                        //    var employeeSkill = new EmployeeSkill
                        //    {
                        //        EmployeeId = newEmployee.Id,
                        //        SkillId = skill.Key,
                        //        SkillLevel = skill.Value
                        //    };

                        //    context.EmployeeSkills.Add(employeeSkill);
                        //    context.SaveChanges();
                        //}

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
            ClearInputs();
            currentId = 0;
            ShowTable();
        }

        private void add_responsible_Click(object sender, EventArgs e)
        {
            var form = new EmployeeForm();
            form.Show();
        }

        private void team_add_Click(object sender, EventArgs e)
        {
            var form = new EmployeeForm();
            form.Show();
        }

        private void Project_Load(object sender, EventArgs e)
        {
            FillTable();
        }

        private void edit_Click(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {

        }

        private void team_remove_Click(object sender, EventArgs e)
        {

        }


    }
}
