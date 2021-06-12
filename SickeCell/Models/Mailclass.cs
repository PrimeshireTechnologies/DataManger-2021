using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SickeCell.Interfaces;

namespace SickeCell.Models
{
    public class Signup:ISignup
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirmpass { get; set; }
        public string Link { get; set; }
        public string Autocode { get; set; }

        public string Sign_Post(ISignup datasigned)
        {
            throw new NotImplementedException();
        }
    }
}