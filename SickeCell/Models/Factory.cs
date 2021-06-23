using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SickeCell.Interfaces;

namespace SickeCell.Models
{
    public static class Factory
    {
        public static ISickleCelloverviewclass CreateSickleCelloverviewclass()
        {
            return new SickleCelloverviewclass();
        }
    }
}