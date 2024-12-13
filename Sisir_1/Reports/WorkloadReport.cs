using Sisir_1.Data;
using System.Data;
using System.Diagnostics;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Sisir_1.Reports
{
    public partial class WorkloadReport : BaseReport
    {
        public WorkloadReport()
        {
            InitializeComponent();
        }
        public bool Validate()
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
            return true;
        }


        protected override void formReport_Click(object sender, EventArgs e)
        {

            if (!Validate()) return;
            using (var context = new HrDepartmentContext())
            {
                var employees = context.Employees
                        .Select(e => new
                        {
                            Name = e.Name,
                            Surname = e.Surname,
                            Patronymic = e.Patronymic,
                            Position = e.Position.Name,
                            Level = e.Level != null ? e.Level.Name : null,
                            ProjectCount = e.ProjectEmployees.Count()
                        })
                        .ToList();
                if (comboBox1.SelectedIndex==0)
                {
                    employees = employees.OrderBy(e => e.ProjectCount).ToList();
                }
                else
                {
                    employees = employees.OrderByDescending(e => e.ProjectCount).ToList();
                }

                string originalFilePath = Path.Combine(Application.StartupPath, "Загруженность.docx"); ; // Путь к исходному документу
                string newFilePath = Path.Combine(Application.StartupPath, "Загруженность2.docx"); // Путь к новому документу
                try
                {
                    using (DocX document = DocX.Load(originalFilePath))
                    {
                        Table table = document.Tables[0];

                        document.ReplaceText("#КТО#", ((Employee)responsible_id.SelectedItem).ToString());
                        document.ReplaceText("#ДАТА#", DateTime.Now.ToShortDateString());
                        foreach (var employee in employees)
                        {
                            Row newRow = table.InsertRow();
                            char firstNameInitial = employee.Name.Length > 0 ? employee.Name[0] : ' ';
                            char? patronymicInitial = employee.Patronymic?.Length > 0 ? employee.Patronymic[0] : null;
                            if (patronymicInitial != null) newRow.Cells[0].Paragraphs[0].Append($"{employee.Surname} {firstNameInitial}.{patronymicInitial}.");
                            else newRow.Cells[0].Paragraphs[0].Append($"{employee.Surname} {firstNameInitial}.");

                            newRow.Cells[1].Paragraphs[0].Append(employee.Position);
                            if (employee.Level != null)
                                newRow.Cells[2].Paragraphs[0].Append(employee.Level);
                            newRow.Cells[3].Paragraphs[0].Append(employee.ProjectCount.ToString());
                        }
                        SetTableFormatting(table, "Times New Roman", 12);
                        document.SaveAs(newFilePath);
                        var p = new Process();
                        p.StartInfo = new ProcessStartInfo(newFilePath)
                        {
                            UseShellExecute = true
                        };
                        p.Start();
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Закройте предыдущий файл");
                }
            }
        }
        protected override void BaseReport_Load(object sender, EventArgs e)
        {
            base.BaseReport_Load(sender, e);
            comboBox1.Items.Add(new { Text = "По возрастанию количества проектов", Value = "asc" });

            comboBox1.Items.Add(new { Text = "По убыванию количества проектов", Value = "desc" });

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value"; // Устанавливаем правильный свойство для отображения значения
            comboBox1.SelectedIndex = 0;
        }
    }

}
