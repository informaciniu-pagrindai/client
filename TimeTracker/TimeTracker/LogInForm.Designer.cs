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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            this.logInLabel = new System.Windows.Forms.Label();
            this.emailTextbox = new System.Windows.Forms.TextBox();
            this.pwdTextbox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.pwdLabel = new System.Windows.Forms.Label();
            this.logInButton = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logInLabel
            // 
            this.logInLabel.AutoSize = true;
            this.logInLabel.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.logInLabel.Location = new System.Drawing.Point(108, 45);
            this.logInLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logInLabel.Name = "logInLabel";
            this.logInLabel.Size = new System.Drawing.Size(182, 37);
            this.logInLabel.TabIndex = 0;
            this.logInLabel.Text = "Prisijungimas";
            // 
            // emailTextbox
            // 
            this.emailTextbox.Location = new System.Drawing.Point(114, 151);
            this.emailTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.emailTextbox.MaxLength = 50;
            this.emailTextbox.Name = "emailTextbox";
            this.emailTextbox.Size = new System.Drawing.Size(187, 26);
            this.emailTextbox.TabIndex = 2;
            // 
            // pwdTextbox
            // 
            this.pwdTextbox.Location = new System.Drawing.Point(114, 231);
            this.pwdTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pwdTextbox.MaxLength = 40;
            this.pwdTextbox.Name = "pwdTextbox";
            this.pwdTextbox.PasswordChar = '*';
            this.pwdTextbox.Size = new System.Drawing.Size(187, 26);
            this.pwdTextbox.TabIndex = 4;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(114, 122);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(151, 24);
            this.emailLabel.TabIndex = 1;
            this.emailLabel.Text = "El. pašto adresas";
            // 
            // pwdLabel
            // 
            this.pwdLabel.AutoSize = true;
            this.pwdLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdLabel.Location = new System.Drawing.Point(114, 202);
            this.pwdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pwdLabel.Name = "pwdLabel";
            this.pwdLabel.Size = new System.Drawing.Size(105, 24);
            this.pwdLabel.TabIndex = 3;
            this.pwdLabel.Text = "Slaptažodis";
            // 
            // logInButton
            // 
            this.logInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logInButton.Location = new System.Drawing.Point(135, 291);
            this.logInButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(148, 38);
            this.logInButton.TabIndex = 5;
            this.logInButton.Text = "Prisijungti";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(146, 347);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(124, 33);
            this.registerBtn.TabIndex = 6;
            this.registerBtn.Text = "Registruotis";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(413, 427);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.logInButton);
            this.Controls.Add(this.pwdLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.pwdTextbox);
            this.Controls.Add(this.emailTextbox);
            this.Controls.Add(this.logInLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LogInForm";
            this.Text = "Laiko sekimo sistema";
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
        private System.Windows.Forms.Button registerBtn;
    }
}

