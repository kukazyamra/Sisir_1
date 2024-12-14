namespace Sisir_1.Reports
{
    partial class SkillReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            delete = new Button();
            add = new Button();
            dataGridView2 = new DataGridView();
            Skill_name = new DataGridViewTextBoxColumn();
            Skill_id = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // title
            // 
            title.Location = new Point(12, 16);
            title.Size = new Size(244, 25);
            title.Text = "Отчет \"Поиск по навыкам\"";
            // 
            // formReport
            // 
            formReport.Location = new Point(203, 246);
            formReport.Size = new Size(108, 23);
            // 
            // label2
            // 
            label2.Location = new Point(12, 192);
            // 
            // button1
            // 
            button1.Location = new Point(288, 209);
            button1.Margin = new Padding(3);
            button1.Size = new Size(24, 23);
            // 
            // responsible_id
            // 
            responsible_id.Location = new Point(12, 209);
            responsible_id.Margin = new Padding(3);
            responsible_id.Size = new Size(267, 23);
            // 
            // delete
            // 
            delete.Font = new Font("Segoe UI", 7F);
            delete.Location = new Point(288, 77);
            delete.Margin = new Padding(3, 2, 3, 2);
            delete.Name = "delete";
            delete.Size = new Size(24, 22);
            delete.TabIndex = 39;
            delete.Text = "-";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // add
            // 
            add.Font = new Font("Segoe UI", 7F);
            add.Location = new Point(288, 48);
            add.Margin = new Padding(3, 2, 3, 2);
            add.Name = "add";
            add.Size = new Size(24, 24);
            add.TabIndex = 38;
            add.Text = "+";
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Skill_name, Skill_id });
            dataGridView2.Location = new Point(10, 48);
            dataGridView2.Margin = new Padding(3, 2, 3, 2);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(269, 141);
            dataGridView2.TabIndex = 37;
            // 
            // Skill_name
            // 
            Skill_name.HeaderText = "Наименование";
            Skill_name.MinimumWidth = 6;
            Skill_name.Name = "Skill_name";
            Skill_name.ReadOnly = true;
            // 
            // Skill_id
            // 
            Skill_id.HeaderText = "ID";
            Skill_id.MinimumWidth = 6;
            Skill_id.Name = "Skill_id";
            Skill_id.ReadOnly = true;
            Skill_id.Visible = false;
            // 
            // SkillReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 317);
            Controls.Add(delete);
            Controls.Add(add);
            Controls.Add(dataGridView2);
            Margin = new Padding(3);
            Name = "SkillReport";
            Text = "Поиск по навыкам";
            Controls.SetChildIndex(title, 0);
            Controls.SetChildIndex(formReport, 0);
            Controls.SetChildIndex(responsible_id, 0);
            Controls.SetChildIndex(button1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(dataGridView2, 0);
            Controls.SetChildIndex(add, 0);
            Controls.SetChildIndex(delete, 0);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button delete;
        private Button add;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn Skill_name;
        private DataGridViewTextBoxColumn Skill_id;
    }
}