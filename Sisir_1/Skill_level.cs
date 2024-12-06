using Sisir_1.Data;

namespace Sisir_1
{
    public partial class Skill_level : Form
    {
        private EmployeeForm employeeForm;
        private int id;
        public Skill_level(EmployeeForm form, int id)
        {
            this.employeeForm = form;
            this.id = id;
            InitializeComponent();
            using (var context = new HrDepartmentContext())
            {
                var skill = context.Skills.Find(id);
                this.label2.Text = $"Добавление навыка \"{skill.Name}\"";

            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) { MessageBox.Show("Вы не указали уровень навыка", "Ошибка"); return; }
            if (int.Parse(textBox1.Text) < 0 || int.Parse(textBox1.Text) > 10) { MessageBox.Show("Уровень навыка должен быть числом от 0 до 10", "Ошибка"); return; }
            try
            {
                employeeForm.temporarySkills.Add(id, int.Parse(textBox1.Text));
                employeeForm.UpdateSkills();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Не удалось добавить навык. \nВозможно, вы закрыли форму добавления сотрудников?", "Ошибка");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Вы уже добавли этот навык.", "Ошибка");

            }
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
