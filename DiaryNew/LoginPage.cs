using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Diary.Basic_Classes;
using System.Configuration;
using System.Security.Cryptography;
using System.Data.OleDb;

namespace Diary
{
    public partial class LoginPage : Form
    {
        // Users Hashtable
        Dictionary<string, User> AllUsers = new Dictionary<string, User>();
        private OleDbConnection myConnection;
        public UserRank userRank;
        public string userName;
        public string firstName;
        public string lastName;
        public string armySerial;

        enum CheckResult
        {
            BadPassword,
            BadUserName,
            Success
        }

        public LoginPage()
        {
            string connectionString = Connect.getConnectionString();
            myConnection = new OleDbConnection(connectionString);
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //// Data to protect. Convert a string to a byte[] using Encoding.UTF8.GetBytes().
            //byte[] plaintext = new byte[PasswordTextBox.Text.Length * sizeof(char)];
            //System.Buffer.BlockCopy(PasswordTextBox.Text.ToCharArray(), 0, plaintext, 0, plaintext.Length);

            //// Generate additional entropy (will be used as the Initialization vector)
            //byte[] entropy = new byte[20];
            //using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            //{
            //    rng.GetBytes(entropy);
            //}

            //byte[] ciphertext = ProtectedData.Protect(plaintext, entropy,
            //    DataProtectionScope.CurrentUser);

            switch (checkUser(txtUserName.Text, PasswordTextBox.Text))
            {
                case CheckResult.Success:
                    {
                        userName = txtUserName.Text;
                        User CurrentUser = AllUsers[txtUserName.Text];
                        userRank = CurrentUser.Rank;
                        firstName = CurrentUser.UserFirstName;
                        lastName = CurrentUser.UserLastName;
                        armySerial = CurrentUser.UserArmySerial;
                        this.Close();
                        break;
                    }
                case CheckResult.BadPassword:
                    {
                        lblResult.Text = "סיסמא לא נכונה";
                        lblResult.ForeColor = Color.Red;
                        break;
                    }
                case CheckResult.BadUserName:
                    {
                        lblResult.Text = "שם משתמש שגוי";
                        lblResult.ForeColor = Color.Red;
                        break;
                    }
                default:
                    {
                        lblResult.Text = "תקלה לא ידועה";
                        lblResult.ForeColor = Color.Red;
                        break;
                    }
            }

            lblResult.Visible = true;
        }

        private CheckResult checkUser(string userName, string userPass)
        {
            try
            {
               DataSet ds = User.getUser(userName);

                if (ds.Tables["tblUsers"].Rows.Count > 0 && ds.Tables["tblUsers"].Rows.Count < 2)
                {
                    if (ds.Tables["tblUsers"].Rows[0]["userPass"].ToString() == userPass)
                    {
                        return CheckResult.Success;
                    }

                    return CheckResult.BadPassword;
                }

                return CheckResult.BadUserName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConnection.Close();
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            DataSet dsUsers = User.getAllUsers();

            foreach (DataRow dtUserRow in dsUsers.Tables["tblUsers"].Rows)
            {
                User newUser = new User();
                newUser.UserName = dtUserRow["userName"].ToString();
                newUser.Rank = (UserRank)Enum.Parse(typeof(UserRank), dtUserRow["userRank"].ToString());
                newUser.UserArmySerial = dtUserRow["armySerial"].ToString();
                newUser.UserFirstName = dtUserRow["firstName"].ToString();
                newUser.UserLastName = dtUserRow["lastName"].ToString();
                AllUsers.Add(dtUserRow["userName"].ToString(), newUser);
            }
        }

       

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            MasterForm myParent = MdiParent as MasterForm;

            myParent.UserLogged.UserName = this.userName;
            myParent.UserLogged.Rank= this.userRank;
            myParent.UserLogged.UserFirstName = this.firstName;
            myParent.UserLogged.UserLastName = this.lastName;
            myParent.UserLogged.UserArmySerial = this.armySerial;
        }
    }
}
