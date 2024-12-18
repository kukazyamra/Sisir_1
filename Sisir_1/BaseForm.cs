﻿using System.Text;
using Microsoft.EntityFrameworkCore;
using Sisir_1.Data;
using Sisir_1.Reports;
namespace Sisir_1
{
    public partial class BaseForm : Form
    {
        // Базовая форма


        public BaseForm()
        {
            InitializeComponent();

            // Создание MenuStrip
            MenuStrip menuStrip = new MenuStrip();

            // Элемент меню "Справочники"
            ToolStripMenuItem directoriesMenuItem = new ToolStripMenuItem("Справочники");

            // Подменю "Сотрудники"
            ToolStripMenuItem employeesMenuItem = new ToolStripMenuItem("Сотрудники");
            employeesMenuItem.Click += (s, e) => OpenForm<EmployeeForm>();

            // Подменю "Проекты"
            ToolStripMenuItem projectsMenuItem = new ToolStripMenuItem("Проекты");
            projectsMenuItem.Click += (s, e) => OpenForm<ProjectForm>();

            // Добавление элементов в раздел "Справочники"
            directoriesMenuItem.DropDownItems.Add(employeesMenuItem);
            directoriesMenuItem.DropDownItems.Add(projectsMenuItem);

            // Создание элемента подменю "Другое"
            ToolStripMenuItem otherMenuItem = new ToolStripMenuItem("Другое");

            // Подменю "Должности"
            ToolStripMenuItem positionsMenuItem = new ToolStripMenuItem("Должности");
            positionsMenuItem.Click += (s, e) => OpenForm<PositionForm>();

            // Подменю "Уровни"
            ToolStripMenuItem levelsMenuItem = new ToolStripMenuItem("Уровни");
            levelsMenuItem.Click += (s, e) => OpenForm<LevelForm>();

            // Подменю "Навыки"
            ToolStripMenuItem skillsMenuItem = new ToolStripMenuItem("Навыки");
            skillsMenuItem.Click += (s, e) => OpenForm<SkillForm>();

            // Добавление подменю в "Другое"
            otherMenuItem.DropDownItems.Add(positionsMenuItem);
            otherMenuItem.DropDownItems.Add(levelsMenuItem);
            otherMenuItem.DropDownItems.Add(skillsMenuItem);

            // Добавление элемента "Другое" в "Справочники"
            directoriesMenuItem.DropDownItems.Add(otherMenuItem);

            // Добавление элементов меню в MenuStrip
            menuStrip.Items.Add(directoriesMenuItem); // Добавляем раздел "Справочники"

            // Элемент меню "Отчеты"
            ToolStripMenuItem reportsMenuItem = new ToolStripMenuItem("Отчеты");

   

            ToolStripMenuItem availableReport = new ToolStripMenuItem("Свободные сотрудники");
            availableReport.Click += (s, e) => OpenForm<AvailableReport>();

            ToolStripMenuItem currentProjects = new ToolStripMenuItem("Проекты в работе");
            currentProjects.Click += (s, e) => OpenForm<CurrentProjects>();

            ToolStripMenuItem workload = new ToolStripMenuItem("Загруженность сотрудников");
            workload.Click += (s, e) => OpenForm<WorkloadReport>();

            ToolStripMenuItem skillRep = new ToolStripMenuItem("Поиск по навыкам");
            skillRep.Click += (s, e) => OpenForm<SkillReport>();

            ToolStripMenuItem responsibleReport = new ToolStripMenuItem("Эффективность ответственных");
            responsibleReport.Click += (s, e) => OpenForm<ResponsibleReport>();

            reportsMenuItem.DropDownItems.Add(availableReport);
            reportsMenuItem.DropDownItems.Add(currentProjects);
            reportsMenuItem.DropDownItems.Add(workload);
            reportsMenuItem.DropDownItems.Add(skillRep);
            reportsMenuItem.DropDownItems.Add(responsibleReport);



            // Добавление элемента "Отчеты" в MenuStrip
            menuStrip.Items.Add(reportsMenuItem);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void OpenForm<T>() where T : Form, new()
        {
            var form = new T();
            form.Show();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
// Базовая форма