
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
            this.UserIdTestBox = new System.Windows.Forms.TextBox();
            this.AppointmentTypeTextbox = new System.Windows.Forms.TextBox();
            this.ClientSearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchClientButton = new System.Windows.Forms.Button();
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.StartLabel = new System.Windows.Forms.Label();
            this.EndLabel = new System.Windows.Forms.Label();
            this.CustomerNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CustomerNameLabel = new System.Windows.Forms.Label();
            this.AppointmentFormExitButton = new System.Windows.Forms.Button();
            this.ScheduleButton = new System.Windows.Forms.Button();
            this.MainFormMCRButton = new System.Windows.Forms.Button();
            this.IDLabel = new System.Windows.Forms.Label();
            this.CustomerIDTextBox = new System.Windows.Forms.TextBox();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // UserIdTestBox
            // 
            this.UserIdTestBox.Location = new System.Drawing.Point(215, 90);
            this.UserIdTestBox.Name = "UserIdTestBox";
            this.UserIdTestBox.Size = new System.Drawing.Size(100, 20);
            this.UserIdTestBox.TabIndex = 0;
            // 
            // AppointmentTypeTextbox
            // 
            this.AppointmentTypeTextbox.Location = new System.Drawing.Point(215, 116);
            this.AppointmentTypeTextbox.Name = "AppointmentTypeTextbox";
            this.AppointmentTypeTextbox.Size = new System.Drawing.Size(100, 20);
            this.AppointmentTypeTextbox.TabIndex = 1;
            // 
            // ClientSearchTextBox
            // 
            this.ClientSearchTextBox.Location = new System.Drawing.Point(146, 9);
            this.ClientSearchTextBox.Name = "ClientSearchTextBox";
            this.ClientSearchTextBox.Size = new System.Drawing.Size(134, 20);
            this.ClientSearchTextBox.TabIndex = 4;
            // 
            // SearchClientButton
            // 
            this.SearchClientButton.Location = new System.Drawing.Point(286, 7);
            this.SearchClientButton.Name = "SearchClientButton";
            this.SearchClientButton.Size = new System.Drawing.Size(104, 23);
            this.SearchClientButton.TabIndex = 5;
            this.SearchClientButton.Text = "Search Clients";
            this.SearchClientButton.UseVisualStyleBackColor = true;
            this.SearchClientButton.Click += new System.EventHandler(this.SearchClientButton_Click);
            // 
            // UserIDLabel
            // 
            this.UserIDLabel.AutoSize = true;
            this.UserIDLabel.Location = new System.Drawing.Point(174, 90);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(40, 13);
            this.UserIDLabel.TabIndex = 6;
            this.UserIDLabel.Text = "UserID";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(174, 119);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(31, 13);
            this.TypeLabel.TabIndex = 7;
            this.TypeLabel.Text = "Type";
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(9, 153);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(55, 13);
            this.StartLabel.TabIndex = 8;
            this.StartLabel.Text = "Start Time";
            // 
            // EndLabel
            // 
            this.EndLabel.AutoSize = true;
            this.EndLabel.Location = new System.Drawing.Point(12, 185);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(52, 13);
            this.EndLabel.TabIndex = 9;
            this.EndLabel.Text = "End Time";
            // 
            // CustomerNameTextBox
            // 
            this.CustomerNameTextBox.Enabled = false;
            this.CustomerNameTextBox.Location = new System.Drawing.Point(58, 90);
            this.CustomerNameTextBox.Name = "CustomerNameTextBox";
            this.CustomerNameTextBox.ReadOnly = true;
            this.CustomerNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.CustomerNameTextBox.TabIndex = 10;
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
            this.ScheduleButton.Click += new System.EventHandler(this.ScheduleButton_Click);
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
            // CustomerIDTextBox
            // 
            this.CustomerIDTextBox.Enabled = false;
            this.CustomerIDTextBox.Location = new System.Drawing.Point(58, 116);
            this.CustomerIDTextBox.Name = "CustomerIDTextBox";
            this.CustomerIDTextBox.ReadOnly = true;
            this.CustomerIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.CustomerIDTextBox.TabIndex = 16;
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StartDatePicker.Location = new System.Drawing.Point(70, 153);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(108, 20);
            this.StartDatePicker.TabIndex = 18;
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.EndDatePicker.Location = new System.Drawing.Point(70, 185);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(108, 20);
            this.EndDatePicker.TabIndex = 19;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.CustomerIDTextBox);
            this.Controls.Add(this.MainFormMCRButton);
            this.Controls.Add(this.ScheduleButton);
            this.Controls.Add(this.AppointmentFormExitButton);
            this.Controls.Add(this.CustomerNameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustomerNameTextBox);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.UserIDLabel);
            this.Controls.Add(this.SearchClientButton);
            this.Controls.Add(this.ClientSearchTextBox);
            this.Controls.Add(this.AppointmentTypeTextbox);
            this.Controls.Add(this.UserIdTestBox);
            this.Name = "AppointmentForm";
            this.Text = "Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserIdTestBox;
        private System.Windows.Forms.TextBox AppointmentTypeTextbox;
        private System.Windows.Forms.TextBox ClientSearchTextBox;
        private System.Windows.Forms.Button SearchClientButton;
        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.TextBox CustomerNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CustomerNameLabel;
        private System.Windows.Forms.Button AppointmentFormExitButton;
        private System.Windows.Forms.Button ScheduleButton;
        private System.Windows.Forms.Button MainFormMCRButton;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.TextBox CustomerIDTextBox;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
    }
}