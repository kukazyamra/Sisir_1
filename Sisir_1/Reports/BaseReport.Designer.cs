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
            title.Location = new Point(12, 26);
            title.Name = "title";
            title.Size = new Size(116, 32);
            title.TabIndex = 25;
            title.Text = "Базовый ";
            // 
            // formReport
            // 
            formReport.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            formReport.Location = new Point(218, 143);
            formReport.Margin = new Padding(3, 2, 3, 2);
            formReport.Name = "formReport";
            formReport.Size = new Size(136, 30);
            formReport.TabIndex = 33;
            formReport.Text = "Сформировать";
            formReport.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 71);
            label2.Name = "label2";
            label2.Size = new Size(134, 20);
            label2.TabIndex = 36;
            label2.Text = "Кто сформировал";
            // 
            // button1
            // 
            button1.Location = new Point(327, 94);
            button1.Name = "button1";
            button1.Size = new Size(27, 29);
            button1.TabIndex = 35;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // responsible_id
            // 
            responsible_id.DropDownStyle = ComboBoxStyle.DropDownList;
            responsible_id.FormattingEnabled = true;
            responsible_id.Location = new Point(12, 94);
            responsible_id.Name = "responsible_id";
            responsible_id.Size = new Size(307, 28);
            responsible_id.TabIndex = 34;
            // 
            // BaseReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 239);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(responsible_id);
            Controls.Add(formReport);
            Controls.Add(title);
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