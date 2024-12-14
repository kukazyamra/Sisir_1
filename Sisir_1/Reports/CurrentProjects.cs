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

namespace Sisir_1.Reports
{
    public partial class CurrentProjects : BaseReport
    {
        public CurrentProjects()
        {
            InitializeComponent();
        }
        public bool Validate()
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
            return true;
        }


        protected override void formReport_Click(object sender, EventArgs e)
        {

     
            if (!Validate()) return;
            using (var context = new HrDepartmentContext())
            {
                var currentDate = DateTime.Today;

                var activeProjects = context.Projects
                    .Where(p => p.EndDateFact == null)
                    .Where(p=>p.StartDateFact!=null||p.StartDatePlan.ToDateTime(TimeOnly.MinValue)<=currentDate)
                    .Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.EndDatePlan,
                        DaysUntilDeadline = (p.EndDatePlan.ToDateTime(TimeOnly.MinValue) - currentDate).Days
                    })
                    .OrderBy(p => p.DaysUntilDeadline) // Сортировка по количеству дней до дедлайна
                    .ToList();
                
        

                string originalFilePath = Path.Combine(Application.StartupPath, "Проекты в работе.docx"); ; // Путь к исходному документу
                string newFilePath = Path.Combine(Application.StartupPath, "Проекты в работе2.docx"); // Путь к новому документу
                try
                {
                    using (DocX document = DocX.Load(originalFilePath))
                    {
                        Table table = document.Tables[0];

                        string who = "";
                        var emp = (Employee)responsible_id.SelectedItem;
                        char firstNameInitial = emp.Name.Length > 0 ? emp.Name[0] : ' ';
                        char? patronymicInitial = emp.Patronymic?.Length > 0 ? emp.Patronymic[0] : null;
                        if (patronymicInitial != null) who += ($"{emp.Surname} {firstNameInitial}.{patronymicInitial}.");
                        else who += ($"{emp.Surname} {firstNameInitial}.");

                        document.ReplaceText("#КТО#", $"{emp.Position.Name} ___/{who}");
                        document.ReplaceText("#ДАТА#", DateTime.Now.ToShortDateString());
                        foreach (var project in activeProjects)
                        {
                            Row newRow = table.InsertRow();
                            newRow.Cells[0].Paragraphs[0].Append(project.Name);
                            newRow.Cells[1].Paragraphs[0].Append(project.EndDatePlan.ToString());

                            newRow.Cells[2].Paragraphs[0].Append(project.DaysUntilDeadline.ToString());
                     

                            int responsibleId = context.ProjectEmployees
                               .Where(e => e.ProjectId == project.Id && e.IsResponsible)
                               .Select(e => e.EmployeeId)
                               .FirstOrDefault();
                            if (responsibleId > 0)
                            {
                                var responsible = context.Employees.Find(responsibleId);
                                newRow.Cells[3].Paragraphs[0].Append(responsible.ToString());
                            }
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
