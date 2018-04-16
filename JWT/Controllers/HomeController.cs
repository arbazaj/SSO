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

        //give the url of this action in helprace sso settings for login url
        public ActionResult LogIn()
        {
            return View();
        }

        //Helprace login can done when redirected from helprace
        [HttpPost]
        public async Task LogIn(string username,string password)//For Helprace Login (sso)
        {
            //mock data of users
            List<Employee> employeeList = new List<Employee>
            {
                new Employee {Name = "shubham", Password = "123", Email = "Abcahjdi@gmail.com", Role = "user"},
                new Employee {Name = "Ansh", Password = "123", Email = "Siuhfid@gmail.com", Role = "user"},
                new Employee {Name = "Arbaz", Password = "123", Email = "asfkhkjdhfjdh@gmail.com", Role = "user"},
                new Employee {Name = "Sumit", Password = "123", Email = "amunitdh@gmail.com", Role = "user"},
                new Employee {Name = "Shubham", Password = "123", Email = "shubham109singh@gmail.com", Role = "user"}

            };
            foreach(Employee employee in employeeList)
            {
                //If user is authenticated successfully then generate his token and redirect to helprace
                if (username == employee.Name & password == employee.Password)
                {
                    string token = TokenGeneration.GenerateToken(employee);
                    HttpContext.Response.Redirect("https://auth.helprace.com/jwt/csharp?jwt=" + token + "&return_to=https://csharp.helprace.com/");
                }
            }
                HttpContext.Response.Redirect("https://jwt20180415100039.azurewebsites.net/Home/Error");
        }

        [HttpGet]
        public ActionResult NativeLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NativeLogin(string username, string password)
        {
            //Write code for native login here
            return View();
        }


        public ActionResult Error()
        {
            return View();
        }
    }
}
