
namespace SoftwareII
{
    partial class AppointmentForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.ClientTextBox = new System.Windows.Forms.TextBox();
            this.SearchClientButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.StartLabel = new System.Windows.Forms.Label();
            this.EndLabel = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CustomerNameLabel = new System.Windows.Forms.Label();
            this.AppointmentFormExitButton = new System.Windows.Forms.Button();
            this.ScheduleButton = new System.Windows.Forms.Button();
            this.MainFormMCRButton = new System.Windows.Forms.Button();
            this.IDLabel = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(618, 166);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(618, 192);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(618, 218);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(618, 244);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 3;
            // 
            // ClientTextBox
            // 
            this.ClientTextBox.Location = new System.Drawing.Point(146, 9);
            this.ClientTextBox.Name = "ClientTextBox";
            this.ClientTextBox.Size = new System.Drawing.Size(134, 20);
            this.ClientTextBox.TabIndex = 4;
            // 
            // SearchClientButton
            // 
            this.SearchClientButton.Location = new System.Drawing.Point(286, 7);
            this.SearchClientButton.Name = "SearchClientButton";
            this.SearchClientButton.Size = new System.Drawing.Size(104, 23);
            this.SearchClientButton.TabIndex = 5;
            this.SearchClientButton.Text = "Search Clients";
            this.SearchClientButton.UseVisualStyleBackColor = true;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(577, 166);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(27, 13);
            this.TitleLabel.TabIndex = 6;
            this.TitleLabel.Text = "Title";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(577, 195);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(31, 13);
            this.TypeLabel.TabIndex = 7;
            this.TypeLabel.Text = "Type";
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(557, 225);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(55, 13);
            this.StartLabel.TabIndex = 8;
            this.StartLabel.Text = "Start Time";
            // 
            // EndLabel
            // 
            this.EndLabel.AutoSize = true;
            this.EndLabel.Location = new System.Drawing.Point(560, 247);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(52, 13);
            this.EndLabel.TabIndex = 9;
            this.EndLabel.Text = "End Time";
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(58, 90);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Create Appointment With:";
            // 
            // CustomerNameLabel
            // 
            this.CustomerNameLabel.AutoSize = true;
            this.CustomerNameLabel.Location = new System.Drawing.Point(17, 93);
            this.CustomerNameLabel.Name = "CustomerNameLabel";
            this.CustomerNameLabel.Size = new System.Drawing.Size(35, 13);
            this.CustomerNameLabel.TabIndex = 12;
            this.CustomerNameLabel.Text = "Name";
            // 
            // AppointmentFormExitButton
            // 
            this.AppointmentFormExitButton.Location = new System.Drawing.Point(735, 396);
            this.AppointmentFormExitButton.Name = "AppointmentFormExitButton";
            this.AppointmentFormExitButton.Size = new System.Drawing.Size(53, 42);
            this.AppointmentFormExitButton.TabIndex = 13;
            this.AppointmentFormExitButton.Text = "Exit";
            this.AppointmentFormExitButton.UseVisualStyleBackColor = true;
            this.AppointmentFormExitButton.Click += new System.EventHandler(this.AppointmentFormExitButton_Click);
            // 
            // ScheduleButton
            // 
            this.ScheduleButton.Location = new System.Drawing.Point(615, 396);
            this.ScheduleButton.Name = "ScheduleButton";
            this.ScheduleButton.Size = new System.Drawing.Size(114, 42);
            this.ScheduleButton.TabIndex = 14;
            this.ScheduleButton.Text = "Schedule Appointment";
            this.ScheduleButton.UseVisualStyleBackColor = true;
            // 
            // MainFormMCRButton
            // 
            this.MainFormMCRButton.Location = new System.Drawing.Point(396, 9);
            this.MainFormMCRButton.Name = "MainFormMCRButton";
            this.MainFormMCRButton.Size = new System.Drawing.Size(119, 36);
            this.MainFormMCRButton.TabIndex = 15;
            this.MainFormMCRButton.Text = "Manage Customer Records";
            this.MainFormMCRButton.UseVisualStyleBackColor = true;
            this.MainFormMCRButton.Click += new System.EventHandler(this.MainFormMCRButton_Click);
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(34, 119);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(18, 13);
            this.IDLabel.TabIndex = 17;
            this.IDLabel.Text = "ID";
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(58, 116);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 16;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.MainFormMCRButton);
            this.Controls.Add(this.ScheduleButton);
            this.Controls.Add(this.AppointmentFormExitButton);
            this.Controls.Add(this.CustomerNameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.SearchClientButton);
            this.Controls.Add(this.ClientTextBox);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "AppointmentForm";
            this.Text = "Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox ClientTextBox;
        private System.Windows.Forms.Button SearchClientButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CustomerNameLabel;
        private System.Windows.Forms.Button AppointmentFormExitButton;
        private System.Windows.Forms.Button ScheduleButton;
        private System.Windows.Forms.Button MainFormMCRButton;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.TextBox textBox6;
    }
}