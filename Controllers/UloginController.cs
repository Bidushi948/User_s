using User_s.Models;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace User_s.Controllers
{
    public class UloginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        //GET:USER_ACCOUNT;
        [HttpGet]
        public IActionResult Ulogin()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data Source=DESKTOP-0CBEKCK;database=User_system;integrated security=sspi;";
        }
        [HttpPost]
        public IActionResult Verify(Ulogin ul)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * from userlogin where username='" + ul.Name+ "'and pass='" + ul.Password+ "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("ulog");
            }
            else
            {
                con.Close();
                return View("Error");
            }


        }
    }
}
