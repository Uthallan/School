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
            this.SuspendLayout();
            // 
            // CheckDatabaseConnectionButton
            // 
            this.CheckDatabaseConnectionButton.Location = new System.Drawing.Point(686, 12);
            this.CheckDatabaseConnectionButton.Name = "CheckDatabaseConnectionButton";
            this.CheckDatabaseConnectionButton.Size = new System.Drawing.Size(102, 34);
            this.CheckDatabaseConnectionButton.TabIndex = 0;
            this.CheckDatabaseConnectionButton.Text = "Check Database Connection";
            this.CheckDatabaseConnectionButton.UseVisualStyleBackColor = true;
            this.CheckDatabaseConnectionButton.Click += new System.EventHandler(this.CheckDatabaseConnectionButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CheckDatabaseConnectionButton);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CheckDatabaseConnectionButton;
    }
}