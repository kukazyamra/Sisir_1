namespace Sisir_1.Reports
{
    partial class AvailableReport
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
            position_form = new Button();
            label8 = new Label();
            position_id = new ComboBox();
            SuspendLayout();
            // 
            // title
            // 
            title.Location = new Point(9, 15);
            title.Size = new Size(286, 25);
            title.Text = "Отчет \"Свободные сотрудники\"";
            // 
            // formReport
            // 
            formReport.Location = new Point(217, 154);
            formReport.Size = new Size(104, 26);
            // 
            // label2
            // 
            label2.Location = new Point(21, 95);
            // 
            // button1
            // 
            button1.Location = new Point(297, 112);
            button1.Size = new Size(24, 23);
            // 
            // responsible_id
            // 
            responsible_id.Location = new Point(21, 112);
            // 
            // position_form
            // 
            position_form.Location = new Point(297, 64);
            position_form.Margin = new Padding(3, 2, 3, 2);
            position_form.Name = "position_form";
            position_form.Size = new Size(24, 22);
            position_form.TabIndex = 39;
            position_form.Text = "...";
            position_form.UseVisualStyleBackColor = true;
            position_form.Click += position_form_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 46);
            label8.Name = "label8";
            label8.Size = new Size(69, 15);
            label8.TabIndex = 38;
            label8.Text = "Должность";
            // 
            // position_id
            // 
            position_id.DropDownStyle = ComboBoxStyle.DropDownList;
            position_id.FormattingEnabled = true;
            position_id.Location = new Point(21, 64);
            position_id.Margin = new Padding(3, 2, 3, 2);
            position_id.Name = "position_id";
            position_id.Size = new Size(269, 23);
            position_id.TabIndex = 37;
            // 
            // AvailableReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 209);
            Controls.Add(position_form);
            Controls.Add(label8);
            Controls.Add(position_id);
            Name = "AvailableReport";
            Text = "Свободные сотрудники";
            Load += AvailableReport_Load;
            Controls.SetChildIndex(title, 0);
            Controls.SetChildIndex(formReport, 0);
            Controls.SetChildIndex(responsible_id, 0);
            Controls.SetChildIndex(button1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(position_id, 0);
            Controls.SetChildIndex(label8, 0);
            Controls.SetChildIndex(position_form, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button position_form;
        private Label label8;
        private ComboBox position_id;
    }
}