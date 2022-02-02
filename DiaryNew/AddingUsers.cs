using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

using System.Windows;
using Diary.Basic_Classes;

namespace Diary
{
    public partial class AddingUsers : Form
    {
        public AddingUsers()
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            UserRank currentRank;
            Enum.TryParse<UserRank>(RankBox.SelectedValue.ToString(), out currentRank);
            string userName = TextBoxUserName.Text;
            string password = TextBoxPassword.Text;
            string armySerial = txtBoxArmySerial.Text;
            string firstName = txtBoxFirstName.Text;
            string lastName = txtBoxLastName.Text;

            //// Data to protect. Convert a string to a byte[] using Encoding.UTF8.GetBytes().
            //byte[] plaintext = new byte[password.Length * sizeof(char)];
            //System.Buffer.BlockCopy(password.ToCharArray(), 0, plaintext, 0, plaintext.Length);


            //// Generate additional entropy (will be used as the Initialization vector)
            //byte[] entropy = new byte[20];
            //using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            //{
            //    rng.GetBytes(entropy);
            //}

            //byte[] ciphertext = ProtectedData.Protect(plaintext, entropy,
            //    DataProtectionScope.CurrentUser);

            //string filePath = System.IO.Directory.GetCurrentDirectory() + "\\ConfigFiles\\Users.txt";

            ////File.Open(filePath, FileMode.Append, FileAccess.Write);

            //using (StreamWriter usersFile = File.AppendText(filePath))
            //{
            //    usersFile.WriteLine(userName + '=' + Encoding.UTF8.GetString(ciphertext));
            //    usersFile.WriteLine(userName + "Rank=" + Encoding.UTF8.GetString(ciphertext2));
            //}

            //addNewUser(userName, Encoding.UTF8.GetString(ciphertext), (int)currentRank);

            if (User.addNewUser(userName, password, (int)currentRank, armySerial, firstName, lastName))
            {
                MessageBox.Show("המשתמש הוסף בהצלחה", "מידע",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);

                this.Close();
            }
            else
            {
                MessageBox.Show("המשתמש לא נוסף", "מידע",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RtlReading);
            }

        }

        

        private void AddingUsers_Load(object sender, EventArgs e)
        {
            RankBox.DataSource = Enum.GetValues(typeof(UserRank));

            RankBox.SelectedItem = RankBox.Items[0];
        }
    }
}
