using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
//using System.Web.Services;
using System.Globalization;
using System.Text;
using System.Net;
using System.IO;
using System.Data;
//using System.Net.Http;
//using System.Web.Http;
using System.Runtime.Serialization;
using System.Configuration;
using SickeCell.Interfaces;
using SickeCell.Models;

namespace SickeCell.Controllers
{
    public class SearchController : Controller
    {
        public static string con = ConfigurationManager.ConnectionStrings["SickeCellConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(con);        
        
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        // GET: Search/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Search/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Search/Create
        [HttpPost]
        public ActionResult List(RegisterIdinfo listfilter)
        {
            connection.Open();
            List<IRegisterIdinfo> lisRegistered = new List<IRegisterIdinfo>();
            SqlCommand CmdRegister = new SqlCommand("Information_Search_GET", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            
            SqlDataReader datareader = CmdRegister.ExecuteReader();
            if (datareader.HasRows==true)
            {
                while (datareader.Read())
                {
                    RegisterIdinfo Registered_Data = new RegisterIdinfo();
                    Registered_Data.FirstName = datareader["FirstName"].ToString();
                    Registered_Data.LastName = datareader["LastName"].ToString();
                    lisRegistered.Add(Registered_Data);
                }
            }                

            connection.Close();
            return Json(lisRegistered, JsonRequestBehavior.AllowGet);
        }

        // GET: Search/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Search/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Search/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Search/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }        
    }
}
