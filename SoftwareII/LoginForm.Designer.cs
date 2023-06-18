
namespace SoftwareII
{
    partial class LoginForm
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
            this.LoginFormUsernameTextBox = new System.Windows.Forms.TextBox();
            this.LoginFormPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginFormLoginbutton = new System.Windows.Forms.Button();
            this.LoginFormCancelButton = new System.Windows.Forms.Button();
            this.LogsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginFormUsernameTextBox
            // 
            this.LoginFormUsernameTextBox.Location = new System.Drawing.Point(88, 65);
            this.LoginFormUsernameTextBox.Name = "LoginFormUsernameTextBox";
            this.LoginFormUsernameTextBox.Size = new System.Drawing.Size(135, 20);
            this.LoginFormUsernameTextBox.TabIndex = 0;
            // 
            // LoginFormPasswordTextBox
            // 
            this.LoginFormPasswordTextBox.Location = new System.Drawing.Point(88, 111);
            this.LoginFormPasswordTextBox.Name = "LoginFormPasswordTextBox";
            this.LoginFormPasswordTextBox.Size = new System.Drawing.Size(135, 20);
            this.LoginFormPasswordTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // LoginFormLoginbutton
            // 
            this.LoginFormLoginbutton.Location = new System.Drawing.Point(77, 197);
            this.LoginFormLoginbutton.Name = "LoginFormLoginbutton";
            this.LoginFormLoginbutton.Size = new System.Drawing.Size(75, 23);
            this.LoginFormLoginbutton.TabIndex = 4;
            this.LoginFormLoginbutton.Text = "Login";
            this.LoginFormLoginbutton.UseVisualStyleBackColor = true;
            this.LoginFormLoginbutton.Click += new System.EventHandler(this.LoginFormLoginbutton_Click);
            // 
            // LoginFormCancelButton
            // 
            this.LoginFormCancelButton.Location = new System.Drawing.Point(158, 197);
            this.LoginFormCancelButton.Name = "LoginFormCancelButton";
            this.LoginFormCancelButton.Size = new System.Drawing.Size(75, 23);
            this.LoginFormCancelButton.TabIndex = 5;
            this.LoginFormCancelButton.Text = "Cancel";
            this.LoginFormCancelButton.UseVisualStyleBackColor = true;
            this.LoginFormCancelButton.Click += new System.EventHandler(this.LoginFormCancelButton_Click);
            // 
            // LogsButton
            // 
            this.LogsButton.Location = new System.Drawing.Point(12, 12);
            this.LogsButton.Name = "LogsButton";
            this.LogsButton.Size = new System.Drawing.Size(75, 23);
            this.LogsButton.TabIndex = 6;
            this.LogsButton.Text = "Logs";
            this.LogsButton.UseVisualStyleBackColor = true;
            this.LogsButton.Click += new System.EventHandler(this.LogsButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 260);
            this.Controls.Add(this.LogsButton);
            this.Controls.Add(this.LoginFormCancelButton);
            this.Controls.Add(this.LoginFormLoginbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginFormPasswordTextBox);
            this.Controls.Add(this.LoginFormUsernameTextBox);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LoginFormUsernameTextBox;
        private System.Windows.Forms.TextBox LoginFormPasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LoginFormLoginbutton;
        private System.Windows.Forms.Button LoginFormCancelButton;
        private System.Windows.Forms.Button LogsButton;
    }
}

