using Microsoft.EntityFrameworkCore;
using Sisir_1.Data;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Sisir_1
{
    public partial class EmployeeForm : Form
    {
        private int currentId = 0;

        public EmployeeForm()
        {
            InitializeComponent();
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
        private void ShowInputs()
        {
            panel1.Visible = true;
            dataGridView1.Visible = false;
            add.Enabled = false;
            edit.Enabled = false;
            delete.Enabled = false;
            using (var context = new HrDepartmentContext())
            {
                var positions = context.Positions.ToList();

                // Привязываем данные к ComboBox
                position_id.DataSource = positions;

                // Устанавливаем отображаемое значение (то, что увидит пользователь)
                position_id.DisplayMember = "Name"; // Название должности

                // Устанавливаем значение, которое будет храниться при выборе (например, ID)
                position_id.ValueMember = "Id";

                position_id.SelectedIndex = -1;
                var levels = context.Levels.ToList();
                level_id.Items.Clear();

                // Добавляем пустой элемент в начало ComboBox
                level_id.Items.Add(new Level { Id = 0, Name = "Нет", Coefficient = 1 });

                // Добавляем элементы из базы данных в ComboBox
                foreach (var level in levels)
                {
                    level_id.Items.Add(level);
                }

                // Устанавливаем отображаемое значение (то, что увидит пользователь)
                level_id.DisplayMember = "Name";  // Отображается свойство Name из модели Position

                // Устанавливаем значение, которое будет храниться при выборе (например, ID)
                level_id.ValueMember = "Id";
                level_id.SelectedIndex = -1;

            }

        }

        private bool Validate()
        {
            var fields = new Control[] { surname, name,  birthday, series, number, issued_by, issue_date,
                reegistration_address, residential_address, phone,  position_id,};

            foreach (var field in fields)
            {
                if (string.IsNullOrWhiteSpace(field.Text))
                {
                    return false;
                }
            }
            return true;

        }

        public void FillTable()
        {
            using (var context = new HrDepartmentContext())
            {
                var employees = context.Employees
                .Include(e => e.Position)  // Жадно загружаем должности
                .Include(e => e.Level)      // Жадно загружаем уровни
                .Select(e => new
                {
                    e.Id,
                    e.Surname,
                    e.Name,
                    e.Patronymic,
                    e.Birthdate,
                    e.PassportSeries,
                    e.PassportNumber,
                    e.IssuedBy,
                    e.IssueDate,
                    e.RegistrationAddress,
                    e.ResidenceAddress,
                    e.Phone,
                    e.Email,
                    e.Telegram,
                    PositionName = e.Position.Name,  // Название должности
                    LevelName = e.Level.Name,
                    Salary = e.Position.Salary * (e.Level != null ? e.Level.Coefficient : 1)// Название уровня
                    // Включите дополнительные свойства, если необходимо
                })
                .ToList();
                dataGridView1.DataSource = employees;
                dataGridView1.Columns[0].Visible=false;
                dataGridView1.Columns["Surname"].HeaderText = "Фамилия";
                dataGridView1.Columns["Name"].HeaderText = "Имя";
                dataGridView1.Columns["Patronymic"].HeaderText = "Отчество";
                dataGridView1.Columns["Birthdate"].HeaderText = "Дата рождения";
                dataGridView1.Columns["PassportSeries"].HeaderText = "Серия паспорта";
                dataGridView1.Columns["PassportNumber"].HeaderText = "Номер паспорта";
                dataGridView1.Columns["IssuedBy"].HeaderText = "Кем выдан";
                dataGridView1.Columns["IssueDate"].HeaderText = "Дата выдачи";
                dataGridView1.Columns["RegistrationAddress"].HeaderText = "Адрес регистрации";
                dataGridView1.Columns["ResidenceAddress"].HeaderText = "Адрес проживания";
                dataGridView1.Columns["Phone"].HeaderText = "Телефон";
                dataGridView1.Columns["Email"].HeaderText = "Email";
                dataGridView1.Columns["Telegram"].HeaderText = "Telegram";
                dataGridView1.Columns["PositionName"].HeaderText = "Должность";  // Название должности
                dataGridView1.Columns["LevelName"].HeaderText = "Уровень";
                dataGridView1.Columns["Salary"].HeaderText = "Зарплата";

            }
            //dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[3].Visible = false;

            //dataGridView1.Columns[1].Width = 200;
            //dataGridView1.Columns[2].Width = 78;
            //dataGridView1.Columns[1].HeaderText = "Наименование";
            //dataGridView1.Columns[2].HeaderText = "Заработная плата";

            dataGridView1.ClearSelection();
        }
        private void add_Click(object sender, EventArgs e)
        {
            ShowInputs();
        }



        private void ok_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                using (var context = new HrDepartmentContext())
                {
                    if (currentId != 0)
                    {
                        // Режим редактирования
                        //var recordToUpdate = context.Levels.SingleOrDefault(s => s.Id == currentId);

                        //if (recordToUpdate != null)
                        //{
                        //    recordToUpdate.Name = name.Text;
                        //    recordToUpdate.Coefficient = decimal.Parse(coefficient.Text);
                        //    context.SaveChanges();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Запись не найдена для редактирования.");
                        //}
                    }
                    else
                    {
                        var newEmployee = new Employee
                        {
                            Surname = surname.Text,                // Фамилия из TextBox
                            Name = name.Text,                     // Имя из TextBox
                            Patronymic = patronymic.Text == "" ? null : patronymic.Text,         // Отчество из TextBox
                            Birthdate = DateOnly.FromDateTime(birthday.Value), // Дата рождения из DateTimePicker
                            PassportSeries = series.Text, // Серия паспорта
                            PassportNumber = number.Text, // Номер паспорта
                            IssuedBy = issued_by.Text,             // Кем выдан
                            IssueDate = DateOnly.FromDateTime(issue_date.Value), // Дата выдачи паспорта
                            RegistrationAddress = reegistration_address.Text, // Адрес регистрации
                            ResidenceAddress = residential_address.Text,       // Адрес проживания
                            Phone = phone.Text,                   // Телефон
                            Email = email.Text == "" ? null : email.Text,           // Email
                            Telegram = telegram.Text == "" ? null : telegram.Text,            // Telegram

                            // Получаем выбранные значения из ComboBox
                            PositionId = ((Position)position_id.SelectedItem).Id, // ID должности
                            LevelId = ((Level)level_id.SelectedItem)?.Id          // ID уровня (может быть null)
                        };
                        if (newEmployee.LevelId == 0)
                        {
                            newEmployee.LevelId = null;
                        }

                        // Добавляем нового сотрудника в контекст базы данных
                        context.Employees.Add(newEmployee);

                        // Сохраняем изменения в базе данных
                        context.SaveChanges();
                    }
                }
                currentId = 0;

                ShowTable();
            }
            else
            {
                MessageBox.Show("Вы заполнили не все обязательные поля формы!", "Ошибка");
            }

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            ShowTable();
        }



        private void Employee_Load_1(object sender, EventArgs e)
        {
            FillTable();
        }





        private void button6_Click(object sender, EventArgs e)
        {
            var form = new PositionForm();
            form.Show();
        }


        private void button7_Click_1(object sender, EventArgs e)
        {
            var form = new LevelForm();
            form.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var form = new SkillForm();
            form.Show();
        }

        private void edit_Click(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int employeeId = Convert.ToInt32(selectedRow.Cells[0].Value);
                using (var context = new HrDepartmentContext())
                {

                    var employeeToDelete = context.Employees.SingleOrDefault(s => s.Id == employeeId);

                    if (employeeToDelete != null)
                    {

                        context.Employees.Remove(employeeToDelete);
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
    }
}
