using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UserRegistration2.Entity.User myUser=new UserRegistration2.Entity.User();
        myUser.UserName=txtUserName.Text;
        myUser.UserPassword=txtPassword.Text;
        myUser= UserRegistration2.DataLayer.DataUser.Login(myUser);
        if (myUser != null)
        {
            Response.Write("Successfull");
        }
        else
        {
            Response.Write("No such a username and password");
        }
    }
}