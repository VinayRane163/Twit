using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Data;
using System.Data.SqlClient;
using twit.Models;

namespace twit.Controllers
{
    public class AccountController : Controller
    {
        private string connection;

        public AccountController(IConfiguration configuration) {
            connection = configuration.GetConnectionString("DefaultConnection");
        }
        public IActionResult Login()
        {
            return View();
        }
    
        [HttpPost]
        public IActionResult Login(Login login)
        {

           /* try
            {*/
                string uname = login.username;
                string pass = login.Password;
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("twit_login", conn))
                    {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", uname);
                    cmd.Parameters.AddWithValue("@Password", pass);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                HttpContext.Session.SetString("Username", uname);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewBag.NotSucces = "Wrong Userid Or Password";
                            }

                        }
                    }
                }
            /*}
            catch  
            { 
                ViewBag.NotSucces = "error Occured";
                
            }*/
            return View();
        }

        public ActionResult Register()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string uname = register.Username;
                    string email = register.Email;
                    string pass = register.Password;
                    using (SqlConnection conn = new SqlConnection(connection))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("twit_register", conn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Username", uname);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Password", pass);
                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                HttpContext.Session.SetString("Username", email);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewBag.NotSucces = "Registeration unsuccessful";
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    ViewBag.NotSucces = "User(email) already exist";
                }
                else
                {
                    ViewBag.NotSucces = "error occured";

                }
            }
            catch (Exception ex)
            {
                ViewBag.NotSucces = "unknown error redirectng to default page";

            }
            return View();
        }




    }
}
