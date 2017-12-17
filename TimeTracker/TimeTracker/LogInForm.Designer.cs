namespace TimeTracker
{
    partial class LogInForm
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
            this.logInLabel = new System.Windows.Forms.Label();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            this.pwdTextbox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.pwdLabel = new System.Windows.Forms.Label();
            this.logInButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logInLabel
            // 
            this.logInLabel.AutoSize = true;
            this.logInLabel.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.logInLabel.Location = new System.Drawing.Point(138, 51);
            this.logInLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logInLabel.Name = "logInLabel";
            this.logInLabel.Size = new System.Drawing.Size(182, 37);
            this.logInLabel.TabIndex = 0;
            this.logInLabel.Text = "Prisijungimas";
            // 
            // emailTextbox
            // 
            this.emailTextbox.Location = new System.Drawing.Point(144, 160);
            this.emailTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(187, 26);
            this.emailTextbox.TabIndex = 1;
            // 
            // pwdTextbox
            // 
            this.pwdTextbox.Location = new System.Drawing.Point(144, 240);
            this.pwdTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pwdTextbox.Name = "pwdTextbox";
            this.pwdTextbox.PasswordChar = '*';
            this.pwdTextbox.Size = new System.Drawing.Size(187, 26);
            this.pwdTextbox.TabIndex = 2;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(144, 131);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(151, 24);
            this.emailLabel.TabIndex = 3;
            this.emailLabel.Text = "El. pašto adresas";
            // 
            // pwdLabel
            // 
            this.pwdLabel.AutoSize = true;
            this.pwdLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdLabel.Location = new System.Drawing.Point(144, 211);
            this.pwdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pwdLabel.Name = "pwdLabel";
            this.pwdLabel.Size = new System.Drawing.Size(105, 24);
            this.pwdLabel.TabIndex = 4;
            this.pwdLabel.Text = "Slaptažodis";
            // 
            // logInButton
            // 
            this.logInButton.Location = new System.Drawing.Point(176, 303);
            this.logInButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(124, 35);
            this.logInButton.TabIndex = 5;
            this.logInButton.Text = "Prisijungti";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(482, 415);
            this.Controls.Add(this.logInButton);
            this.Controls.Add(this.pwdLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.pwdTextbox);
            this.Controls.Add(this.emailTextbox);
            this.Controls.Add(this.logInLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LogInForm";
            this.Text = "Laiko sekimo sistema";
            this.Load += new System.EventHandler(this.LogInForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label logInLabel;
        private System.Windows.Forms.TextBox emailTextbox;
        private System.Windows.Forms.TextBox pwdTextbox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label pwdLabel;
        private System.Windows.Forms.Button logInButton;
    }
}

