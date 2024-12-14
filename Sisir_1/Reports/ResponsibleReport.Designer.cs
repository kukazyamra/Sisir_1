namespace Sisir_1.Reports
{
    partial class ResponsibleReport
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
            label3 = new Label();
            start_period = new DateTimePicker();
            label1 = new Label();
            end_period = new DateTimePicker();
            SuspendLayout();
            // 
            // title
            // 
            title.Size = new Size(350, 25);
            title.Text = "Отчет \"Эффективность ответственных\"";
            // 
            // formReport
            // 
            formReport.Location = new Point(186, 154);
            // 
            // label2
            // 
            label2.Location = new Point(10, 104);
            // 
            // button1
            // 
            button1.Location = new Point(282, 121);
            // 
            // responsible_id
            // 
            responsible_id.Location = new Point(10, 121);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 56);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 38;
            label3.Text = "Начало периода";
            // 
            // start_period
            // 
            start_period.Format = DateTimePickerFormat.Short;
            start_period.Location = new Point(10, 73);
            start_period.Margin = new Padding(3, 2, 3, 2);
            start_period.Name = "start_period";
            start_period.Size = new Size(133, 23);
            start_period.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(173, 56);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 40;
            label1.Text = "Конец периода";
            // 
            // end_period
            // 
            end_period.Format = DateTimePickerFormat.Short;
            end_period.Location = new Point(173, 73);
            end_period.Margin = new Padding(3, 2, 3, 2);
            end_period.Name = "end_period";
            end_period.Size = new Size(133, 23);
            end_period.TabIndex = 39;
            // 
            // ResponsibleReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 212);
            Controls.Add(label1);
            Controls.Add(end_period);
            Controls.Add(label3);
            Controls.Add(start_period);
            Name = "ResponsibleReport";
            Text = "Эффективность ответственных";
            Controls.SetChildIndex(title, 0);
            Controls.SetChildIndex(formReport, 0);
            Controls.SetChildIndex(responsible_id, 0);
            Controls.SetChildIndex(button1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(start_period, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(end_period, 0);
            Controls.SetChildIndex(label1, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private DateTimePicker start_period;
        private Label label1;
        private DateTimePicker end_period;
    }
}