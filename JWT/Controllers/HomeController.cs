using JWT.Models;
using JWT.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JWT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task LogIn(string username,string password)
        {
            Employee employee = new Employee { Name = "shubham", Password = "123", Email = "shubham109singh", Role = "user" };
            if(username==employee.Name& password == employee.Password)
            {
                string token = TokenGeneration.GenerateToken(employee);
                HttpContext.Response.Redirect("https://auth.helprace.com/jwt/csharp?jwt=" + token);
            }
           
        }
    }
}
