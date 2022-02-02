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
    public partial class WatchOldSignatures : Form
    {
        public WatchOldSignatures()
        {
            InitializeComponent();
        }

        private void WatchOldSignatures_Load(object sender, EventArgs e)
        {
            // Getting all signatures
            DataSet dsSignatures = ToolCheckSignature.getSignaturesFromDB();


            if (dsSignatures.Tables.Count > 0)
            {
                dataGridViewOldSigns.DataSource = dsSignatures.Tables["tblSignatures"];
            }
        }
    }
}
