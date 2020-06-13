using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
}