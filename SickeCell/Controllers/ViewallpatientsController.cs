using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
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
using System.Runtime.Serialization;

namespace SickeCell.Controllers
{
    public class ViewallpatientsController : ApiController
    {
        public static string con = ConfigurationManager.ConnectionStrings["SickeCellConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(con);
        SqlConnection connection3 = new SqlConnection(con);
        SqlConnection connect = new SqlConnection(con);

        string vlname = "";
        string vfname2 = "";
        string vgender = "";
        string vclientid;
        long vdata;

        public class SickleCelloverviewclass
        {
            public string Clientidx { get; set; }
            public string ClientID { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Middle_Initial { get; set; }
            public string UniqueID { get; set; }
            public string DOB { get; set; }
            public string Age { get; set; }
            public string AgeGroup { get; set; }
            public string Ageat { get; set; }
            public string Gender { get; set; }
            public string Race { get; set; }
            public string Ethnicity { get; set; }
            public string Eligibility { get; set; }
            public string SSN { get; set; }
            public string CountyCode { get; set; }
            public string CountyCodeDescription { get; set; }
            public string SickleCellDiagnosis { get; set; }
            public string FullStreetAddress { get; set; }
            public string FullStreetAddress2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
            public string HomePhone { get; set; }
            public string WorkPhone { get; set; }
            public string PMPProviderName { get; set; }
            public string Specialist { get; set; }
            public string CCUCase { get; set; }
            public string Email_Address { get; set; }
            public string ClientresideinruralID { get; set; }
            public string Nameofmother { get; set; }
            public string Address_Of_Mother { get; set; }
            public string Telephone_Of_Mother { get; set; }
            public string Nameoffather { get; set; }
            public string Address_Of_Father { get; set; }
            public string Telephone_Of_Father { get; set; }
            public string Nameofguardian { get; set; }
            public string Address_Of_Guardian { get; set; }
            public string Guardian_Telephone { get; set; }
            public string Emergency_Contact1 { get; set; }
            public string Emergency_Contact1_HomePhone { get; set; }
            public string Emergency_Contact1_CellPhone { get; set; }
            public string Emergency_Contact2 { get; set; }
            public string Emergency_Contact2_HomePhone { get; set; }
            public string Emergency_Contact2_CellPhone { get; set; }
            public string SicklecelltypeID { get; set; }
            public string Medication { get; set; }
            public string HydroxyureaheardID { get; set; }
            public string HydroxyureatakenID { get; set; }
            public string HydroxyureacurrentlyID { get; set; }
            public string HydroxyureapasttakenID { get; set; }
            public string Globalid { get; set; }
            public string FullName { get; set; }
            public string SelectedSearch { get; set; }
            public string Comments { get; set; }
            public string UserFirstName { get; set; }
            public string UserLastName { get; set; }
            public string TimeStamp { get; set; }
            public DateTime Datenotescreated { get; set; }
            public int NotesID { get; set; }
            public string PhoneNumber { get; set; }
        }

        // GET: api/Viewallpatients
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Viewallpatients/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Viewallpatients
        public IEnumerable<SickleCelloverviewclass> ViewallList(SickleCelloverviewclass listdataview)
        {
            List<SickleCelloverviewclass> overviewdata = new List<SickleCelloverviewclass>();
            int rows = 0;

            try
            {               
                connection.Open();
                SqlCommand searchoverview = new SqlCommand("Information_Stored_Overview", connection);
                searchoverview.CommandType = CommandType.StoredProcedure;
                SqlDataReader overviewreader = searchoverview.ExecuteReader();
                int counter = 0;

                if (overviewreader.HasRows == true)
                {
                    while (overviewreader.Read())
                    {
                        counter = counter + 1;
                        SickleCelloverviewclass overviewddatagroup = new SickleCelloverviewclass();
                        overviewddatagroup.ClientID = overviewreader["ClientID"].ToString();
                        overviewddatagroup.LastName = overviewreader["LastName"].ToString();
                        overviewddatagroup.FirstName = overviewreader["FirstName"].ToString();
                        overviewddatagroup.DOB = overviewreader["DOB"].ToString();
                        overviewddatagroup.Gender = overviewreader["Gender"].ToString();
                        overviewddatagroup.FullStreetAddress = overviewreader["FullStreetAddress"].ToString();
                        overviewddatagroup.City = overviewreader["City"].ToString();
                        overviewddatagroup.UniqueID = overviewreader["UniqueID"].ToString();
                        overviewddatagroup.State = overviewreader["State"].ToString();
                        overviewddatagroup.Email_Address = overviewreader["Email_Address"].ToString();
                        overviewddatagroup.Race = overviewreader["Race"].ToString();
                        overviewddatagroup.Ethnicity = overviewreader["Ethnicity"].ToString();
                        overviewddatagroup.ZipCode = overviewreader["ZipCode"].ToString();
                        overviewddatagroup.HomePhone = overviewreader["HomePhone"].ToString();
                        overviewddatagroup.WorkPhone = overviewreader["WorkPhone"].ToString();
                        overviewddatagroup.SicklecelltypeID = overviewreader["SicklecelltypeID"].ToString();
                        overviewddatagroup.Eligibility = overviewreader["Eligibility"].ToString();
                        overviewddatagroup.SickleCellDiagnosis = overviewreader["SickleCellDiagnosis"].ToString();
                        overviewddatagroup.PMPProviderName = overviewreader["PMPProviderName"].ToString();
                        overviewddatagroup.CCUCase = overviewreader["CCUCase"].ToString();
                        overviewddatagroup.PhoneNumber = overviewreader["PhoneNumber"].ToString();
                        //overviewddatagroup.Comments = overviewreader["Comments"].ToString();

                        connect.Open();
                        SqlCommand RecentCommentcmd = new SqlCommand("select Notesid, ClientID, Comments, TimeStamp from Notes where ClientID= '" + overviewreader["ClientID"].ToString() + "' order by Notesid  DESC", connect);
                        SqlDataReader recentcommentreader = RecentCommentcmd.ExecuteReader();
                        while (recentcommentreader.Read())
                        {
                            overviewddatagroup.Comments = recentcommentreader["Comments"].ToString();
                            break;
                        }
                        recentcommentreader.Close();
                        connect.Close();

                        if (vlname != overviewreader["LastName"].ToString().Trim() && vfname2 != overviewreader["FirstName"].ToString().Trim())
                        {
                            overviewdata.Add(overviewddatagroup);
                        }                      

                        vlname = overviewreader["LastName"].ToString().Trim();
                        vfname2 = overviewreader["FirstName"].ToString().Trim();
                        vgender = overviewreader["Gender"].ToString().Trim();
                        vclientid = overviewreader["ClientID"].ToString();
                    }
                }
                else
                {
                    overviewreader.Close();
                    connection.Close();
                    return overviewdata;
                }
                overviewreader.Close();
                connection.Close();
                return overviewdata;
            }
            catch (Exception ab)
            {
                ab.Message.ToString();
            }
            return overviewdata;
        }

        // PUT: api/Viewallpatients/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Viewallpatients/5
        public void Delete(int id)
        {
        }
    }
}
