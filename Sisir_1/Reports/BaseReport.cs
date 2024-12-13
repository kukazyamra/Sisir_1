using Sisir_1.Data;
using Xceed.Words.NET;
using System.Diagnostics;
using Xceed.Document.NET;
namespace Sisir_1.Reports
{
    public partial class BaseReport : Form
    {
        public BaseReport()
        {
            InitializeComponent();
        }
        protected static void SetTableFormatting(Table table, string fontName, float fontSize)
        {
            // Проходим по всем строкам в таблице
            foreach (Row row in table.Rows)
            {
                // Проходим по всем ячейкам в строке
                foreach (Cell cell in row.Cells)
                {
                    // Устанавливаем форматирование для всех абзацев в ячейке
                    foreach (Paragraph paragraph in cell.Paragraphs)
                    {
                        paragraph.Font(fontName).FontSize(fontSize);
                    }
                }
            }
        }
        protected virtual void formReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Base Button Clicked");

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
      
        protected virtual void BaseReport_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            formReport.Click += formReport_Click;

            responsible_id.SelectedIndex = -1;
            UpdateResponsibleCombobox();
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            var form = new EmployeeForm(this, "responsible");
            form.Show();
        }
    }
}
