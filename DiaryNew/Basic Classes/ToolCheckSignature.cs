using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Diary.Basic_Classes
{
    class ToolCheckSignature
    {
        private static OleDbConnection myConnection;

        public enum SignatureType
        {
            MorningFirst = 1,
            MorningSec,
            LaunchFirst,
            LaunchSec,
            EveningFirst,
            EveningSec,
            EndDayFirst,
            EndDaySec,
            None
        };

        string signatureCreator;
        private SignatureType signType;
        private DateTime signDate;

        public DateTime SignDate
        {
            get { return signDate; }
            set { signDate = value; }
        }

        public string SignatureCreator
        {
            get { return signatureCreator; }
            set { signatureCreator = value; }
        }

        public SignatureType SignType
        {
            get { return signType; }
            set { signType = value; }
        }

        public static DataSet getSignaturesFromDB()
        {
            string connectionString = Connect.getConnectionString();
            myConnection = new OleDbConnection(connectionString);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();

            try
            {
                myConnection.Open();

                OleDbCommand mycmd = new OleDbCommand("spGetAllSignatures", myConnection);
                mycmd.CommandType = CommandType.StoredProcedure;

                myDataAdapter.SelectCommand = mycmd;
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds, "tblSignatures");
                return ds;
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

        internal static bool CreateSign(User user, SignatureType signatureType)
        {
            bool CreateSucceed = true;
            string connectionString = Connect.getConnectionString();
            myConnection = new OleDbConnection(connectionString);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();

            // Check Adding sign (checking if another user on the same level signed)
            // TODO: if someone high level signs and than low level - it will work. is it ok?

            if ((Convert.ToInt32(signatureType) % 2) == 0)
            {
                DataSet todaySigns = GetSignatureCreatorsByDate();

                foreach (DataRow drCurrent in todaySigns.Tables["tblCreators"].Rows)
                {
                    // Checking the rank of the man who sign before
                    if (Convert.ToInt32(drCurrent["signatureType"]) == (Convert.ToInt32(signatureType) - 1))
                    {
                        // If the this sign has already been made
                        if (((user.Rank == (UserRank)Convert.ToInt32(drCurrent["userRank"])) && (user.Rank == UserRank.Technician)) ||
                            user.UserArmySerial == drCurrent["armySerial"].ToString())
                        {
                            CreateSucceed = false;
                        }
                    }
                }
            }

            if (CreateSucceed)
            {
                OleDbCommand mycmd = new OleDbCommand("spInsertSignature", myConnection);
                mycmd.CommandType = CommandType.StoredProcedure;
                OleDbParameter objpar;
                objpar = mycmd.Parameters.Add("@armySerial", OleDbType.BSTR);
                objpar.Direction = ParameterDirection.Input;
                objpar.Value = user.UserArmySerial;
                objpar = mycmd.Parameters.Add("@signatureType", OleDbType.Integer);
                objpar.Direction = ParameterDirection.Input;
                objpar.Value = signatureType;
                objpar = mycmd.Parameters.Add("@signatureDate", OleDbType.Date);
                objpar.Direction = ParameterDirection.Input;
                objpar.Value = DateTime.Now;

                try
                {
                    myConnection.Open();
                    mycmd.ExecuteNonQuery();

                    return (CreateSucceed);
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

            return (false);
        }

        internal static DataSet GetSignatureCreatorsByDate()
        {
            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            string connectionString = Connect.getConnectionString();
            myConnection = new OleDbConnection(connectionString);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();

            OleDbCommand mycmd = new OleDbCommand("spGetSignatureCreatorsByDate", myConnection);
            mycmd.CommandType = CommandType.StoredProcedure;
            OleDbParameter objpar;
            objpar = mycmd.Parameters.Add("@signatureDate", OleDbType.Date);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = today;

            try
            {
                myConnection.Open();

                myDataAdapter.SelectCommand = mycmd;
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds, "tblCreators");

                if (ds.Tables["tblCreators"].Rows.Count != 0)
                {
                    return ds;
                }

                return null;
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
    }
}
