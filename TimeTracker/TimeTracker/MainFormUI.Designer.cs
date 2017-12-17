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
            this.curProjLabel = new System.Windows.Forms.Label();
            this.curStateLabel = new System.Windows.Forms.Label();
            this.curStateNameLabel = new System.Windows.Forms.Label();
            this.curProjNameLabel = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.actionNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionShortcutColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // curProjLabel
            // 
            this.curProjLabel.AutoSize = true;
            this.curProjLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curProjLabel.Location = new System.Drawing.Point(56, 61);
            this.curProjLabel.Name = "curProjLabel";
            this.curProjLabel.Size = new System.Drawing.Size(293, 64);
            this.curProjLabel.TabIndex = 1;
            this.curProjLabel.Text = "Projektas: ";
            // 
            // curStateLabel
            // 
            this.curStateLabel.AutoSize = true;
            this.curStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curStateLabel.Location = new System.Drawing.Point(56, 162);
            this.curStateLabel.Name = "curStateLabel";
            this.curStateLabel.Size = new System.Drawing.Size(248, 64);
            this.curStateLabel.TabIndex = 2;
            this.curStateLabel.Text = "Būsena: ";
            // 
            // curStateNameLabel
            // 
            this.curStateNameLabel.AutoSize = true;
            this.curStateNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curStateNameLabel.Location = new System.Drawing.Point(341, 162);
            this.curStateNameLabel.Name = "curStateNameLabel";
            this.curStateNameLabel.Size = new System.Drawing.Size(47, 64);
            this.curStateNameLabel.TabIndex = 4;
            this.curStateNameLabel.Text = "-";
            // 
            // curProjNameLabel
            // 
            this.curProjNameLabel.AutoSize = true;
            this.curProjNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.curProjNameLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.curProjNameLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.curProjNameLabel.Location = new System.Drawing.Point(341, 61);
            this.curProjNameLabel.Name = "curProjNameLabel";
            this.curProjNameLabel.Size = new System.Drawing.Size(289, 64);
            this.curProjNameLabel.TabIndex = 5;
            this.curProjNameLabel.TabStop = true;
            this.curProjNameLabel.Text = "-pasirinkti-";
            this.curProjNameLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.curProjNameLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.curProjNameLabel_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.groupBox1.Location = new System.Drawing.Point(755, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(336, 544);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Veiksmai";
            this.groupBox1.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 665);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1148, 30);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(179, 25);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.action,
            this.timeFrom,
            this.timeTo,
            this.edit});
            this.dataGridView1.Location = new System.Drawing.Point(67, 300);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(615, 315);
            this.dataGridView1.TabIndex = 8;
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
            this.timeFrom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.timeFrom.HeaderText = "Nuo";
            this.timeFrom.Name = "timeFrom";
            this.timeFrom.ReadOnly = true;
            this.timeFrom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.timeFrom.Width = 74;
            // 
            // timeTo
            // 
            this.timeTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.timeTo.HeaderText = "Iki";
            this.timeTo.Name = "timeTo";
            this.timeTo.ReadOnly = true;
            this.timeTo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.timeTo.Width = 61;
            // 
            // edit
            // 
            this.edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.edit.HeaderText = "Keisti";
            this.edit.Name = "edit";
            this.edit.Width = 53;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeight = 40;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.actionNameColumn,
            this.actionShortcutColumn});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(10, 47);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(316, 487);
            this.dataGridView2.TabIndex = 0;
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
            this.actionNameColumn.Width = 206;
            // 
            // actionShortcutColumn
            // 
            this.actionShortcutColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.actionShortcutColumn.FillWeight = 60F;
            this.actionShortcutColumn.HeaderText = "Kombinacija";
            this.actionShortcutColumn.Name = "actionShortcutColumn";
            this.actionShortcutColumn.ReadOnly = true;
            this.actionShortcutColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.actionShortcutColumn.Width = 198;
            // 
            // MainFormUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1148, 695);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.curProjNameLabel);
            this.Controls.Add(this.curStateNameLabel);
            this.Controls.Add(this.curStateLabel);
            this.Controls.Add(this.curProjLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainFormUI";
            this.Text = "MainFormUI";
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label curProjLabel;
        private System.Windows.Forms.Label curStateLabel;
        private System.Windows.Forms.Label curStateNameLabel;
        private System.Windows.Forms.LinkLabel curProjNameLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn action;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeTo;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionNameColumn;
        private System.Windows.Forms.DataGridViewButtonColumn actionShortcutColumn;
    }
}
