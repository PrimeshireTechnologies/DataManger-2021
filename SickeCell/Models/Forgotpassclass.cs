using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SickeCell.Models
{
    public class Verification
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirmpass { get; set; }
        public string Link { get; set; }
        public string Stringautocode { get; set; }
        public Int64 Autocode { get; set; }
    }
}