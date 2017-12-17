namespace TimeTracker
{
    partial class MainFormUI
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
            this.MyProjectsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MyProjectsBtn
            // 
            this.MyProjectsBtn.Location = new System.Drawing.Point(58, 104);
            this.MyProjectsBtn.Name = "MyProjectsBtn";
            this.MyProjectsBtn.Size = new System.Drawing.Size(110, 23);
            this.MyProjectsBtn.TabIndex = 0;
            this.MyProjectsBtn.Text = "Mano projektai";
            this.MyProjectsBtn.UseVisualStyleBackColor = true;
            this.MyProjectsBtn.Click += new System.EventHandler(this.MyProjectsBtn_Click);
            // 
            // MainFormUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(753, 491);
            this.Controls.Add(this.MyProjectsBtn);
            this.Name = "MainFormUI";
            this.Text = "MainFormUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MyProjectsBtn;
    }
}