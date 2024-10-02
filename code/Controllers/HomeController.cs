using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using twit.Models;

namespace twit.Controllers
{
    public class HomeController : Controller
    {
        private string connection;

        public HomeController(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("DefaultConnection");
        }
        /********************************/

       /* private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Username") == null) { 
                return RedirectToAction("Register","Account");
            
            }

            return View();
        }

       /* [HttpPost]
        public IActionResult Index() {
            try
            {
                string pass = n.Name;
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("insert into nigga values (@Password)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Password", pass);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            ViewBag.NotSucces = "Registered";

                        }
                        else
                        {
                            ViewBag.NotSucces = "Registeration unsuccessful";
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    ViewBag.NotSucces = "Duplicate data";

                }
                else
                {
                    // Handle other SQL errors
                    ViewBag.NotSucces = "An error occurred while inserting the user email: " + ex.Message;
                }
            }
            catch(Exception ex)
            {
                ViewBag.NotSucces = "ERROR.";

            }
            return View(); 
        }*/

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
