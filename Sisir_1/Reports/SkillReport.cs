using Sisir_1.Data;
using System.Data;
using System.Diagnostics;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Sisir_1.Reports
{
    public partial class SkillReport : BaseReport
    {
        public List<int> temporarySkills;
        public SkillReport()
        {
            InitializeComponent();
        }
        private bool Validate()
        {
            var fields = new Control[] { responsible_id };

            foreach (var field in fields)
            {
                if (string.IsNullOrWhiteSpace(field.Text))
                {
                    MessageBox.Show("Вы заполнили не все обязательные поля формы!", "Ошибка");
                    return false;
                }
            }
            if (temporarySkills.Count == 0)
            {
                MessageBox.Show("Вы не указали ни один навык", "Ошибка");
                return false;
            }
            return true;
        }

        private void add_Click(object sender, EventArgs e)
        {
            var form = new SkillForm(this);
            form.Show();
        }
        public void UpdateSkills()
        {
            dataGridView2.Rows.Clear();
            using (var context = new HrDepartmentContext())
            {
                foreach (var id in temporarySkills)
                {
                    var record = context.Skills.Find(id);
                    if (record != null)
                    {
                        dataGridView2.Rows.Add(record.Name, record.Id);
                    }
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView2.SelectedRows[0];
                int skillId = Convert.ToInt32(selectedRow.Cells[1].Value);
                temporarySkills.Remove(skillId);
                UpdateSkills();
            }
            else
            {
                MessageBox.Show("Вы не выбрали навык для удаления.");
            }
        }
        protected override void BaseReport_Load(object sender, EventArgs e)
        {
            base.BaseReport_Load(sender, e);
            this.temporarySkills = new List<int>();
        }
        protected override void formReport_Click(object sender, EventArgs e)
        {

            if (!Validate()) return;
            using (var context = new HrDepartmentContext())
            {
                string originalFilePath = Path.Combine(Application.StartupPath, "Поиск по навыкам.docx"); ; // Путь к исходному документу
                string newFilePath = Path.Combine(Application.StartupPath, "Поиск по навыкам2.docx"); // Путь к новому документу
                try
                {
                    using (DocX document = DocX.Load(originalFilePath))
                    {
                        Table table = document.Tables[0];

                        //    Row newRow = table.InsertRow();
                        //    newRow.Cells[0].Paragraphs[0].Append("Данные в новой строке, столбец 1");
                        //    newRow.Cells[1].Paragraphs[0].Append("Данные в новой строке, столбец 2");
                        //    newRow.Cells[2].Paragraphs[0].Append("Данные в новой строке, столбец 3");
                        //    newRow = table.InsertRow();
                        string who = "";
                        var emp = (Employee)responsible_id.SelectedItem;
                        char firstNameInitial = emp.Name.Length > 0 ? emp.Name[0] : ' ';
                        char? patronymicInitial = emp.Patronymic?.Length > 0 ? emp.Patronymic[0] : null;
                        if (patronymicInitial != null) who += ($"{emp.Surname} {firstNameInitial}.{patronymicInitial}.");
                        else who += ($"{emp.Surname} {firstNameInitial}.");

                        document.ReplaceText("#КТО#", $"{emp.Position.Name} ___/{who}");

                        document.ReplaceText("#ДАТА#", DateTime.Now.ToShortDateString());

                        var employeesWithSkills = context.Employees
                            .Where(e => temporarySkills.All(skillId =>
                                e.EmployeeSkills.Any(es => es.SkillId == skillId))) // Фильтруем сотрудников, у которых есть все навыки
                            .Select(e => new
                            {
                                Employee = e,
                                Skills = e.EmployeeSkills
                                    .Where(es => temporarySkills.Contains(es.SkillId)) // Оставляем только нужные навыки
                                    .Select(es => new
                                    {
                                        SkillId = es.SkillId,

                                        SkillName = es.Skill.Name, // Предполагается, что есть связь с сущностью Skill
                                        SkillLevel = es.SkillLevel // Уровень владения навыком
                                    }).ToList(),
                                TotalSkillLevel = e.EmployeeSkills
                                    .Where(es => temporarySkills.Contains(es.SkillId)) // Только для нужных навыков
                                    .Sum(es => es.SkillLevel) // Суммируем уровни навыков
                            })
                            .OrderByDescending(e => e.TotalSkillLevel) // Сортируем по убыванию суммарного уровня навыков
                            .ToList();

                        foreach (var employee in employeesWithSkills)
                        {

                            Row newRow = table.InsertRow();
                            
                            newRow.Cells[0].Paragraphs[0].Append(employee.Employee.ToString());
                            for (int i = 0; i < employee.Skills.Count; i++)
                            {
                                if (i != 0) newRow.Cells[1].InsertParagraph();

                                newRow.Cells[1].Paragraphs[i].Append($"{employee.Skills[i].SkillName}: {employee.Skills[i].SkillLevel}");
                            }
                            newRow.Cells[2].Paragraphs[0].Append(employee.Employee.ProjectEmployees.Count.ToString());
                        }
                        SetTableFormatting(table, "Times new Roman", 11);
                        document.SaveAs(newFilePath);
                        var p = new Process();
                        p.StartInfo = new ProcessStartInfo(newFilePath)
                        {
                            UseShellExecute = true
                        };
                        p.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Закройте предыдущий файл");
                }
            }
        }


    }
}