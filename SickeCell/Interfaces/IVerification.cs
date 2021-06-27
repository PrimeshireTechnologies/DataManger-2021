using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SickeCell.Models;
using System.Web.Mvc;

namespace SickeCell.Interfaces
{
    public interface IVerification
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Role { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string Confirmpass { get; set; }
        string Link { get; set; }
        string Stringautocode { get; set; }
        Int64 Autocode { get; set; }
        string Verifyemail(IVerification verifyvalue);        
    }
}
