namespace PlayerListSubmissionProject
{
    partial class SpreadsheetSelectionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_member = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_TeamManage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Select Your Team";
            // 
            // button_member
            // 
            this.button_member.Location = new System.Drawing.Point(13, 55);
            this.button_member.Name = "button_member";
            this.button_member.Size = new System.Drawing.Size(136, 23);
            this.button_member.TabIndex = 2;
            this.button_member.Text = "Member";
            this.button_member.UseVisualStyleBackColor = true;
            this.button_member.Click += new System.EventHandler(this.spreadsheetSubmit);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(279, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // button_TeamManage
            // 
            this.button_TeamManage.Location = new System.Drawing.Point(155, 55);
            this.button_TeamManage.Name = "button_TeamManage";
            this.button_TeamManage.Size = new System.Drawing.Size(136, 23);
            this.button_TeamManage.TabIndex = 4;
            this.button_TeamManage.Text = "Team Management";
            this.button_TeamManage.UseVisualStyleBackColor = true;
            this.button_TeamManage.Click += new System.EventHandler(this.button_TeamManage_Click);
            // 
            // SpreadsheetSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 90);
            this.Controls.Add(this.button_TeamManage);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button_member);
            this.Controls.Add(this.label1);
            this.Name = "SpreadsheetSelectionForm";
            this.Text = "MCOC Team Selector";
            this.Load += new System.EventHandler(this.SpreadsheetSelectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_member;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button_TeamManage;
    }
}