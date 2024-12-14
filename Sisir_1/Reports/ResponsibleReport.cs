using Microsoft.EntityFrameworkCore;
using Sisir_1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sisir_1.Reports
{
    public partial class ResponsibleReport : BaseReport
    {
        public ResponsibleReport()
        {
            InitializeComponent();
        }

        private bool Validate()
        {
            var fields = new Control[] { responsible_id};

            foreach (var field in fields)
            {
                if (string.IsNullOrWhiteSpace(field.Text))
                {
                    MessageBox.Show("Вы заполнили не все обязательные поля формы!", "Ошибка");
                    return false;
                }
            }
            if (!string.IsNullOrWhiteSpace(end_period.Text)&& !string.IsNullOrWhiteSpace(start_period.Text))
            {
                if (end_period.Value<start_period.Value)
                {
                    MessageBox.Show("Конец периода не может быть раньше начала периода","Ошибка");
                    return false;
                }
            }
            return true;
        }
        protected override void BaseReport_Load(object sender, EventArgs e)
        {
            base.BaseReport_Load(sender, e);
            start_period.Format = DateTimePickerFormat.Custom;
            start_period.CustomFormat = " "; // Устанавливаем пустой формат по умолча
            end_period.Format = DateTimePickerFormat.Custom;
            end_period.CustomFormat = " "; // Устанавливаем пустой формат по умолча
            start_period.ValueChanged += UniversalDateTimePicker_ValueChanged;
            end_period.ValueChanged += UniversalDateTimePicker_ValueChanged;

        }
        private void UniversalDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (sender is DateTimePicker dateTimePicker)
            {
                // Устанавливаем формат для отображения выбранной даты
                dateTimePicker.CustomFormat = "dd.MM.yyyy"; // Ваш желаемый формат
            }
        }
        protected override void formReport_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            using (var context = new HrDepartmentContext())
            {
                var currentDate = DateTime.Today;

                var responsibleProjects = context.ProjectEmployees
                    .Include(pe => pe.Project) // Загрузка связанных проектов
                    .Include(pe => pe.Employee) // Загрузка связанных сотрудников
                    .Where(pe => pe.IsResponsible)
                    .Where(pe =>
                        (string.IsNullOrWhiteSpace(end_period.Text) ||
                        pe.Project.EndDatePlan.ToDateTime(TimeOnly.MinValue) <= end_period.Value ||
                        (pe.Project.EndDateFact != null && pe.Project.EndDateFact.Value.ToDateTime(TimeOnly.MinValue) <= end_period.Value)))
                    .Where(pe =>
                        (string.IsNullOrWhiteSpace(start_period.Text) ||
                        pe.Project.EndDatePlan.ToDateTime(TimeOnly.MinValue) >= start_period.Value ||
                        (pe.Project.EndDateFact != null && pe.Project.EndDateFact.Value.ToDateTime(TimeOnly.MinValue) >= start_period.Value)))
                    .ToList();
               
                // Группируем данные по сотрудникам и подсчитываем количество проектов
                var results = responsibleProjects
                 .GroupBy(pe => pe.Employee)
                 .Select(group => new
                 {
                     Employee = group.Key,
                     ClosedOnTime = group.Count(pe => pe.Project.EndDateFact != null && pe.Project.EndDateFact <= pe.Project.EndDatePlan),
                     ClosedLate = group.Count(pe =>
                         (pe.Project.EndDateFact != null && pe.Project.EndDateFact > pe.Project.EndDatePlan) ||
                         (pe.Project.EndDateFact == null && pe.Project.EndDatePlan.ToDateTime(TimeOnly.MinValue) < currentDate)) // Учитываем незавершенные проекты с истекшим сроком
                 })
                 .Where(r => r.ClosedOnTime > 0 || r.ClosedLate > 0) // Исключить сотрудников без закрытых проектов

                 .ToList();


                string originalFilePath = Path.Combine(Application.StartupPath, "Ответственные.docx"); ; // Путь к исходному документу
                string newFilePath = Path.Combine(Application.StartupPath, "Ответственные2.docx"); // Путь к новому документу
                try
                {
                    using (DocX document = DocX.Load(originalFilePath))
                    {
                        Table table = document.Tables[0];
                        if (!string.IsNullOrWhiteSpace(end_period.Text)) document.ReplaceText("#КОНЕЦПЕРИОДА#", end_period.Value.ToShortDateString());
                        else document.ReplaceText("#КОНЕЦПЕРИОДА#", DateTime.Today.ToShortDateString());

                        if (!string.IsNullOrWhiteSpace(start_period.Text)) 
                        {
                            document.ReplaceText("#НАЧАЛОПЕРИОДА#", start_period.Value.ToShortDateString());
                        } 
                        else
                        {
                            var earliestEndDatePlan = context.Projects
                                .Where(p => p.EndDatePlan != null) // Фильтруем проекты с установленной плановой датой завершения
                                .Select(p => p.EndDatePlan) // Извлекаем только плановую дату завершения
                                .Min(); // Находим самую маленькую дату среди всех

                            document.ReplaceText("#НАЧАЛОПЕРИОДА#", earliestEndDatePlan.ToString());
                        }
                        string who = "";
                        var emp = (Employee)responsible_id.SelectedItem;
                        char firstNameInitial2 = emp.Name.Length > 0 ? emp.Name[0] : ' ';
                        char? patronymicInitial2 = emp.Patronymic?.Length > 0 ? emp.Patronymic[0] : null;
                        if (patronymicInitial2 != null) who += ($"{emp.Surname} {firstNameInitial2}.{patronymicInitial2}.");
                        else who += ($"{emp.Surname} {firstNameInitial2}.");

                        document.ReplaceText("#КТО#", $"{emp.Position.Name} ___/{who}");
                        document.ReplaceText("#ДАТА#", DateTime.Now.ToShortDateString());
                        foreach (var result in results)
                        {
                            

                            Row newRow = table.InsertRow();
                            char firstNameInitial = result.Employee.Name.Length > 0 ? result.Employee.Name[0] : ' ';
                            char? patronymicInitial = result.Employee.Patronymic?.Length > 0 ? result.Employee.Patronymic[0] : null;
                            if (patronymicInitial != null) newRow.Cells[0].Paragraphs[0].Append($"{result.Employee.Surname} {firstNameInitial}.{patronymicInitial}.");
                            else newRow.Cells[0].Paragraphs[0].Append($"{result.Employee.Surname} {firstNameInitial}.");
                            newRow.Cells[1].Paragraphs[0].Append(result.Employee.Position.Name);
                            if (result.Employee.Level!=null) newRow.Cells[2].Paragraphs[0].Append(result.Employee.Level.Name);
                            newRow.Cells[3].Paragraphs[0].Append(Math.Round(result.Employee.Position.Salary * (result.Employee.Level != null ? result.Employee.Level.Coefficient : 1)).ToString());

                            newRow.Cells[4].Paragraphs[0].Append(result.ClosedOnTime.ToString());
                            newRow.Cells[5].Paragraphs[0].Append(result.ClosedLate.ToString());

                
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
                catch
                {
                    MessageBox.Show("Закройте предыдущий файл");
                }
            }
        }
    }
}
