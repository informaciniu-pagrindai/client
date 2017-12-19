namespace TimeTracker
{
    partial class HistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryForm));
            this.historyGrid = new System.Windows.Forms.DataGridView();
            this.action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.historyGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // historyGrid
            // 
            this.historyGrid.AllowUserToAddRows = false;
            this.historyGrid.AllowUserToDeleteRows = false;
            this.historyGrid.ColumnHeadersHeight = 40;
            this.historyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.historyGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.action,
            this.timeFrom,
            this.timeTo,
            this.edit});
            this.historyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyGrid.Location = new System.Drawing.Point(0, 0);
            this.historyGrid.Name = "historyGrid";
            this.historyGrid.ReadOnly = true;
            this.historyGrid.RowTemplate.Height = 28;
            this.historyGrid.Size = new System.Drawing.Size(785, 484);
            this.historyGrid.TabIndex = 9;
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
            this.timeFrom.HeaderText = "Nuo";
            this.timeFrom.Name = "timeFrom";
            this.timeFrom.ReadOnly = true;
            this.timeFrom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // timeTo
            // 
            this.timeTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeTo.HeaderText = "Iki";
            this.timeTo.Name = "timeTo";
            this.timeTo.ReadOnly = true;
            this.timeTo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // edit
            // 
            this.edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.edit.HeaderText = "Keisti";
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Width = 53;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 484);
            this.Controls.Add(this.historyGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HistoryForm";
            this.Text = "Veiksmų istorija";
            ((System.ComponentModel.ISupportInitialize)(this.historyGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView historyGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn action;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeTo;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
    }
}