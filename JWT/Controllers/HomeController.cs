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
            List<Employee> employeeList = new List<Employee>
            {
                new Employee {Name = "shubham", Password = "123", Email = "Abcahjdi@gmail.com", Role = "user"},
                new Employee {Name = "Ansh", Password = "123", Email = "Siuhfid@gmail.com", Role = "user"},
                new Employee {Name = "Arbaz", Password = "123", Email = "asfkhkjdhfjdh@gmail.com", Role = "user"},
                new Employee {Name = "Sumit", Password = "123", Email = "amunitdh@gmail.com", Role = "user"},

            };
            foreach(Employee employee in employeeList)
            {
                if (username == employee.Name & password == employee.Password)
                {
                    string token = TokenGeneration.GenerateToken(employee);
                    HttpContext.Response.Redirect("https://auth.helprace.com/jwt/csharp?jwt=" + token + "&return_to=https://csharp.helprace.com/");
                }
            }
                HttpContext.Response.Redirect("http://localhost:63719/Home/Error");
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
