using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Diary.Basic_Classes
{
    public class TechTools
    {
        private static OleDbConnection myConnection;

        public enum ToolStatusEnum
        {
            Available,
            TakenTemporarly,
            TakenPermanently
        }

        public TechTools() 
        {
        }

        // Class Elements

        // The tool name (in order to know what type of tool we're dealing with)
        private string _toolName;
        private ToolStatusEnum _toolStatus;
        private int _toolSerial;
        private DateTime _takingTime;

        public ToolStatusEnum ToolStatus
        {
            get { return _toolStatus; }
            set { _toolStatus = value; }
        }

        public int ToolSerial
        {
            get { return _toolSerial; }
            set { _toolSerial = value; }
        }

        public DateTime TakingTime
        {
            get { return _takingTime; }
            set { _takingTime = value; }
        }

        // Properties

        public string ToolName
        {
            get
            { 
                return this._toolName; 
            }
            
            set
            {
                this._toolName = value;
            }
        }

        public static DataSet getToolsFromDB()
        {
            string connectionString = Connect.getConnectionString();
            myConnection = new OleDbConnection(connectionString);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();

            try
            {
                myConnection.Open();

                OleDbCommand mycmd = new OleDbCommand("spGetAllTools", myConnection);
                mycmd.CommandType = CommandType.StoredProcedure;

                myDataAdapter.SelectCommand = mycmd;
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds, "tblTools");
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


        internal static Diary.Basic_Classes.ToolTransaction getTransaction(int _ironNumber, DateTime _timeLendStart)
        {
            string connectionString = Connect.getConnectionString();
            myConnection = new OleDbConnection(connectionString);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();

            OleDbCommand mycmd = new OleDbCommand("spGetTransaction", myConnection);
            mycmd.CommandType = CommandType.StoredProcedure;
            OleDbParameter objpar;
            objpar = mycmd.Parameters.Add("@toolSerial", OleDbType.Integer);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = _ironNumber;
            objpar = mycmd.Parameters.Add("@takingTimeLess", OleDbType.Date);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = _timeLendStart.AddSeconds(-5);
            objpar = mycmd.Parameters.Add("@takingTimeMore", OleDbType.Date);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = _timeLendStart.AddSeconds(5);

            try
            {
                myConnection.Open();

                myDataAdapter.SelectCommand = mycmd;
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds, "tblTransaction");

                if (ds.Tables["tblTransaction"].Rows.Count != 0)
                {
                    ToolTransaction tTransaction = new ToolTransaction();

                    // TODO: Fix date thing so it will take a date

                    tTransaction.IronNumber = Convert.ToInt32(ds.Tables["tblTransaction"].Rows[0]["toolSerial"]);
                    tTransaction.LendReason = ds.Tables["tblTransaction"].Rows[0]["toolTransactionReason"].ToString();
                    tTransaction.Signature = ds.Tables["tblTransaction"].Rows[0]["Signed"].ToString();

                    if (ds.Tables["tblTransaction"].Rows[0]["returnTime"] != DBNull.Value)
                    {
                        tTransaction.TimeLendFinished = Convert.ToDateTime(ds.Tables["tblTransaction"].Rows[0]["returnTime"]);
                    }

                    if (ds.Tables["tblTransaction"].Rows[0]["toolReturner"] != DBNull.Value)
                    {
                        tTransaction.ToolReturner = ds.Tables["tblTransaction"].Rows[0]["toolReturner"].ToString();
                    }

                    tTransaction.TimeLendStart = Convert.ToDateTime(ds.Tables["tblTransaction"].Rows[0]["takingTime"]);
                    tTransaction.ToolName = ds.Tables["tblTransaction"].Rows[0]["toolName"].ToString();
                    tTransaction.TransactionCreator = ds.Tables["tblTransaction"].Rows[0]["transactionCreator"].ToString();
                    tTransaction.ToolPlace = ds.Tables["tblTransaction"].Rows[0]["toolPlace"].ToString();

                    return (tTransaction);
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

        internal static bool UpdateToolStatus(string toolSerial, string newStatus, bool isNull = false)
        {
            string connectionString = Connect.getConnectionString();
            myConnection = new OleDbConnection(connectionString);

            try
            {
                myConnection.Open();

                OleDbCommand mycmd = new OleDbCommand("spUpdateToolStatus", myConnection);
                mycmd.CommandType = CommandType.StoredProcedure;
                OleDbParameter objpar;
                objpar = mycmd.Parameters.Add("@toolStatus", OleDbType.BSTR);
                objpar.Direction = ParameterDirection.Input;
                objpar.Value = newStatus;

                if (!isNull)
                {
                    objpar = mycmd.Parameters.Add("@takingTime", OleDbType.Date);
                    objpar.Direction = ParameterDirection.Input;
                    objpar.Value = DateTime.Now;
                }
                else
                {
                    objpar = mycmd.Parameters.Add("@takingTime", OleDbType.Date);
                    objpar.Direction = ParameterDirection.Input;
                    objpar.Value = DBNull.Value;
                }
                
                objpar = mycmd.Parameters.Add("@toolSerial", OleDbType.BSTR);
                objpar.Direction = ParameterDirection.Input;
                objpar.Value = toolSerial;

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
