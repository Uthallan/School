
namespace SoftwareII
{
    partial class MCRForm
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
            this.DeleteRecordButton = new System.Windows.Forms.Button();
            this.UpdateRecordButton = new System.Windows.Forms.Button();
            this.NewRecordButton = new System.Windows.Forms.Button();
            this.RecordssDataGridView = new System.Windows.Forms.DataGridView();
            this.MCRFormExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RecordssDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DeleteRecordButton
            // 
            this.DeleteRecordButton.Location = new System.Drawing.Point(15, 149);
            this.DeleteRecordButton.Name = "DeleteRecordButton";
            this.DeleteRecordButton.Size = new System.Drawing.Size(83, 36);
            this.DeleteRecordButton.TabIndex = 13;
            this.DeleteRecordButton.Text = "Delete Record";
            this.DeleteRecordButton.UseVisualStyleBackColor = true;
            // 
            // UpdateRecordButton
            // 
            this.UpdateRecordButton.Location = new System.Drawing.Point(15, 107);
            this.UpdateRecordButton.Name = "UpdateRecordButton";
            this.UpdateRecordButton.Size = new System.Drawing.Size(83, 36);
            this.UpdateRecordButton.TabIndex = 12;
            this.UpdateRecordButton.Text = "Update Record";
            this.UpdateRecordButton.UseVisualStyleBackColor = true;
            // 
            // NewRecordButton
            // 
            this.NewRecordButton.Location = new System.Drawing.Point(15, 65);
            this.NewRecordButton.Name = "NewRecordButton";
            this.NewRecordButton.Size = new System.Drawing.Size(83, 36);
            this.NewRecordButton.TabIndex = 11;
            this.NewRecordButton.Text = "New Record";
            this.NewRecordButton.UseVisualStyleBackColor = true;
            // 
            // RecordssDataGridView
            // 
            this.RecordssDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecordssDataGridView.Location = new System.Drawing.Point(104, 65);
            this.RecordssDataGridView.Name = "RecordssDataGridView";
            this.RecordssDataGridView.Size = new System.Drawing.Size(580, 287);
            this.RecordssDataGridView.TabIndex = 10;
            // 
            // MCRFormExitButton
            // 
            this.MCRFormExitButton.Location = new System.Drawing.Point(736, 400);
            this.MCRFormExitButton.Name = "MCRFormExitButton";
            this.MCRFormExitButton.Size = new System.Drawing.Size(52, 38);
            this.MCRFormExitButton.TabIndex = 14;
            this.MCRFormExitButton.Text = "Exit";
            this.MCRFormExitButton.UseVisualStyleBackColor = true;
            this.MCRFormExitButton.Click += new System.EventHandler(this.MCRFormExitButton_Click);
            // 
            // MCRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MCRFormExitButton);
            this.Controls.Add(this.DeleteRecordButton);
            this.Controls.Add(this.UpdateRecordButton);
            this.Controls.Add(this.NewRecordButton);
            this.Controls.Add(this.RecordssDataGridView);
            this.Name = "MCRForm";
            this.Text = "Customer Records";
            ((System.ComponentModel.ISupportInitialize)(this.RecordssDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DeleteRecordButton;
        private System.Windows.Forms.Button UpdateRecordButton;
        private System.Windows.Forms.Button NewRecordButton;
        private System.Windows.Forms.DataGridView RecordssDataGridView;
        private System.Windows.Forms.Button MCRFormExitButton;
    }
}