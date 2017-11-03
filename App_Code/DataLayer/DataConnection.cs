using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataConnection
/// </summary>
namespace UserRegistration2.DataLayer
{
    public class DataConnection
    {
        public DataConnection()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename="+HttpContext.Current.Server.MapPath("App_Data\\DatabaseUser.mdf")+";Integrated Security=True;User Instance=True");

                
        }
    }
}