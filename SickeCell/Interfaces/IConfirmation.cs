using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SickeCell.Models;
using System.Web.Mvc;

namespace SickeCell.Interfaces
{
    public interface IConfirmation
    {
        string Email { get; set; }
        string Confirmed { get; set; }
        string Message { get; set; }
        ActionResult Validation(IConfirmation confirmvalue);
    }
}
