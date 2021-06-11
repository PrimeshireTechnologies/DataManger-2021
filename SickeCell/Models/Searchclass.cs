using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SickeCell.Interfaces;
using System.Web.Mvc;

namespace SickeCell.Models
{
    public class RegisterIdinfo:IRegisterIdinfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Globalid { get; set; }

        public ActionResult List(IRegisterIdinfo listfilter)
        {
            throw new NotImplementedException();
        }
    }
}