using Sisir_1.Data;
using System.Data;

namespace Sisir_1
{
    public partial class ProjectForm : Form
    {
        private int currentId = 0;
        public List<int> temporaryTeam;
        private void ClearInputs()
        {
            name.Text = string.Empty;
            description.Text = string.Empty;
            responsible_id.SelectedIndex = -1;
            var datePickers = new[] { start_date_plan, start_date_fact, finish_date_fact, finish_date_plan };
            foreach (var datePicker in datePickers)
            {
                datePicker.Format = DateTimePickerFormat.Custom;
                datePicker.CustomFormat = " "; // Устанавливаем пустой формат по умолчанию
            }

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
                dataGridView1.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns["Description"].Width = 300;

                // Устанавливаем фиксированную ширину для этой колонки

                dataGridView1.Columns["CreationDate"].HeaderText = "Дата создания"; // Дата создания
                dataGridView1.Columns["CreationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns["CreationDate"].Width = 80;
                dataGridView1.Columns["StartDatePlan"].HeaderText = "Дата начала (план)"; // Плановая дата начала
                dataGridView1.Columns["StartDateFact"].HeaderText = "Данача начала (факт)"; // Фактическая дата начала
                dataGridView1.Columns["EndDatePlan"].HeaderText = "Дата завершения (план)"; // Плановая дата окончания
                dataGridView1.Columns["EndDateFact"].HeaderText = "Дата завершения (факт)"; // Фактическая дата окончания

                dataGridView1.Columns["StartDatePlan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns["StartDatePlan"].Width = 80;

                dataGridView1.Columns["StartDateFact"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns["StartDateFact"].Width = 80;

                dataGridView1.Columns["EndDatePlan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns["EndDatePlan"].Width = 80;

                dataGridView1.Columns["EndDateFact"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns["EndDateFact"].Width = 80;


            }
            dataGridView1.ClearSelection();

        }

        private void ShowInputs()
        {


            label4.Visible = false;
            label7.Visible = false;
            start_date_fact.Visible = false;
            finish_date_fact.Visible = false;
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
                using (var context = new HrDepartmentContext())
                {
                    label4.Visible = true;
                    label7.Visible = true;
                    start_date_fact.Visible = true;
                    finish_date_fact.Visible = true;
                    var record = context.Projects.SingleOrDefault(s => s.Id == currentId);
                    name.Text = record.Name;
                    description.Text = record.Description;
                    creation_date.Value = record.CreationDate.ToDateTime(TimeOnly.MinValue);
                    start_date_plan.Value = record.StartDatePlan.ToDateTime(TimeOnly.MinValue);
                    start_date_plan.CustomFormat = "dd.MM.yyyy";
                    if (record.StartDateFact.HasValue)
                    {
                        start_date_fact.CustomFormat = "dd.MM.yyyy";
                        start_date_fact.Value = record.StartDateFact.Value.ToDateTime(TimeOnly.MinValue);
                    }

                    finish_date_plan.Value = record.EndDatePlan.ToDateTime(TimeOnly.MinValue);
                    finish_date_plan.CustomFormat = "dd.MM.yyyy";
                    if (record.EndDateFact.HasValue)
                    {
                        finish_date_fact.CustomFormat = "dd.MM.yyyy";
                        finish_date_fact.Value = record.EndDateFact.Value.ToDateTime(TimeOnly.MinValue);
                    }
                    int responsibleId = context.ProjectEmployees
                        .Where(e => e.ProjectId == currentId && e.IsResponsible)
                        .Select(e => e.EmployeeId)
                        .FirstOrDefault();

                    foreach (var item in responsible_id.Items)
                    {
                        if (item is Employee employee && employee.Id == responsibleId)
                        {
                            responsible_id.SelectedItem = item;
                            break;
                        }
                    }
                    UpdateTeam(record.Id);
                }
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
            var fields = new Control[] { name, description, creation_date, finish_date_plan, start_date_plan };

            foreach (var field in fields)
            {
                if (string.IsNullOrWhiteSpace(field.Text))
                {
                    MessageBox.Show("Вы заполнили не все обязательные поля формы", "Ошибка");
                    return false;
                }
            }
            if (finish_date_plan.Value<start_date_plan.Value)
            {
                MessageBox.Show("Плановая дата завершения не может быть раньше плановой даты начала", "Ошибка");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(finish_date_fact.Text))
            {
                if (string.IsNullOrWhiteSpace(start_date_fact.Text))
                {
                    MessageBox.Show("Вы указали фактическую дату завершения, но не указали фактическую дату начала", "Ошибка");
                    return false;
                }
                if (finish_date_fact.Value<start_date_fact.Value)
                {
                    MessageBox.Show("Фактическая дата завершения не может быть раньше фактической даты начала", "Ошибка");
                    return false;
                }
            }
            return true;
        }
        public ProjectForm()
        {
            InitializeComponent();
        }
        public void UpdateTeam(int? id = null)
        {
            dataGridView2.Rows.Clear();
            using (var context = new HrDepartmentContext())
            {
                if (id != null)
                {
                    var team = context.ProjectEmployees
                        .Where(es => es.ProjectId == id && es.IsResponsible == false)
                        .ToList();
                    foreach (var member in team)
                    {
                        temporaryTeam.Add(member.EmployeeId);
                    }
                }
                foreach (var member in temporaryTeam)
                {
                    var record = context.Employees.Find(member);
                    if (record != null)
                    {
                        char firstNameInitial = record.Name[0];
                        
                        char? patronymicInitial = record.Patronymic?.Length > 0 ? record.Patronymic[0] : null;
                        if (patronymicInitial != null) dataGridView2.Rows.Add($"{record.Surname} {firstNameInitial}.{patronymicInitial}.", record.Position, record.Id);
                        else dataGridView2.Rows.Add($"{record.Surname} {firstNameInitial}.", record.Position, record.Id);

                        // Get the Position name (assuming Position has a property called Name)

                        // Construct the desired format

                    }

                }
            }
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

                responsible_id.DisplayMember = "ToString";
                responsible_id.ValueMember = "Id";
                if (id.HasValue)
                {
                    foreach (var item in responsible_id.Items)
                    {
                        if (item is Employee employee && employee.Id == id.Value)
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
                        var recordToUpdate = context.Projects.SingleOrDefault(s => s.Id == currentId);

                        if (recordToUpdate != null)
                        {
                            // Фамилия из TextBox
                            recordToUpdate.Name = name.Text;
                            recordToUpdate.Description = description.Text;
                            recordToUpdate.CreationDate = DateOnly.FromDateTime(creation_date.Value);
                            recordToUpdate.StartDatePlan = DateOnly.FromDateTime(start_date_plan.Value);
                            recordToUpdate.EndDatePlan = DateOnly.FromDateTime(finish_date_plan.Value);
                            if (!string.IsNullOrWhiteSpace(finish_date_fact.Text)) { recordToUpdate.EndDateFact = DateOnly.FromDateTime(finish_date_fact.Value); }
                            if (!string.IsNullOrWhiteSpace(start_date_fact.Text)) { recordToUpdate.StartDateFact = DateOnly.FromDateTime(start_date_fact.Value); }


                            var old_responsible = context.ProjectEmployees.Where(e => e.ProjectId == recordToUpdate.Id && e.IsResponsible == true).ToList();
                            context.ProjectEmployees.RemoveRange(old_responsible);
                            var old_team = context.ProjectEmployees.Where(e => e.ProjectId == recordToUpdate.Id && e.IsResponsible == false).ToList();
                            context.ProjectEmployees.RemoveRange(old_team);
                            context.SaveChanges();
                            var employeeId = -1000;
                            if (!string.IsNullOrWhiteSpace(responsible_id.Text))
                            {
                                employeeId = ((Employee)responsible_id.SelectedItem).Id;
                                var responsible = new ProjectEmployee
                                {
                                    EmployeeId = employeeId,
                                    ProjectId = recordToUpdate.Id,
                                    IsResponsible = true
                                };
                                context.ProjectEmployees.Add(responsible);
                                context.SaveChanges();
                            }
                               
                            foreach (var member in temporaryTeam)
                            {
                                if (member != employeeId)
                                {
                                    var projectEmployee = new ProjectEmployee
                                    {
                                        EmployeeId = member,
                                        ProjectId = recordToUpdate.Id,
                                        IsResponsible = false
                                    };

                                    context.ProjectEmployees.Add(projectEmployee);
                                    context.SaveChanges();
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("Запись не найдена для редактирования.");
                        }
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
                        var employeeId = -100;
                        if (!string.IsNullOrWhiteSpace(responsible_id.Text))
                        {
                            employeeId = ((Employee)responsible_id.SelectedItem).Id;
                            var responsible = new ProjectEmployee
                            {
                                EmployeeId = employeeId,
                                ProjectId = project.Id,
                                IsResponsible = true
                            };
                            context.ProjectEmployees.Add(responsible);
                            context.SaveChanges();
                        }
                        
                        foreach (var member in temporaryTeam)
                        {
                            if (member != employeeId)
                            {
                                var projectEmployee = new ProjectEmployee
                                {
                                    EmployeeId = member,
                                    ProjectId = project.Id,
                                    IsResponsible = false
                                };

                                context.ProjectEmployees.Add(projectEmployee);
                                context.SaveChanges();
                            }
                        }

                    }
                }
                currentId = 0;
                ClearInputs();
                ShowTable();
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
            var form = new EmployeeForm(this, "responsible");
            form.Show();
        }

        private void team_add_Click(object sender, EventArgs e)
        {
            var form = new EmployeeForm(this, "team");
            form.Show();
        }

        private void Project_Load(object sender, EventArgs e)
        {
            var datePickers = new[] { start_date_plan, start_date_fact, finish_date_fact, finish_date_plan };
            foreach (var datePicker in datePickers)
            {
                datePicker.Format = DateTimePickerFormat.Custom;
                datePicker.CustomFormat = " "; // Устанавливаем пустой формат по умолчанию
                datePicker.ValueChanged += UniversalDateTimePicker_ValueChanged;
            }
            FillTable();
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
                int projId = Convert.ToInt32(selectedRow.Cells[0].Value);
                using (var context = new HrDepartmentContext())
                {

                    var projToDelete = context.Projects.SingleOrDefault(s => s.Id == projId);

                    if (projToDelete != null)
                    {
                        try
                        {
                            context.Projects.Remove(projToDelete);
                            context.SaveChanges();
                        }
                        catch
                        {
                            MessageBox.Show("Данный проект невозможно удалить, так как за ним уже закреплены сотрудники", "Ошибка");
                        }
                    }
                }

                FillTable();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
            }
        }

        private void team_remove_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView2.SelectedRows[0];
                int skillId = Convert.ToInt32(selectedRow.Cells[2].Value);
                temporaryTeam.Remove(skillId);
                UpdateTeam();
            }
            else
            {
                MessageBox.Show("Вы не выбрали навык для удаления.");
            }
        }

        private void UniversalDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (sender is DateTimePicker dateTimePicker)
            {
                // Устанавливаем формат для отображения выбранной даты
                dateTimePicker.CustomFormat = "dd.MM.yyyy"; // Ваш желаемый формат
            }
        }

        
    }
}
