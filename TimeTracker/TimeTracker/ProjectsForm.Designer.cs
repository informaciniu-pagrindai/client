namespace TimeTracker
{
    partial class ProjectsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectsForm));
            this.projectsGrid = new System.Windows.Forms.DataGridView();
            this.projectNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectRoleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectActionListColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // projectsGrid
            // 
            this.projectsGrid.AllowUserToAddRows = false;
            this.projectsGrid.AllowUserToDeleteRows = false;
            this.projectsGrid.ColumnHeadersHeight = 40;
            this.projectsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.projectsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.projectNameColumn,
            this.projectRoleColumn,
            this.projectActionListColumn});
            this.projectsGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.projectsGrid.Location = new System.Drawing.Point(0, 0);
            this.projectsGrid.Name = "projectsGrid";
            this.projectsGrid.ReadOnly = true;
            this.projectsGrid.RowTemplate.Height = 28;
            this.projectsGrid.Size = new System.Drawing.Size(746, 300);
            this.projectsGrid.TabIndex = 10;
            // 
            // projectNameColumn
            // 
            this.projectNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.projectNameColumn.HeaderText = "Pavadinimas";
            this.projectNameColumn.Name = "projectNameColumn";
            this.projectNameColumn.ReadOnly = true;
            this.projectNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.projectNameColumn.Width = 134;
            // 
            // projectRoleColumn
            // 
            this.projectRoleColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.projectRoleColumn.HeaderText = "Rolė";
            this.projectRoleColumn.Name = "projectRoleColumn";
            this.projectRoleColumn.ReadOnly = true;
            this.projectRoleColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.projectRoleColumn.Width = 78;
            // 
            // projectActionListColumn
            // 
            this.projectActionListColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.projectActionListColumn.HeaderText = "Veiksmai";
            this.projectActionListColumn.Name = "projectActionListColumn";
            this.projectActionListColumn.ReadOnly = true;
            this.projectActionListColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.projectActionListColumn.Width = 109;
            // 
            // selectBtn
            // 
            this.selectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectBtn.Location = new System.Drawing.Point(506, 314);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(105, 44);
            this.selectBtn.TabIndex = 11;
            this.selectBtn.Text = "Pasirinkti";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(629, 314);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(105, 44);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Atšaukti";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ProjectsForm
            // 
            this.AcceptButton = this.selectBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(746, 370);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.projectsGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProjectsForm";
            this.Text = "Pasirinkti projektą";
            ((System.ComponentModel.ISupportInitialize)(this.projectsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView projectsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectRoleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectActionListColumn;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}