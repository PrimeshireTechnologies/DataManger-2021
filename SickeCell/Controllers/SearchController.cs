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
namespace SickeCell.Controllers
{
    public class SearchController : Controller
    {
        public static string con = ConfigurationManager.ConnectionStrings["SickeCellConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(con);

        public class RegisterIdinfo
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Globalid { get; set; }
        }
        
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
            List<RegisterIdinfo> lisRegistered = new List<RegisterIdinfo>();
            SqlCommand CmdRegister = new SqlCommand("Information_Search_GET", connection);
            CmdRegister.CommandType = CommandType.StoredProcedure;
            //CmdRegister.Parameters.Add("@Globalid", SqlDbType.VarChar).Value = listfilter.Globalid;
            //connection.Open();
            //SqlParameter RegisterId = CmdRegister.Parameters.Add("@RegisterId", SqlDbType.BigInt);
            //RegisterId.Direction = ParameterDirection.Input;
            //RegisterId.Value = 0;

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
