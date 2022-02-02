using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diary.Basic_Classes;

namespace Diary
{
    public partial class MasterForm : Form
    {
        private int childFormNumber = 0;
        private User userLogged;

        internal User UserLogged
        {
            get { return userLogged; }
            set { userLogged = value; }
        }
       

        public MasterForm()
        {
            userLogged = new User();

            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
            childFormNumber--;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
                childFormNumber--;
            }
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            ToolWindow childForm = new ToolWindow();
            childForm.MdiParent = this;
            childFormNumber++;
            childForm.Show();
            childFormNumber--;
        }

        private void MasterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void MasterForm_MdiChildActivate(object sender, EventArgs e)
        {
            // When there are no forms
            if (this.ActiveMdiChild == null)
            {
                DayStart childForm = new DayStart();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
            }
        }

        private void newUserToolStrip_Click(object sender, EventArgs e)
        {
            if (userLogged.Rank == UserRank.Admin)
            {
                AddingUsers childForm = new AddingUsers();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
                childFormNumber--;
            }
        }

      

        private void LogInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginPage childForm = new LoginPage();
            childForm.MdiParent = this;
            childFormNumber++;
            childForm.Show();
            childFormNumber--;
        }

        private void lendToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userLogged.Rank != UserRank.Guest)
            {
                ChooseTool childForm = new ChooseTool();
                childForm.MdiParent = this;
                childFormNumber++;
                childForm.Show();
                childFormNumber--;
            }
        }

        private void toolTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolWindow childForm = new ToolWindow();
            childForm.MdiParent = this;
            childFormNumber++;
            childForm.Show();
            childFormNumber--;
        }

        private void SignatureStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DayStart childForm = new DayStart();
            childForm.MdiParent = this;
            childFormNumber++;
            childForm.Show();
            childFormNumber--;
        }

        private void watchOldSignsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WatchOldSignatures childForm = new WatchOldSignatures();
            childForm.MdiParent = this;
            childFormNumber++;
            childForm.Show();
            childFormNumber--;
        }

        private void watchAllTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WatchOldTransactions childForm = new WatchOldTransactions();
            childForm.MdiParent = this;
            childFormNumber++;
            childForm.Show();
            childFormNumber--;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}
