using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SickeCell.Models;

namespace SickeCell.Interfaces
{
    public interface IRegisterIdinfo
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Globalid { get; set; }
        ActionResult List(IRegisterIdinfo listfilter);
    }
}
