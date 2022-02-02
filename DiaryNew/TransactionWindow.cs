using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diary
{
    public partial class TransactionWindow : Form
    {
        MasterForm mdiparent;
        Diary.Basic_Classes.ToolTransaction tTransaction;
        private int _ironNumber;
        private string _toolName;
        private DateTime _timeLendStart;
        private Diary.Basic_Classes.TechTools.ToolStatusEnum _status;

        public TransactionWindow(Diary.Basic_Classes.TechTools newTool)
        {
            _ironNumber    = newTool.ToolSerial;
            _toolName      = newTool.ToolName;
            _timeLendStart = newTool.TakingTime;
            _status        = newTool.ToolStatus;

            InitializeComponent();
        }

        private void TransactionWindow_Load(object sender, EventArgs e)
        {
            if (_timeLendStart != new DateTime())
            {
                tTransaction = Diary.Basic_Classes.TechTools.getTransaction(_ironNumber, _timeLendStart);

                // Setting text to boxes
                txtBoxLender.Text = tTransaction.TransactionCreator;
                txtBoxLendReason.Text = tTransaction.LendReason;
                txtBoxSignature.Text = tTransaction.Signature;
                txtboxPlace.Text = tTransaction.ToolPlace;
                txtboxReturner.Text = tTransaction.ToolReturner;

                if (tTransaction.TimeLendFinished != new DateTime())
                    txtBoxTransactionEnd.Text = tTransaction.TimeLendFinished.ToString();

                txtBoxTransactionStart.Text = tTransaction.TimeLendStart.ToString(); 
            }

            txtboxIronNumber.Text = _ironNumber.ToString();
            txtBoxToolName.Text = _toolName;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            mdiparent = this.MdiParent as MasterForm;

            if (tTransaction == null)
            {
                MessageBox.Show("מה אתה מנסה לעבוד עליי זה לא הושאל בכלל", "מידע",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RtlReading);
            }
            else if (mdiparent.UserLogged.Rank != Basic_Classes.UserRank.Guest)
            {
                bool Success;


                Success = Diary.Basic_Classes.TechTools.UpdateToolStatus(tTransaction.IronNumber.ToString(), "זמין", true);
                Success = Diary.Basic_Classes.ToolTransaction.updateTransaction(mdiparent.UserLogged, tTransaction);

                if (Success)
                {

                    MessageBox.Show("הכלי הוחזר בהצלחה", "מידע",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);

                    this.Close();


                }
                else
                {
                    MessageBox.Show("הכלי לא הוחזר בהצלחה", "מידע",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                }
            }
            else
            {
                MessageBox.Show("אין לך מספיק הרשאות להחזיר כלי", "מידע",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RtlReading);
            }
        }
    }
}
