using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserRegistration2.Entity;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DataUser
/// </summary>
namespace UserRegistration2.DataLayer
{

public class DataUser
{
	public DataUser()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static Entity.User Login(Entity.User LoginRequest)
    {
        Entity.User LoginResult =null;

        SqlConnection con = UserRegistration2.DataLayer.DataConnection.GetConnection();

        SqlCommand com = new SqlCommand();

        string query = "SELECT UserDetails.FirstName, UserDetails.LastName, UserDetails.UserAge, UserDetails.UserGender, UserDetails.UserEmail, UserDetails.UserPhone, UserDetails.UserId, Users.UserName, Users.UserPassword "
        +"FROM UserDetails INNER JOIN Users ON UserDetails.UserId = Users.UserId "
        +"where Users.UserName=@un and Users.UserPassword=@up;";
        com.Connection = con;
        com.CommandText = query;

        com.Parameters.AddWithValue("@un", LoginRequest.UserName);
        com.Parameters.AddWithValue("@up", LoginRequest.UserPassword);
        con.Open();
        SqlDataReader rdr = com.ExecuteReader();
        if (rdr.Read())
        {
            LoginResult = new UserRegistration2.Entity.User();
            LoginResult.Gender = bool.Parse(rdr["UserGender"].ToString());
            LoginResult.Age = int.Parse(rdr["UserAge"].ToString());
            LoginResult.Email = rdr["UserEmail"].ToString();
            LoginResult.FirstName = rdr["FirstName"].ToString();
            LoginResult.LastName = rdr["LastName"].ToString();
            LoginResult.Phone = rdr["UserPhone"].ToString();
            LoginResult.UserId = int.Parse(rdr["UserId"].ToString());
            LoginResult.UserName = rdr["UserName"].ToString();
            LoginResult.UserPassword = rdr["UserPassword"].ToString();
        }
        return LoginResult;
    }



    public static void Registration(User temp)
    {
        SqlConnection con = null;
        SqlCommand com = new SqlCommand();

        con = UserRegistration2.DataLayer.DataConnection.GetConnection();
        string query = "insert into Users(UserName,UserPassword) value (@username,@password)";

        com.CommandText = query;
        com.Connection = con;

        com.Parameters.AddWithValue("@username", temp.UserName);
        com.Parameters.AddWithValue("@password", temp.UserPassword);

        con.Open();
        com.ExecuteNonQuery();

        com.CommandText = "select @@IDENTITY";
        com.Parameters.Clear();

        object result = com.ExecuteScalar();
    }
}
}