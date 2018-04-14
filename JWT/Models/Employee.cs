using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWT.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string role { get; set; }
    }
}