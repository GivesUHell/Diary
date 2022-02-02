namespace Diary
{
    partial class WatchOldTransactions
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
            this.dataGridViewOldTransactions = new System.Windows.Forms.DataGridView();
            this.ColumntoolSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumntoolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumntransactionCreator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumntakingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnreturnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumntoolTransactionReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOldTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOldTransactions
            // 
            this.dataGridViewOldTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOldTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumntoolSerial,
            this.ColumntoolName,
            this.ColumntransactionCreator,
            this.ColumntakingTime,
            this.ColumnreturnTime,
            this.ColumnSigned,
            this.ColumntoolTransactionReason});
            this.dataGridViewOldTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOldTransactions.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewOldTransactions.Name = "dataGridViewOldTransactions";
            this.dataGridViewOldTransactions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewOldTransactions.Size = new System.Drawing.Size(751, 435);
            this.dataGridViewOldTransactions.TabIndex = 0;
            // 
            // ColumntoolSerial
            // 
            this.ColumntoolSerial.DataPropertyName = "toolSerial";
            this.ColumntoolSerial.HeaderText = "מספר כלי";
            this.ColumntoolSerial.Name = "ColumntoolSerial";
            this.ColumntoolSerial.ReadOnly = true;
            // 
            // ColumntoolName
            // 
            this.ColumntoolName.DataPropertyName = "toolName";
            this.ColumntoolName.HeaderText = "שם כלי";
            this.ColumntoolName.Name = "ColumntoolName";
            this.ColumntoolName.ReadOnly = true;
            // 
            // ColumntransactionCreator
            // 
            this.ColumntransactionCreator.DataPropertyName = "transactionCreator";
            this.ColumntransactionCreator.HeaderText = "שם משתמש";
            this.ColumntransactionCreator.Name = "ColumntransactionCreator";
            this.ColumntransactionCreator.ReadOnly = true;
            // 
            // ColumntakingTime
            // 
            this.ColumntakingTime.DataPropertyName = "takingTime";
            this.ColumntakingTime.HeaderText = "זמן השאלה";
            this.ColumntakingTime.Name = "ColumntakingTime";
            this.ColumntakingTime.ReadOnly = true;
            // 
            // ColumnreturnTime
            // 
            this.ColumnreturnTime.DataPropertyName = "returnTime";
            this.ColumnreturnTime.HeaderText = "זמן החזרה";
            this.ColumnreturnTime.Name = "ColumnreturnTime";
            this.ColumnreturnTime.ReadOnly = true;
            // 
            // ColumnSigned
            // 
            this.ColumnSigned.DataPropertyName = "Signed";
            this.ColumnSigned.HeaderText = "ההשאלה נחתמה";
            this.ColumnSigned.Name = "ColumnSigned";
            this.ColumnSigned.ReadOnly = true;
            // 
            // ColumntoolTransactionReason
            // 
            this.ColumntoolTransactionReason.DataPropertyName = "toolTransactionReason";
            this.ColumntoolTransactionReason.HeaderText = "סיבת השאלה";
            this.ColumntoolTransactionReason.Name = "ColumntoolTransactionReason";
            this.ColumntoolTransactionReason.ReadOnly = true;
            // 
            // WatchOldTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 435);
            this.Controls.Add(this.dataGridViewOldTransactions);
            this.Name = "WatchOldTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "צפה בהשאלות ישנות";
            this.Load += new System.EventHandler(this.WatchOldTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOldTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOldTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumntoolSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumntoolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumntransactionCreator;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumntakingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnreturnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSigned;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumntoolTransactionReason;
    }
}