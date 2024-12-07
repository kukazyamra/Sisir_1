﻿using Microsoft.EntityFrameworkCore;
using Sisir_1.Data;
using System.Data;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
            start_date_fact.Value = DateTime.Today;
            start_date_plan.Value = DateTime.Today;
            finish_date_plan.Value = DateTime.Today;
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

        private void ShowInputs()
        {

         
            // Пустой формат
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
                    var record = context.Projects.SingleOrDefault(s => s.Id == currentId);
                    name.Text = record.Name;
                    description.Text = record.Description;
                    creation_date.Value = record.CreationDate.ToDateTime(TimeOnly.MinValue);
                    start_date_plan.Value = record.StartDatePlan.ToDateTime(TimeOnly.MinValue);
                    if (record.StartDateFact.HasValue)
                    {
                        start_date_fact.Value = record.StartDateFact.Value.ToDateTime(TimeOnly.MinValue);
                    }

                    finish_date_plan.Value = record.EndDatePlan.ToDateTime(TimeOnly.MinValue);

                    if (record.EndDateFact.HasValue)
                    {
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
            var fields = new Control[] { name, description, creation_date, responsible_id, start_date_fact, start_date_plan, finish_date_fact, finish_date_plan };

            foreach (var field in fields)
            {
                if (string.IsNullOrWhiteSpace(field.Text))
                {
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
                        char firstNameInitial = record.Name.Length > 0 ? Name[0] : ' ';
                        char patronymicInitial = record.Patronymic?.Length > 0 ? record.Patronymic[0] : ' ';

                        // Get the Position name (assuming Position has a property called Name)

                        // Construct the desired format

                        dataGridView2.Rows.Add($"{record.Surname} {firstNameInitial}.{patronymicInitial}.", record.Position, record.Id);
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
                        MessageBox.Show("edit");
                        var recordToUpdate = context.Projects.SingleOrDefault(s => s.Id == currentId);

                        if (recordToUpdate != null)
                        {
                            // Фамилия из TextBox
                            recordToUpdate.Name = name.Text;
                            recordToUpdate.Description = description.Text;
                            recordToUpdate.CreationDate = DateOnly.FromDateTime(creation_date.Value);
                            recordToUpdate.StartDatePlan = DateOnly.FromDateTime(start_date_plan.Value);
                            recordToUpdate.EndDatePlan = DateOnly.FromDateTime(finish_date_plan.Value);
                            recordToUpdate.EndDateFact = DateOnly.FromDateTime(finish_date_plan.Value);
                            recordToUpdate.StartDateFact = DateOnly.FromDateTime(start_date_fact.Value);

                            var old_responsible = context.ProjectEmployees.Where(e => e.ProjectId == recordToUpdate.Id && e.IsResponsible == true).ToList();
                            context.ProjectEmployees.RemoveRange(old_responsible);

                            var employeeId = ((Employee)responsible_id.SelectedItem).Id;
                            var responsible = new ProjectEmployee
                            {
                                EmployeeId = employeeId,
                                ProjectId = recordToUpdate.Id,
                                IsResponsible = true
                            };
                            context.ProjectEmployees.Add(responsible);
                            context.SaveChanges();

                            var old_team = context.ProjectEmployees.Where(e => e.ProjectId == recordToUpdate.Id && e.IsResponsible == false).ToList();
                            context.ProjectEmployees.RemoveRange(old_team);
                            context.SaveChanges();
                            foreach (var member in temporaryTeam)
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
                        var employeeId = ((Employee)responsible_id.SelectedItem).Id;
                        var responsible = new ProjectEmployee
                        {
                            EmployeeId = employeeId,
                            ProjectId = project.Id,
                            IsResponsible = true
                        };
                        context.ProjectEmployees.Add(responsible);
                        context.SaveChanges();
                        foreach (var member in temporaryTeam)
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

        
    }
}
