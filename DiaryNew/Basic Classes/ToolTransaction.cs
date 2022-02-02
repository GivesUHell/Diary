using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Diary.Basic_Classes
{
    class ToolTransaction
    {
        private static OleDbConnection myConnection;

        private int _ironNumber;
        private string _toolName;
        private string _transactionCreator;
        private DateTime _timeLendStart;
        private DateTime _timeLendFinished;
        private string _signature;
        private string _lendReason;
        private string _toolReturner;
        private string _toolPlace;

        public string ToolReturner
        {
            get { return _toolReturner; }
            set { _toolReturner = value; }
        }

        public string ToolPlace
        {
            get { return _toolPlace; }
            set { _toolPlace = value; }
        }

        public int IronNumber
        {
            get { return _ironNumber; }
            set { _ironNumber = value; }
        }

        public string ToolName
        {
            get { return _toolName; }
            set { _toolName = value; }
        }

        public string TransactionCreator
        {
            get { return _transactionCreator; }
            set { _transactionCreator = value; }
        }

        public DateTime TimeLendStart
        {
            get { return _timeLendStart; }
            set { _timeLendStart = value; }
        }

        public DateTime TimeLendFinished
        {
            get { return _timeLendFinished; }
            set { _timeLendFinished = value; }
        }

        public string Signature
        {
            get { return _signature; }
            set { _signature = value; }
        }

        public string LendReason
        {
            get { return _lendReason; }
            set { _lendReason = value; }
        }


        internal static System.Data.DataSet getAllTransactions()
        {
            string connectionString = Connect.getConnectionString();
            myConnection = new OleDbConnection(connectionString);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();

            try
            {
                myConnection.Open();

                OleDbCommand mycmd = new OleDbCommand("spGetAllTransactions", myConnection);
                mycmd.CommandType = CommandType.StoredProcedure;

                myDataAdapter.SelectCommand = mycmd;
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds, "tblTransactions");
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

        internal static bool addTransaction(string toolSerial, string toolName, string toolPlace, string transactionReason, User transactionCreator)
        {
            string connectionString = Connect.getConnectionString();
            myConnection = new OleDbConnection(connectionString);

            OleDbCommand mycmd = new OleDbCommand("spInsertTransaction", myConnection);
            mycmd.CommandType = CommandType.StoredProcedure;
            OleDbParameter objpar;
            objpar = mycmd.Parameters.Add("@toolSerial", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = toolSerial;
            objpar = mycmd.Parameters.Add("@toolName", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = toolName;
            objpar = mycmd.Parameters.Add("@toolPlace", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = toolPlace;
            objpar = mycmd.Parameters.Add("@toolTransactionReason", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = transactionReason;
            objpar = mycmd.Parameters.Add("@transactionCreator", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = transactionCreator.UserName;
            objpar = mycmd.Parameters.Add("@toolReturner", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = DBNull.Value;
            objpar = mycmd.Parameters.Add("@takingTime", OleDbType.Date);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = DateTime.Now;
            objpar = mycmd.Parameters.Add("@returnTime", OleDbType.Date);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = DBNull.Value;
            objpar = mycmd.Parameters.Add("@Signed", OleDbType.Boolean);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = false;

            try
            {
                myConnection.Open();
                mycmd.ExecuteNonQuery();
                return (true);
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

        internal static bool updateTransaction(User user, ToolTransaction tTransaction)
        {
            string connectionString = Connect.getConnectionString();
            myConnection = new OleDbConnection(connectionString);

            OleDbCommand mycmd = new OleDbCommand("spUpdateTransaction", myConnection);
            mycmd.CommandType = CommandType.StoredProcedure;
            OleDbParameter objpar;
            objpar = mycmd.Parameters.Add("@toolReturner", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = user.UserName;
            objpar = mycmd.Parameters.Add("@returnTime", OleDbType.Date);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = tTransaction.TimeLendFinished;
            objpar = mycmd.Parameters.Add("@Signed", OleDbType.Boolean);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = false;
            objpar = mycmd.Parameters.Add("@toolSerial", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = tTransaction.IronNumber;

            try
            {
                myConnection.Open();
                mycmd.ExecuteNonQuery();
                return (true);
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
