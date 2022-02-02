namespace Diary
{
    partial class ToolWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolsGridView = new System.Windows.Forms.DataGridView();
            this.toolSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.takingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ToolsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolsGridView
            // 
            this.ToolsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ToolsGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ToolsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.ToolsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ToolsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.toolSerial,
            this.toolName,
            this.toolStatus,
            this.takingTime});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ToolsGridView.DefaultCellStyle = dataGridViewCellStyle11;
            this.ToolsGridView.Location = new System.Drawing.Point(12, 41);
            this.ToolsGridView.Name = "ToolsGridView";
            this.ToolsGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ToolsGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.ToolsGridView.Size = new System.Drawing.Size(620, 374);
            this.ToolsGridView.TabIndex = 0;
            this.ToolsGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ToolsGridView_CellContentDoubleClick);
            this.ToolsGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.ToolsGridView_CellPainting_1);
            // 
            // toolSerial
            // 
            this.toolSerial.DataPropertyName = "toolSerial";
            this.toolSerial.HeaderText = "מספר ברזל";
            this.toolSerial.Name = "toolSerial";
            this.toolSerial.ReadOnly = true;
            // 
            // toolName
            // 
            this.toolName.DataPropertyName = "toolName";
            this.toolName.HeaderText = "שם הכלי";
            this.toolName.Name = "toolName";
            this.toolName.ReadOnly = true;
            // 
            // toolStatus
            // 
            this.toolStatus.DataPropertyName = "toolStatus";
            this.toolStatus.HeaderText = "סטטוס";
            this.toolStatus.Name = "toolStatus";
            this.toolStatus.ReadOnly = true;
            // 
            // takingTime
            // 
            this.takingTime.DataPropertyName = "takingTime";
            this.takingTime.HeaderText = "תאריך השאלה";
            this.takingTime.Name = "takingTime";
            this.takingTime.ReadOnly = true;
            // 
            // DateLabel
            // 
            this.DateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLabel.Location = new System.Drawing.Point(276, 9);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(79, 20);
            this.DateLabel.TabIndex = 1;
            this.DateLabel.Text = "- תאריך -";
            // 
            // ToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 427);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.ToolsGridView);
            this.Name = "ToolWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "עמוד כלים";
            this.Load += new System.EventHandler(this.ToolWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ToolsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ToolsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn toolSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn toolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn toolStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn takingTime;
        private System.Windows.Forms.Label DateLabel;
    }
}