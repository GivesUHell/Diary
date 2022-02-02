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
    public partial class WatchOldTransactions : Form
    {
        public WatchOldTransactions()
        {
            InitializeComponent();
        }

        private void WatchOldTransactions_Load(object sender, EventArgs e)
        {
            // Getting all signatures
            DataSet dsTransactions = ToolTransaction.getAllTransactions();


            if (dsTransactions.Tables.Count > 0)
            {
                dataGridViewOldTransactions.DataSource = dsTransactions.Tables["tblTransactions"];
            }
        }
    }
}
