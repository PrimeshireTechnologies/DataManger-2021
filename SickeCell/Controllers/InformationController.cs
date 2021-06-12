using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data.Sql;

using OfficeOpenXml;
using System.Text;
using System.Collections;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

using System.Web.UI;
using System.Web.UI.WebControls;

using System.Globalization;

using System.Net;
using System.Runtime.Serialization;
using SickeCell.Models;

namespace SickeCell.Controllers
{
    public class InformationController : Controller
    {
        public static string con = ConfigurationManager.ConnectionStrings["SickeCellConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(con);
        SqlConnection connection3 = new SqlConnection(con);

        string vlname = "";
        string vfname2 = "";
        string vgender = "";
        int vclientid;
        long vdata;        

        // GET: Information
        public ActionResult Index()
        {
            return View();
        }

        // GET: Information/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Information/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Information/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Information/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Information/Edit/5
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

        // GET: Information/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Information/Delete/5
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

        //[HttpPost]
        //public ActionResult ViewallList(SickleCelloverviewclass listdataview)
        //{            

        //    List<SickleCelloverviewclass> overviewdata = new List<SickleCelloverviewclass>();
        //    int rows = 0;

        //    try
        //    {
        //        connection3.Open();
        //        SqlCommand command3 = new SqlCommand("select count(*) as TotRec from information", connection3);
        //        SqlDataReader locatelogsaveReader = command3.ExecuteReader();
        //        if (locatelogsaveReader.HasRows ==true)
        //        {                    
        //            while (locatelogsaveReader.Read())
        //            {
        //                rows = Convert.ToInt32(locatelogsaveReader["TotRec"]);                       
        //            }
        //        }

        //        connection.Open();
        //        SqlCommand searchoverview = new SqlCommand("Information_Stored_Overview", connection);
        //        searchoverview.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader overviewreader = searchoverview.ExecuteReader();
        //        int counter = 0;

        //        if (overviewreader.HasRows == true)
        //        {                    
        //            while (overviewreader.Read())
        //            {
        //                counter = counter + 1;
        //                SickleCelloverviewclass overviewddatagroup = new SickleCelloverviewclass();
        //                overviewddatagroup.ClientID = Convert.ToInt32(overviewreader["ClientID"].ToString());
        //                overviewddatagroup.LastName = overviewreader["LastName"].ToString();
        //                overviewddatagroup.FirstName = overviewreader["FirstName"].ToString();
        //                overviewddatagroup.DOB = overviewreader["DOB"].ToString();
        //                overviewddatagroup.Gender = overviewreader["Gender"].ToString();
        //                overviewddatagroup.FullStreetAddress = overviewreader["FullStreetAddress"].ToString();
        //                overviewddatagroup.City = overviewreader["City"].ToString();
        //                overviewddatagroup.State = overviewreader["State"].ToString();
        //                overviewddatagroup.Email_Address = overviewreader["Email_Address"].ToString();

        //                if (vlname != overviewreader["LastName"].ToString().Trim() && vfname2 != overviewreader["FirstName"].ToString().Trim())
        //                {                            
        //                    overviewdata.Add(overviewddatagroup);                                                     
        //                }

        //                if (counter == rows)
        //                {
        //                    break;
        //                }

        //                vlname = overviewreader["LastName"].ToString().Trim();
        //                vfname2 = overviewreader["FirstName"].ToString().Trim();
        //                vgender = overviewreader["Gender"].ToString().Trim();
        //                vclientid = Convert.ToInt32(overviewreader["ClientID"].ToString());
        //            }
        //        }
        //        else
        //        {
        //            overviewreader.Close();
        //            connection.Close();
        //            return Json(overviewdata);
        //        }
        //        overviewreader.Close();
        //        connection.Close();
        //        return Json(overviewdata);
        //    }
        //    catch (Exception ab)
        //    {
        //        ab.ToString();              
        //    }
        //    return Json(overviewdata);
        //}
    }
}
