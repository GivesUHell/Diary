using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Diary.Basic_Classes
{

    public enum UserRank
    {
        Guest,
        Technician,
        Head_Technician,
        Admin
    }

    class User
    {
        private static OleDbConnection myConnection;

        // Ctor
        public User()
        {
            _rank = UserRank.Guest;
        }

        // Class Elements
        
        private UserRank _rank;
        private string _userFirstName;
        private string _userLastName;
        private string _userName;
        private string _userArmySerial;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string UserFirstName
        {
            get { return _userFirstName; }
            set { _userFirstName = value; }
        }

        public string UserLastName
        {
            get { return _userLastName; }
            set { _userLastName = value; }
        }

        public string UserArmySerial
        {
            get { return _userArmySerial; }
            set { _userArmySerial = value; }
        }

        public UserRank Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }
        
        public static bool addNewUser(string userName, string userPass, int userRank, string userArmySerial, string userFirstName, string userLastName)
        {
            DataSet dsUsers = getAllUsers();

            foreach (DataRow dtUserRow in dsUsers.Tables["tblUsers"].Rows)
            {
                if (dtUserRow["armySerial"].ToString() == userArmySerial || dtUserRow["userName"].ToString() == userName)
                {
                    return (false);
                }
            }

            string connectionString = Connect.getConnectionString();
            myConnection = new OleDbConnection(connectionString);

            OleDbCommand mycmd = new OleDbCommand("spInsertUser", myConnection);
            mycmd.CommandType = CommandType.StoredProcedure;
            OleDbParameter objpar;
            objpar = mycmd.Parameters.Add("@userName", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = userName;
            objpar = mycmd.Parameters.Add("@userPass", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = userPass;
            objpar = mycmd.Parameters.Add("@userRank", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = userRank;
            objpar = mycmd.Parameters.Add("@firstName", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = userFirstName;
            objpar = mycmd.Parameters.Add("@lastName", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = userLastName;
            objpar = mycmd.Parameters.Add("@armySerial", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = userArmySerial;

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

        public static DataSet getAllUsers()
        {
            string connectionString = Connect.getConnectionString();
            myConnection = new OleDbConnection(connectionString);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();

            try
            {
                myConnection.Open();

                OleDbCommand mycmd = new OleDbCommand("spGetAllUsersNoPass", myConnection);
                mycmd.CommandType = CommandType.StoredProcedure;

                myDataAdapter.SelectCommand = mycmd;
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds, "tblUsers");

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

        public static DataSet getUser(string userName)
        {
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();

            try
            {
                myConnection.Open();

                OleDbCommand mycmd = new OleDbCommand("spGetUser", myConnection);
                mycmd.CommandType = CommandType.StoredProcedure;

                OleDbParameter objpar;
                objpar = mycmd.Parameters.Add("@userName", OleDbType.BSTR);
                objpar.Direction = ParameterDirection.Input;
                objpar.Value = userName;

                myDataAdapter.SelectCommand = mycmd;
                DataSet ds = new DataSet();
                myDataAdapter.Fill(ds, "tblUsers");

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
    }
}
