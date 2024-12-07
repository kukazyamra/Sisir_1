using Microsoft.EntityFrameworkCore;
using Sisir_1.Data;

namespace Sisir_1
{
    public partial class EmployeeForm : Form
    {

        private int currentId = 0;
        private string mode;
        public ProjectForm projectForm;
        public Dictionary<int, int?> temporarySkills;

        public EmployeeForm (ProjectForm form, string mode_)
        {
            this.projectForm = form;
            this.mode = mode_;
            InitializeComponent();
        }
        private void ClearInputs()
        {
            name.Text = string.Empty;
            surname.Text = string.Empty;
            patronymic.Text = string.Empty;
            birthday.Value = DateTime.Today;
            series.Text = string.Empty;
            number.Text = string.Empty;
            issued_by.Text = string.Empty;
            issue_date.Value = DateTime.Today;
            reegistration_address.Text = string.Empty;
            residential_address.Text = string.Empty;
            phone.Text = string.Empty;
            telegram.Text = string.Empty;
            email.Text = string.Empty;
            position_id.SelectedIndex = -1;
            level_id.SelectedIndex = -1;

        }
        public void UpdateSkills(int? id = null)
        {
            dataGridView2.Rows.Clear();
            using (var context = new HrDepartmentContext())
            {
                if (id != null)
                {
                    var skills = context.EmployeeSkills
                        .Where(es => es.EmployeeId == id)  // ��������� �� ����������
                        .ToList();
                    foreach (var skill in skills)
                    {
                        temporarySkills.Add(skill.SkillId, skill.SkillLevel);
                    }
                }
                foreach (var kvp in temporarySkills)
                {
                    var record = context.Skills.Find(kvp.Key);
                    if (record != null)
                    {
                        dataGridView2.Rows.Add(record.Name, kvp.Value, kvp.Key);

                    }
                }
            }


        }

        public void UpdatePositionsCombobox(int? id = null)
        {
            using (var context = new HrDepartmentContext())
            {
                var positions = context.Positions.ToList();
                position_id.DataSource = positions;

                // ������������� ������������ �������� (��, ��� ������ ������������)
                position_id.DisplayMember = "Name"; // �������� ���������

                // ������������� ��������, ������� ����� ��������� ��� ������ (��������, ID)
                position_id.ValueMember = "Id";
                if (id.HasValue)
                {
                    position_id.SelectedValue = id.Value;
                }
                else
                {
                    position_id.SelectedIndex = -1; // ����� ���������, ���� id �� �������
                }
            }

        }
        public void UpdateLevelsCombobox(int? id = null)
        {
            using (var context = new HrDepartmentContext())
            {
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
                if (id.HasValue)
                {
                    foreach (var item in level_id.Items)
                    {
                        if (item is Level level && level.Id == id.Value)
                        {
                            level_id.SelectedItem = item;
                            break;
                        }
                    }
                }
                else
                {
                    level_id.SelectedIndex = -1; // ����� ���������, ���� id �� �������
                }

            }
        }
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
            UpdatePositionsCombobox();
            UpdateLevelsCombobox();
            temporarySkills = new Dictionary<int, int?>();
            UpdateSkills();
            if (currentId != 0)
            {
                using (var context = new HrDepartmentContext())
                {
                    var record = context.Employees.SingleOrDefault(s => s.Id == currentId);
                    name.Text = record.Name;
                    surname.Text = record.Surname;
                    patronymic.Text = record.Patronymic;
                    birthday.Value = record.Birthdate.ToDateTime(TimeOnly.MinValue);
                    series.Text = record.PassportSeries;
                    number.Text = record.PassportNumber;
                    issued_by.Text = record.IssuedBy;
                    issue_date.Value = record.IssueDate.ToDateTime(TimeOnly.MinValue);
                    reegistration_address.Text = record.RegistrationAddress;
                    residential_address.Text = record.ResidenceAddress;
                    phone.Text = record.Phone;
                    telegram.Text = record.Telegram;
                    email.Text = record.Email;
                    position_id.SelectedValue = record.PositionId;
                    if (record.LevelId != null)
                    {
                        // ������� ������� � ���������� id
                        foreach (var item in level_id.Items)
                        {
                            if (item is Level level && level.Id == record.LevelId)
                            {
                                level_id.SelectedItem = item;
                                break;
                            }
                        }
                    }
                    UpdateSkills(record.Id);
                }
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
                .OrderBy(e => e.Id)
                .ToList();
                dataGridView1.DataSource = employees;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns["Surname"].HeaderText = "�������";
                dataGridView1.Columns["Name"].HeaderText = "���";
                dataGridView1.Columns["Patronymic"].HeaderText = "��������";
                dataGridView1.Columns["Birthdate"].HeaderText = "���� ��������";
                dataGridView1.Columns["PassportSeries"].HeaderText = "����� �.";
                dataGridView1.Columns["PassportNumber"].HeaderText = "����� �.";
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
            int? id = null;
            if (Validate())
            {
                using (var context = new HrDepartmentContext())
                {
                    if (currentId != 0)
                    {
                        var recordToUpdate = context.Employees.SingleOrDefault(s => s.Id == currentId);

                        if (recordToUpdate != null)
                        {
                            recordToUpdate.Surname = surname.Text;                // ������� �� TextBox
                            recordToUpdate.Name = name.Text;               // ��� �� TextBox
                            recordToUpdate.Patronymic = patronymic.Text == "" ? null : patronymic.Text;         // �������� �� TextBox
                            recordToUpdate.Birthdate = DateOnly.FromDateTime(birthday.Value); // ���� �������� �� DateTimePicker
                            recordToUpdate.PassportSeries = series.Text; // ����� ��������
                            recordToUpdate.PassportNumber = number.Text; // ����� ��������
                            recordToUpdate.IssuedBy = issued_by.Text;          // ��� �����
                            recordToUpdate.IssueDate = DateOnly.FromDateTime(issue_date.Value); // ���� ������ ��������
                            recordToUpdate.RegistrationAddress = reegistration_address.Text; // ����� �����������
                            recordToUpdate.ResidenceAddress = residential_address.Text;       // ����� ����������
                            recordToUpdate.Phone = phone.Text;                   // �������
                            recordToUpdate.Email = email.Text == "" ? null : email.Text;           // Email
                            recordToUpdate.Telegram = telegram.Text == "" ? null : telegram.Text;            // Telegram

                            // �������� ��������� �������� �� ComboBox
                            recordToUpdate.PositionId = ((Position)position_id.SelectedItem).Id; // ID ���������
                            recordToUpdate.LevelId = ((Level)level_id.SelectedItem)?.Id;
                            if (recordToUpdate.LevelId == 0)
                            {
                                recordToUpdate.LevelId = null;
                            }
                            var employeeSkills = context.EmployeeSkills
                                .Where(es => es.EmployeeId == recordToUpdate.Id)
                                .ToList();

                            // ������� ��� ������ �� ������� EmployeeSkill, ��������������� ������� ����������
                            context.EmployeeSkills.RemoveRange(employeeSkills);

                            // ��������� ��������� � ���� ������
                            context.SaveChanges();
                            id = recordToUpdate.Id;

                            foreach (var skill in temporarySkills)
                            {
                                var employeeSkill = new EmployeeSkill
                                {
                                    EmployeeId = recordToUpdate.Id,
                                    SkillId = skill.Key,
                                    SkillLevel = skill.Value
                                };
                                context.EmployeeSkills.Add(employeeSkill);
                                context.SaveChanges();
                            }

                        }
                        else
                        {
                            MessageBox.Show("������ �� ������� ��� ��������������.");
                        }
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
                        context.Employees.Add(newEmployee);

                        context.SaveChanges();
                        id = newEmployee.Id;

                        foreach (var skill in temporarySkills)
                        {
                            var employeeSkill = new EmployeeSkill
                            {
                                EmployeeId = newEmployee.Id,
                                SkillId = skill.Key,
                                SkillLevel = skill.Value
                            };

                            context.EmployeeSkills.Add(employeeSkill);
                            context.SaveChanges();
                        }

                    }
                }
                
                currentId = 0;
                ClearInputs();
                ShowTable();
                if (projectForm != null&&mode=="responsible")
                {
                    projectForm.UpdateResponsibleCombobox(id);
                }
                if (projectForm != null && mode == "team")
                {
                    projectForm.UpdateTeam();
                }
            }
            else
            {
                MessageBox.Show("�� ��������� �� ��� ������������ ���� �����!", "������");
            }

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            ClearInputs();
            currentId = 0;

            ShowTable();
        }



        private void Employee_Load_1(object sender, EventArgs e)
        {
            FillTable();
        }





        private void button6_Click(object sender, EventArgs e)
        {
            var form = new PositionForm(this);
            form.Show();
        }


        private void button7_Click_1(object sender, EventArgs e)
        {
            var form = new LevelForm(this);
            form.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var form = new SkillForm(this);
            form.Show();
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
                MessageBox.Show("����������, �������� ������ ��� ���������.");
            }
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
                if (projectForm != null&&mode=="responsible")
                {
                    projectForm.UpdateResponsibleCombobox();
                }
                if (projectForm != null && mode == "team")
                {
                    projectForm.UpdateTeam();
                }

                MessageBox.Show("������ ������� ������.");
                FillTable();
            }
            else
            {
                MessageBox.Show("����������, �������� ������ ��� ��������.");
            }
        }



        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView2.SelectedRows[0];
                int skillId = Convert.ToInt32(selectedRow.Cells[2].Value);
                temporarySkills.Remove(skillId);
                UpdateSkills();
            }
            else
            {
                MessageBox.Show("�� �� ������� ����� ��� ��������.");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (projectForm != null && e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                // ������������, ��� ID �������� � ������� � ������ "Id"
                var idValue = row.Cells["Id"].Value;
                if (idValue != null)
                {
                    int id = Convert.ToInt32(idValue);
                    if (mode == "responsible")
                    {
                        projectForm.UpdateResponsibleCombobox(id);
                        this.Close();
                    }
                    if (mode == "team")
                    {
                        projectForm.temporaryTeam.Add(id);
                        projectForm.UpdateTeam();
                        this.Close();

                    }


                }
            }
        }
    }
}
