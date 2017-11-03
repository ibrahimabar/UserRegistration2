using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 10; i < 100; i++)
        {
            ddlAge.Items.Add(new ListItem(i.ToString(),i.ToString()));
        }
        ddlPhoneArea.Items.Add(new ListItem("532", "532"));
        ddlPhoneArea.Items.Add(new ListItem("533", "533"));
        ddlPhoneArea.Items.Add(new ListItem("534", "534"));

        ddlPhoneArea.Items.Add(new ListItem("542", "542"));
        ddlPhoneArea.Items.Add(new ListItem("543", "543"));
        ddlPhoneArea.Items.Add(new ListItem("544", "544"));
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        UserRegistration2.Entity.User temp = new UserRegistration2.Entity.User();
        try
        {
            if (txtPassword.Text==txtRePassword.Text)
            {
                temp.Age = int.Parse(ddlAge.SelectedItem.Value);
                temp.Email = txtEmail.Text;
                temp.FirstName = txtName.Text;
                temp.LastName = txtSurname.Text;
                temp.Phone = "(" + ddlPhoneArea.SelectedItem.Value + ")" + txtPhone.Text;
                temp.UserName = txtUserName.Text;
                temp.UserPassword = txtPassword.Text;
                if (rbtnFemale.Checked)
                {
                    temp.Gender = true;
                }
                else
                {
                    temp.Gender = false;
                }
                UserRegistration2.DataLayer.DataUser.Registration(temp);
            }
            
        }
        catch (Exception)
        {
            
            throw;
        }
        
    }
}