using Sisir_1.Data;
using System.Diagnostics;
using Xceed.Document.NET;
using Xceed.Words.NET;


namespace Sisir_1.Reports
{

    public partial class AvailableReport : BaseReport
    {
        public bool Validate()
        {
            var fields = new Control[] { responsible_id, position_id, };

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

        public AvailableReport()
        {
            InitializeComponent();
        }

        protected override void formReport_Click(object sender, EventArgs e)
        {
         
            if (!Validate()) return;
            using (var context = new HrDepartmentContext())
            {
                var employeesWithoutProjects = context.Employees
                  .Where(e => !e.ProjectEmployees.Any())
                  .Where(e => e.PositionId == ((Position)position_id.SelectedItem).Id)
                  .ToList();
                string originalFilePath = Path.Combine(Application.StartupPath, "Свободные сотрудники.docx"); ; // Путь к исходному документу
                string newFilePath = Path.Combine(Application.StartupPath, "Свободные сотрудники2.docx"); // Путь к новому документу
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
                        document.ReplaceText("#КТО#", ((Employee)responsible_id.SelectedItem).ToString());
                        document.ReplaceText("#ДАТА#", DateTime.Now.ToShortDateString());
                        document.ReplaceText("#ДОЛЖНОСТЬ#", ((Position)position_id.SelectedItem).Name);
                        foreach(var employee in employeesWithoutProjects)
                        {
                            Row newRow = table.InsertRow();
                            newRow.Cells[0].Paragraphs[0].Append(employee.ToString().Split("-")[0]);
                            if (employee.Level!=null)
                                    newRow.Cells[1].Paragraphs[0].Append(employee.Level.Name);
                        }
                        SetTableFormatting(table, "Arial", 11);
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
        public void UpdatePositionsCombobox(int? id = null)
        {
            using (var context = new HrDepartmentContext())
            {
                var positions = context.Positions.ToList();
                position_id.DataSource = positions;

                // Устанавливаем отображаемое значение (то, что увидит пользователь)
                position_id.DisplayMember = "Name"; // Название должности

                // Устанавливаем значение, которое будет храниться при выборе (например, ID)
                position_id.ValueMember = "Id";
                if (id.HasValue)
                {
                    position_id.SelectedValue = id.Value;
                }
                else
                {
                    position_id.SelectedIndex = -1; // Сброс выделения, если id не передан
                }
            }

        }

        private void AvailableReport_Load(object sender, EventArgs e)
        {
            UpdatePositionsCombobox();
        }

        private void position_form_Click(object sender, EventArgs e)
        {
            var form = new PositionForm(this);
            form.Show();
        }
    }
}

