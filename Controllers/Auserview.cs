using User_s.Models;
using System.Web;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace User_s.Controllers
{
    public class Auserview : Controller
    {

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        List<UV> au =new List<UV>();

        public IActionResult Userview()
        {
            fetchdata();
            
            return View(au);
        }
        void connectionString()
        {
            con.ConnectionString = "data Source=DESKTOP-0CBEKCK;database=User_system;integrated security=sspi;";
        }
        
        private void fetchdata()
        {
            connectionString();
            
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [u_id],[username],[useraddress],[userphoneno] FROM [User_system].[dbo].[userdetails]";
                dr =com.ExecuteReader();
                while (dr.Read())
                {
                    au.Add(new UV() {
                        u_id = dr["u_id"].ToString(),
                        username = dr["username"].ToString(),
                        useraddress = dr["useraddress"].ToString(),
                        userphoneno = dr["userphoneno"].ToString()

                    });
                }
                con.Close();

            }
            catch(Exception e)
            {
                throw ;
            }
        }
        private void edit()
        {
            connectionString();
        }
        public  IActionResult Add_user(Ulogin ul)
        {
            connectionString();
            com = new SqlCommand("InsertData", con);
            com.CommandType = CommandType.Text;

            return View();
            
        }
        public IActionResult delete()
        {
            connectionString() ;
            con.Open();
            com.Connection = con;
            com.CommandText = "delete from userdetails where u_id=@Html.Raw(str);";
            con.Close();
            return View("Userview");
        }

    }
}
