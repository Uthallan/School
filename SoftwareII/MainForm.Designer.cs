﻿
namespace SoftwareII
{
    partial class MainForm
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
            this.CheckDatabaseConnectionButton = new System.Windows.Forms.Button();
            this.MainFormExitButton = new System.Windows.Forms.Button();
            this.AppointmentsDataGridView = new System.Windows.Forms.DataGridView();
            this.MainFormAllRadioButton = new System.Windows.Forms.RadioButton();
            this.MainFormWeekRadioButton = new System.Windows.Forms.RadioButton();
            this.MainFormMonthRadioButton = new System.Windows.Forms.RadioButton();
            this.NewAppointmentButton = new System.Windows.Forms.Button();
            this.UpdateAppointmentButton = new System.Windows.Forms.Button();
            this.CancelAppointmentButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.MainFormMCRButton = new System.Windows.Forms.Button();
            this.LoggedInUserLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReportsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckDatabaseConnectionButton
            // 
            this.CheckDatabaseConnectionButton.Location = new System.Drawing.Point(530, 404);
            this.CheckDatabaseConnectionButton.Name = "CheckDatabaseConnectionButton";
            this.CheckDatabaseConnectionButton.Size = new System.Drawing.Size(102, 34);
            this.CheckDatabaseConnectionButton.TabIndex = 0;
            this.CheckDatabaseConnectionButton.Text = "Check Database Connection";
            this.CheckDatabaseConnectionButton.UseVisualStyleBackColor = true;
            this.CheckDatabaseConnectionButton.Click += new System.EventHandler(this.CheckDatabaseConnectionButton_Click);
            // 
            // MainFormExitButton
            // 
            this.MainFormExitButton.Location = new System.Drawing.Point(638, 405);
            this.MainFormExitButton.Name = "MainFormExitButton";
            this.MainFormExitButton.Size = new System.Drawing.Size(43, 33);
            this.MainFormExitButton.TabIndex = 1;
            this.MainFormExitButton.Text = "Exit";
            this.MainFormExitButton.UseVisualStyleBackColor = true;
            this.MainFormExitButton.Click += new System.EventHandler(this.MainFormExitButton_Click);
            // 
            // AppointmentsDataGridView
            // 
            this.AppointmentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentsDataGridView.Location = new System.Drawing.Point(101, 77);
            this.AppointmentsDataGridView.Name = "AppointmentsDataGridView";
            this.AppointmentsDataGridView.Size = new System.Drawing.Size(580, 287);
            this.AppointmentsDataGridView.TabIndex = 2;
            this.AppointmentsDataGridView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AppointmentsDataGridView_MouseMove);
            // 
            // MainFormAllRadioButton
            // 
            this.MainFormAllRadioButton.AutoSize = true;
            this.MainFormAllRadioButton.Location = new System.Drawing.Point(12, 250);
            this.MainFormAllRadioButton.Name = "MainFormAllRadioButton";
            this.MainFormAllRadioButton.Size = new System.Drawing.Size(36, 17);
            this.MainFormAllRadioButton.TabIndex = 4;
            this.MainFormAllRadioButton.TabStop = true;
            this.MainFormAllRadioButton.Text = "All";
            this.MainFormAllRadioButton.UseVisualStyleBackColor = true;
            this.MainFormAllRadioButton.CheckedChanged += new System.EventHandler(this.MainFormAllRadioButton_CheckedChanged);
            // 
            // MainFormWeekRadioButton
            // 
            this.MainFormWeekRadioButton.AutoSize = true;
            this.MainFormWeekRadioButton.Location = new System.Drawing.Point(12, 273);
            this.MainFormWeekRadioButton.Name = "MainFormWeekRadioButton";
            this.MainFormWeekRadioButton.Size = new System.Drawing.Size(54, 17);
            this.MainFormWeekRadioButton.TabIndex = 5;
            this.MainFormWeekRadioButton.TabStop = true;
            this.MainFormWeekRadioButton.Text = "Week";
            this.MainFormWeekRadioButton.UseVisualStyleBackColor = true;
            this.MainFormWeekRadioButton.CheckedChanged += new System.EventHandler(this.MainFormWeekRadioButton_CheckedChanged);
            // 
            // MainFormMonthRadioButton
            // 
            this.MainFormMonthRadioButton.AutoSize = true;
            this.MainFormMonthRadioButton.Location = new System.Drawing.Point(12, 296);
            this.MainFormMonthRadioButton.Name = "MainFormMonthRadioButton";
            this.MainFormMonthRadioButton.Size = new System.Drawing.Size(55, 17);
            this.MainFormMonthRadioButton.TabIndex = 6;
            this.MainFormMonthRadioButton.TabStop = true;
            this.MainFormMonthRadioButton.Text = "Month";
            this.MainFormMonthRadioButton.UseVisualStyleBackColor = true;
            this.MainFormMonthRadioButton.CheckedChanged += new System.EventHandler(this.MainFormMonthRadioButton_CheckedChanged);
            // 
            // NewAppointmentButton
            // 
            this.NewAppointmentButton.Location = new System.Drawing.Point(12, 77);
            this.NewAppointmentButton.Name = "NewAppointmentButton";
            this.NewAppointmentButton.Size = new System.Drawing.Size(83, 36);
            this.NewAppointmentButton.TabIndex = 7;
            this.NewAppointmentButton.Text = "New Appointment";
            this.NewAppointmentButton.UseVisualStyleBackColor = true;
            this.NewAppointmentButton.Click += new System.EventHandler(this.NewAppointmentButton_Click);
            // 
            // UpdateAppointmentButton
            // 
            this.UpdateAppointmentButton.Location = new System.Drawing.Point(12, 119);
            this.UpdateAppointmentButton.Name = "UpdateAppointmentButton";
            this.UpdateAppointmentButton.Size = new System.Drawing.Size(83, 36);
            this.UpdateAppointmentButton.TabIndex = 8;
            this.UpdateAppointmentButton.Text = "Update Appointment";
            this.UpdateAppointmentButton.UseVisualStyleBackColor = true;
            this.UpdateAppointmentButton.Click += new System.EventHandler(this.UpdateAppointmentButton_Click);
            // 
            // CancelAppointmentButton
            // 
            this.CancelAppointmentButton.Location = new System.Drawing.Point(12, 161);
            this.CancelAppointmentButton.Name = "CancelAppointmentButton";
            this.CancelAppointmentButton.Size = new System.Drawing.Size(83, 36);
            this.CancelAppointmentButton.TabIndex = 9;
            this.CancelAppointmentButton.Text = "Cancel Appointment";
            this.CancelAppointmentButton.UseVisualStyleBackColor = true;
            this.CancelAppointmentButton.Click += new System.EventHandler(this.CancelAppointmentButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(12, 12);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(57, 27);
            this.LoginButton.TabIndex = 10;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // MainFormMCRButton
            // 
            this.MainFormMCRButton.Location = new System.Drawing.Point(101, 370);
            this.MainFormMCRButton.Name = "MainFormMCRButton";
            this.MainFormMCRButton.Size = new System.Drawing.Size(119, 36);
            this.MainFormMCRButton.TabIndex = 11;
            this.MainFormMCRButton.Text = "Manage Customer Records";
            this.MainFormMCRButton.UseVisualStyleBackColor = true;
            this.MainFormMCRButton.Click += new System.EventHandler(this.MainFormMCRButton_Click);
            // 
            // LoggedInUserLabel
            // 
            this.LoggedInUserLabel.AutoSize = true;
            this.LoggedInUserLabel.Location = new System.Drawing.Point(75, 19);
            this.LoggedInUserLabel.Name = "LoggedInUserLabel";
            this.LoggedInUserLabel.Size = new System.Drawing.Size(0, 13);
            this.LoggedInUserLabel.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Calendar: Appointments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "View";
            // 
            // ReportsButton
            // 
            this.ReportsButton.Location = new System.Drawing.Point(606, 48);
            this.ReportsButton.Name = "ReportsButton";
            this.ReportsButton.Size = new System.Drawing.Size(75, 23);
            this.ReportsButton.TabIndex = 15;
            this.ReportsButton.Text = "Reports";
            this.ReportsButton.UseVisualStyleBackColor = true;
            this.ReportsButton.Click += new System.EventHandler(this.ReportsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 450);
            this.Controls.Add(this.ReportsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoggedInUserLabel);
            this.Controls.Add(this.MainFormMCRButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.CancelAppointmentButton);
            this.Controls.Add(this.UpdateAppointmentButton);
            this.Controls.Add(this.NewAppointmentButton);
            this.Controls.Add(this.MainFormMonthRadioButton);
            this.Controls.Add(this.MainFormWeekRadioButton);
            this.Controls.Add(this.MainFormAllRadioButton);
            this.Controls.Add(this.AppointmentsDataGridView);
            this.Controls.Add(this.MainFormExitButton);
            this.Controls.Add(this.CheckDatabaseConnectionButton);
            this.Name = "MainForm";
            this.Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CheckDatabaseConnectionButton;
        private System.Windows.Forms.Button MainFormExitButton;
        private System.Windows.Forms.DataGridView AppointmentsDataGridView;
        private System.Windows.Forms.RadioButton MainFormAllRadioButton;
        private System.Windows.Forms.RadioButton MainFormWeekRadioButton;
        private System.Windows.Forms.RadioButton MainFormMonthRadioButton;
        private System.Windows.Forms.Button NewAppointmentButton;
        private System.Windows.Forms.Button UpdateAppointmentButton;
        private System.Windows.Forms.Button CancelAppointmentButton;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button MainFormMCRButton;
        private System.Windows.Forms.Label LoggedInUserLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ReportsButton;
    }
}