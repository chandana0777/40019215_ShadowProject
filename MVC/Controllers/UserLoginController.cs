using MVC.Models;
using ProjectDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UserLoginController : Controller
    {
        SHOPEntities db = new SHOPEntities();
        // GET: UserLogin
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ULogin(User u)
        {
            string conStr = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conStr);
            string sqlquery = "select UserName,Password from USER_LOGIN where UserName=@UserName and Password=@Password";
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            sqlcom.Parameters.AddWithValue("@UserName", u.UserName);
            sqlcom.Parameters.AddWithValue("@Password", u.Password);
            SqlDataReader sqdr = sqlcom.ExecuteReader();
            if (sqdr.Read())
            {
                Session["username"] = u.UserName.ToString();
                return RedirectToAction("ViewProduct", "User");
            }
            else
            {
                ViewData["Message"] = "Enter Valid UserName and Password!!";
                return RedirectToAction("UserLogin");
               
            }
            sqlcon.Close();

            return View();
        }
       
     

        
    }
}