using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SickeCell.Interfaces
{
    public interface ISavelogged
    {
        int HistologinId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Role { get; set; }
        string Email { get; set; }
        DateTime CurrentDate { get; set; }
        string CurrentDatehis { get; set; }
        string Logged_In { get; set; }
        string Logged_Out { get; set; }
        TimeZone CurrentTimeZone { get; set; }
    }
}
