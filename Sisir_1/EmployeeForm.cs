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

                // ����������� ������ � ComboBox
                position_id.DataSource = positions;

                // ������������� ������������ �������� (��, ��� ������ ������������)
                position_id.DisplayMember = "Name"; // �������� ���������

                // ������������� ��������, ������� ����� ��������� ��� ������ (��������, ID)
                position_id.ValueMember = "Id";

                position_id.SelectedIndex = -1;
                var levels = context.Levels.ToList();
                level_id.Items.Clear();

                // ��������� ������ ������� � ������ ComboBox
                level_id.Items.Add(new Level { Id = 0, Name = "���", Coefficient = 1 });

                // ��������� �������� �� ���� ������ � ComboBox
                foreach (var level in levels)
                {
                    level_id.Items.Add(level);
                }

                // ������������� ������������ �������� (��, ��� ������ ������������)
                level_id.DisplayMember = "Name";  // ������������ �������� Name �� ������ Position

                // ������������� ��������, ������� ����� ��������� ��� ������ (��������, ID)
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
                .Include(e => e.Position)  // ����� ��������� ���������
                .Include(e => e.Level)      // ����� ��������� ������
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
                    PositionName = e.Position.Name,  // �������� ���������
                    LevelName = e.Level.Name,
                    Salary = e.Position.Salary * (e.Level != null ? e.Level.Coefficient : 1)// �������� ������
                    // �������� �������������� ��������, ���� ����������
                })
                .ToList();
                dataGridView1.DataSource = employees;
                dataGridView1.Columns[0].Visible=false;
                dataGridView1.Columns["Surname"].HeaderText = "�������";
                dataGridView1.Columns["Name"].HeaderText = "���";
                dataGridView1.Columns["Patronymic"].HeaderText = "��������";
                dataGridView1.Columns["Birthdate"].HeaderText = "���� ��������";
                dataGridView1.Columns["PassportSeries"].HeaderText = "����� ��������";
                dataGridView1.Columns["PassportNumber"].HeaderText = "����� ��������";
                dataGridView1.Columns["IssuedBy"].HeaderText = "��� �����";
                dataGridView1.Columns["IssueDate"].HeaderText = "���� ������";
                dataGridView1.Columns["RegistrationAddress"].HeaderText = "����� �����������";
                dataGridView1.Columns["ResidenceAddress"].HeaderText = "����� ����������";
                dataGridView1.Columns["Phone"].HeaderText = "�������";
                dataGridView1.Columns["Email"].HeaderText = "Email";
                dataGridView1.Columns["Telegram"].HeaderText = "Telegram";
                dataGridView1.Columns["PositionName"].HeaderText = "���������";  // �������� ���������
                dataGridView1.Columns["LevelName"].HeaderText = "�������";
                dataGridView1.Columns["Salary"].HeaderText = "��������";

            }
            //dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[3].Visible = false;

            //dataGridView1.Columns[1].Width = 200;
            //dataGridView1.Columns[2].Width = 78;
            //dataGridView1.Columns[1].HeaderText = "������������";
            //dataGridView1.Columns[2].HeaderText = "���������� �����";

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
                        // ����� ��������������
                        //var recordToUpdate = context.Levels.SingleOrDefault(s => s.Id == currentId);

                        //if (recordToUpdate != null)
                        //{
                        //    recordToUpdate.Name = name.Text;
                        //    recordToUpdate.Coefficient = decimal.Parse(coefficient.Text);
                        //    context.SaveChanges();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("������ �� ������� ��� ��������������.");
                        //}
                    }
                    else
                    {
                        var newEmployee = new Employee
                        {
                            Surname = surname.Text,                // ������� �� TextBox
                            Name = name.Text,                     // ��� �� TextBox
                            Patronymic = patronymic.Text == "" ? null : patronymic.Text,         // �������� �� TextBox
                            Birthdate = DateOnly.FromDateTime(birthday.Value), // ���� �������� �� DateTimePicker
                            PassportSeries = series.Text, // ����� ��������
                            PassportNumber = number.Text, // ����� ��������
                            IssuedBy = issued_by.Text,             // ��� �����
                            IssueDate = DateOnly.FromDateTime(issue_date.Value), // ���� ������ ��������
                            RegistrationAddress = reegistration_address.Text, // ����� �����������
                            ResidenceAddress = residential_address.Text,       // ����� ����������
                            Phone = phone.Text,                   // �������
                            Email = email.Text == "" ? null : email.Text,           // Email
                            Telegram = telegram.Text == "" ? null : telegram.Text,            // Telegram

                            // �������� ��������� �������� �� ComboBox
                            PositionId = ((Position)position_id.SelectedItem).Id, // ID ���������
                            LevelId = ((Level)level_id.SelectedItem)?.Id          // ID ������ (����� ���� null)
                        };
                        if (newEmployee.LevelId == 0)
                        {
                            newEmployee.LevelId = null;
                        }

                        // ��������� ������ ���������� � �������� ���� ������
                        context.Employees.Add(newEmployee);

                        // ��������� ��������� � ���� ������
                        context.SaveChanges();
                    }
                }
                currentId = 0;

                ShowTable();
            }
            else
            {
                MessageBox.Show("�� ��������� �� ��� ������������ ���� �����!", "������");
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
                MessageBox.Show("������ ������� ������.");
                FillTable();
            }
            else
            {
                MessageBox.Show("����������, �������� ������ ��� ��������.");
            }
        }
    }
}
