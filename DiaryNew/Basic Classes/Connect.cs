using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;

/// <summary>
/// Summary description for Connect
/// </summary>
public class Connect
{
    const string FILE_NAME = "Diary_DB.mdb";
    public static string getConnectionString()
    {
        string location = "App_Data/" + FILE_NAME;
        string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;data source=" + location;
        return ConnectionString;
    }

}
