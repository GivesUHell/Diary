namespace Diary
{
    partial class ChooseTool
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
            this.ddlChooseTool = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlChooseAction = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtboxReason = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtboxPlace = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ddlChooseTool
            // 
            this.ddlChooseTool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlChooseTool.FormattingEnabled = true;
            this.ddlChooseTool.Location = new System.Drawing.Point(291, 86);
            this.ddlChooseTool.Name = "ddlChooseTool";
            this.ddlChooseTool.Size = new System.Drawing.Size(144, 21);
            this.ddlChooseTool.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(494, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "חפש";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "בחר כלי";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(292, 38);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(143, 20);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "בחר פעולה";
            // 
            // ddlChooseAction
            // 
            this.ddlChooseAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlChooseAction.FormattingEnabled = true;
            this.ddlChooseAction.Location = new System.Drawing.Point(292, 131);
            this.ddlChooseAction.Name = "ddlChooseAction";
            this.ddlChooseAction.Size = new System.Drawing.Size(143, 21);
            this.ddlChooseAction.TabIndex = 5;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(360, 229);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "השאל";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "סיבת השאלה";
            // 
            // txtboxReason
            // 
            this.txtboxReason.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtboxReason.Location = new System.Drawing.Point(24, 54);
            this.txtboxReason.Multiline = true;
            this.txtboxReason.Name = "txtboxReason";
            this.txtboxReason.Size = new System.Drawing.Size(197, 114);
            this.txtboxReason.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(481, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "נלקח ל";
            // 
            // txtboxPlace
            // 
            this.txtboxPlace.Location = new System.Drawing.Point(292, 177);
            this.txtboxPlace.Name = "txtboxPlace";
            this.txtboxPlace.Size = new System.Drawing.Size(143, 20);
            this.txtboxPlace.TabIndex = 10;
            // 
            // ChooseTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 292);
            this.Controls.Add(this.txtboxPlace);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtboxReason);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.ddlChooseAction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlChooseTool);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChooseTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "בחירת כלי";
            this.Load += new System.EventHandler(this.ChooseTool_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlChooseTool;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox ddlChooseAction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtboxReason;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtboxPlace;
    }
}