namespace Sisir_1.Reports
{
    partial class BaseReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = new System.ComponentModel.Container();

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
            title = new Label();
            formReport = new Button();
            label2 = new Label();
            button1 = new Button();
            responsible_id = new ComboBox();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 14F);
            title.Location = new Point(10, 20);
            title.Name = "title";
            title.Size = new Size(91, 25);
            title.TabIndex = 25;
            title.Text = "Базовый ";
            // 
            // formReport
            // 
            formReport.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            formReport.Location = new Point(191, 107);
            formReport.Margin = new Padding(3, 2, 3, 2);
            formReport.Name = "formReport";
            formReport.Size = new Size(119, 23);
            formReport.TabIndex = 33;
            formReport.Text = "Сформировать";
            formReport.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 53);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 36;
            label2.Text = "Кто сформировал";
            // 
            // button1
            // 
            button1.Location = new Point(285, 70);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(24, 24);
            button1.TabIndex = 35;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // responsible_id
            // 
            responsible_id.DropDownStyle = ComboBoxStyle.DropDownList;
            responsible_id.FormattingEnabled = true;
            responsible_id.Location = new Point(10, 70);
            responsible_id.Margin = new Padding(3, 2, 3, 2);
            responsible_id.Name = "responsible_id";
            responsible_id.Size = new Size(269, 23);
            responsible_id.TabIndex = 34;
            // 
            // BaseReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 179);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(responsible_id);
            Controls.Add(formReport);
            Controls.Add(title);
            Margin = new Padding(3, 2, 3, 2);
            Name = "BaseReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BaseReport";
            Load += BaseReport_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label title;
        protected Button formReport;
        protected Label label2;
        protected Button button1;
        protected ComboBox responsible_id;
    }
}