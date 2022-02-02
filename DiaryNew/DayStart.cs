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
    public partial class DayStart : Form
    {
        Dictionary<ToolCheckSignature.SignatureType, SignatureWithUserInfo> TodaySign =
            new Dictionary<ToolCheckSignature.SignatureType, SignatureWithUserInfo>();

        struct SignatureWithUserInfo
        {
            public ToolCheckSignature Signature;
            public string userFirstName;
            public string userLastName;
        }

        MasterForm mdiparent;

        public DayStart()
        {
            mdiparent = this.MdiParent as MasterForm;

            InitializeComponent();
        }

        private void DayStart_Load(object sender, EventArgs e)
        {
            // Set the lables of signs
            labelMorning.Text = "08:00";
            lableLaunch.Text = "12:00";
            labelEvening.Text = "17:30";
            labelEndDay.Text = "";



            mdiparent = this.MdiParent as MasterForm;

            SetSignsColors();

            DateLabel.Text = DateTime.Now.ToString();

            if (this.mdiparent != null)
            {
                switch (this.mdiparent.UserLogged.Rank)
                {
                    case UserRank.Admin:
                        {
                            lblUserRank.Text = "מנהל";
                            lblUserRank.ForeColor = Color.Green;
                            break;
                        }
                    case UserRank.Guest:
                        {
                            lblUserRank.Text = "אורח";
                            lblUserRank.ForeColor = Color.Green;
                            break;
                        }
                    case UserRank.Head_Technician:
                        {
                            lblUserRank.Text = "טכנאי ראשי";
                            lblUserRank.ForeColor = Color.Green;
                            break;
                        }
                    case UserRank.Technician:
                        {
                            lblUserRank.Text = "טכנאי";
                            lblUserRank.ForeColor = Color.Green;
                            break;
                        }
                    default:
                        {
                            lblUserRank.Text = "לא ידוע";
                            lblUserRank.ForeColor = Color.Green;
                            break;
                        }
                }
            }
        }


        private void StartDay_Click(object sender, EventArgs e)
        {
            bool SignUp = ShowMessageDialog();

            if (SignUp)
            {
                bool CreateSuccess = ToolCheckSignature.CreateSign(mdiparent.UserLogged, GetCurrentSignature());

                if (CreateSuccess)
                {
                    MessageBox.Show("בדיקת הכלים הוזנה בהצלחה", "מידע",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);

                    SetSignsColors();
                }
                else
                {
                    MessageBox.Show("בדיקת הכלים לא הוזנה, כבר בוצעה בדיקה על ידך או על ידי טכנאי ואתה גם טכנאי", "מידע",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
                }
            }
        }

        #region Helper Functions

        private ToolCheckSignature.SignatureType GetCurrentSignature()
        {
            ToolCheckSignature.SignatureType SignatureResult = ToolCheckSignature.SignatureType.None;

            if (DateTime.Now.Hour < 12)
            {
                if (MorningTechSign.ForeColor == Color.Red && 
                            (MorningHeadTechSign.ForeColor == Color.Green || 
                             MorningHeadTechSign.ForeColor == Color.Red))
                {
                    SignatureResult = ToolCheckSignature.SignatureType.MorningFirst;
                }
                else if (MorningTechSign.ForeColor == Color.Green && MorningHeadTechSign.ForeColor == Color.Red)
                {
                    SignatureResult = ToolCheckSignature.SignatureType.MorningSec;
                }
                
            }
            // Launch
            else if (DateTime.Now.Hour < 17)
            {
                if (LaunchTechSign.ForeColor == Color.Red &&
                            (LaunchHeadTechSign.ForeColor == Color.Green ||
                             LaunchHeadTechSign.ForeColor == Color.Red))
                {
                    SignatureResult = ToolCheckSignature.SignatureType.LaunchFirst;
                }
                else if (LaunchTechSign.ForeColor == Color.Green && LaunchHeadTechSign.ForeColor == Color.Red)
                {
                    SignatureResult = ToolCheckSignature.SignatureType.LaunchSec;
                }

            }
            // Evening
            else if (DateTime.Now.Hour < 18)
            {
                if (EveningTechSign.ForeColor == Color.Red &&
                            (EveningHeadTechSign.ForeColor == Color.Green ||
                             EveningHeadTechSign.ForeColor == Color.Red))
                {
                    SignatureResult = ToolCheckSignature.SignatureType.EveningFirst;
                }
                else if (EveningTechSign.ForeColor == Color.Green && EveningHeadTechSign.ForeColor == Color.Red)
                {
                    SignatureResult = ToolCheckSignature.SignatureType.EveningSec;
                }
            }
            // EndDay
            else if (DateTime.Now.Hour > 18)
            {
                if (DayEndTechSign.ForeColor == Color.Red &&
                            (EndDayHeadTechSign.ForeColor == Color.Green ||
                             EndDayHeadTechSign.ForeColor == Color.Red))
                {
                    SignatureResult = ToolCheckSignature.SignatureType.EndDayFirst;
                }
                else if (DayEndTechSign.ForeColor == Color.Green && EndDayHeadTechSign.ForeColor == Color.Red)
                {
                    SignatureResult = ToolCheckSignature.SignatureType.EndDaySec;
                }
            }

            return (SignatureResult);
        }

        private void SetSignsColors()
        {

            MorningTechSign.ForeColor = Color.Red;
            LaunchTechSign.ForeColor = Color.Red;
            EveningTechSign.ForeColor = Color.Red;
            DayEndTechSign.ForeColor = Color.Red;
            MorningHeadTechSign.ForeColor = Color.Red;
            LaunchHeadTechSign.ForeColor = Color.Red;
            EveningHeadTechSign.ForeColor = Color.Red;
            EndDayHeadTechSign.ForeColor = Color.Red;

            ToolCheckSignature.SignatureType currentSignType = ToolCheckSignature.SignatureType.None;
            DataSet Signatures = ToolCheckSignature.GetSignatureCreatorsByDate();

            // TODO: Set Colors with db

            if (Signatures != null)
            {
                // Setting green techs
                foreach (DataRow drCurrentRow in Signatures.Tables["tblCreators"].Rows)
                {
                    currentSignType = (ToolCheckSignature.SignatureType)Convert.ToInt32(drCurrentRow["signatureType"]);

                    // Adding signature to dictionary
                    ToolCheckSignature currentSignature = new ToolCheckSignature();
                    currentSignature.SignDate = DateTime.Now;
                    currentSignature.SignatureCreator = drCurrentRow["armySerial"].ToString();
                    currentSignature.SignType = currentSignType;
                    string firstName = drCurrentRow["firstName"].ToString();
                    string lastName = drCurrentRow["lastName"].ToString();

                    SignatureWithUserInfo newSignWithInfo;

                    newSignWithInfo.Signature = currentSignature;
                    newSignWithInfo.userFirstName = firstName;
                    newSignWithInfo.userLastName = lastName;

                    if (!TodaySign.ContainsKey(currentSignType))
                    {
                        TodaySign.Add(currentSignType, newSignWithInfo);
                    }


                    switch (currentSignType)
                    {
                        case ToolCheckSignature.SignatureType.MorningFirst:
                            {
                                MorningTechSign.ForeColor = Color.Green;
                                break;
                            }
                        case ToolCheckSignature.SignatureType.MorningSec:
                            {
                                MorningHeadTechSign.ForeColor = Color.Green;
                                break;
                            }
                        case ToolCheckSignature.SignatureType.LaunchFirst:
                            {
                                LaunchTechSign.ForeColor = Color.Green;
                                break;
                            }
                        case ToolCheckSignature.SignatureType.LaunchSec:
                            {
                                LaunchHeadTechSign.ForeColor = Color.Green;
                                break;
                            }
                        case ToolCheckSignature.SignatureType.EveningFirst:
                            {
                                EveningTechSign.ForeColor = Color.Green;
                                break;
                            }
                        case ToolCheckSignature.SignatureType.EveningSec:
                            {
                                EveningHeadTechSign.ForeColor = Color.Green;
                                break;
                            }
                        case ToolCheckSignature.SignatureType.EndDayFirst:
                            {
                                DayEndTechSign.ForeColor = Color.Green;
                                break;
                            }
                        case ToolCheckSignature.SignatureType.EndDaySec:
                            {
                                EndDayHeadTechSign.ForeColor = Color.Green;
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }

        private bool ShowMessageDialog()
        {
            if (mdiparent.UserLogged.Rank == UserRank.Guest)
            {
                MessageBox.Show("אורח לא יכול לחתום", "אזהרה",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
            }
            else
            {
                DialogResult res = new DialogResult();

                // Morning
                if (DateTime.Now.Hour < 11)
                {
                    if (MorningTechSign.ForeColor == Color.Green && MorningHeadTechSign.ForeColor == Color.Green)
                    {
                        MessageBox.Show("כבר בוצעה חתימת בוקר, לאחר 11:00 תוכל לחתום צהריים", "מידע",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);

                    }
                    else
                    {
                        res = MessageBox.Show("האם תרצה לבצע חתימת בוקר?", "האם אתה בטוח?",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question,
                                              MessageBoxDefaultButton.Button1,
                                              MessageBoxOptions.RtlReading);
                    }
                }
                // Launch
                else if (DateTime.Now.Hour < 16)
                {
                    if (LaunchTechSign.ForeColor == Color.Green && LaunchHeadTechSign.ForeColor == Color.Green)
                    {
                        MessageBox.Show("כבר בוצעה חתימת צהריים, לאחר 16:00 תוכל לחתום ערב", "מידע",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);

                    }
                    else
                    {
                        res = MessageBox.Show("האם תרצה לבצע חתימת צהריים?",
                                              "האם אתה בטוח?",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question,
                                              MessageBoxDefaultButton.Button1,
                                              MessageBoxOptions.RtlReading);
                    }
                }
                // Evening
                else if (DateTime.Now.Hour < 18)
                {
                    if (EveningTechSign.ForeColor == Color.Green && EveningHeadTechSign.ForeColor == Color.Green)
                    {
                        MessageBox.Show("כבר בוצעה חתימת צהריים, לאחר 18:00 תוכל לחתום סוף יום", "מידע",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);

                    }
                    else
                    {
                        res = MessageBox.Show("האם תרצה לבצע חתימת ערב?",
                                              "האם אתה בטוח?",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question,
                                              MessageBoxDefaultButton.Button1,
                                              MessageBoxOptions.RtlReading);
                    }
                }
                // EndDay
                else if (DateTime.Now.Hour > 18)
                {
                    if (DayEndTechSign.ForeColor == Color.Green && EndDayHeadTechSign.ForeColor == Color.Green)
                    {
                        MessageBox.Show("כבר בוצעה חתימת סוף יום", "מידע",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);

                    }
                    else
                    {
                        res = MessageBox.Show("האם תרצה לבצע חתימת סוף יום?",
                                              "האם אתה בטוח?",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question,
                                              MessageBoxDefaultButton.Button1,
                                              MessageBoxOptions.RtlReading);
                    }
                }

                if (res == DialogResult.Yes)
                {
                    return (true);
                }
            }

            return (false);
        }

        #endregion

        #region TextClick

        /* CLICK ON SIGNS AND GET THE ONE WHO SIGNED IT */

        private void LaunchTechSign_Click(object sender, EventArgs e)
        {
            // TODO: GET USER BY SIGN TYPE AND DATE

            if (LaunchTechSign.ForeColor == Color.Red)
            {
                MessageBox.Show("עדיין לא נחתם", "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
            }
            else
            {
                SignatureWithUserInfo daySignature;

                if (TodaySign.TryGetValue(ToolCheckSignature.SignatureType.LaunchFirst, out daySignature))
                {
                    string signedBy = " נחתם על ידי " + daySignature.userFirstName + " " + daySignature.userLastName;

                    MessageBox.Show(signedBy, "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
                }
            }
        }

        private void EveningTechSign_Click(object sender, EventArgs e)
        {
            if (EveningTechSign.ForeColor == Color.Red)
            {
                MessageBox.Show("עדיין לא נחתם", "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
            }
            else
            {
                SignatureWithUserInfo daySignature;

                if (TodaySign.TryGetValue(ToolCheckSignature.SignatureType.EveningFirst, out daySignature))
                {
                    string signedBy = " נחתם על ידי " + daySignature.userFirstName + " " + daySignature.userLastName;

                    MessageBox.Show(signedBy, "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
                }
            }
        }

        private void DayEndTechSign_Click(object sender, EventArgs e)
        {
            if (DayEndTechSign.ForeColor == Color.Red)
            {
                MessageBox.Show("עדיין לא נחתם", "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
            }
            else
            {
                SignatureWithUserInfo daySignature;

                if (TodaySign.TryGetValue(ToolCheckSignature.SignatureType.EndDayFirst, out daySignature))
                {
                    string signedBy = " נחתם על ידי " + daySignature.userFirstName + " " + daySignature.userLastName;

                    MessageBox.Show(signedBy, "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
                }
            }
        }

        private void MorningTechSign_Click(object sender, EventArgs e)
        {
            if (MorningTechSign.ForeColor == Color.Red)
            {
                MessageBox.Show("עדיין לא נחתם", "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
            }
            else
            {
                SignatureWithUserInfo daySignature;

                if (TodaySign.TryGetValue(ToolCheckSignature.SignatureType.MorningFirst, out daySignature))
                {
                    string signedBy = " נחתם על ידי " + daySignature.userFirstName + " " + daySignature.userLastName;

                    MessageBox.Show(signedBy, "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
                }
            }
        }

        private void MorningHeadTechSign_Click(object sender, EventArgs e)
        {
            if (MorningHeadTechSign.ForeColor == Color.Red)
            {
                MessageBox.Show("עדיין לא נחתם", "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
            }
            else
            {
                SignatureWithUserInfo daySignature;

                if (TodaySign.TryGetValue(ToolCheckSignature.SignatureType.MorningSec, out daySignature))
                {
                    string signedBy = " נחתם על ידי " + daySignature.userFirstName + " " + daySignature.userLastName;

                    MessageBox.Show(signedBy, "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
                }
            }
        }

        private void LaunchHeadTechSign_Click(object sender, EventArgs e)
        {
            if (LaunchHeadTechSign.ForeColor == Color.Red)
            {
                MessageBox.Show("עדיין לא נחתם", "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
            }
            else
            {
                SignatureWithUserInfo daySignature;

                if (TodaySign.TryGetValue(ToolCheckSignature.SignatureType.LaunchSec, out daySignature))
                {
                    string signedBy = " נחתם על ידי " + daySignature.userFirstName + " " + daySignature.userLastName;

                    MessageBox.Show(signedBy, "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
                }
            }
        }

        private void EveningHeadTechSign_Click(object sender, EventArgs e)
        {
            if (EveningHeadTechSign.ForeColor == Color.Red)
            {
                MessageBox.Show("עדיין לא נחתם", "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
            }
            else
            {
                SignatureWithUserInfo daySignature;

                if (TodaySign.TryGetValue(ToolCheckSignature.SignatureType.EveningSec, out daySignature))
                {
                    string signedBy = " נחתם על ידי " + daySignature.userFirstName + " " + daySignature.userLastName;

                    MessageBox.Show(signedBy, "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
                }
            }
        }

        private void EndDayHeadTechSign_Click(object sender, EventArgs e)
        {
            if (EndDayHeadTechSign.ForeColor == Color.Red)
            {
                MessageBox.Show("עדיין לא נחתם", "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
            }
            else
            {
                SignatureWithUserInfo daySignature;

                if (TodaySign.TryGetValue(ToolCheckSignature.SignatureType.EndDaySec, out daySignature))
                {
                    string signedBy = " נחתם על ידי " + daySignature.userFirstName + " " + daySignature.userLastName;

                    MessageBox.Show(signedBy, "מידע",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1,
                             MessageBoxOptions.RtlReading);
                }
            }
        }

        #endregion
    }
}
