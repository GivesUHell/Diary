namespace Diary
{
    partial class MasterForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newUserToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.LogInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.השאלותToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lendToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchAllTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.כליםToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.מצביומיToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SignatureStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.חתימותToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchOldSignsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.viewMenu,
            this.השאלותToolStripMenuItem,
            this.כליםToolStripMenuItem,
            this.מצביומיToolStripMenuItem,
            this.חתימותToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip.Size = new System.Drawing.Size(1384, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(44, 20);
            this.fileMenu.Text = "&קובץ";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.printToolStripMenuItem.Text = "&הדפסה";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(150, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newUserToolStrip,
            this.LogInToolStripMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(73, 20);
            this.viewMenu.Text = "משתמשים";
            // 
            // newUserToolStrip
            // 
            this.newUserToolStrip.Name = "newUserToolStrip";
            this.newUserToolStrip.Size = new System.Drawing.Size(207, 22);
            this.newUserToolStrip.Text = "משתמש חדש - רק למנהל";
            this.newUserToolStrip.Click += new System.EventHandler(this.newUserToolStrip_Click);
            // 
            // LogInToolStripMenuItem
            // 
            this.LogInToolStripMenuItem.Name = "LogInToolStripMenuItem";
            this.LogInToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.LogInToolStripMenuItem.Text = "התחבר";
            this.LogInToolStripMenuItem.Click += new System.EventHandler(this.LogInToolStripMenuItem_Click);
            // 
            // השאלותToolStripMenuItem
            // 
            this.השאלותToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lendToolToolStripMenuItem,
            this.watchAllTransactionsToolStripMenuItem});
            this.השאלותToolStripMenuItem.Name = "השאלותToolStripMenuItem";
            this.השאלותToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.השאלותToolStripMenuItem.Text = "השאלות";
            // 
            // lendToolToolStripMenuItem
            // 
            this.lendToolToolStripMenuItem.Name = "lendToolToolStripMenuItem";
            this.lendToolToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.lendToolToolStripMenuItem.Text = "השאלת כלי - לא לאורח";
            this.lendToolToolStripMenuItem.Click += new System.EventHandler(this.lendToolToolStripMenuItem_Click);
            // 
            // watchAllTransactionsToolStripMenuItem
            // 
            this.watchAllTransactionsToolStripMenuItem.Name = "watchAllTransactionsToolStripMenuItem";
            this.watchAllTransactionsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.watchAllTransactionsToolStripMenuItem.Text = "צפה בכל ההשאלות";
            this.watchAllTransactionsToolStripMenuItem.Click += new System.EventHandler(this.watchAllTransactionsToolStripMenuItem_Click);
            // 
            // כליםToolStripMenuItem
            // 
            this.כליםToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTableToolStripMenuItem});
            this.כליםToolStripMenuItem.Name = "כליםToolStripMenuItem";
            this.כליםToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.כליםToolStripMenuItem.Text = "כלים";
            // 
            // toolTableToolStripMenuItem
            // 
            this.toolTableToolStripMenuItem.Name = "toolTableToolStripMenuItem";
            this.toolTableToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.toolTableToolStripMenuItem.Text = "טבלת הכלים";
            this.toolTableToolStripMenuItem.Click += new System.EventHandler(this.toolTableToolStripMenuItem_Click);
            // 
            // מצביומיToolStripMenuItem
            // 
            this.מצביומיToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SignatureStatusToolStripMenuItem});
            this.מצביומיToolStripMenuItem.Name = "מצביומיToolStripMenuItem";
            this.מצביומיToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.מצביומיToolStripMenuItem.Text = "מצב יומי";
            // 
            // SignatureStatusToolStripMenuItem
            // 
            this.SignatureStatusToolStripMenuItem.Name = "SignatureStatusToolStripMenuItem";
            this.SignatureStatusToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.SignatureStatusToolStripMenuItem.Text = "מצב חתימות יומי";
            this.SignatureStatusToolStripMenuItem.Click += new System.EventHandler(this.SignatureStatusToolStripMenuItem_Click);
            // 
            // חתימותToolStripMenuItem
            // 
            this.חתימותToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.watchOldSignsToolStripMenuItem});
            this.חתימותToolStripMenuItem.Name = "חתימותToolStripMenuItem";
            this.חתימותToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.חתימותToolStripMenuItem.Text = "חתימות";
            // 
            // watchOldSignsToolStripMenuItem
            // 
            this.watchOldSignsToolStripMenuItem.Name = "watchOldSignsToolStripMenuItem";
            this.watchOldSignsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.watchOldSignsToolStripMenuItem.Text = "צפה בחתימות ישנות";
            this.watchOldSignsToolStripMenuItem.Click += new System.EventHandler(this.watchOldSignsToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 839);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip.Size = new System.Drawing.Size(1384, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "סטטוס";
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 861);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MasterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "המסך הראשי";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MasterForm_FormClosing);
            this.Load += new System.EventHandler(this.MasterForm_Load);
            this.MdiChildActivate += new System.EventHandler(this.MasterForm_MdiChildActivate);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem newUserToolStrip;
        private System.Windows.Forms.ToolStripMenuItem LogInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem השאלותToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem כליםToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem מצביומיToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem חתימותToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lendToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem watchAllTransactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SignatureStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem watchOldSignsToolStripMenuItem;
    }
}



