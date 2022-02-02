namespace Diary
{
    partial class WatchOldSignatures
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
            this.dataGridViewOldSigns = new System.Windows.Forms.DataGridView();
            this.ColumnfirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnlastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnarmySerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnsignatureDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnsignatureType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOldSigns)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOldSigns
            // 
            this.dataGridViewOldSigns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOldSigns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOldSigns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnfirstName,
            this.ColumnlastName,
            this.ColumnarmySerial,
            this.ColumnsignatureDate,
            this.ColumnsignatureType});
            this.dataGridViewOldSigns.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewOldSigns.Name = "dataGridViewOldSigns";
            this.dataGridViewOldSigns.ReadOnly = true;
            this.dataGridViewOldSigns.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewOldSigns.Size = new System.Drawing.Size(632, 390);
            this.dataGridViewOldSigns.TabIndex = 0;
            // 
            // ColumnfirstName
            // 
            this.ColumnfirstName.DataPropertyName = "firstName";
            this.ColumnfirstName.HeaderText = "שם פרטי חותם";
            this.ColumnfirstName.Name = "ColumnfirstName";
            this.ColumnfirstName.ReadOnly = true;
            this.ColumnfirstName.Width = 110;
            // 
            // ColumnlastName
            // 
            this.ColumnlastName.DataPropertyName = "lastName";
            this.ColumnlastName.HeaderText = "שם משפחה חותם";
            this.ColumnlastName.Name = "ColumnlastName";
            this.ColumnlastName.ReadOnly = true;
            this.ColumnlastName.Width = 110;
            // 
            // ColumnarmySerial
            // 
            this.ColumnarmySerial.DataPropertyName = "armySerial";
            this.ColumnarmySerial.HeaderText = "מספר אישי";
            this.ColumnarmySerial.Name = "ColumnarmySerial";
            this.ColumnarmySerial.ReadOnly = true;
            // 
            // ColumnsignatureDate
            // 
            this.ColumnsignatureDate.DataPropertyName = "signatureDate";
            this.ColumnsignatureDate.HeaderText = "תאריך חתימה";
            this.ColumnsignatureDate.Name = "ColumnsignatureDate";
            this.ColumnsignatureDate.ReadOnly = true;
            this.ColumnsignatureDate.Width = 145;
            // 
            // ColumnsignatureType
            // 
            this.ColumnsignatureType.DataPropertyName = "signatureType";
            this.ColumnsignatureType.HeaderText = "סוג חתימה";
            this.ColumnsignatureType.Name = "ColumnsignatureType";
            this.ColumnsignatureType.ReadOnly = true;
            this.ColumnsignatureType.Width = 120;
            // 
            // WatchOldSignatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 414);
            this.Controls.Add(this.dataGridViewOldSigns);
            this.Name = "WatchOldSignatures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "צפה בחתימות ישנות";
            this.Load += new System.EventHandler(this.WatchOldSignatures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOldSigns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOldSigns;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnfirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnlastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnarmySerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnsignatureDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnsignatureType;
    }
}