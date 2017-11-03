using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for User
/// </summary>
namespace UserRegistration2.Entity
{
public class User
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public bool Gender { get; set; }

	public User()
	{
		//
		// TODO: Add constructor logic here
		//
	}

}

}