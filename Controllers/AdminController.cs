using User_s.Models;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace User_s.Controllers
{
    public class AdminController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public IActionResult Adminlogin()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data Source=DESKTOP-0CBEKCK;database=User_system;integrated security=sspi;";
        }
        [HttpPost]
        public IActionResult Verify(Admin a)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * from adminlogin where username='" + a.Name + "'and pass='" + a.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("loggedadmin");
            }
            else
            {
                con.Close();
                return View("error");
            }


        }

    }
}
