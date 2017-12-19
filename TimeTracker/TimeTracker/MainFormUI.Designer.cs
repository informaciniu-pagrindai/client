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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormUI));
            this.curProjLabel = new System.Windows.Forms.Label();
            this.curStateLabel = new System.Windows.Forms.Label();
            this.curProjNameLabel = new System.Windows.Forms.LinkLabel();
            this.shortcutGBox = new System.Windows.Forms.GroupBox();
            this.shortcutsEditBtn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.stateGBox = new System.Windows.Forms.GroupBox();
            this.historyBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.actionNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionShortcutColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortcutGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.stateGBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // curProjLabel
            // 
            this.curProjLabel.AutoSize = true;
            this.curProjLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.curProjLabel.Location = new System.Drawing.Point(60, 197);
            this.curProjLabel.Name = "curProjLabel";
            this.curProjLabel.Size = new System.Drawing.Size(142, 32);
            this.curProjLabel.TabIndex = 1;
            this.curProjLabel.Text = "Projektas:";
            // 
            // curStateLabel
            // 
            this.curStateLabel.AutoSize = true;
            this.curStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curStateLabel.Location = new System.Drawing.Point(60, 60);
            this.curStateLabel.Name = "curStateLabel";
            this.curStateLabel.Size = new System.Drawing.Size(183, 32);
            this.curStateLabel.TabIndex = 2;
            this.curStateLabel.Text = "Neprisijungta";
            // 
            // curProjNameLabel
            // 
            this.curProjNameLabel.AutoSize = true;
            this.curProjNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.curProjNameLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.curProjNameLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.curProjNameLabel.Location = new System.Drawing.Point(222, 197);
            this.curProjNameLabel.Name = "curProjNameLabel";
            this.curProjNameLabel.Size = new System.Drawing.Size(147, 32);
            this.curProjNameLabel.TabIndex = 5;
            this.curProjNameLabel.TabStop = true;
            this.curProjNameLabel.Text = "-pasirinkti-";
            this.curProjNameLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.curProjNameLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.curProjNameLabel_LinkClicked);
            // 
            // shortcutGBox
            // 
            this.shortcutGBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shortcutGBox.AutoSize = true;
            this.shortcutGBox.Controls.Add(this.shortcutsEditBtn);
            this.shortcutGBox.Controls.Add(this.dataGridView2);
            this.shortcutGBox.Enabled = false;
            this.shortcutGBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.shortcutGBox.Location = new System.Drawing.Point(578, 13);
            this.shortcutGBox.Name = "shortcutGBox";
            this.shortcutGBox.Padding = new System.Windows.Forms.Padding(10);
            this.shortcutGBox.Size = new System.Drawing.Size(395, 507);
            this.shortcutGBox.TabIndex = 6;
            this.shortcutGBox.TabStop = false;
            this.shortcutGBox.Text = "Veiksmai";
            // 
            // shortcutsEditBtn
            // 
            this.shortcutsEditBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.shortcutsEditBtn.Location = new System.Drawing.Point(10, 449);
            this.shortcutsEditBtn.Name = "shortcutsEditBtn";
            this.shortcutsEditBtn.Size = new System.Drawing.Size(375, 48);
            this.shortcutsEditBtn.TabIndex = 1;
            this.shortcutsEditBtn.Text = "Redaguoti";
            this.shortcutsEditBtn.UseVisualStyleBackColor = true;
            this.shortcutsEditBtn.Click += new System.EventHandler(this.shortcutsEditBtn_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeight = 40;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.actionNameColumn,
            this.actionShortcutColumn});
            this.dataGridView2.Location = new System.Drawing.Point(10, 29);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(375, 414);
            this.dataGridView2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.action,
            this.timeFrom});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(10, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(369, 82);
            this.dataGridView1.TabIndex = 8;
            // 
            // stateGBox
            // 
            this.stateGBox.Controls.Add(this.historyBtn);
            this.stateGBox.Controls.Add(this.dataGridView1);
            this.stateGBox.Enabled = false;
            this.stateGBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.stateGBox.Location = new System.Drawing.Point(31, 335);
            this.stateGBox.Name = "stateGBox";
            this.stateGBox.Padding = new System.Windows.Forms.Padding(10);
            this.stateGBox.Size = new System.Drawing.Size(518, 121);
            this.stateGBox.TabIndex = 9;
            this.stateGBox.TabStop = false;
            this.stateGBox.Text = "Būsena";
            // 
            // historyBtn
            // 
            this.historyBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.historyBtn.Location = new System.Drawing.Point(385, 29);
            this.historyBtn.Name = "historyBtn";
            this.historyBtn.Size = new System.Drawing.Size(123, 82);
            this.historyBtn.TabIndex = 9;
            this.historyBtn.Text = "Istorija";
            this.historyBtn.UseVisualStyleBackColor = true;
            this.historyBtn.Click += new System.EventHandler(this.historyBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.Location = new System.Drawing.Point(60, 117);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(131, 41);
            this.logoutBtn.TabIndex = 10;
            this.logoutBtn.Text = "Atsijungti";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // actionNameColumn
            // 
            this.actionNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.actionNameColumn.FillWeight = 40F;
            this.actionNameColumn.HeaderText = "Pavadinimas";
            this.actionNameColumn.Name = "actionNameColumn";
            this.actionNameColumn.ReadOnly = true;
            this.actionNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.actionNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.actionNameColumn.Width = 104;
            // 
            // actionShortcutColumn
            // 
            this.actionShortcutColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.actionShortcutColumn.FillWeight = 60F;
            this.actionShortcutColumn.HeaderText = "Kombinacija";
            this.actionShortcutColumn.Name = "actionShortcutColumn";
            this.actionShortcutColumn.ReadOnly = true;
            this.actionShortcutColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // action
            // 
            this.action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.action.HeaderText = "Veiksmas";
            this.action.Name = "action";
            this.action.ReadOnly = true;
            this.action.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.action.Width = 114;
            // 
            // timeFrom
            // 
            this.timeFrom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeFrom.HeaderText = "Pradėta";
            this.timeFrom.Name = "timeFrom";
            this.timeFrom.ReadOnly = true;
            this.timeFrom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // MainFormUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(986, 533);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.stateGBox);
            this.Controls.Add(this.shortcutGBox);
            this.Controls.Add(this.curProjNameLabel);
            this.Controls.Add(this.curStateLabel);
            this.Controls.Add(this.curProjLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainFormUI";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Laiko sekimo sistema";
            this.shortcutGBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.stateGBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label curProjLabel;
        private System.Windows.Forms.Label curStateLabel;
        private System.Windows.Forms.LinkLabel curProjNameLabel;
        private System.Windows.Forms.GroupBox shortcutGBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox stateGBox;
        private System.Windows.Forms.Button historyBtn;
        private System.Windows.Forms.Button shortcutsEditBtn;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionNameColumn;
        private System.Windows.Forms.DataGridViewButtonColumn actionShortcutColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn action;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeFrom;
    }
}
