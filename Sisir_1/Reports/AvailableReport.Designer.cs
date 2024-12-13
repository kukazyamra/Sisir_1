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
            title.Size = new Size(366, 32);
            title.Text = "Отчет \"Свободные сотрудники\"";
            // 
            // formReport
            // 
            formReport.Location = new Point(230, 205);
            // 
            // label2
            // 
            label2.Location = new Point(24, 127);
            // 
            // button1
            // 
            button1.Location = new Point(339, 150);
            // 
            // responsible_id
            // 
            responsible_id.Location = new Point(24, 150);
            // 
            // position_form
            // 
            position_form.Location = new Point(339, 86);
            position_form.Name = "position_form";
            position_form.Size = new Size(27, 29);
            position_form.TabIndex = 39;
            position_form.Text = "...";
            position_form.UseVisualStyleBackColor = true;
            position_form.Click += position_form_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(20, 62);
            label8.Name = "label8";
            label8.Size = new Size(86, 20);
            label8.TabIndex = 38;
            label8.Text = "Должность";
            // 
            // position_id
            // 
            position_id.DropDownStyle = ComboBoxStyle.DropDownList;
            position_id.FormattingEnabled = true;
            position_id.Location = new Point(24, 86);
            position_id.Name = "position_id";
            position_id.Size = new Size(307, 28);
            position_id.TabIndex = 37;
            // 
            // AvailableReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 279);
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