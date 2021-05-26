using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SickeCell.Models;
using System.Web.Mvc;

namespace SickeCell.Interfaces
{
    public interface ILoggedIn
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Role { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string Confirmed { get; set; }
        string LoginErrorMessage { get; set; }
        IEnumerable<ILoggedIn> Validate(LoggedIn datalogin);
    }
}
