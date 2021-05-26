using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SickeCell.Interfaces;

namespace SickeCell.Models
{
    public class ReportInfo
    {
        public int ClientID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string FullStreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email_Address { get; set; }
    }

    public class LoggedIn : ILoggedIn
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirmed { get; set; }
        public string LoginErrorMessage { get; set; }
        public IEnumerable<ILoggedIn> Validate(LoggedIn datalogin)
        {
            throw new NotImplementedException();
        }
    }    
}