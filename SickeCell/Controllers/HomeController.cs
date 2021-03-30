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

namespace SickeCell.Controllers
{
    public class HomeController : Controller
    {
        public static string con = ConfigurationManager.ConnectionStrings["SickeCellConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(con);
        SqlConnection connection2 = new SqlConnection(con);
        SqlConnection connect = new SqlConnection(con);

        //string vfname = "";
        //int counter;
        //int counter1;

        string historyid ="";

        string vlname = "";
        string vfname2 = "";
        string vgender = "";
        string vclientid;
        long vdata;

        string[] b;
        
        public class Confirmation
        {
            public string Email { get; set; }
            public string Confirmed { get; set; }
            public string Message { get; set; }
        }

        public class SickeCellclass
        {            
            public string Clientseacrh { get; set; }
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
            public string Medication2 { get; set; }
            public string Medication3 { get; set; }
            public string Medication4 { get; set; }
            public string HydroxyureaheardID { get; set; }
            public string HydroxyureatakenID { get; set; }
            public string HydroxyureacurrentlyID { get; set; }
            public string HydroxyureapasttakenID { get; set; }
            public string Hydroxyureadosage { get; set; }
            public string Hydroxyureadosageunknown { get; set; }
            public string Hydroxyureacapsulescolor { get; set; }
            public string Hydroxyureadatelasttaken { get; set; }
            public string Hydroxyureadatepickedup { get; set; }
            public string Pharma1heardID { get; set; }
            public string Pharma1takenID { get; set; }
            public string Pharma1currentlyID { get; set; }
            public string Pharma1pasttakenID { get; set; }
            public string Pharma1dosage { get; set; }
            public string Pharma1dosageunknown { get; set; }
            public string Pharma1capsulescolor { get; set; }
            public string Pharma1datelasttaken { get; set; }
            public string Pharma1datepickedup { get; set; }
            public string Pharma2heardID { get; set; }
            public string Pharma2takenID { get; set; }
            public string Pharma2currentlyID { get; set; }
            public string Pharma2pasttakenID { get; set; }
            public string Pharma2dosage { get; set; }
            public string Pharma2dosageunknown { get; set; }
            public string Pharma2capsulescolor { get; set; }
            public string Pharma2datelasttaken { get; set; }
            public string Pharma2datepickedup { get; set; }
            public string Pharma3heardID { get; set; }
            public string Pharma3takenID { get; set; }
            public string Pharma3currentlyID { get; set; }
            public string Pharma3pasttakenID { get; set; }
            public string Pharma3dosage { get; set; }
            public string Pharma3dosageunknown { get; set; }
            public string Pharma3capsulescolor { get; set; }
            public string Pharma3datelasttaken { get; set; }
            public string Pharma3datepickedup { get; set; }
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
            public Decimal ZipCode2 { get; set; }
            public Decimal CountryCode2 { get; set; }
            public Decimal PhoneNumber2 { get; set; }
            public string Deceased { get; set; }
        }

        public class SickleCelloverviewclass
        {            
            public string Clientidx { get; set; }
            public string Clientseacrh { get; set; }
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
            public string Hydroxyureadosage { get; set; }
            public string Hydroxyureadosageunknown { get; set; }
            public string Hydroxyureacapsulescolor { get; set; }
            public string Hydroxyureadatelasttaken { get; set; }
            public string Hydroxyureadatepickedup { get; set; }
            public string Pharma1heardID { get; set; }
            public string Pharma1takenID { get; set; }
            public string Pharma1currentlyID { get; set; }
            public string Pharma1pasttakenID { get; set; }
            public string Pharma1dosage { get; set; }
            public string Pharma1dosageunknown { get; set; }
            public string Pharma1capsulescolor { get; set; }
            public string Pharma1datelasttaken { get; set; }
            public string Pharma1datepickedup { get; set; }
            public string Pharma2heardID { get; set; }
            public string Pharma2takenID { get; set; }
            public string Pharma2currentlyID { get; set; }
            public string Pharma2pasttakenID { get; set; }
            public string Pharma2dosage { get; set; }
            public string Pharma2dosageunknown { get; set; }
            public string Pharma2capsulescolor { get; set; }
            public string Pharma2datelasttaken { get; set; }
            public string Pharma2datepickedup { get; set; }
            public string Pharma3takenID { get; set; }
            public string Pharma3currentlyID { get; set; }
            public string Pharma3pasttakenID { get; set; }
            public string Pharma3dosage { get; set; }
            public string Pharma3dosageunknown { get; set; }
            public string Pharma3capsulescolor { get; set; }
            public string Pharma3datelasttaken { get; set; }
            public string Pharma3datepickedup { get; set; }
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
            public string Deceased { get; set; }
        }        

        public class Conversion
        {
            public string Path { get; set; }
            public object Jresult { get; set; }
        }

        public class Savelogged
        {
            public int HistologinId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Role { get; set; }
            public string Email { get; set; }
            public DateTime CurrentDate { get; set; }
            public string CurrentDatehis { get; set; }
            public string Logged_In { get; set; }
            public string Logged_Out { get; set; }
            public static TimeZone CurrentTimeZone { get; }
        }

        public ActionResult Entry()
        {
            ViewBag.Title = "Patient Entry Form - SickleCell";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Login Page - SickleCell";

            return View();
        }

        public ActionResult Login2()
        {
            ViewBag.Title = "Login Page - SickleCell";

            return View();
        }

        public ActionResult Signup()
        {
            ViewBag.Title = "Signup Page - SickleCell";

            return View();
        }

        public ActionResult Successful()
        {
            ViewBag.Title = "Successfull Page - SickleCell";

            return View();
        }

        public ActionResult PleaseConfirm()
        {
            ViewBag.Title = "PleaseConfirm. Page - SickleCell";

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "This is a menu Page - SickleCell";

            return View();
        }

        public ActionResult Casenotes()
        {
            ViewBag.Title = "This is a Casenotes Page - SickleCell";

            return View();
        }

        public ActionResult PatientOverview()
        {
            ViewBag.Title = "This is a Patient Overview Page - SickleCell";

            //SickeCellEntities1 entities = new SickeCellEntities1();
            //return View(from information in entities.Information select information);
            return View();
        }

        public ActionResult Uploadcsv()
        {
            ViewBag.Title = "This is for Upload CSV Page - SickleCell";

            return View();
        }

        public ActionResult Modular()
        {
            ViewBag.Title = "This is Patient Entry Form Page - SickleCell";

            return View();
        }

        public ActionResult Reportviewer()
        {
            ViewBag.Title = "This is for the ReportViewer Page - SickleCell";

            return View();
        }

        public ActionResult Integration()
        {
            ViewBag.Title = "Information Preview - SickleCell";

            return View();
        }

        public ActionResult Scroll()
        {
            ViewBag.Title = "This is for scroll";

            return View();
        }

        public ActionResult Manageconsole()
        {
            ViewBag.Title = "This is for a Management Console";

            return View();
        }

        public ActionResult Manageconsoleoption()
        {
            ViewBag.Title = "This is for a Console Option";

            return View();
        }

        public ActionResult Consolesignup()
        {
            ViewBag.Title = "This is for a Super Admin and Admin Signup";

            return View();
        }

        public ActionResult Forgot()
        {
            ViewBag.Title = "Forgot Password";

            return View();
        }

        public ActionResult Banner()
        {
            ViewBag.Title = "Please contact the System ASdministrator";

            return View();
        }

        public ActionResult Changepassword()
        {
            ViewBag.Title = "This is to change Password";

            return View();
        }

        public ActionResult Changepassverify()
        {
            ViewBag.Title = "Change Password Verification";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Title = "Testing";

            return View();
        }

        public ActionResult ForgotPassword()
        {
            ViewBag.Title = "ForgotPassword";

            return View();
        }

        public ActionResult Verificationcode()
        {
            ViewBag.Title = "ForgotPassword";

            return View();
        }

        public ActionResult ResetPassword()
        {
            ViewBag.Title = "ResetPassword";

            return View();
        }

        public ActionResult Resetsuccess()
        {
            ViewBag.Title = "Resetsuccess";

            return View();
        }        

        //[HttpPost]
        public ActionResult PatientView(SickleCelloverviewclass patientdataview)
        {                      
            List<SickleCelloverviewclass> overviewdata = new List<SickleCelloverviewclass>();
            try
            {                
                if (patientdataview.FirstName == null)
                {
                    connection.Open();
                    SqlCommand searchoverview;
                    searchoverview = new SqlCommand("SickeCell_Stored_Search_idx", connection);                    
                    searchoverview.CommandType = CommandType.StoredProcedure;
                    searchoverview.Parameters.Add("@Clientidx", SqlDbType.VarChar).Value = patientdataview.ClientID;

                    SqlDataReader overviewreader = searchoverview.ExecuteReader();

                    if (overviewreader.HasRows == true)
                    {
                        while (overviewreader.Read())
                        {
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
                            overviewddatagroup.Eligibility = overviewreader["Eligibility"].ToString();
                            overviewddatagroup.Ethnicity = overviewreader["Ethnicity"].ToString();
                            overviewddatagroup.SSN = overviewreader["SSN"].ToString();
                            overviewddatagroup.PhoneNumber = overviewreader["PhoneNumber"].ToString();
                            overviewddatagroup.ZipCode = overviewreader["ZipCode"].ToString();
                            overviewddatagroup.HomePhone = overviewreader["HomePhone"].ToString();
                            overviewddatagroup.WorkPhone = overviewreader["WorkPhone"].ToString();
                            overviewddatagroup.SicklecelltypeID = overviewreader["SicklecelltypeID"].ToString();
                            overviewddatagroup.SickleCellDiagnosis = overviewreader["SickleCellDiagnosis"].ToString();
                            overviewddatagroup.PMPProviderName = overviewreader["PMPProviderName"].ToString();
                            overviewddatagroup.CCUCase = overviewreader["CCUCase"].ToString();
                            overviewddatagroup.Specialist = overviewreader["Specialist"].ToString();
                            overviewddatagroup.Medication = overviewreader["Medication"].ToString();
                            overviewddatagroup.Emergency_Contact1 = overviewreader["Emergency_Contact1"].ToString();
                            overviewddatagroup.Emergency_Contact1_HomePhone = overviewreader["Emergency_Contact1_HomePhone"].ToString();
                            overviewddatagroup.Emergency_Contact1_CellPhone = overviewreader["Emergency_Contact1_CellPhone"].ToString();

                            connect.Open();
                                   SqlCommand RecentCommentcmd = new SqlCommand("select Notesid, ClientID, Comments, TimeStamp from Notes where ClientID= '" + patientdataview.ClientID + "' order by Notesid  DESC", connect);
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
                                //if (vgender != overviewreader["Gender"].ToString().Trim() && vclientid != Convert.ToInt32(overviewreader["ClientID"].ToString()))
                                //{
                                overviewdata.Add(overviewddatagroup);
                                //}                            
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
                        patientdataview.FirstName = "none";
                        return Json(patientdataview.FirstName);
                        //return Json(overviewdata);
                    }
                    overviewreader.Close();
                    connection.Close();
                    return Json(overviewdata);
                }
                else {
                    connect.Open();

                    DateTime vdob = Convert.ToDateTime(patientdataview.DOB);
                    SqlCommand searchoverview2 = new SqlCommand("select * from information where FirstName = '"+ patientdataview.FirstName + "' and LastName = '" + patientdataview.LastName + "' and DOB = '" + vdob + "' ", connect);
                    SqlDataReader overviewreader2 = searchoverview2.ExecuteReader();

                    if (overviewreader2.HasRows == true)
                    {
                        while (overviewreader2.Read())
                        {
                            SickleCelloverviewclass overviewddatagroup2 = new SickleCelloverviewclass();
                            overviewddatagroup2.ClientID = overviewreader2["ClientID"].ToString();
                            overviewddatagroup2.LastName = overviewreader2["LastName"].ToString();
                            overviewddatagroup2.FirstName = overviewreader2["FirstName"].ToString();
                            overviewddatagroup2.DOB = overviewreader2["DOB"].ToString();
                            overviewddatagroup2.Gender = overviewreader2["Gender"].ToString();
                            overviewddatagroup2.FullStreetAddress = overviewreader2["FullStreetAddress"].ToString();
                            overviewddatagroup2.City = overviewreader2["City"].ToString();
                            overviewddatagroup2.State = overviewreader2["State"].ToString();
                            overviewddatagroup2.Email_Address = overviewreader2["Email_Address"].ToString();

                            if (vlname != overviewreader2["LastName"].ToString().Trim() && vfname2 != overviewreader2["FirstName"].ToString().Trim())
                            {
                                //if (vgender != overviewreader["Gender"].ToString().Trim() && vclientid != Convert.ToInt32(overviewreader["ClientID"].ToString()))
                                //{
                                overviewdata.Add(overviewddatagroup2);
                                //}                            
                            }

                            vlname = overviewreader2["LastName"].ToString().Trim();
                            vfname2 = overviewreader2["FirstName"].ToString().Trim();
                            vgender = overviewreader2["Gender"].ToString().Trim();
                            vclientid = overviewreader2["ClientID"].ToString();

                        }
                    }
                    else
                    {
                        overviewreader2.Close();
                        connect.Close();
                        
                        patientdataview.FirstName = "none";
                        return Json(patientdataview.FirstName);
                        //return Json(overviewdata);
                    }
                    overviewreader2.Close();
                    connect.Close();
                    return Json(overviewdata);
                }
                
            }
            catch (Exception ab)
            {
                ab.ToString();
                Console.Write(ab.ToString());
                Console.WriteLine(ab.ToString());
            }
            
            return Json(overviewdata);
        }
        
        /// <summary>
        public ActionResult Breakdown(SickleCelloverviewclass breakdownfilter)
        {
            connection.Open();
            ////////////////////////////////////////            
            List<SickleCelloverviewclass> breakdownview = new List<SickleCelloverviewclass>();

            try
            {
                SqlCommand breakdownoverview = new SqlCommand("Information_Stored_Overview", connection);
                breakdownoverview.CommandType = CommandType.StoredProcedure;
                SqlDataReader breakdownreader = breakdownoverview.ExecuteReader();                

                if (breakdownreader.HasRows == true)
                {
                    while (breakdownreader.Read())
                    {
                        SickleCelloverviewclass breakdowndatagroup = new SickleCelloverviewclass();
                        breakdowndatagroup.ClientID = breakdownreader["ClientID"].ToString();
                        breakdowndatagroup.LastName = breakdownreader["LastName"].ToString();
                        breakdowndatagroup.FirstName = breakdownreader["FirstName"].ToString();
                        breakdowndatagroup.DOB = breakdownreader["DOB"].ToString();
                        breakdowndatagroup.Gender = breakdownreader["Gender"].ToString();
                        breakdowndatagroup.FullStreetAddress = breakdownreader["FullStreetAddress"].ToString();
                        breakdowndatagroup.City = breakdownreader["City"].ToString();
                        breakdowndatagroup.State = breakdownreader["State"].ToString();
                        breakdowndatagroup.Email_Address = breakdownreader["Email_Address"].ToString();

                        breakdownview.Add(breakdowndatagroup);
                    }
                }
                else
                {
                    breakdownreader.Close();
                    connection.Close();
                    return Json(breakdownview, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception err)
            {
                err.Message.ToString();
            }


            Directory.CreateDirectory(HttpContext.Server.MapPath("~/ExcelFile2/"));            

            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");

                var excelWorksheet = excel.Workbook.Worksheets["Worksheet1"];

                List<string[]> headerRow = new List<string[]>()
                {
                    new string[] { "ClientID", "Name", "Date of Birth", "Gender", "Address", "City", "State", "Email Address" }
                };

                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                excelWorksheet.Cells[headerRange].LoadFromArrays(headerRow);

                excelWorksheet.Cells[headerRange].Style.Font.Bold = true;
                excelWorksheet.Cells[headerRange].Style.Font.Size = 15;
                excelWorksheet.Cells[headerRange].Style.Font.Color.SetColor(System.Drawing.Color.DarkOrange);

                for (int i = 1; i <= 7; i++)
                {
                    if (i == 8)
                    {
                        excelWorksheet.Column(i).Width = 37;
                    }
                    else { excelWorksheet.Column(i).Width = 22; }
                }

                var rowcounter = 2;
                for (var i = 0; i < breakdownview.Count; i++)
                {
                    excelWorksheet.Cells[rowcounter, 1].Value = breakdownview[i].ClientID.ToString().Trim();
                    excelWorksheet.Cells[rowcounter, 2].Value = breakdownview[i].FirstName + "  " + breakdownview[i].LastName;
                    excelWorksheet.Cells[rowcounter, 3].Value = breakdownview[i].DOB.Substring(0,9);
                    excelWorksheet.Cells[rowcounter, 4].Value = breakdownview[i].Gender;
                    excelWorksheet.Cells[rowcounter, 5].Value = breakdownview[i].FullStreetAddress;
                    excelWorksheet.Cells[rowcounter, 6].Value = breakdownview[i].City;
                    excelWorksheet.Cells[rowcounter, 7].Value = breakdownview[i].State;
                    excelWorksheet.Cells[rowcounter, 8].Value = breakdownview[i].Email_Address;
                    rowcounter = rowcounter + 1;
                }                               

                FileInfo excelFile = new FileInfo(Server.MapPath("~/Excelfile2/ViewLogsReport.xlsx"));
                excel.SaveAs(excelFile);                

                try
                {
                    bool isExcelInstalled = Type.GetTypeFromProgID("Excel.Application") != null ? true : false;

                    if (isExcelInstalled)
                    {
                        System.Diagnostics.Process.Start(excelFile.ToString());
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message.ToString());
                    Console.Read();
                }

            }
            return Json(breakdownview, JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult Save(SickeCellclass datavalue)
        {
            List<string> x = new List<string>();
            x.Add(datavalue.ToString());

            try
            {
                string strdata = " ";
                long longdata = 0;
                connection.Open();
                SqlCommand command = connection.CreateCommand();                
                command.CommandText = "Execute Information_Stored_Save @ClientID,@LastName, @FirstName, @Middle_Initial, @UniqueID, @DOB, @Age, @AgeGroup, @Ageat, @Gender,@Race, @Ethnicity, @Eligibility, @SSN, @CountyCode, @CountyCodeDescription, @PhoneNumber, @SickleCellDiagnosis, @FullStreetAddress, @FullStreetAddress2, @City, @State, @ZipCode, @HomePhone, @WorkPhone ,@PMPProviderName, @Specialist, @CCUCase, @Email_Address, @ClientresideinruralID, @Nameofmother, @Address_Of_Mother, @Telephone_Of_Mother, @Nameoffather, @Address_Of_Father, @Telephone_Of_Father, @Nameofguardian, @Address_Of_Guardian, @Guardian_Telephone, @Emergency_Contact1, @Emergency_Contact1_HomePhone , @Emergency_Contact1_CellPhone, @Emergency_Contact2, @Emergency_Contact2_HomePhone, @Emergency_Contact2_CellPhone, @SicklecelltypeID, @Medication, @Medication2, @Medication3, @Medication4, @HydroxyureaheardID, @HydroxyureatakenID, @HydroxyureacurrentlyID, @HydroxyureapasttakenID, @Hydroxyureadosage, @Hydroxyureadosageunknown,@Hydroxyureacapsulescolor, @Hydroxyureadatelasttaken, @Hydroxyureadatepickedup, @Pharma1heardID, @Pharma1takenID, @Pharma1currentlyID, @Pharma1pasttakenID, @Pharma1dosage, @Pharma1dosageunknown, @Pharma1capsulescolor, @Pharma1datelasttaken, @Pharma1datepickedup, @Pharma2heardID, @Pharma2takenID, @Pharma2currentlyID, @Pharma2pasttakenID, @Pharma2dosage, @Pharma2dosageunknown, @Pharma2capsulescolor, @Pharma2datelasttaken, @Pharma2datepickedup, @Pharma3heardID, @Pharma3takenID, @Pharma3currentlyID, @Pharma3pasttakenID, @Pharma3dosage, @Pharma3dosageunknown, @Pharma3capsulescolor, @Pharma3datelasttaken, @Pharma3datepickedup, @Deceased";
                SqlCommand command2 = new SqlCommand("select top 1 ClientID from Information order by ClientID DESC", connection);
                SqlDataReader clientidreader = command2.ExecuteReader();

                if (clientidreader.HasRows == true)
                {
                    while (clientidreader.Read())
                    {
                        strdata = clientidreader[0].ToString();
                        longdata = Convert.ToInt64(strdata);
                        //command.Parameters.Add("@ClientID", SqlDbType.BigInt).Value = longdata + 1;

                        if (datavalue.ClientID == "" || datavalue.ClientID == null)
                        {
                            command.Parameters.Add("@ClientID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@ClientID", SqlDbType.VarChar, 25).Value = datavalue.ClientID;
                        }

                        if (datavalue.LastName == "" || datavalue.LastName == null)
                        {
                            command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = datavalue.LastName;
                        }

                        if (datavalue.FirstName == "" || datavalue.FirstName == null)
                        {
                            command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = datavalue.FirstName;
                        }

                        if (datavalue.Middle_Initial == "" || datavalue.Middle_Initial == null)
                        {
                            command.Parameters.Add("@Middle_Initial", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Middle_Initial", SqlDbType.VarChar, 50).Value = datavalue.Middle_Initial;
                        }

                        if (datavalue.UniqueID == "" || datavalue.UniqueID == null)
                        {
                            command.Parameters.Add("@UniqueID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@UniqueID", SqlDbType.VarChar, 50).Value = datavalue.UniqueID;
                        }

                        if (datavalue.DOB == null)
                        {
                            command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = datavalue.DOB;
                        }

                        if (datavalue.Age == "" || datavalue.Age == null)
                        {
                            command.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = datavalue.Age;
                        }

                        if (datavalue.AgeGroup == "" || datavalue.AgeGroup == null)
                        {
                            command.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 50).Value = datavalue.AgeGroup;
                        }

                        if (datavalue.Ageat == "" || datavalue.Ageat == null)
                        {
                            command.Parameters.Add("@Ageat", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Ageat", SqlDbType.VarChar, 50).Value = datavalue.Ageat;
                        }

                        if (datavalue.Gender == "" || datavalue.Gender == null)
                        {
                            command.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = datavalue.Gender;
                        }

                        if (datavalue.Race == "" || datavalue.Race == null)
                        {
                            command.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = datavalue.Race;
                        }

                        if (datavalue.Ethnicity == "" || datavalue.Ethnicity == null)
                        {
                            command.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 50).Value = datavalue.Ethnicity;
                        }

                        if (datavalue.SSN == "" || datavalue.SSN == null)
                        {
                            command.Parameters.Add("@SSN", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@SSN", SqlDbType.VarChar, 50).Value = datavalue.SSN;
                        }

                        if (datavalue.Eligibility == "" || datavalue.Eligibility == null)
                        {
                            command.Parameters.Add("@Eligibility", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Eligibility", SqlDbType.VarChar, 50).Value = datavalue.Eligibility;
                        }

                        if (datavalue.CountyCode == "" || datavalue.CountyCode == null)
                        {
                            command.Parameters.Add("@CountyCode", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@CountyCode", SqlDbType.VarChar, 50).Value = datavalue.CountyCode;
                        }

                        if (datavalue.CountyCodeDescription == "" || datavalue.CountyCodeDescription == null)
                        {
                            command.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 50).Value = datavalue.CountyCodeDescription;
                        }

                        if (datavalue.PhoneNumber == "" || datavalue.PhoneNumber == null)
                        {
                            command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50).Value = datavalue.PhoneNumber;
                        }

                        if (datavalue.SickleCellDiagnosis == "" || datavalue.SickleCellDiagnosis == null)
                        {
                            command.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 50).Value = datavalue.SickleCellDiagnosis;
                        }

                        if (datavalue.FullStreetAddress == "" || datavalue.FullStreetAddress == null)
                        {
                            command.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 50).Value = datavalue.FullStreetAddress;
                        }

                        if (datavalue.FullStreetAddress2 == "" || datavalue.FullStreetAddress2 == null)
                        {
                            command.Parameters.Add("@FullStreetAddress2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@FullStreetAddress2", SqlDbType.VarChar, 50).Value = datavalue.FullStreetAddress2;
                        }

                        if (datavalue.City == "" || datavalue.City == null)
                        {
                            command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = datavalue.City;
                        }

                        if (datavalue.State == "" || datavalue.State == null)
                        {
                            command.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = datavalue.State;
                        }

                        if (datavalue.ZipCode == "" || datavalue.ZipCode == null)
                        {
                            command.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = datavalue.ZipCode;
                        }

                        if (datavalue.HomePhone == "" || datavalue.HomePhone == null)
                        {
                            command.Parameters.Add("@HomePhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@HomePhone", SqlDbType.VarChar, 50).Value = datavalue.HomePhone;
                        }

                        if (datavalue.WorkPhone == "" || datavalue.WorkPhone == null)
                        {
                            command.Parameters.Add("@WorkPhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@WorkPhone", SqlDbType.VarChar, 50).Value = datavalue.WorkPhone;
                        }

                        if (datavalue.PMPProviderName == "" || datavalue.PMPProviderName == null)
                        {
                            command.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 50).Value = datavalue.PMPProviderName;
                        }

                        if (datavalue.Specialist == "" || datavalue.Specialist == null)
                        {
                            command.Parameters.Add("@Specialist", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Specialist", SqlDbType.VarChar, 50).Value = datavalue.Specialist;
                        }

                        if (datavalue.CCUCase == "" || datavalue.CCUCase == null)
                        {
                            command.Parameters.Add("@CCUCase", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@CCUCase", SqlDbType.VarChar, 50).Value = datavalue.CCUCase;
                        }

                        if (datavalue.Email_Address == "" || datavalue.Email_Address == null)
                        {
                            command.Parameters.Add("@Email_Address", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Email_Address", SqlDbType.VarChar, 50).Value = datavalue.Email_Address;
                        }

                        if (datavalue.ClientresideinruralID == "" || datavalue.ClientresideinruralID == null)
                        {
                            command.Parameters.Add("@ClientresideinruralID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@ClientresideinruralID", SqlDbType.VarChar, 50).Value = datavalue.ClientresideinruralID;
                        }

                        if (datavalue.Nameofmother == "" || datavalue.Nameofmother == null)
                        {
                            command.Parameters.Add("@Nameofmother", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Nameofmother", SqlDbType.VarChar, 50).Value = datavalue.Nameofmother;
                        }

                        if (datavalue.Address_Of_Mother == "" || datavalue.Address_Of_Mother == null)
                        {
                            command.Parameters.Add("@Address_Of_Mother", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Address_Of_Mother", SqlDbType.VarChar, 50).Value = datavalue.Address_Of_Mother;
                        }

                        if (datavalue.Telephone_Of_Mother == "" || datavalue.Telephone_Of_Mother == null)
                        {
                            command.Parameters.Add("@Telephone_Of_Mother", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Telephone_Of_Mother", SqlDbType.VarChar, 50).Value = datavalue.Telephone_Of_Mother;
                        }


                        if (datavalue.Nameoffather == "" || datavalue.Nameoffather == null)
                        {
                            command.Parameters.Add("@Nameoffather", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Nameoffather", SqlDbType.VarChar, 50).Value = datavalue.Nameoffather;
                        }

                        if (datavalue.Address_Of_Father == "" || datavalue.Address_Of_Father == null)
                        {
                            command.Parameters.Add("@Address_Of_Father", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Address_Of_Father", SqlDbType.VarChar, 50).Value = datavalue.Address_Of_Father;
                        }

                        if (datavalue.Telephone_Of_Father == "" || datavalue.Telephone_Of_Father == null)
                        {
                            command.Parameters.Add("@Telephone_Of_Father", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Telephone_Of_Father", SqlDbType.VarChar, 50).Value = datavalue.Telephone_Of_Father;
                        }

                        if (datavalue.Nameofguardian == "" || datavalue.Nameofguardian == null)
                        {
                            command.Parameters.Add("@Nameofguardian", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Nameofguardian", SqlDbType.VarChar, 50).Value = datavalue.Nameofguardian;
                        }

                        if (datavalue.Address_Of_Guardian == "" || datavalue.Address_Of_Guardian == null)
                        {
                            command.Parameters.Add("@Address_Of_Guardian", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Address_Of_Guardian", SqlDbType.VarChar, 50).Value = datavalue.Address_Of_Guardian;
                        }

                        if (datavalue.Guardian_Telephone == "" || datavalue.Guardian_Telephone == null)
                        {
                            command.Parameters.Add("@Guardian_Telephone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Guardian_Telephone", SqlDbType.VarChar, 50).Value = datavalue.Guardian_Telephone;
                        }

                        if (datavalue.Emergency_Contact1 == "" || datavalue.Emergency_Contact1 == null)
                        {
                            command.Parameters.Add("@Emergency_Contact1", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Emergency_Contact1", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact1;
                        }

                        if (datavalue.Emergency_Contact1_HomePhone == "" || datavalue.Emergency_Contact1_HomePhone == null)
                        {
                            command.Parameters.Add("@Emergency_Contact1_HomePhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Emergency_Contact1_HomePhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact1_HomePhone;
                        }

                        if (datavalue.Emergency_Contact1_CellPhone == "" || datavalue.Emergency_Contact1_CellPhone == null)
                        {
                            command.Parameters.Add("@Emergency_Contact1_CellPhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Emergency_Contact1_CellPhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact1_CellPhone;
                        }

                        if (datavalue.Emergency_Contact2 == "" || datavalue.Emergency_Contact2 == null)
                        {
                            command.Parameters.Add("@Emergency_Contact2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Emergency_Contact2", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact2;
                        }

                        if (datavalue.Emergency_Contact2_HomePhone == "" || datavalue.Emergency_Contact2_HomePhone == null)
                        {
                            command.Parameters.Add("@Emergency_Contact2_HomePhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Emergency_Contact2_HomePhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact2_HomePhone;
                        }

                        if (datavalue.Emergency_Contact2_CellPhone == "" || datavalue.Emergency_Contact2_CellPhone == null)
                        {
                            command.Parameters.Add("@Emergency_Contact2_CellPhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Emergency_Contact2_CellPhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact2_CellPhone;
                        }

                        if (datavalue.SicklecelltypeID == "" || datavalue.SicklecelltypeID == null)
                        {
                            command.Parameters.Add("@SicklecelltypeID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@SicklecelltypeID", SqlDbType.VarChar, 50).Value = datavalue.SicklecelltypeID;
                        }

                        if (datavalue.Medication == "" || datavalue.Medication == null)
                        {
                            command.Parameters.Add("@Medication", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Medication", SqlDbType.VarChar, 50).Value = datavalue.Medication;
                        }

                        if (datavalue.Medication2 == "" || datavalue.Medication2 == null)
                        {
                            command.Parameters.Add("@Medication2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Medication2", SqlDbType.VarChar, 50).Value = datavalue.Medication2;
                        }

                        if (datavalue.Medication3 == "" || datavalue.Medication3 == null)
                        {
                            command.Parameters.Add("@Medication3", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Medication3", SqlDbType.VarChar, 50).Value = datavalue.Medication3;
                        }

                        if (datavalue.Medication4 == "" || datavalue.Medication4 == null)
                        {
                            command.Parameters.Add("@Medication4", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Medication4", SqlDbType.VarChar, 50).Value = datavalue.Medication4;
                        }

                        if (datavalue.HydroxyureaheardID == "" || datavalue.HydroxyureaheardID == null)
                        {
                            command.Parameters.Add("@HydroxyureaheardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@HydroxyureaheardID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureaheardID;
                        }

                        if (datavalue.HydroxyureatakenID == "" || datavalue.HydroxyureatakenID == null)
                        {
                            command.Parameters.Add("@HydroxyureatakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@HydroxyureatakenID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureatakenID;
                        }

                        if (datavalue.HydroxyureacurrentlyID == "" || datavalue.HydroxyureacurrentlyID == null)
                        {
                            command.Parameters.Add("@HydroxyureacurrentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@HydroxyureacurrentlyID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureacurrentlyID;
                        }

                        if (datavalue.HydroxyureapasttakenID == "" || datavalue.HydroxyureapasttakenID == null)
                        {
                            command.Parameters.Add("@HydroxyureapasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@HydroxyureapasttakenID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureapasttakenID;
                        }

                        if (datavalue.Hydroxyureadosage == "" || datavalue.Hydroxyureadosage == null)
                        {
                            command.Parameters.Add("@Hydroxyureadosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Hydroxyureadosage", SqlDbType.VarChar, 50).Value = datavalue.Hydroxyureadosage;
                        }

                        if (datavalue.Hydroxyureadosageunknown == "" || datavalue.Hydroxyureadosageunknown == null)
                        {
                            command.Parameters.Add("@Hydroxyureadosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Hydroxyureadosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Hydroxyureadosageunknown;
                        }

                        if (datavalue.Hydroxyureacapsulescolor == "" || datavalue.Hydroxyureacapsulescolor == null)
                        {
                            command.Parameters.Add("@Hydroxyureacapsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Hydroxyureacapsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Hydroxyureacapsulescolor;
                        }

                        if (datavalue.Hydroxyureadatelasttaken == "" || datavalue.Hydroxyureadatelasttaken == null)
                        {
                            command.Parameters.Add("@Hydroxyureadatelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Hydroxyureadatelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Hydroxyureadatelasttaken;
                        }

                        if (datavalue.Hydroxyureadatepickedup == "" || datavalue.Hydroxyureadatepickedup == null)
                        {
                            command.Parameters.Add("@Hydroxyureadatepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Hydroxyureadatepickedup", SqlDbType.VarChar, 10).Value = datavalue.Hydroxyureadatepickedup;
                        }

                        if (datavalue.Pharma1heardID == "" || datavalue.Pharma1heardID == null)
                        {
                            command.Parameters.Add("@Pharma1heardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma1heardID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1heardID;
                        }

                        if (datavalue.Pharma1takenID == "" || datavalue.Pharma1takenID == null)
                        {
                            command.Parameters.Add("@Pharma1takenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma1takenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1takenID;
                        }

                        if (datavalue.Pharma1currentlyID == "" || datavalue.Pharma1currentlyID == null)
                        {
                            command.Parameters.Add("@Pharma1currentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma1currentlyID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1currentlyID;
                        }

                        if (datavalue.Pharma1pasttakenID == "" || datavalue.Pharma1pasttakenID == null)
                        {
                            command.Parameters.Add("@Pharma1pasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma1pasttakenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1pasttakenID;
                        }
                        
                        if (datavalue.Pharma1dosage == "" || datavalue.Pharma1dosage == null)
                        {
                            command.Parameters.Add("@Pharma1dosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma1dosage", SqlDbType.VarChar, 50).Value = datavalue.Pharma1dosage;
                        }

                        if (datavalue.Pharma1dosageunknown == "" || datavalue.Pharma1dosageunknown == null)
                        {
                            command.Parameters.Add("@Pharma1dosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma1dosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Pharma1dosageunknown;
                        }

                        if (datavalue.Pharma1capsulescolor == "" || datavalue.Pharma1capsulescolor == null)
                        {
                            command.Parameters.Add("@Pharma1capsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma1capsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Pharma1capsulescolor;
                        }

                        if (datavalue.Pharma1datelasttaken == "" || datavalue.Pharma1datelasttaken == null)
                        {
                            command.Parameters.Add("@Pharma1datelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma1datelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Pharma1datelasttaken;
                        }

                        if (datavalue.Pharma1datepickedup == "" || datavalue.Pharma1datepickedup == null)
                        {
                            command.Parameters.Add("@Pharma1datepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma1datepickedup", SqlDbType.VarChar, 10).Value = datavalue.Pharma1datepickedup;
                        }

                        if (datavalue.Pharma2heardID == "" || datavalue.Pharma2heardID == null)
                        {
                            command.Parameters.Add("@Pharma2heardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma2heardID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2heardID;
                        }

                        if (datavalue.Pharma2takenID == "" || datavalue.Pharma2takenID == null)
                        {
                            command.Parameters.Add("@Pharma2takenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma2takenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2takenID;
                        }

                        if (datavalue.Pharma2currentlyID == "" || datavalue.Pharma2currentlyID == null)
                        {
                            command.Parameters.Add("@Pharma2currentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma2currentlyID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2currentlyID;
                        }

                        if (datavalue.Pharma2pasttakenID == "" || datavalue.Pharma2pasttakenID == null)
                        {
                            command.Parameters.Add("@Pharma2pasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma2pasttakenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2pasttakenID;
                        }

                        if (datavalue.Pharma2dosage == "" || datavalue.Pharma2dosage == null)
                        {
                            command.Parameters.Add("@Pharma2dosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma2dosage", SqlDbType.VarChar, 50).Value = datavalue.Pharma2dosage;
                        }

                        if (datavalue.Pharma2dosageunknown == "" || datavalue.Pharma2dosageunknown == null)
                        {
                            command.Parameters.Add("@Pharma2dosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma2dosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Pharma2dosageunknown;
                        }

                        if (datavalue.Pharma2capsulescolor == "" || datavalue.Pharma2capsulescolor == null)
                        {
                            command.Parameters.Add("@Pharma2capsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma2capsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Pharma2capsulescolor;
                        }

                        if (datavalue.Pharma2datelasttaken == "" || datavalue.Pharma2datelasttaken == null)
                        {
                            command.Parameters.Add("@Pharma2datelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma2datelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Pharma2datelasttaken;
                        }

                        if (datavalue.Pharma2datepickedup == "" || datavalue.Pharma2datepickedup == null)
                        {
                            command.Parameters.Add("@Pharma2datepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma2datepickedup", SqlDbType.VarChar, 10).Value = datavalue.Pharma2datepickedup;
                        }

                        if (datavalue.Pharma3heardID == "" || datavalue.Pharma3heardID == null)
                        {
                            command.Parameters.Add("@Pharma3heardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma3heardID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3heardID;
                        }

                        if (datavalue.Pharma3takenID == "" || datavalue.Pharma3takenID == null)
                        {
                            command.Parameters.Add("@Pharma3takenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma3takenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3takenID;
                        }

                        if (datavalue.Pharma3currentlyID == "" || datavalue.Pharma3currentlyID == null)
                        {
                            command.Parameters.Add("@Pharma3currentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma3currentlyID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3currentlyID;
                        }

                        if (datavalue.Pharma3pasttakenID == "" || datavalue.Pharma3pasttakenID == null)
                        {
                            command.Parameters.Add("@Pharma3pasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma3pasttakenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3pasttakenID;
                        }

                        if (datavalue.Pharma3dosage == "" || datavalue.Pharma3dosage == null)
                        {
                            command.Parameters.Add("@Pharma3dosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma3dosage", SqlDbType.VarChar, 50).Value = datavalue.Pharma3dosage;
                        }

                        if (datavalue.Pharma3dosageunknown == "" || datavalue.Pharma3dosageunknown == null)
                        {
                            command.Parameters.Add("@Pharma3dosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma3dosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Pharma3dosageunknown;
                        }

                        if (datavalue.Pharma3capsulescolor == "" || datavalue.Pharma3capsulescolor == null)
                        {
                            command.Parameters.Add("@Pharma3capsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma3capsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Pharma3capsulescolor;
                        }

                        if (datavalue.Pharma3datelasttaken == "" || datavalue.Pharma3datelasttaken == null)
                        {
                            command.Parameters.Add("@Pharma3datelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma3datelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Pharma3datelasttaken;
                        }

                        if (datavalue.Pharma3datepickedup == "" || datavalue.Pharma3datepickedup == null)
                        {
                            command.Parameters.Add("@Pharma3datepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Pharma3datepickedup", SqlDbType.VarChar, 10).Value = datavalue.Pharma3datepickedup;
                        }

                        if (datavalue.Deceased == "" || datavalue.Deceased == null)
                        {
                            command.Parameters.Add("@Deceased", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Deceased", SqlDbType.VarChar, 50).Value = datavalue.Deceased;
                        }
                    }
                    clientidreader.Close();
                }
                //this is ThemeableAttribute condition for the first entry
                else
                {
                    //command.Parameters.Add("@ClientID", SqlDbType.BigInt).Value = longdata + 1;
                    if (datavalue.ClientID =="" || datavalue.ClientID == null)
                    {
                        command.Parameters.Add("@ClientID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@ClientID", SqlDbType.VarChar, 25).Value = datavalue.ClientID;
                    }

                    if (datavalue.LastName == "" || datavalue.LastName == null)
                    {
                        command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = datavalue.LastName;
                    }

                    if (datavalue.FirstName == "" || datavalue.FirstName == null)
                    {
                        command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = datavalue.FirstName;
                    }

                    if (datavalue.Middle_Initial == "" || datavalue.Middle_Initial == null)
                    {
                        command.Parameters.Add("@Middle_Initial", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Middle_Initial", SqlDbType.VarChar, 50).Value = datavalue.Middle_Initial;
                    }

                    if (datavalue.UniqueID == "" || datavalue.UniqueID == null)
                    {
                        command.Parameters.Add("@UniqueID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@UniqueID", SqlDbType.VarChar, 50).Value = datavalue.UniqueID;
                    }

                    if (datavalue.DOB == null)
                    {
                        command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = datavalue.DOB;
                    }

                    if (datavalue.Age == "" || datavalue.Age == null)
                    {
                        command.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = datavalue.Age;
                    }

                    if (datavalue.AgeGroup == "" || datavalue.AgeGroup == null)
                    {
                        command.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 50).Value = datavalue.AgeGroup;
                    }

                    if (datavalue.Ageat == "" || datavalue.Ageat == null)
                    {
                        command.Parameters.Add("@Ageat", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Ageat", SqlDbType.VarChar, 50).Value = datavalue.Ageat;
                    }

                    if (datavalue.Gender == "" || datavalue.Gender == null)
                    {
                        command.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = datavalue.Gender;
                    }

                    if (datavalue.Race == "" || datavalue.Race == null)
                    {
                        command.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = datavalue.Race;
                    }

                    if (datavalue.Ethnicity == "" || datavalue.Ethnicity == null)
                    {
                        command.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 50).Value = datavalue.Ethnicity;
                    }

                    if (datavalue.SSN == "" || datavalue.SSN == null)
                    {
                        command.Parameters.Add("@SSN", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@SSN", SqlDbType.VarChar, 50).Value = datavalue.SSN;
                    }

                    if (datavalue.Eligibility == "" || datavalue.Eligibility == null)
                    {
                        command.Parameters.Add("@Eligibility", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Eligibility", SqlDbType.VarChar, 50).Value = datavalue.Eligibility;
                    }

                    if (datavalue.CountyCode == "" || datavalue.CountyCode == null)
                    {
                        command.Parameters.Add("@CountyCode", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@CountyCode", SqlDbType.VarChar, 50).Value = datavalue.CountyCode;
                    }

                    if (datavalue.CountyCodeDescription == "" || datavalue.CountyCodeDescription == null)
                    {
                        command.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 50).Value = datavalue.CountyCodeDescription;
                    }

                    if (datavalue.PhoneNumber == "" || datavalue.PhoneNumber == null)
                    {
                        command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50).Value = datavalue.PhoneNumber;
                    }

                    if (datavalue.SickleCellDiagnosis == "" || datavalue.SickleCellDiagnosis == null)
                    {
                        command.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 50).Value = datavalue.SickleCellDiagnosis;
                    }

                    if (datavalue.FullStreetAddress == "" || datavalue.FullStreetAddress == null)
                    {
                        command.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 50).Value = datavalue.FullStreetAddress;
                    }

                    if (datavalue.FullStreetAddress2 == "" || datavalue.FullStreetAddress2 == null)
                    {
                        command.Parameters.Add("@FullStreetAddress2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@FullStreetAddress2", SqlDbType.VarChar, 50).Value = datavalue.FullStreetAddress2;
                    }

                    if (datavalue.City == "" || datavalue.City == null)
                    {
                        command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = datavalue.City;
                    }

                    if (datavalue.State == "" || datavalue.State == null)
                    {
                        command.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = datavalue.State;
                    }

                    if (datavalue.ZipCode == "" || datavalue.ZipCode == null)
                    {
                        command.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = datavalue.ZipCode;
                    }

                    if (datavalue.HomePhone == "" || datavalue.HomePhone == null)
                    {
                        command.Parameters.Add("@HomePhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@HomePhone", SqlDbType.VarChar, 50).Value = datavalue.HomePhone;
                    }

                    if (datavalue.WorkPhone == "" || datavalue.WorkPhone == null)
                    {
                        command.Parameters.Add("@WorkPhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@WorkPhone", SqlDbType.VarChar, 50).Value = datavalue.WorkPhone;
                    }

                    if (datavalue.PMPProviderName == "" || datavalue.PMPProviderName == null)
                    {
                        command.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 50).Value = datavalue.PMPProviderName;
                    }

                    if (datavalue.Specialist == "" || datavalue.Specialist == null)
                    {
                        command.Parameters.Add("@Specialist", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Specialist", SqlDbType.VarChar, 50).Value = datavalue.Specialist;
                    }

                    if (datavalue.CCUCase == "" || datavalue.CCUCase == null)
                    {
                        command.Parameters.Add("@CCUCase", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@CCUCase", SqlDbType.VarChar, 50).Value = datavalue.CCUCase;
                    }

                    if (datavalue.Email_Address == "" || datavalue.Email_Address == null)
                    {
                        command.Parameters.Add("@Email_Address", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Email_Address", SqlDbType.VarChar, 50).Value = datavalue.Email_Address;
                    }

                    if (datavalue.ClientresideinruralID == "" || datavalue.ClientresideinruralID == null)
                    {
                        command.Parameters.Add("@ClientresideinruralID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@ClientresideinruralID", SqlDbType.VarChar, 50).Value = datavalue.ClientresideinruralID;
                    }

                    if (datavalue.Nameofmother == "" || datavalue.Nameofmother == null)
                    {
                        command.Parameters.Add("@Nameofmother", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Nameofmother", SqlDbType.VarChar, 50).Value = datavalue.Nameofmother;
                    }

                    if (datavalue.Address_Of_Mother == "" || datavalue.Address_Of_Mother == null)
                    {
                        command.Parameters.Add("@Address_Of_Mother", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Address_Of_Mother", SqlDbType.VarChar, 50).Value = datavalue.Address_Of_Mother;
                    }

                    if (datavalue.Telephone_Of_Mother == "" || datavalue.Telephone_Of_Mother == null)
                    {
                        command.Parameters.Add("@Telephone_Of_Mother", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Telephone_Of_Mother", SqlDbType.VarChar, 50).Value = datavalue.Telephone_Of_Mother;
                    }

                    if (datavalue.Nameoffather == "" || datavalue.Nameoffather == null)
                    {
                        command.Parameters.Add("@Nameoffather", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Nameoffather", SqlDbType.VarChar, 50).Value = datavalue.Nameoffather;
                    }

                    if (datavalue.Address_Of_Father == "" || datavalue.Address_Of_Father == null)
                    {
                        command.Parameters.Add("@Address_Of_Father", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Address_Of_Father", SqlDbType.VarChar, 50).Value = datavalue.Address_Of_Father;
                    }

                    if (datavalue.Telephone_Of_Father == "" || datavalue.Telephone_Of_Father == null)
                    {
                        command.Parameters.Add("@Telephone_Of_Father", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Telephone_Of_Father", SqlDbType.VarChar, 50).Value = datavalue.Telephone_Of_Father;
                    }

                    if (datavalue.Nameofguardian == "" || datavalue.Nameofguardian == null)
                    {
                        command.Parameters.Add("@Nameofguardian", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Nameofguardian", SqlDbType.VarChar, 50).Value = datavalue.Nameofguardian;
                    }

                    if (datavalue.Address_Of_Guardian == "" || datavalue.Address_Of_Guardian == null)
                    {
                        command.Parameters.Add("@Address_Of_Guardian", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Address_Of_Guardian", SqlDbType.VarChar, 50).Value = datavalue.Address_Of_Guardian;
                    }

                    if (datavalue.Guardian_Telephone == "" || datavalue.Guardian_Telephone == null)
                    {
                        command.Parameters.Add("@Guardian_Telephone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Guardian_Telephone", SqlDbType.VarChar, 50).Value = datavalue.Guardian_Telephone;
                    }

                    if (datavalue.Emergency_Contact1 == "" || datavalue.Emergency_Contact1 == null)
                    {
                        command.Parameters.Add("@Emergency_Contact1", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Emergency_Contact1", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact1;
                    }

                    if (datavalue.Emergency_Contact1_HomePhone == "" || datavalue.Emergency_Contact1_HomePhone == null)
                    {
                        command.Parameters.Add("@Emergency_Contact1_HomePhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Emergency_Contact1_HomePhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact1_HomePhone;
                    }

                    if (datavalue.Emergency_Contact1_CellPhone == "" || datavalue.Emergency_Contact1_CellPhone == null)
                    {
                        command.Parameters.Add("@Emergency_Contact1_CellPhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Emergency_Contact1_CellPhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact1_CellPhone;
                    }

                    if (datavalue.Emergency_Contact2 == "" || datavalue.Emergency_Contact2 == null)
                    {
                        command.Parameters.Add("@Emergency_Contact2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Emergency_Contact2", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact2;
                    }

                    if (datavalue.Emergency_Contact2_HomePhone == "" || datavalue.Emergency_Contact2_HomePhone == null)
                    {
                        command.Parameters.Add("@Emergency_Contact2_HomePhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Emergency_Contact2_HomePhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact2_HomePhone;
                    }

                    if (datavalue.Emergency_Contact2_CellPhone == "" || datavalue.Emergency_Contact2_CellPhone == null)
                    {
                        command.Parameters.Add("@Emergency_Contact2_CellPhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Emergency_Contact2_CellPhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact2_CellPhone;
                    }

                    if (datavalue.SicklecelltypeID == "" || datavalue.SicklecelltypeID == null)
                    {
                        command.Parameters.Add("@SicklecelltypeID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@SicklecelltypeID", SqlDbType.VarChar, 50).Value = datavalue.SicklecelltypeID;
                    }

                    if (datavalue.Medication == "" || datavalue.Medication == null)
                    {
                        command.Parameters.Add("@Medication", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Medication", SqlDbType.VarChar, 50).Value = datavalue.Medication;
                    }

                    if (datavalue.Medication2 == "" || datavalue.Medication2 == null)
                    {
                        command.Parameters.Add("@Medication2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Medication2", SqlDbType.VarChar, 50).Value = datavalue.Medication2;
                    }

                    if (datavalue.Medication3 == "" || datavalue.Medication3 == null)
                    {
                        command.Parameters.Add("@Medication3", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Medication3", SqlDbType.VarChar, 50).Value = datavalue.Medication3;
                    }

                    if (datavalue.Medication4 == "" || datavalue.Medication4 == null)
                    {
                        command.Parameters.Add("@Medication4", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Medication4", SqlDbType.VarChar, 50).Value = datavalue.Medication4;
                    }

                    if (datavalue.HydroxyureaheardID == "" || datavalue.HydroxyureaheardID == null)
                    {
                        command.Parameters.Add("@HydroxyureaheardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@HydroxyureaheardID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureaheardID;
                    }

                    if (datavalue.HydroxyureatakenID == "" || datavalue.HydroxyureatakenID == null)
                    {
                        command.Parameters.Add("@HydroxyureatakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@HydroxyureatakenID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureatakenID;
                    }

                    if (datavalue.HydroxyureacurrentlyID == "" || datavalue.HydroxyureacurrentlyID == null)
                    {
                        command.Parameters.Add("@HydroxyureacurrentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@HydroxyureacurrentlyID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureacurrentlyID;
                    }

                    if (datavalue.HydroxyureapasttakenID == "" || datavalue.HydroxyureapasttakenID == null)
                    {
                        command.Parameters.Add("@HydroxyureapasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@HydroxyureapasttakenID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureapasttakenID;
                    }

                    if (datavalue.Hydroxyureadosage == "" || datavalue.Hydroxyureadosage == null)
                    {
                        command.Parameters.Add("@Hydroxyureadosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Hydroxyureadosage", SqlDbType.VarChar, 50).Value = datavalue.Hydroxyureadosage;
                    }

                    if (datavalue.Hydroxyureadosageunknown == "" || datavalue.Hydroxyureadosageunknown == null)
                    {
                        command.Parameters.Add("@Hydroxyureadosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Hydroxyureadosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Hydroxyureadosageunknown;
                    }

                    if (datavalue.Hydroxyureacapsulescolor == "" || datavalue.Hydroxyureacapsulescolor == null)
                    {
                        command.Parameters.Add("@Hydroxyureacapsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Hydroxyureacapsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Hydroxyureacapsulescolor;
                    }

                    if (datavalue.Hydroxyureadatelasttaken == "" || datavalue.Hydroxyureadatelasttaken == null)
                    {
                        command.Parameters.Add("@Hydroxyureadatelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Hydroxyureadatelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Hydroxyureadatelasttaken;
                    }

                    if (datavalue.Hydroxyureadatepickedup == "" || datavalue.Hydroxyureadatepickedup == null)
                    {
                        command.Parameters.Add("@Hydroxyureadatepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Hydroxyureadatepickedup", SqlDbType.VarChar, 10).Value = datavalue.Hydroxyureadatepickedup;
                    }

                    if (datavalue.Pharma1heardID == "" || datavalue.Pharma1heardID == null)
                    {
                        command.Parameters.Add("@Pharma1heardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma1heardID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1heardID;
                    }

                    if (datavalue.Pharma1takenID == "" || datavalue.Pharma1takenID == null)
                    {
                        command.Parameters.Add("@Pharma1takenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma1takenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1takenID;
                    }

                    if (datavalue.Pharma1currentlyID == "" || datavalue.Pharma1currentlyID == null)
                    {
                        command.Parameters.Add("@Pharma1currentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma1currentlyID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1currentlyID;
                    }

                    if (datavalue.Pharma1pasttakenID == "" || datavalue.Pharma1pasttakenID == null)
                    {
                        command.Parameters.Add("@Pharma1pasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma1pasttakenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1pasttakenID;
                    }

                    if (datavalue.Pharma1dosage == "" || datavalue.Pharma1dosage == null)
                    {
                        command.Parameters.Add("@Pharma1dosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma1dosage", SqlDbType.VarChar, 50).Value = datavalue.Pharma1dosage;
                    }

                    if (datavalue.Pharma1dosageunknown == "" || datavalue.Pharma1dosageunknown == null)
                    {
                        command.Parameters.Add("@Pharma1dosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma1dosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Pharma1dosageunknown;
                    }

                    if (datavalue.Pharma1capsulescolor == "" || datavalue.Pharma1capsulescolor == null)
                    {
                        command.Parameters.Add("@Pharma1capsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma1capsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Pharma1capsulescolor;
                    }

                    if (datavalue.Pharma1datelasttaken == "" || datavalue.Pharma1datelasttaken == null)
                    {
                        command.Parameters.Add("@Pharma1datelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma1datelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Pharma1datelasttaken;
                    }

                    if (datavalue.Pharma1datepickedup == "" || datavalue.Pharma1datepickedup == null)
                    {
                        command.Parameters.Add("@Pharma1datepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma1datepickedup", SqlDbType.VarChar, 10).Value = datavalue.Pharma1datepickedup;
                    }

                    if (datavalue.Pharma2heardID == "" || datavalue.Pharma2heardID == null)
                    {
                        command.Parameters.Add("@Pharma2heardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma2heardID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2heardID;
                    }

                    if (datavalue.Pharma2takenID == "" || datavalue.Pharma2takenID == null)
                    {
                        command.Parameters.Add("@Pharma2takenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma2takenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2takenID;
                    }

                    if (datavalue.Pharma2currentlyID == "" || datavalue.Pharma2currentlyID == null)
                    {
                        command.Parameters.Add("@Pharma2currentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma2currentlyID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2currentlyID;
                    }

                    if (datavalue.Pharma2pasttakenID == "" || datavalue.Pharma2pasttakenID == null)
                    {
                        command.Parameters.Add("@Pharma2pasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma2pasttakenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2pasttakenID;
                    }

                    if (datavalue.Pharma2dosage == "" || datavalue.Pharma2dosage == null)
                    {
                        command.Parameters.Add("@Pharma2dosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma2dosage", SqlDbType.VarChar, 50).Value = datavalue.Pharma2dosage;
                    }

                    if (datavalue.Pharma2dosageunknown == "" || datavalue.Pharma2dosageunknown == null)
                    {
                        command.Parameters.Add("@Pharma2dosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma2dosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Pharma2dosageunknown;
                    }

                    if (datavalue.Pharma2capsulescolor == "" || datavalue.Pharma2capsulescolor == null)
                    {
                        command.Parameters.Add("@Pharma2capsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma2capsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Pharma2capsulescolor;
                    }

                    if (datavalue.Pharma2datelasttaken == "" || datavalue.Pharma2datelasttaken == null)
                    {
                        command.Parameters.Add("@Pharma2datelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma2datelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Pharma2datelasttaken;
                    }

                    if (datavalue.Pharma2datepickedup == "" || datavalue.Pharma2datepickedup == null)
                    {
                        command.Parameters.Add("@Pharma2datepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma2datepickedup", SqlDbType.VarChar, 10).Value = datavalue.Pharma2datepickedup;
                    }

                    if (datavalue.Pharma3heardID == "" || datavalue.Pharma3heardID == null)
                    {
                        command.Parameters.Add("@Pharma3heardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma3heardID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3heardID;
                    }

                    if (datavalue.Pharma3takenID == "" || datavalue.Pharma3takenID == null)
                    {
                        command.Parameters.Add("@Pharma3takenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma3takenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3takenID;
                    }

                    if (datavalue.Pharma3currentlyID == "" || datavalue.Pharma3currentlyID == null)
                    {
                        command.Parameters.Add("@Pharma3currentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma3currentlyID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3currentlyID;
                    }

                    if (datavalue.Pharma3pasttakenID == "" || datavalue.Pharma3pasttakenID == null)
                    {
                        command.Parameters.Add("@Pharma3pasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma3pasttakenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3pasttakenID;
                    }

                    if (datavalue.Pharma3dosage == "" || datavalue.Pharma3dosage == null)
                    {
                        command.Parameters.Add("@Pharma3dosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma3dosage", SqlDbType.VarChar, 50).Value = datavalue.Pharma3dosage;
                    }

                    if (datavalue.Pharma3dosageunknown == "" || datavalue.Pharma3dosageunknown == null)
                    {
                        command.Parameters.Add("@Pharma3dosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma3dosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Pharma3dosageunknown;
                    }

                    if (datavalue.Pharma3capsulescolor == "" || datavalue.Pharma3capsulescolor == null)
                    {
                        command.Parameters.Add("@Pharma3capsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma3capsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Pharma3capsulescolor;
                    }

                    if (datavalue.Pharma3datelasttaken == "" || datavalue.Pharma3datelasttaken == null)
                    {
                        command.Parameters.Add("@Pharma3datelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma3datelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Pharma3datelasttaken;
                    }

                    if (datavalue.Pharma3datepickedup == "" || datavalue.Pharma3datepickedup == null)
                    {
                        command.Parameters.Add("@Pharma3datepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Pharma3datepickedup", SqlDbType.VarChar, 10).Value = datavalue.Pharma3datepickedup;
                    }

                    if (datavalue.Deceased == "" || datavalue.Deceased == null)
                    {
                        command.Parameters.Add("@Deceased", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Deceased", SqlDbType.VarChar, 50).Value = datavalue.Deceased;
                    }
                    clientidreader.Close();
                }
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception err)
            {
                err.Message.ToString();
            }

            return Json(x);
        }

        [HttpPost]
        // POST: Search/Edit/5
        public ActionResult Select(SickeCellclass selected)
        {
            connection.Open();

            List<SickeCellclass> selecteddata = new List<SickeCellclass>();
            SickeCellclass selecteddatagroup = new SickeCellclass();           

            try
            {
               CheckexistingFullName();
               IEnumerable<SickeCellclass> CheckexistingFullName()
               {
                    if (selected.FirstName==null)
                    {
                        //SqlCommand searchfullname = new SqlCommand("SisckeCell_Stored_Search", connection);
                        SqlCommand searchfullname = new SqlCommand("SickeCell_Stored_Search_idx", connection);
                        searchfullname.CommandType = CommandType.StoredProcedure;
                        searchfullname.Parameters.Add("@Clientidx", SqlDbType.VarChar).Value = selected.ClientID;
                        SqlDataReader searchfullnamereader = searchfullname.ExecuteReader();

                        if (searchfullnamereader.HasRows == true)
                        {
                            while (searchfullnamereader.Read())
                            {                                
                                selecteddatagroup.ClientID = searchfullnamereader["ClientID"].ToString();
                                selecteddatagroup.LastName = searchfullnamereader["LastName"].ToString();
                                selecteddatagroup.FirstName = searchfullnamereader["FirstName"].ToString();
                                selecteddatagroup.Middle_Initial = searchfullnamereader["Middle_Initial"].ToString();
                                selecteddatagroup.UniqueID = searchfullnamereader["UniqueID"].ToString();
                                selecteddatagroup.DOB = searchfullnamereader["DOB"].ToString();
                                selecteddatagroup.Age = searchfullnamereader["Age"].ToString();
                                selecteddatagroup.AgeGroup = searchfullnamereader["AgeGroup"].ToString();
                                selecteddatagroup.Ageat = searchfullnamereader["Ageat"].ToString();
                                selecteddatagroup.Gender = searchfullnamereader["Gender"].ToString();
                                selecteddatagroup.Race = searchfullnamereader["Race"].ToString();
                                selecteddatagroup.Ethnicity = searchfullnamereader["Ethnicity"].ToString();
                                selecteddatagroup.Eligibility = searchfullnamereader["Eligibility"].ToString();
                                selecteddatagroup.SSN = searchfullnamereader["SSN"].ToString();
                                selecteddatagroup.CountyCode = searchfullnamereader["CountyCode"].ToString();
                                selecteddatagroup.CountyCodeDescription = searchfullnamereader["CountyCodeDescription"].ToString();
                                selecteddatagroup.PhoneNumber = searchfullnamereader["PhoneNumber"].ToString();
                                selecteddatagroup.SickleCellDiagnosis = searchfullnamereader["SickleCellDiagnosis"].ToString();
                                selecteddatagroup.FullStreetAddress = searchfullnamereader["FullStreetAddress"].ToString();
                                selecteddatagroup.FullStreetAddress2 = searchfullnamereader["FullStreetAddress2"].ToString();
                                selecteddatagroup.City = searchfullnamereader["City"].ToString();
                                selecteddatagroup.State = searchfullnamereader["State"].ToString();
                                selecteddatagroup.ZipCode = searchfullnamereader["ZipCode"].ToString();
                                selecteddatagroup.HomePhone = searchfullnamereader["HomePhone"].ToString();
                                selecteddatagroup.WorkPhone = searchfullnamereader["WorkPhone"].ToString();
                                selecteddatagroup.PMPProviderName = searchfullnamereader["PMPProviderName"].ToString();
                                selecteddatagroup.Specialist = searchfullnamereader["Specialist"].ToString();
                                selecteddatagroup.CCUCase = searchfullnamereader["CCUCase"].ToString();
                                selecteddatagroup.Email_Address = searchfullnamereader["Email_Address"].ToString();
                                selecteddatagroup.ClientresideinruralID = searchfullnamereader["ClientresideinruralID"].ToString();
                                selecteddatagroup.Nameofmother = searchfullnamereader["Nameofmother"].ToString();
                                selecteddatagroup.Address_Of_Mother = searchfullnamereader["Address_Of_Mother"].ToString();
                                selecteddatagroup.Telephone_Of_Mother = searchfullnamereader["Telephone_Of_Mother"].ToString();
                                selecteddatagroup.Nameoffather = searchfullnamereader["Nameoffather"].ToString();
                                selecteddatagroup.Address_Of_Father = searchfullnamereader["Address_Of_Father"].ToString();
                                selecteddatagroup.Telephone_Of_Father = searchfullnamereader["Telephone_Of_Father"].ToString();
                                selecteddatagroup.Nameofguardian = searchfullnamereader["Nameofguardian"].ToString();
                                selecteddatagroup.Address_Of_Guardian = searchfullnamereader["Address_Of_Guardian"].ToString();
                                selecteddatagroup.Guardian_Telephone = searchfullnamereader["Guardian_Telephone"].ToString();
                                selecteddatagroup.Emergency_Contact1 = searchfullnamereader["Emergency_Contact1"].ToString();
                                selecteddatagroup.Emergency_Contact1_HomePhone = searchfullnamereader["Emergency_Contact1_HomePhone"].ToString();
                                selecteddatagroup.Emergency_Contact1_CellPhone = searchfullnamereader["Emergency_Contact1_CellPhone"].ToString();
                                selecteddatagroup.Emergency_Contact2 = searchfullnamereader["Emergency_Contact2"].ToString();
                                selecteddatagroup.Emergency_Contact2_HomePhone = searchfullnamereader["Emergency_Contact2_HomePhone"].ToString();
                                selecteddatagroup.Emergency_Contact2_CellPhone = searchfullnamereader["Emergency_Contact2_CellPhone"].ToString();
                                selecteddatagroup.SicklecelltypeID = searchfullnamereader["SicklecelltypeID"].ToString();
                                selecteddatagroup.Medication = searchfullnamereader["Medication"].ToString();
                                selecteddatagroup.Medication2 = searchfullnamereader["Medication2"].ToString();
                                selecteddatagroup.Medication3 = searchfullnamereader["Medication3"].ToString();
                                selecteddatagroup.Medication4 = searchfullnamereader["Medication4"].ToString();
                                selecteddatagroup.HydroxyureaheardID = searchfullnamereader["HydroxyureaheardID"].ToString();
                                selecteddatagroup.HydroxyureatakenID = searchfullnamereader["HydroxyureatakenID"].ToString();
                                selecteddatagroup.HydroxyureacurrentlyID = searchfullnamereader["HydroxyureacurrentlyID"].ToString();
                                selecteddatagroup.HydroxyureapasttakenID = searchfullnamereader["HydroxyureapasttakenID"].ToString();
                                selecteddatagroup.Hydroxyureadosage = searchfullnamereader["Hydroxyureadosage"].ToString();
                                selecteddatagroup.Hydroxyureadosageunknown = searchfullnamereader["Hydroxyureadosageunknown"].ToString();
                                selecteddatagroup.Hydroxyureacapsulescolor = searchfullnamereader["Hydroxyureacapsulescolor"].ToString();
                                selecteddatagroup.Hydroxyureadatelasttaken = searchfullnamereader["Hydroxyureadatelasttaken"].ToString();
                                selecteddatagroup.Hydroxyureadatepickedup  = searchfullnamereader["Hydroxyureadatepickedup"].ToString();
                                selecteddatagroup.Pharma1heardID = searchfullnamereader["Pharma1heardID"].ToString();
                                selecteddatagroup.Pharma1takenID = searchfullnamereader["Pharma1takenID"].ToString();
                                selecteddatagroup.Pharma1currentlyID = searchfullnamereader["Pharma1currentlyID"].ToString();
                                selecteddatagroup.Pharma1pasttakenID = searchfullnamereader["Pharma1pasttakenID"].ToString();
                                selecteddatagroup.Pharma1dosage = searchfullnamereader["Pharma1dosage"].ToString();
                                selecteddatagroup.Pharma1dosageunknown = searchfullnamereader["Pharma1dosageunknown"].ToString();
                                selecteddatagroup.Pharma1capsulescolor = searchfullnamereader["Pharma1capsulescolor"].ToString();
                                selecteddatagroup.Pharma1datelasttaken = searchfullnamereader["Pharma1datelasttaken"].ToString();
                                selecteddatagroup.Pharma1datepickedup = searchfullnamereader["Pharma1datepickedup"].ToString();
                                selecteddatagroup.Pharma2heardID = searchfullnamereader["Pharma2heardID"].ToString();
                                selecteddatagroup.Pharma2takenID = searchfullnamereader["Pharma2takenID"].ToString();
                                selecteddatagroup.Pharma2currentlyID = searchfullnamereader["Pharma2currentlyID"].ToString();
                                selecteddatagroup.Pharma2pasttakenID = searchfullnamereader["Pharma2pasttakenID"].ToString();
                                selecteddatagroup.Pharma2dosage = searchfullnamereader["Pharma2dosage"].ToString();
                                selecteddatagroup.Pharma2dosageunknown = searchfullnamereader["Pharma2dosageunknown"].ToString();
                                selecteddatagroup.Pharma2capsulescolor = searchfullnamereader["Pharma2capsulescolor"].ToString();
                                selecteddatagroup.Pharma2datelasttaken = searchfullnamereader["Pharma2datelasttaken"].ToString();
                                selecteddatagroup.Pharma2datepickedup = searchfullnamereader["Pharma2datepickedup"].ToString();
                                selecteddatagroup.Pharma3heardID = searchfullnamereader["Pharma3heardID"].ToString();
                                selecteddatagroup.Pharma3takenID = searchfullnamereader["Pharma3takenID"].ToString();
                                selecteddatagroup.Pharma3currentlyID = searchfullnamereader["Pharma3currentlyID"].ToString();
                                selecteddatagroup.Pharma3pasttakenID = searchfullnamereader["Pharma3pasttakenID"].ToString();
                                selecteddatagroup.Pharma3dosage = searchfullnamereader["Pharma3dosage"].ToString();
                                selecteddatagroup.Pharma3dosageunknown = searchfullnamereader["Pharma3dosageunknown"].ToString();
                                selecteddatagroup.Pharma3capsulescolor = searchfullnamereader["Pharma3capsulescolor"].ToString();
                                selecteddatagroup.Pharma3datelasttaken = searchfullnamereader["Pharma3datelasttaken"].ToString();
                                selecteddatagroup.Pharma3datepickedup = searchfullnamereader["Pharma3datepickedup"].ToString();
                                selecteddatagroup.PhoneNumber = searchfullnamereader["PhoneNumber"].ToString().Trim();
                                selecteddatagroup.Comments = searchfullnamereader["Comments"].ToString();
                                selecteddatagroup.Deceased = searchfullnamereader["Deceased"].ToString();

                                selecteddata.Add(selecteddatagroup);

                                searchfullnamereader.Close();
                                connection.Close();
                                return selecteddata;
                            }
                        }
                        else
                        {                            
                                    searchfullnamereader.Close();                            
                                    SqlCommand refcmd = new SqlCommand("select ClientID, FirstName, LastName, DOB, Age, AgeGroup, Race, Gender, Ethnicity, FullStreetAddress, "+
                                               "City, State, ZipCode, HomePhone, WorkPhone, CountyCode, CountyCodeDescription, PhoneNumber, Eligibility, SickleCellDiagnosis, PMPProviderName, " +
                                               "CCUCase, Email_Address from Information where ClientID= '" + selected.Clientseacrh + "' ", connection);
                                    SqlDataReader referencereader = refcmd.ExecuteReader();
                                    if (referencereader.HasRows == true)
                                    {
                                         while (referencereader.Read())
                                         {
                                                selecteddatagroup.ClientID = referencereader["ClientID"].ToString();
                                                selecteddatagroup.FirstName = referencereader["FirstName"].ToString();
                                                selecteddatagroup.LastName = referencereader["LastName"].ToString();
                                                selecteddatagroup.DOB = referencereader["DOB"].ToString();
                                                selecteddatagroup.Age = referencereader["Age"].ToString();
                                                selecteddatagroup.AgeGroup = referencereader["AgeGroup"].ToString();
                                                selecteddatagroup.Race = referencereader["Race"].ToString();
                                                selecteddatagroup.Gender = referencereader["Gender"].ToString();
                                                selecteddatagroup.Ethnicity = referencereader["Ethnicity"].ToString();
                                                selecteddatagroup.FullStreetAddress = referencereader["FullStreetAddress"].ToString();
                                                selecteddatagroup.City = referencereader["City"].ToString();
                                                selecteddatagroup.State = referencereader["State"].ToString();
                                                selecteddatagroup.ZipCode2 = Convert.ToDecimal(referencereader["ZipCode"].ToString());
                                                selecteddatagroup.HomePhone = referencereader["HomePhone"].ToString();
                                                selecteddatagroup.WorkPhone = referencereader["WorkPhone"].ToString();
                                                selecteddatagroup.CountryCode2 = Convert.ToDecimal(referencereader["CountyCode"].ToString());
                                                selecteddatagroup.CountyCodeDescription = referencereader["CountyCodeDescription"].ToString();
                                                selecteddatagroup.PhoneNumber2 = Convert.ToDecimal(referencereader["PhoneNumber"].ToString());
                                                selecteddatagroup.Eligibility = referencereader["Eligibility"].ToString();
                                                selecteddatagroup.SickleCellDiagnosis = referencereader["SickleCellDiagnosis"].ToString();
                                                selecteddatagroup.PMPProviderName = referencereader["PMPProviderName"].ToString();
                                                selecteddatagroup.CCUCase = referencereader["CCUCase"].ToString();
                                                selecteddatagroup.Email_Address = referencereader["Email_Address"].ToString();

                                                selecteddata.Add(selecteddatagroup);

                                                referencereader.Close();
                                                connection.Close();                                                
                                                return selecteddata;                                                
                                         }                                             
                                    }
                                    else {
                                          selecteddatagroup.FirstName = "";
                                          selecteddata.Add(selecteddatagroup);

                                          searchfullnamereader.Close();
                                          connection.Close();
                                          return selecteddata;
                                    }                                         
                        }
                        return selecteddata;
                    }
                    else
                    {
                        connect.Open();
                        //DateTime vdob3 = Convert.ToDateTime(selected.DOB);
                        String vdob3 = selected.DOB.ToString().Trim();
                        SqlCommand searchoverview3 = new SqlCommand("select * from information where FirstName = '" + selected.FirstName + "' and LastName = '" + selected.LastName + "' and DOB = '" + vdob3 + "' ", connect);
                        SqlDataReader searchfullnamereader = searchoverview3.ExecuteReader();

                        if (searchfullnamereader.HasRows == true)
                        {
                            while (searchfullnamereader.Read())
                            {
                                selecteddatagroup.ClientID = searchfullnamereader["ClientID"].ToString();
                                selecteddatagroup.LastName = searchfullnamereader["LastName"].ToString();
                                selecteddatagroup.FirstName = searchfullnamereader["FirstName"].ToString();
                                selecteddatagroup.Middle_Initial = searchfullnamereader["Middle_Initial"].ToString();
                                selecteddatagroup.UniqueID = searchfullnamereader["UniqueID"].ToString();
                                selecteddatagroup.DOB = searchfullnamereader["DOB"].ToString();
                                selecteddatagroup.Age = searchfullnamereader["Age"].ToString();
                                selecteddatagroup.AgeGroup = searchfullnamereader["AgeGroup"].ToString();
                                selecteddatagroup.Ageat = searchfullnamereader["Ageat"].ToString();
                                selecteddatagroup.Gender = searchfullnamereader["Gender"].ToString();
                                selecteddatagroup.Race = searchfullnamereader["Race"].ToString();
                                selecteddatagroup.Ethnicity = searchfullnamereader["Ethnicity"].ToString();
                                selecteddatagroup.Eligibility = searchfullnamereader["Eligibility"].ToString();
                                selecteddatagroup.SSN = searchfullnamereader["SSN"].ToString();
                                selecteddatagroup.CountyCode = searchfullnamereader["CountyCode"].ToString();
                                selecteddatagroup.CountyCodeDescription = searchfullnamereader["CountyCodeDescription"].ToString();
                                selecteddatagroup.PhoneNumber = searchfullnamereader["PhoneNumber"].ToString();
                                selecteddatagroup.SickleCellDiagnosis = searchfullnamereader["SickleCellDiagnosis"].ToString();
                                selecteddatagroup.FullStreetAddress = searchfullnamereader["FullStreetAddress"].ToString();
                                selecteddatagroup.FullStreetAddress2 = searchfullnamereader["FullStreetAddress2"].ToString();
                                selecteddatagroup.City = searchfullnamereader["City"].ToString();
                                selecteddatagroup.State = searchfullnamereader["State"].ToString();
                                selecteddatagroup.ZipCode = searchfullnamereader["ZipCode"].ToString();
                                selecteddatagroup.HomePhone = searchfullnamereader["HomePhone"].ToString();
                                selecteddatagroup.WorkPhone = searchfullnamereader["WorkPhone"].ToString();                                
                                selecteddatagroup.PMPProviderName = searchfullnamereader["PMPProviderName"].ToString();
                                selecteddatagroup.Specialist = searchfullnamereader["Specialist"].ToString();
                                selecteddatagroup.CCUCase = searchfullnamereader["CCUCase"].ToString();
                                selecteddatagroup.Email_Address = searchfullnamereader["Email_Address"].ToString();
                                selecteddatagroup.ClientresideinruralID = searchfullnamereader["ClientresideinruralID"].ToString();
                                selecteddatagroup.Nameofmother = searchfullnamereader["Nameofmother"].ToString();
                                selecteddatagroup.Address_Of_Mother = searchfullnamereader["Address_Of_Mother"].ToString();
                                selecteddatagroup.Telephone_Of_Mother = searchfullnamereader["Telephone_Of_Mother"].ToString();
                                selecteddatagroup.Nameoffather = searchfullnamereader["Nameoffather"].ToString();
                                selecteddatagroup.Address_Of_Father = searchfullnamereader["Address_Of_Father"].ToString();
                                selecteddatagroup.Telephone_Of_Father = searchfullnamereader["Telephone_Of_Father"].ToString();
                                selecteddatagroup.Nameofguardian = searchfullnamereader["Nameofguardian"].ToString();
                                selecteddatagroup.Address_Of_Guardian = searchfullnamereader["Address_Of_Guardian"].ToString();
                                selecteddatagroup.Guardian_Telephone = searchfullnamereader["Guardian_Telephone"].ToString();
                                selecteddatagroup.Emergency_Contact1 = searchfullnamereader["Emergency_Contact1"].ToString();
                                selecteddatagroup.Emergency_Contact1_HomePhone = searchfullnamereader["Emergency_Contact1_HomePhone"].ToString();
                                selecteddatagroup.Emergency_Contact1_CellPhone = searchfullnamereader["Emergency_Contact1_CellPhone"].ToString();
                                selecteddatagroup.Emergency_Contact2 = searchfullnamereader["Emergency_Contact2"].ToString();
                                selecteddatagroup.Emergency_Contact2_HomePhone = searchfullnamereader["Emergency_Contact2_HomePhone"].ToString();
                                selecteddatagroup.Emergency_Contact2_CellPhone = searchfullnamereader["Emergency_Contact2_CellPhone"].ToString();
                                selecteddatagroup.SicklecelltypeID = searchfullnamereader["SicklecelltypeID"].ToString();
                                selecteddatagroup.Medication = searchfullnamereader["Medication"].ToString();
                                selecteddatagroup.Medication2 = searchfullnamereader["Medication2"].ToString();
                                selecteddatagroup.Medication3 = searchfullnamereader["Medication3"].ToString();
                                selecteddatagroup.Medication4 = searchfullnamereader["Medication4"].ToString();
                                selecteddatagroup.HydroxyureaheardID = searchfullnamereader["HydroxyureaheardID"].ToString();
                                selecteddatagroup.HydroxyureatakenID = searchfullnamereader["HydroxyureatakenID"].ToString();
                                selecteddatagroup.HydroxyureacurrentlyID = searchfullnamereader["HydroxyureacurrentlyID"].ToString();
                                selecteddatagroup.HydroxyureapasttakenID = searchfullnamereader["HydroxyureapasttakenID"].ToString();
                                selecteddatagroup.Hydroxyureadosage = searchfullnamereader["Hydroxyureadosage"].ToString();
                                selecteddatagroup.Hydroxyureadosageunknown = searchfullnamereader["Hydroxyureadosageunknown"].ToString();
                                selecteddatagroup.Hydroxyureacapsulescolor = searchfullnamereader["Hydroxyureacapsulescolor"].ToString();
                                selecteddatagroup.Hydroxyureadatelasttaken = searchfullnamereader["Hydroxyureadatelasttaken"].ToString();
                                selecteddatagroup.Hydroxyureadatepickedup = searchfullnamereader["Hydroxyureadatepickedup"].ToString();
                                selecteddatagroup.Pharma1heardID = searchfullnamereader["Pharma1heardID"].ToString();
                                selecteddatagroup.Pharma1takenID = searchfullnamereader["Pharma1takenID"].ToString();
                                selecteddatagroup.Pharma1currentlyID = searchfullnamereader["Pharma1currentlyID"].ToString();
                                selecteddatagroup.Pharma1pasttakenID = searchfullnamereader["Pharma1pasttakenID"].ToString();
                                selecteddatagroup.Pharma1dosage = searchfullnamereader["Pharma1dosage"].ToString();
                                selecteddatagroup.Pharma1dosageunknown = searchfullnamereader["Pharma1dosageunknown"].ToString();
                                selecteddatagroup.Pharma1capsulescolor = searchfullnamereader["Pharma1capsulescolor"].ToString();
                                selecteddatagroup.Pharma1datelasttaken = searchfullnamereader["Pharma1datelasttaken"].ToString();
                                selecteddatagroup.Pharma1datepickedup = searchfullnamereader["Pharma1datepickedup"].ToString();
                                selecteddatagroup.Pharma2heardID = searchfullnamereader["Pharma2heardID"].ToString();
                                selecteddatagroup.Pharma2takenID = searchfullnamereader["Pharma2takenID"].ToString();
                                selecteddatagroup.Pharma2currentlyID = searchfullnamereader["Pharma2currentlyID"].ToString();
                                selecteddatagroup.Pharma2pasttakenID = searchfullnamereader["Pharma2pasttakenID"].ToString();
                                selecteddatagroup.Pharma2dosage = searchfullnamereader["Pharma2dosage"].ToString();
                                selecteddatagroup.Pharma2dosageunknown = searchfullnamereader["Pharma2dosageunknown"].ToString();
                                selecteddatagroup.Pharma2capsulescolor = searchfullnamereader["Pharma2capsulescolor"].ToString();
                                selecteddatagroup.Pharma2datelasttaken = searchfullnamereader["Pharma2datelasttaken"].ToString();
                                selecteddatagroup.Pharma2datepickedup = searchfullnamereader["Pharma2datepickedup"].ToString();
                                selecteddatagroup.Pharma3heardID = searchfullnamereader["Pharma3heardID"].ToString();
                                selecteddatagroup.Pharma3takenID = searchfullnamereader["Pharma3takenID"].ToString();
                                selecteddatagroup.Pharma3currentlyID = searchfullnamereader["Pharma3currentlyID"].ToString();
                                selecteddatagroup.Pharma3pasttakenID = searchfullnamereader["Pharma3pasttakenID"].ToString();
                                selecteddatagroup.Pharma3dosage = searchfullnamereader["Pharma3dosage"].ToString();
                                selecteddatagroup.Pharma3dosageunknown = searchfullnamereader["Pharma3dosageunknown"].ToString();
                                selecteddatagroup.Pharma3capsulescolor = searchfullnamereader["Pharma3capsulescolor"].ToString();
                                selecteddatagroup.Pharma3datelasttaken = searchfullnamereader["Pharma3datelasttaken"].ToString();
                                selecteddatagroup.Pharma3datepickedup = searchfullnamereader["Pharma3datepickedup"].ToString();
                                selecteddatagroup.Comments = searchfullnamereader["Comments"].ToString();
                                selecteddatagroup.Deceased = searchfullnamereader["Deceased"].ToString();

                                selecteddata.Add(selecteddatagroup);

                                searchfullnamereader.Close();
                                connect.Close();
                                return selecteddata;
                            }
                        }
                        else
                        {
                            selecteddatagroup.FirstName = "";
                            selecteddata.Add(selecteddatagroup);

                            searchfullnamereader.Close();
                            connect.Close();
                            return selecteddata;
                        }
                        return selecteddata;
                    }
                    //return selecteddata;
                }
            }
            catch (Exception ab)
            {
                ab.Message.ToString();
                selecteddatagroup.FirstName = ab.Message;
                selecteddata.Add(selecteddatagroup);
            }
            return Json(selecteddata, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(SickeCellclass datavalue)
        {
            var varclientidex = datavalue.Clientidx;
            List<string> x = new List<string>();
            x.Add(datavalue.ToString());

            var count = 0;

            try
            {
                string strdata = " ";
                long longdata = 0;

                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Execute Information_Stored_Save @ClientID,@LastName, @FirstName, @Middle_Initial, @UniqueID, @DOB, @Age, @AgeGroup, @Ageat, @Gender,@Race, @Ethnicity, @Eligibility, @SSN, @CountyCode, @CountyCodeDescription, @PhoneNumber, @SickleCellDiagnosis, @FullStreetAddress, @FullStreetAddress2, @City, @State, @ZipCode, @HomePhone, @WorkPhone, @PMPProviderName, @Specialist, @CCUCase, @Email_Address, @ClientresideinruralID, @Nameofmother, @Address_Of_Mother, @Telephone_Of_Mother, @Nameoffather, @Address_Of_Father, @Telephone_Of_Father, @Nameofguardian, @Address_Of_Guardian, @Guardian_Telephone, @Emergency_Contact1, @Emergency_Contact1_HomePhone , @Emergency_Contact1_CellPhone, @Emergency_Contact2, @Emergency_Contact2_HomePhone, @Emergency_Contact2_CellPhone, @SicklecelltypeID, @Medication, @Medication2, @Medication3, @Medication4, @HydroxyureaheardID, @HydroxyureatakenID, @HydroxyureacurrentlyID, @HydroxyureapasttakenID, @Hydroxyureadosage, @Hydroxyureadosageunknown,@Hydroxyureacapsulescolor, @Hydroxyureadatelasttaken, @Hydroxyureadatepickedup, @Pharma1heardID, @Pharma1takenID, @Pharma1currentlyID, @Pharma1pasttakenID, @Pharma1dosage, @Pharma1dosageunknown, @Pharma1capsulescolor, @Pharma1datelasttaken, @Pharma1datepickedup, @Pharma2heardID, @Pharma2takenID, @Pharma2currentlyID, @Pharma2pasttakenID, @Pharma2dosage, @Pharma2dosageunknown, @Pharma2capsulescolor, @Pharma2datelasttaken, @Pharma2datepickedup, @Pharma3heardID, @Pharma3takenID, @Pharma3currentlyID, @Pharma3pasttakenID, @Pharma3dosage, @Pharma3dosageunknown, @Pharma3capsulescolor, @Pharma3datelasttaken, @Pharma3datepickedup, @Deceased";

                SqlCommand searchclientid = new SqlCommand("SickeCell_Stored_Search_idx", connection);
                searchclientid.CommandType = CommandType.StoredProcedure;
                searchclientid.Parameters.Add("@Clientidx", SqlDbType.VarChar).Value = datavalue.Clientidx;

                SqlDataReader clientidreader = searchclientid.ExecuteReader();

                if (clientidreader.HasRows == true)
                {
                    ////////////////////////////////////////////////                              
                    while (clientidreader.Read())
                    {
                        strdata = clientidreader[0].ToString();
                        clientidreader.Close();

                        SqlCommand deletefullname = new SqlCommand("SickeCell_Stored_Delete", connection);
                        deletefullname.CommandType = CommandType.StoredProcedure;
                        deletefullname.Parameters.Add("@Clientidx", SqlDbType.VarChar).Value = datavalue.Clientidx;
                        SqlDataReader deletereader = deletefullname.ExecuteReader();
                        deletereader.Close();

                        if (count == 0)
                        {
                            longdata = Convert.ToInt64(strdata);
                            //command.Parameters.Add("@ClientID", SqlDbType.BigInt).Value = longdata + 1;

                            if (datavalue.ClientID == "" || datavalue.ClientID == null)
                            {
                                command.Parameters.Add("@ClientID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@ClientID", SqlDbType.VarChar, 25).Value = datavalue.ClientID;
                            }

                            if (datavalue.LastName == "" || datavalue.LastName == null)
                            {
                                command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = datavalue.LastName;
                            }

                            if (datavalue.FirstName == "" || datavalue.FirstName == null)
                            {
                                command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = datavalue.FirstName;
                            }

                            if (datavalue.Middle_Initial == "" || datavalue.Middle_Initial == null)
                            {
                                command.Parameters.Add("@Middle_Initial", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Middle_Initial", SqlDbType.VarChar, 50).Value = datavalue.Middle_Initial;
                            }

                            if (datavalue.UniqueID == "" || datavalue.UniqueID == null)
                            {
                                command.Parameters.Add("@UniqueID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@UniqueID", SqlDbType.VarChar, 50).Value = datavalue.UniqueID;
                            }

                            if (datavalue.DOB == ""  || datavalue.DOB == null)
                            {
                                command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = datavalue.DOB;
                            }

                            if (datavalue.Age == "" || datavalue.Age == null)
                            {
                                command.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = datavalue.Age;
                            }

                            if (datavalue.AgeGroup == "" || datavalue.AgeGroup == null)
                            {
                                command.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 50).Value = datavalue.AgeGroup;
                            }

                            if (datavalue.Ageat == "" || datavalue.Ageat == null)
                            {
                                command.Parameters.Add("@Ageat", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Ageat", SqlDbType.VarChar, 50).Value = datavalue.Ageat;
                            }

                            if (datavalue.Gender == "" || datavalue.Gender == null)
                            {
                                command.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = datavalue.Gender;
                            }

                            if (datavalue.Race == "" || datavalue.Race == null)
                            {
                                command.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = datavalue.Race;
                            }

                            if (datavalue.Ethnicity == "" || datavalue.Ethnicity == null)
                            {
                                command.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 50).Value = datavalue.Ethnicity;
                            }

                            if (datavalue.SSN == "" || datavalue.SSN == null)
                            {
                                command.Parameters.Add("@SSN", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@SSN", SqlDbType.VarChar, 50).Value = datavalue.SSN;
                            }

                            if (datavalue.Eligibility == "" || datavalue.Eligibility == null)
                            {
                                command.Parameters.Add("@Eligibility", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Eligibility", SqlDbType.VarChar, 50).Value = datavalue.Eligibility;
                            }

                            if (datavalue.CountyCode == "" || datavalue.CountyCode == null)
                            {
                                command.Parameters.Add("@CountyCode", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@CountyCode", SqlDbType.VarChar, 50).Value = datavalue.CountyCode;
                            }

                            if (datavalue.CountyCodeDescription == "" || datavalue.CountyCodeDescription == null)
                            {
                                command.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 50).Value = datavalue.CountyCodeDescription;
                            }

                            if (datavalue.PhoneNumber == "" || datavalue.PhoneNumber == null)
                            {
                                command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50).Value = datavalue.PhoneNumber;
                            }

                            if (datavalue.SickleCellDiagnosis == "" || datavalue.SickleCellDiagnosis == null)
                            {
                                command.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 50).Value = datavalue.SickleCellDiagnosis;
                            }

                            if (datavalue.FullStreetAddress == "" || datavalue.FullStreetAddress == null)
                            {
                                command.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 50).Value = datavalue.FullStreetAddress;
                            }

                            if (datavalue.FullStreetAddress2 == "" || datavalue.FullStreetAddress2 == null)
                            {
                                command.Parameters.Add("@FullStreetAddress2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@FullStreetAddress2", SqlDbType.VarChar, 50).Value = datavalue.FullStreetAddress2;
                            }

                            if (datavalue.City == "" || datavalue.City == null)
                            {
                                command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = datavalue.City;
                            }

                            if (datavalue.State == "" || datavalue.State == null)
                            {
                                command.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = datavalue.State;
                            }

                            if (datavalue.ZipCode == "" || datavalue.ZipCode == null)
                            {
                                command.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = datavalue.ZipCode;
                            }

                            if (datavalue.HomePhone == "" || datavalue.HomePhone == null)
                            {
                                command.Parameters.Add("@HomePhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@HomePhone", SqlDbType.VarChar, 50).Value = datavalue.HomePhone;
                            }

                            if (datavalue.WorkPhone == "" || datavalue.WorkPhone == null)
                            {
                                command.Parameters.Add("@WorkPhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@WorkPhone", SqlDbType.VarChar, 50).Value = datavalue.WorkPhone;
                            }

                            if (datavalue.PMPProviderName == "" || datavalue.PMPProviderName == null)
                            {
                                command.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 50).Value = datavalue.PMPProviderName;
                            }

                            if (datavalue.Specialist == "" || datavalue.Specialist == null)
                            {
                                command.Parameters.Add("@Specialist", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Specialist", SqlDbType.VarChar, 50).Value = datavalue.Specialist;
                            }

                            if (datavalue.CCUCase == "" || datavalue.CCUCase == null)
                            {
                                command.Parameters.Add("@CCUCase", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@CCUCase", SqlDbType.VarChar, 50).Value = datavalue.CCUCase;
                            }

                            if (datavalue.Email_Address == "" || datavalue.Email_Address == null)
                            {
                                command.Parameters.Add("@Email_Address", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Email_Address", SqlDbType.VarChar, 50).Value = datavalue.Email_Address;
                            }

                            if (datavalue.ClientresideinruralID == "" || datavalue.ClientresideinruralID == null)
                            {
                                command.Parameters.Add("@ClientresideinruralID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@ClientresideinruralID", SqlDbType.VarChar, 50).Value = datavalue.ClientresideinruralID;
                            }

                            if (datavalue.Nameofmother == "" || datavalue.Nameofmother == null)
                            {
                                command.Parameters.Add("@Nameofmother", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Nameofmother", SqlDbType.VarChar, 50).Value = datavalue.Nameofmother;
                            }

                            if (datavalue.Address_Of_Mother == "" || datavalue.Address_Of_Mother == null)
                            {
                                command.Parameters.Add("@Address_Of_Mother", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Address_Of_Mother", SqlDbType.VarChar, 50).Value = datavalue.Address_Of_Mother;
                            }

                            if (datavalue.Telephone_Of_Mother == "" || datavalue.Telephone_Of_Mother == null)
                            {
                                command.Parameters.Add("@Telephone_Of_Mother", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Telephone_Of_Mother", SqlDbType.VarChar, 50).Value = datavalue.Telephone_Of_Mother;
                            }

                            if (datavalue.Nameoffather == "" || datavalue.Nameoffather == null)
                            {
                                command.Parameters.Add("@Nameoffather", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Nameoffather", SqlDbType.VarChar, 50).Value = datavalue.Nameoffather;
                            }

                            if (datavalue.Address_Of_Father == "" || datavalue.Address_Of_Father == null)
                            {
                                command.Parameters.Add("@Address_Of_Father", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Address_Of_Father", SqlDbType.VarChar, 50).Value = datavalue.Address_Of_Father;
                            }

                            if (datavalue.Telephone_Of_Father == "" || datavalue.Telephone_Of_Father == null)
                            {
                                command.Parameters.Add("@Telephone_Of_Father", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Telephone_Of_Father", SqlDbType.VarChar, 50).Value = datavalue.Telephone_Of_Father;
                            }

                            if (datavalue.Nameofguardian == "" || datavalue.Nameofguardian == null)
                            {
                                command.Parameters.Add("@Nameofguardian", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Nameofguardian", SqlDbType.VarChar, 50).Value = datavalue.Nameofguardian;
                            }

                            if (datavalue.Address_Of_Guardian == "" || datavalue.Address_Of_Guardian == null)
                            {
                                command.Parameters.Add("@Address_Of_Guardian", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Address_Of_Guardian", SqlDbType.VarChar, 50).Value = datavalue.Address_Of_Guardian;
                            }

                            if (datavalue.Guardian_Telephone == "" || datavalue.Guardian_Telephone == null)
                            {
                                command.Parameters.Add("@Guardian_Telephone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Guardian_Telephone", SqlDbType.VarChar, 50).Value = datavalue.Guardian_Telephone;
                            }

                            if (datavalue.Emergency_Contact1 == "" || datavalue.Emergency_Contact1 == null)
                            {
                                command.Parameters.Add("@Emergency_Contact1", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Emergency_Contact1", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact1;
                            }

                            if (datavalue.Emergency_Contact1_HomePhone == "" || datavalue.Emergency_Contact1_HomePhone == null)
                            {
                                command.Parameters.Add("@Emergency_Contact1_HomePhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Emergency_Contact1_HomePhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact1_HomePhone;
                            }

                            if (datavalue.Emergency_Contact1_CellPhone == "" || datavalue.Emergency_Contact1_CellPhone == null)
                            {
                                command.Parameters.Add("@Emergency_Contact1_CellPhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Emergency_Contact1_CellPhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact1_CellPhone;
                            }

                            if (datavalue.Emergency_Contact2 == "" || datavalue.Emergency_Contact2 == null)
                            {
                                command.Parameters.Add("@Emergency_Contact2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Emergency_Contact2", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact2;
                            }

                            if (datavalue.Emergency_Contact2_HomePhone == "" || datavalue.Emergency_Contact2_HomePhone == null)
                            {
                                command.Parameters.Add("@Emergency_Contact2_HomePhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Emergency_Contact2_HomePhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact2_HomePhone;
                            }

                            if (datavalue.Emergency_Contact2_CellPhone == "" || datavalue.Emergency_Contact2_CellPhone == null)
                            {
                                command.Parameters.Add("@Emergency_Contact2_CellPhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Emergency_Contact2_CellPhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact2_CellPhone;
                            }

                            if (datavalue.SicklecelltypeID == "" || datavalue.SicklecelltypeID == null)
                            {
                                command.Parameters.Add("@SicklecelltypeID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@SicklecelltypeID", SqlDbType.VarChar, 50).Value = datavalue.SicklecelltypeID;
                            }

                            if (datavalue.Medication == "" || datavalue.Medication == null)
                            {
                                command.Parameters.Add("@Medication", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Medication", SqlDbType.VarChar, 50).Value = datavalue.Medication;
                            }

                            if (datavalue.Medication2 == "" || datavalue.Medication2 == null)
                            {
                                command.Parameters.Add("@Medication2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Medication2", SqlDbType.VarChar, 50).Value = datavalue.Medication2;
                            }

                            if (datavalue.Medication3 == "" || datavalue.Medication3 == null)
                            {
                                command.Parameters.Add("@Medication3", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Medication3", SqlDbType.VarChar, 50).Value = datavalue.Medication3;
                            }

                            if (datavalue.Medication4 == "" || datavalue.Medication4 == null)
                            {
                                command.Parameters.Add("@Medication4", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Medication4", SqlDbType.VarChar, 50).Value = datavalue.Medication4;
                            }

                            if (datavalue.HydroxyureaheardID == "" || datavalue.HydroxyureaheardID == null)
                            {
                                command.Parameters.Add("@HydroxyureaheardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@HydroxyureaheardID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureaheardID;
                            }

                            if (datavalue.HydroxyureatakenID == "" || datavalue.HydroxyureatakenID == null)
                            {
                                command.Parameters.Add("@HydroxyureatakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@HydroxyureatakenID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureatakenID;
                            }

                            if (datavalue.HydroxyureacurrentlyID == "" || datavalue.HydroxyureacurrentlyID == null)
                            {
                                command.Parameters.Add("@HydroxyureacurrentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@HydroxyureacurrentlyID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureacurrentlyID;
                            }

                            if (datavalue.HydroxyureapasttakenID == "" || datavalue.HydroxyureapasttakenID == null)
                            {
                                command.Parameters.Add("@HydroxyureapasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@HydroxyureapasttakenID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureapasttakenID;
                            }

                            if (datavalue.Hydroxyureadosage == "" || datavalue.Hydroxyureadosage == null)
                            {
                                command.Parameters.Add("@Hydroxyureadosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Hydroxyureadosage", SqlDbType.VarChar, 50).Value = datavalue.Hydroxyureadosage;
                            }

                            if (datavalue.Hydroxyureadosageunknown == "" || datavalue.Hydroxyureadosageunknown == null)
                            {
                                command.Parameters.Add("@Hydroxyureadosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Hydroxyureadosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Hydroxyureadosageunknown;
                            }

                            if (datavalue.Hydroxyureacapsulescolor == "" || datavalue.Hydroxyureacapsulescolor == null)
                            {
                                command.Parameters.Add("@Hydroxyureacapsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Hydroxyureacapsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Hydroxyureacapsulescolor;
                            }

                            if (datavalue.Hydroxyureadatelasttaken == "" || datavalue.Hydroxyureadatelasttaken == null)
                            {
                                command.Parameters.Add("@Hydroxyureadatelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Hydroxyureadatelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Hydroxyureadatelasttaken;
                            }
                            if (datavalue.Hydroxyureadatepickedup == "" || datavalue.Hydroxyureadatepickedup == null)
                            {
                                command.Parameters.Add("@Hydroxyureadatepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Hydroxyureadatepickedup", SqlDbType.VarChar, 10).Value = datavalue.Hydroxyureadatepickedup;
                            }

                            if (datavalue.Pharma1heardID == "" || datavalue.Pharma1heardID == null)
                            {
                                command.Parameters.Add("@Pharma1heardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma1heardID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1heardID;
                            }

                            if (datavalue.Pharma1takenID == "" || datavalue.Pharma1takenID == null)
                            {
                                command.Parameters.Add("@Pharma1takenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma1takenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1takenID;
                            }

                            if (datavalue.Pharma1currentlyID == "" || datavalue.Pharma1currentlyID == null)
                            {
                                command.Parameters.Add("@Pharma1currentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma1currentlyID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1currentlyID;
                            }

                            if (datavalue.Pharma1pasttakenID == "" || datavalue.Pharma1pasttakenID == null)
                            {
                                command.Parameters.Add("@Pharma1pasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma1pasttakenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1pasttakenID;
                            }

                            if (datavalue.Pharma1dosage == "" || datavalue.Pharma1dosage == null)
                            {
                                command.Parameters.Add("@Pharma1dosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma1dosage", SqlDbType.VarChar, 50).Value = datavalue.Pharma1dosage;
                            }

                            if (datavalue.Pharma1dosageunknown == "" || datavalue.Pharma1dosageunknown == null)
                            {
                                command.Parameters.Add("@Pharma1dosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma1dosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Pharma1dosageunknown;
                            }

                            if (datavalue.Pharma1capsulescolor == "" || datavalue.Pharma1capsulescolor == null)
                            {
                                command.Parameters.Add("@Pharma1capsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma1capsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Pharma1capsulescolor;
                            }

                            if (datavalue.Pharma1datelasttaken == "" || datavalue.Pharma1datelasttaken == null)
                            {
                                command.Parameters.Add("@Pharma1datelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma1datelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Pharma1datelasttaken;
                            }

                            if (datavalue.Pharma1datepickedup == "" || datavalue.Pharma1datepickedup == null)
                            {
                                command.Parameters.Add("@Pharma1datepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma1datepickedup", SqlDbType.VarChar, 10).Value = datavalue.Pharma1datepickedup;
                            }

                            if (datavalue.Pharma2heardID == "" || datavalue.Pharma2heardID == null)
                            {
                                command.Parameters.Add("@Pharma2heardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma2heardID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2heardID;
                            }

                            if (datavalue.Pharma2takenID == "" || datavalue.Pharma2takenID == null)
                            {
                                command.Parameters.Add("@Pharma2takenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma2takenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2takenID;
                            }

                            if (datavalue.Pharma2currentlyID == "" || datavalue.Pharma2currentlyID == null)
                            {
                                command.Parameters.Add("@Pharma2currentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma2currentlyID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2currentlyID;
                            }

                            if (datavalue.Pharma2pasttakenID == "" || datavalue.Pharma2pasttakenID == null)
                            {
                                command.Parameters.Add("@Pharma2pasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma2pasttakenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2pasttakenID;
                            }

                            if (datavalue.Pharma2dosage == "" || datavalue.Pharma2dosage == null)
                            {
                                command.Parameters.Add("@Pharma2dosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma2dosage", SqlDbType.VarChar, 50).Value = datavalue.Pharma2dosage;
                            }

                            if (datavalue.Pharma2dosageunknown == "" || datavalue.Pharma2dosageunknown == null)
                            {
                                command.Parameters.Add("@Pharma2dosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma2dosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Pharma2dosageunknown;
                            }

                            if (datavalue.Pharma2capsulescolor == "" || datavalue.Pharma2capsulescolor == null)
                            {
                                command.Parameters.Add("@Pharma2capsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma2capsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Pharma2capsulescolor;
                            }

                            if (datavalue.Pharma2datelasttaken == "" || datavalue.Pharma2datelasttaken == null)
                            {
                                command.Parameters.Add("@Pharma2datelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma2datelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Pharma2datelasttaken;
                            }

                            if (datavalue.Pharma2datepickedup == "" || datavalue.Pharma2datepickedup == null)
                            {
                                command.Parameters.Add("@Pharma2datepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma2datepickedup", SqlDbType.VarChar, 10).Value = datavalue.Pharma2datepickedup;
                            }

                            if (datavalue.Pharma3heardID == "" || datavalue.Pharma3heardID == null)
                            {
                                command.Parameters.Add("@Pharma3heardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma3heardID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3heardID;
                            }

                            if (datavalue.Pharma3takenID == "" || datavalue.Pharma3takenID == null)
                            {
                                command.Parameters.Add("@Pharma3takenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma3takenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3takenID;
                            }

                            if (datavalue.Pharma3currentlyID == "" || datavalue.Pharma3currentlyID == null)
                            {
                                command.Parameters.Add("@Pharma3currentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma3currentlyID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3currentlyID;
                            }

                            if (datavalue.Pharma3pasttakenID == "" || datavalue.Pharma3pasttakenID == null)
                            {
                                command.Parameters.Add("@Pharma3pasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma3pasttakenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3pasttakenID;
                            }

                            if (datavalue.Pharma3dosage == "" || datavalue.Pharma3dosage == null)
                            {
                                command.Parameters.Add("@Pharma3dosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma3dosage", SqlDbType.VarChar, 50).Value = datavalue.Pharma3dosage;
                            }

                            if (datavalue.Pharma3dosageunknown == "" || datavalue.Pharma3dosageunknown == null)
                            {
                                command.Parameters.Add("@Pharma3dosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma3dosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Pharma3dosageunknown;
                            }

                            if (datavalue.Pharma3capsulescolor == "" || datavalue.Pharma3capsulescolor == null)
                            {
                                command.Parameters.Add("@Pharma3capsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma3capsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Pharma3capsulescolor;
                            }

                            if (datavalue.Pharma3datelasttaken == "" || datavalue.Pharma3datelasttaken == null)
                            {
                                command.Parameters.Add("@Pharma3datelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma3datelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Pharma3datelasttaken;
                            }

                            if (datavalue.Pharma3datepickedup == "" || datavalue.Pharma3datepickedup == null)
                            {
                                command.Parameters.Add("@Pharma3datepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Pharma3datepickedup", SqlDbType.VarChar, 10).Value = datavalue.Pharma3datepickedup;
                            }

                            if (datavalue.Deceased == "" || datavalue.Deceased == null)
                            {
                                command.Parameters.Add("@Deceased", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Deceased", SqlDbType.VarChar, 50).Value = datavalue.Deceased;
                            }
                            count = 1;
                            break;
                        }
                    }
                    ////////////////////////////////////////////////                    
                }
                //this is ThemeableAttribute condition for the first entry
                else
                {
                    String str = "";
                    str = datavalue.Clientidx.ToString();
                    if (str.All(char.IsDigit))
                    {
                        clientidreader.Close();
                        //command.CommandText = "Execute Information_Stored_Save @ClientID,@LastName, @FirstName, @Middle_Initial, @UniqueID, @DOB, @Age, @AgeGroup, @Ageat, @Gender,@Race, @Ethnicity, @Eligibility, @SSN, @CountyCode, @CountyCodeDescription, @Mobile_Number, @SickleCellDiagnosis, @FullStreetAddress, @FullStreetAddress2, @City, @State, @ZipCode, @PMPProviderName, @Specialist, @CCUCase, @Email_Address, @ClientresideinruralID, @Nameofmother, @Address_Of_Mother, @Telephone_Of_Mother, @Nameoffather, @Address_Of_Father, @Telephone_Of_Father, @Nameofguardian, @Address_Of_Guardian, @Guardian_Telephone, @Emergency_Contact1, @Emergency_Contact1_HomePhone , @Emergency_Contact1_CellPhone, @Emergency_Contact2, @Emergency_Contact2_HomePhone, @Emergency_Contact2_CellPhone, @SicklecelltypeID, @Medication, @Medication2, @Medication3, @Medication4, @HydroxyureaheardID, @HydroxyureatakenID, @HydroxyureacurrentlyID, @HydroxyureapasttakenID, @Hydroxyureadosage, @Hydroxyureadosageunknown,@Hydroxyureacapsulescolor, @Pharma1heardID, @Pharma1takenID, @Pharma1currentlyID, @Pharma1pasttakenID, @Pharma1dosage, @Pharma1dosageunknown, @Pharma1capsulescolor, @Pharma2heardID, @Pharma2takenID, @Pharma2currentlyID, @Pharma2pasttakenID, @Pharma2dosage, @Pharma2dosageunknown, @Pharma2capsulescolor, @Pharma3heardID, @Pharma3takenID, @Pharma3currentlyID, @Pharma3pasttakenID, @Pharma3dosage, @Pharma3dosageunknown, @Pharma3capsulescolor";
                        SqlCommand command2 = new SqlCommand("select top 1 ClientID from Information order by ClientID DESC", connection);
                        SqlDataReader clientidreader2 = command2.ExecuteReader();
                        ////////////////////////////////////////////////////////////////////////////////
                        while (clientidreader2.Read())
                        {
                             strdata = clientidreader2[0].ToString();                        

                            if (count == 0)
                            {

                                longdata = Convert.ToInt64(strdata);                        

                                if (datavalue.ClientID == "" || datavalue.ClientID == null)
                                {
                                    command.Parameters.Add("@ClientID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@ClientID", SqlDbType.VarChar, 25).Value = datavalue.ClientID;
                                }

                                if (datavalue.LastName == "" || datavalue.LastName == null)
                                {
                                    command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = datavalue.LastName;
                                }

                                if (datavalue.FirstName == "" || datavalue.FirstName == null)
                                {
                                    command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = datavalue.FirstName;
                                }

                                if (datavalue.Middle_Initial == "" || datavalue.Middle_Initial == null)
                                {
                                    command.Parameters.Add("@Middle_Initial", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Middle_Initial", SqlDbType.VarChar, 50).Value = datavalue.Middle_Initial;
                                }

                                if (datavalue.UniqueID == "" || datavalue.UniqueID == null)
                                {
                                    command.Parameters.Add("@UniqueID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@UniqueID", SqlDbType.VarChar, 50).Value = datavalue.UniqueID;
                                }

                                if (datavalue.DOB == null)
                                {
                                    command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = datavalue.DOB;
                                }

                                if (datavalue.Age == "" || datavalue.Age == null)
                                {
                                    command.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = datavalue.Age;
                                }

                                if (datavalue.AgeGroup == "" || datavalue.AgeGroup == null)
                                {
                                    command.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 50).Value = datavalue.AgeGroup;
                                }

                                if (datavalue.Ageat == "" || datavalue.Ageat == null)
                                {
                                    command.Parameters.Add("@Ageat", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Ageat", SqlDbType.VarChar, 50).Value = datavalue.Ageat;
                                }

                                if (datavalue.Gender == "" || datavalue.Gender == null)
                                {
                                    command.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = datavalue.Gender;
                                }

                                if (datavalue.Race == "" || datavalue.Race == null)
                                {
                                    command.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = datavalue.Race;
                                }

                                if (datavalue.Ethnicity == "" || datavalue.Ethnicity == null)
                                {
                                    command.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 50).Value = datavalue.Ethnicity;
                                }

                                if (datavalue.SSN == "" || datavalue.SSN == null)
                                {
                                    command.Parameters.Add("@SSN", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@SSN", SqlDbType.VarChar, 50).Value = datavalue.SSN;
                                }

                                if (datavalue.Eligibility == "" || datavalue.Eligibility == null)
                                {
                                    command.Parameters.Add("@Eligibility", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Eligibility", SqlDbType.VarChar, 50).Value = datavalue.Eligibility;
                                }

                                if (datavalue.CountyCode == "" || datavalue.CountyCode == null)
                                {
                                    command.Parameters.Add("@CountyCode", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@CountyCode", SqlDbType.VarChar, 50).Value = datavalue.CountyCode;
                                }

                                if (datavalue.CountyCodeDescription == "" || datavalue.CountyCodeDescription == null)
                                {
                                    command.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 50).Value = datavalue.CountyCodeDescription;
                                }

                                if (datavalue.PhoneNumber == "" || datavalue.PhoneNumber == null)
                                {
                                    command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@MPhoneNumber", SqlDbType.VarChar, 50).Value = datavalue.PhoneNumber;
                                }

                                if (datavalue.SickleCellDiagnosis == "" || datavalue.SickleCellDiagnosis == null)
                                {
                                    command.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 50).Value = datavalue.SickleCellDiagnosis;
                                }

                                if (datavalue.FullStreetAddress == "" || datavalue.FullStreetAddress == null)
                                {
                                    command.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 50).Value = datavalue.FullStreetAddress;
                                }

                                if (datavalue.FullStreetAddress2 == "" || datavalue.FullStreetAddress2 == null)
                                {
                                    command.Parameters.Add("@FullStreetAddress2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@FullStreetAddress2", SqlDbType.VarChar, 50).Value = datavalue.FullStreetAddress2;
                                }

                                if (datavalue.City == "" || datavalue.City == null)
                                {
                                    command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = datavalue.City;
                                }

                                if (datavalue.State == "" || datavalue.State == null)
                                {
                                    command.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = datavalue.State;
                                }

                                if (datavalue.ZipCode == "" || datavalue.ZipCode == null)
                                {
                                    command.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = datavalue.ZipCode;
                                }

                                if (datavalue.HomePhone == "" || datavalue.HomePhone == null)
                                {
                                    command.Parameters.Add("@HomePhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@HomePhone", SqlDbType.VarChar, 50).Value = datavalue.HomePhone;
                                }

                                if (datavalue.WorkPhone == "" || datavalue.WorkPhone == null)
                                {
                                    command.Parameters.Add("@WorkPhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@WorkPhone", SqlDbType.VarChar, 50).Value = datavalue.WorkPhone;
                                }

                                if (datavalue.PMPProviderName == "" || datavalue.PMPProviderName == null)
                                {
                                    command.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 50).Value = datavalue.PMPProviderName;
                                }

                                if (datavalue.Specialist == "" || datavalue.Specialist == null)
                                {
                                    command.Parameters.Add("@Specialist", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Specialist", SqlDbType.VarChar, 50).Value = datavalue.Specialist;
                                }

                                if (datavalue.CCUCase == "" || datavalue.CCUCase == null)
                                {
                                    command.Parameters.Add("@CCUCase", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@CCUCase", SqlDbType.VarChar, 50).Value = datavalue.CCUCase;
                                }

                                if (datavalue.Email_Address == "" || datavalue.Email_Address == null)
                                {
                                    command.Parameters.Add("@Email_Address", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Email_Address", SqlDbType.VarChar, 50).Value = datavalue.Email_Address;
                                }

                                if (datavalue.ClientresideinruralID == "" || datavalue.ClientresideinruralID == null)
                                {
                                    command.Parameters.Add("@ClientresideinruralID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@ClientresideinruralID", SqlDbType.VarChar, 50).Value = datavalue.ClientresideinruralID;
                                }

                                if (datavalue.Nameofmother == "" || datavalue.Nameofmother == null)
                                {
                                    command.Parameters.Add("@Nameofmother", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Nameofmother", SqlDbType.VarChar, 50).Value = datavalue.Nameofmother;
                                }

                                if (datavalue.Address_Of_Mother == "" || datavalue.Address_Of_Mother == null)
                                {
                                    command.Parameters.Add("@Address_Of_Mother", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Address_Of_Mother", SqlDbType.VarChar, 50).Value = datavalue.Address_Of_Mother;
                                }

                                if (datavalue.Telephone_Of_Mother == "" || datavalue.Telephone_Of_Mother == null)
                                {
                                    command.Parameters.Add("@Telephone_Of_Mother", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Telephone_Of_Mother", SqlDbType.VarChar, 50).Value = datavalue.Telephone_Of_Mother;
                                }

                                if (datavalue.Nameoffather == "" || datavalue.Nameoffather == null)
                                {
                                    command.Parameters.Add("@Nameoffather", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Nameoffather", SqlDbType.VarChar, 50).Value = datavalue.Nameoffather;
                                }

                                if (datavalue.Address_Of_Father == "" || datavalue.Address_Of_Father == null)
                                {
                                    command.Parameters.Add("@Address_Of_Father", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Address_Of_Father", SqlDbType.VarChar, 50).Value = datavalue.Address_Of_Father;
                                }

                                if (datavalue.Telephone_Of_Father == "" || datavalue.Telephone_Of_Father == null)
                                {
                                    command.Parameters.Add("@Telephone_Of_Father", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Telephone_Of_Father", SqlDbType.VarChar, 50).Value = datavalue.Telephone_Of_Father;
                                }

                                if (datavalue.Nameofguardian == "" || datavalue.Nameofguardian == null)
                                {
                                    command.Parameters.Add("@Nameofguardian", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Nameofguardian", SqlDbType.VarChar, 50).Value = datavalue.Nameofguardian;
                                }

                                if (datavalue.Address_Of_Guardian == "" || datavalue.Address_Of_Guardian == null)
                                {
                                    command.Parameters.Add("@Address_Of_Guardian", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Address_Of_Guardian", SqlDbType.VarChar, 50).Value = datavalue.Address_Of_Guardian;
                                }

                                if (datavalue.Guardian_Telephone == "" || datavalue.Guardian_Telephone == null)
                                {
                                    command.Parameters.Add("@Guardian_Telephone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Guardian_Telephone", SqlDbType.VarChar, 50).Value = datavalue.Guardian_Telephone;
                                }

                                if (datavalue.Emergency_Contact1 == "" || datavalue.Emergency_Contact1 == null)
                                {
                                    command.Parameters.Add("@Emergency_Contact1", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Emergency_Contact1", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact1;
                                }

                                if (datavalue.Emergency_Contact1_HomePhone == "" || datavalue.Emergency_Contact1_HomePhone == null)
                                {
                                    command.Parameters.Add("@Emergency_Contact1_HomePhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Emergency_Contact1_HomePhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact1_HomePhone;
                                }

                                if (datavalue.Emergency_Contact1_CellPhone == "" || datavalue.Emergency_Contact1_CellPhone == null)
                                {
                                    command.Parameters.Add("@Emergency_Contact1_CellPhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Emergency_Contact1_CellPhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact1_CellPhone;
                                }

                                if (datavalue.Emergency_Contact2 == "" || datavalue.Emergency_Contact2 == null)
                                {
                                    command.Parameters.Add("@Emergency_Contact2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Emergency_Contact2", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact2;
                                }

                                if (datavalue.Emergency_Contact2_HomePhone == "" || datavalue.Emergency_Contact2_HomePhone == null)
                                {
                                    command.Parameters.Add("@Emergency_Contact2_HomePhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Emergency_Contact2_HomePhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact2_HomePhone;
                                }

                                if (datavalue.Emergency_Contact2_CellPhone == "" || datavalue.Emergency_Contact2_CellPhone == null)
                                {
                                    command.Parameters.Add("@Emergency_Contact2_CellPhone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Emergency_Contact2_CellPhone", SqlDbType.VarChar, 50).Value = datavalue.Emergency_Contact2_CellPhone;
                                }

                                if (datavalue.SicklecelltypeID == "" || datavalue.SicklecelltypeID == null)
                                {
                                    command.Parameters.Add("@SicklecelltypeID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@SicklecelltypeID", SqlDbType.VarChar, 50).Value = datavalue.SicklecelltypeID;
                                }

                                if (datavalue.Medication == "" || datavalue.Medication == null)
                                {
                                    command.Parameters.Add("@Medication", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Medication", SqlDbType.VarChar, 50).Value = datavalue.Medication;
                                }

                                if (datavalue.Medication2 == "" || datavalue.Medication2 == null)
                                {
                                    command.Parameters.Add("@Medication2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Medication2", SqlDbType.VarChar, 50).Value = datavalue.Medication2;
                                }

                                if (datavalue.Medication3 == "" || datavalue.Medication3 == null)
                                {
                                    command.Parameters.Add("@Medication3", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Medication3", SqlDbType.VarChar, 50).Value = datavalue.Medication3;
                                }

                                if (datavalue.Medication4 == "" || datavalue.Medication4 == null)
                                {
                                    command.Parameters.Add("@Medication4", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Medication4", SqlDbType.VarChar, 50).Value = datavalue.Medication4;
                                }

                                if (datavalue.HydroxyureaheardID == "" || datavalue.HydroxyureaheardID == null)
                                {
                                    command.Parameters.Add("@HydroxyureaheardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@HydroxyureaheardID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureaheardID;
                                }

                                if (datavalue.HydroxyureatakenID == "" || datavalue.HydroxyureatakenID == null)
                                {
                                    command.Parameters.Add("@HydroxyureatakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@HydroxyureatakenID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureatakenID;
                                }

                                if (datavalue.HydroxyureacurrentlyID == "" || datavalue.HydroxyureacurrentlyID == null)
                                {
                                    command.Parameters.Add("@HydroxyureacurrentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@HydroxyureacurrentlyID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureacurrentlyID;
                                }

                                if (datavalue.HydroxyureapasttakenID == "" || datavalue.HydroxyureapasttakenID == null)
                                {
                                    command.Parameters.Add("@HydroxyureapasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@HydroxyureapasttakenID", SqlDbType.VarChar, 50).Value = datavalue.HydroxyureapasttakenID;
                                }

                                if (datavalue.Hydroxyureadosage == "" || datavalue.Hydroxyureadosage == null)
                                {
                                    command.Parameters.Add("@Hydroxyureadosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Hydroxyureadosage", SqlDbType.VarChar, 50).Value = datavalue.Hydroxyureadosage;
                                }

                                if (datavalue.Hydroxyureadosageunknown == "" || datavalue.Hydroxyureadosageunknown == null)
                                {
                                    command.Parameters.Add("@Hydroxyureadosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Hydroxyureadosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Hydroxyureadosageunknown;
                                }

                                if (datavalue.Hydroxyureacapsulescolor == "" || datavalue.Hydroxyureacapsulescolor == null)
                                {
                                    command.Parameters.Add("@Hydroxyureacapsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Hydroxyureacapsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Hydroxyureacapsulescolor;
                                }

                                if (datavalue.Hydroxyureadatelasttaken == "" || datavalue.Hydroxyureadatelasttaken == null)
                                {
                                    command.Parameters.Add("@Hydroxyureadatelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Hydroxyureadatelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Hydroxyureadatelasttaken;
                                }
                                if (datavalue.Hydroxyureadatepickedup == "" || datavalue.Hydroxyureadatepickedup == null)
                                {
                                    command.Parameters.Add("@Hydroxyureadatepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Hydroxyureadatepickedup", SqlDbType.VarChar, 10).Value = datavalue.Hydroxyureadatepickedup;
                                }

                                if (datavalue.Pharma1heardID == "" || datavalue.Pharma1heardID == null)
                                {
                                    command.Parameters.Add("@Pharma1heardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma1heardID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1heardID;
                                }

                                if (datavalue.Pharma1takenID == "" || datavalue.Pharma1takenID == null)
                                {
                                    command.Parameters.Add("@Pharma1takenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma1takenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1takenID;
                                }

                                if (datavalue.Pharma1currentlyID == "" || datavalue.Pharma1currentlyID == null)
                                {
                                    command.Parameters.Add("@Pharma1currentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma1currentlyID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1currentlyID;
                                }

                                if (datavalue.Pharma1pasttakenID == "" || datavalue.Pharma1pasttakenID == null)
                                {
                                    command.Parameters.Add("@Pharma1pasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma1pasttakenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma1pasttakenID;
                                }

                                if (datavalue.Pharma1dosage == "" || datavalue.Pharma1dosage == null)
                                {
                                    command.Parameters.Add("@Pharma1dosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma1dosage", SqlDbType.VarChar, 50).Value = datavalue.Pharma1dosage;
                                }

                                if (datavalue.Pharma1dosageunknown == "" || datavalue.Pharma1dosageunknown == null)
                                {
                                    command.Parameters.Add("@Pharma1dosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma1dosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Pharma1dosageunknown;
                                }

                                if (datavalue.Pharma1capsulescolor == "" || datavalue.Pharma1capsulescolor == null)
                                {
                                    command.Parameters.Add("@Pharma1capsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma1capsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Pharma1capsulescolor;
                                }

                                if (datavalue.Pharma1datelasttaken == "" || datavalue.Pharma1datelasttaken == null)
                                {
                                    command.Parameters.Add("@Pharma1datelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma1datelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Pharma1datelasttaken;
                                }

                                if (datavalue.Pharma1datepickedup == "" || datavalue.Pharma1datepickedup == null)
                                {
                                    command.Parameters.Add("@Pharma1datepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma1datepickedup", SqlDbType.VarChar, 10).Value = datavalue.Pharma1datepickedup;
                                }

                                if (datavalue.Pharma2heardID == "" || datavalue.Pharma2heardID == null)
                                {
                                    command.Parameters.Add("@Pharma2heardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma2heardID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2heardID;
                                }

                                if (datavalue.Pharma2takenID == "" || datavalue.Pharma2takenID == null)
                                {
                                    command.Parameters.Add("@Pharma2takenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma2takenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2takenID;
                                }

                                if (datavalue.Pharma2currentlyID == "" || datavalue.Pharma2currentlyID == null)
                                {
                                    command.Parameters.Add("@Pharma2currentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma2currentlyID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2currentlyID;
                                }

                                if (datavalue.Pharma2pasttakenID == "" || datavalue.Pharma2pasttakenID == null)
                                {
                                    command.Parameters.Add("@Pharma2pasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma2pasttakenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma2pasttakenID;
                                }

                                if (datavalue.Pharma2dosage == "" || datavalue.Pharma2dosage == null)
                                {
                                    command.Parameters.Add("@Pharma2dosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma2dosage", SqlDbType.VarChar, 50).Value = datavalue.Pharma2dosage;
                                }

                                if (datavalue.Pharma2dosageunknown == "" || datavalue.Pharma2dosageunknown == null)
                                {
                                    command.Parameters.Add("@Pharma2dosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma2dosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Pharma2dosageunknown;
                                }

                                if (datavalue.Pharma2capsulescolor == "" || datavalue.Pharma2capsulescolor == null)
                                {
                                    command.Parameters.Add("@Pharma2capsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma2capsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Pharma2capsulescolor;
                                }

                                if (datavalue.Pharma2datelasttaken == "" || datavalue.Pharma2datelasttaken == null)
                                {
                                    command.Parameters.Add("@Pharma2datelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma2datelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Pharma2datelasttaken;
                                }

                                if (datavalue.Pharma2datepickedup == "" || datavalue.Pharma2datepickedup == null)
                                {
                                    command.Parameters.Add("@Pharma2datepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma2datepickedup", SqlDbType.VarChar, 10).Value = datavalue.Pharma2datepickedup;
                                }

                                if (datavalue.Pharma3heardID == "" || datavalue.Pharma3heardID == null)
                                {
                                    command.Parameters.Add("@Pharma3heardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma3heardID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3heardID;
                                }

                                if (datavalue.Pharma3takenID == "" || datavalue.Pharma3takenID == null)
                                {
                                    command.Parameters.Add("@Pharma3takenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma3takenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3takenID;
                                }

                                if (datavalue.Pharma3currentlyID == "" || datavalue.Pharma3currentlyID == null)
                                {
                                    command.Parameters.Add("@Pharma3currentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma3currentlyID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3currentlyID;
                                }

                                if (datavalue.Pharma3pasttakenID == "" || datavalue.Pharma3pasttakenID == null)
                                {
                                    command.Parameters.Add("@Pharma3pasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma3pasttakenID", SqlDbType.VarChar, 50).Value = datavalue.Pharma3pasttakenID;
                                }

                                if (datavalue.Pharma3dosage == "" || datavalue.Pharma3dosage == null)
                                {
                                    command.Parameters.Add("@Pharma3dosage", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma3dosage", SqlDbType.VarChar, 50).Value = datavalue.Pharma3dosage;
                                }

                                if (datavalue.Pharma3dosageunknown == "" || datavalue.Pharma3dosageunknown == null)
                                {
                                    command.Parameters.Add("@Pharma3dosageunknown", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma3dosageunknown", SqlDbType.VarChar, 50).Value = datavalue.Pharma3dosageunknown;
                                }

                                if (datavalue.Pharma3capsulescolor == "" || datavalue.Pharma3capsulescolor == null)
                                {
                                    command.Parameters.Add("@Pharma3capsulescolor", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma3capsulescolor", SqlDbType.VarChar, 50).Value = datavalue.Pharma3capsulescolor;
                                }

                                if (datavalue.Pharma3datelasttaken == "" || datavalue.Pharma3datelasttaken == null)
                                {
                                    command.Parameters.Add("@Pharma3datelasttaken", SqlDbType.VarChar, 10).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma3datelasttaken", SqlDbType.VarChar, 10).Value = datavalue.Pharma3datelasttaken;
                                }

                                if (datavalue.Pharma3datepickedup == "" || datavalue.Pharma3datepickedup == null)
                                {
                                    command.Parameters.Add("@Pharma3datepickedup", SqlDbType.VarChar, 10).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Pharma3datepickedup", SqlDbType.VarChar, 10).Value = datavalue.Pharma3datepickedup;
                                }

                                if (datavalue.Deceased == "" || datavalue.Deceased == null)
                                {
                                    command.Parameters.Add("@Deceased", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Deceased", SqlDbType.VarChar, 50).Value = datavalue.Deceased;
                                }
                                clientidreader2.Close();

                                count = 1;
                                break;
                            }
                        }
                        ////////////////////////////////////////////////////////////////////////////////
                    }
                    else
                    {
                        clientidreader.Close();
                    }
                    //clientidreader.Close();                    
                }
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception xyz)
            {
                xyz.Message.ToString();
            }
            return Json(x);
        }

        [HttpPost]
        public ActionResult Delete(SickeCellclass datavalue)
        {
            var FirstLast = datavalue.FirstName + datavalue.LastName;
            connection.Open();
            SqlCommand deletefullname = new SqlCommand("SickeCell_Stored_Delete", connection);
            deletefullname.CommandType = CommandType.StoredProcedure;
            deletefullname.Parameters.Add("@Clientidx", SqlDbType.VarChar).Value = datavalue.Clientidx;
            SqlDataReader deletereader = deletefullname.ExecuteReader();
            deletereader.Close();

            deletefullname.ExecuteNonQuery();
            connection.Close();

            return Json(datavalue, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Validation(Confirmation confirmvalue)
        {
            connection.Open();

            List<Confirmation> listdata = new List<Confirmation>();
            Confirmation listdataResponse = new Confirmation();
            try
            {
                if (confirmvalue.Email == null || confirmvalue.Email == "")
                {
                    confirmvalue.Email = "";
                }
                SqlCommand locateEmailcmd = new SqlCommand("login_stored_validation", connection);
                locateEmailcmd.CommandType = CommandType.StoredProcedure;
                locateEmailcmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = confirmvalue.Email.Trim();
                locateEmailcmd.Parameters.Add("@Confirmed", SqlDbType.VarChar).Value = confirmvalue.Confirmed.Trim();
                SqlDataReader locateEmailReader = locateEmailcmd.ExecuteReader();

                if (locateEmailReader.HasRows == true)
                {
                    while (locateEmailReader.Read())
                    {
                        listdataResponse.Email = locateEmailReader["Email"].ToString();
                        listdataResponse.Confirmed = locateEmailReader["Confirmed"].ToString();
                        listdataResponse.Message = "Yes";
                        listdata.Add(listdataResponse);
                    }
                }
                else
                {
                    if (confirmvalue.Email == "")
                    {
                        listdataResponse.Message = "Empty";
                        listdata.Add(listdataResponse);
                    }
                    else
                    {
                        if (confirmvalue.Email != "")
                        {
                            listdataResponse.Message = "No";
                            listdata.Add(listdataResponse);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                err.ToString();
            }
            connection.Close();
            return Json(listdata);
        }

        public ActionResult Confirm(Confirmation confirmvalue)
        {
            connection.Open();

            List<Confirmation> listdata = new List<Confirmation>();
            Confirmation listdataResponse = new Confirmation();

            SqlCommand locateEmailcmd = new SqlCommand("login_stored_confirm", connection);
            locateEmailcmd.CommandType = CommandType.StoredProcedure;
            locateEmailcmd.Parameters.Add("@Confirmed", SqlDbType.VarChar).Value = confirmvalue.Confirmed.Trim();
            SqlDataReader locateEmailReader = locateEmailcmd.ExecuteReader();

            if (locateEmailReader.HasRows == true)
            {
                while (locateEmailReader.Read())
                {
                    listdataResponse.Confirmed = locateEmailReader["Confirmed"].ToString();
                    listdata.Add(listdataResponse);
                }
            }
            else
            {
            }
            connection.Close();
            return Json(listdata);
        }              

        public ActionResult Savenotes(SickeCellclass savingnotes)
        {
            List<string> x = new List<string>();
            x.Add(savingnotes.ToString());

            try
            {
                string strdata = " ";
                long longdata = 0;
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Execute Notes_Stored_Save @NotesID,@ClientID,@FirstName,@LastName,@DOB,@Comments,@UserFirstName,@UserLastName,@TimeStamp,@Datenotescreated";
                SqlCommand command2 = new SqlCommand("select top 1 NotesID from Notes order by NotesID DESC", connection);
                SqlDataReader noteidreader = command2.ExecuteReader();

                if (noteidreader.HasRows == true)
                {
                    while (noteidreader.Read())
                    {
                        strdata = noteidreader[0].ToString();
                        longdata = Convert.ToInt64(strdata);
                        command.Parameters.Add("@NotesID", SqlDbType.BigInt).Value = longdata + 1;

                        if (savingnotes.ClientID == "" || savingnotes.ClientID == null)
                        {
                            command.Parameters.Add("@ClientID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@ClientID", SqlDbType.VarChar, 25).Value = savingnotes.ClientID;
                        }

                        if (savingnotes.FirstName == "" || savingnotes.FirstName == null)
                        {
                            command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = savingnotes.FirstName;
                        }

                        if (savingnotes.LastName == "" || savingnotes.LastName == null)
                        {
                            command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = savingnotes.LastName;
                        }

                        if (savingnotes.DOB == ""  || savingnotes.DOB == null)
                        {
                            command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = savingnotes.DOB;
                        }

                        if (savingnotes.Comments == "" || savingnotes.Comments == null)
                        {
                            command.Parameters.Add("@Comments", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Comments", SqlDbType.VarChar).Value = savingnotes.Comments;
                        }

                        if (savingnotes.UserFirstName == "" || savingnotes.UserFirstName == null)
                        {
                            command.Parameters.Add("@UserFirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@UserFirstName", SqlDbType.VarChar, 50).Value = savingnotes.UserFirstName;
                        }

                        if (savingnotes.UserLastName == "" || savingnotes.UserLastName == null)
                        {
                            command.Parameters.Add("@UserLastName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@UserLastName", SqlDbType.VarChar, 50).Value = savingnotes.UserLastName;
                        }

                        if (savingnotes.TimeStamp == "" || savingnotes.TimeStamp == null)
                        {
                            command.Parameters.Add("@TimeStamp", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@TimeStamp", SqlDbType.VarChar, 50).Value = savingnotes.TimeStamp;
                        }

                        if (savingnotes.Datenotescreated == null)
                        {
                            command.Parameters.Add("@Datenotescreated", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Datenotescreated", SqlDbType.Date).Value = savingnotes.Datenotescreated;
                        }
                    }
                    noteidreader.Close();
                }
                //this is ThemeableAttribute condition for the first entry
                else
                {
                    //command.Parameters.Add("@ClientID", SqlDbType.BigInt).Value = longdata + 1;
                    command.Parameters.Add("@NotesID", SqlDbType.BigInt).Value = longdata + 1;

                    if (savingnotes.ClientID == "" || savingnotes.ClientID == null)
                    {
                        command.Parameters.Add("@ClientID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@ClientID", SqlDbType.VarChar, 25).Value = savingnotes.ClientID;
                    }

                    if (savingnotes.FirstName == "" || savingnotes.FirstName == null)
                    {
                        command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = savingnotes.FirstName;
                    }

                    if (savingnotes.LastName == "" || savingnotes.LastName == null)
                    {
                        command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = savingnotes.LastName;
                    }

                    if (savingnotes.DOB == "" ||  savingnotes.DOB == null)
                    {
                        command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = savingnotes.DOB;
                    }

                    if (savingnotes.Comments == "" || savingnotes.Comments == null)
                    {
                        command.Parameters.Add("@Comments", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Comments", SqlDbType.VarChar).Value = savingnotes.Comments;
                    }

                    if (savingnotes.UserFirstName == "" || savingnotes.UserFirstName == null)
                    {
                        command.Parameters.Add("@UserFirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@UserFirstName", SqlDbType.VarChar, 50).Value = savingnotes.UserFirstName;
                    }

                    if (savingnotes.UserLastName == "" || savingnotes.UserLastName == null)
                    {
                        command.Parameters.Add("@UserLastName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@UserLastName", SqlDbType.VarChar, 50).Value = savingnotes.UserLastName;
                    }

                    if (savingnotes.TimeStamp == "" || savingnotes.TimeStamp == null)
                    {
                        command.Parameters.Add("@TimeStamp", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@TimeStamp", SqlDbType.VarChar, 50).Value = savingnotes.TimeStamp;
                    }

                    if (savingnotes.Datenotescreated == null)
                    {
                        command.Parameters.Add("@Datenotescreated", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Datenotescreated", SqlDbType.VarChar, 50).Value = savingnotes.Datenotescreated;
                    }

                    noteidreader.Close();
                }
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception err)
            {
                err.Message.ToString();
            }

            return Json(x);
        }
        
        public ActionResult Loadnotes(SickeCellclass selectednotes)
        {
            List<SickeCellclass> lisRegistered = new List<SickeCellclass>();
            try
            {
                SqlCommand CmdRegister = new SqlCommand("Notes_Stored_Load", connection);
                CmdRegister.CommandType = CommandType.StoredProcedure;
                connection.Open();
                CmdRegister.Parameters.Add("@ClientID", SqlDbType.VarChar).Value = selectednotes.ClientID;

                //DateTime dregis;
                SqlDataReader datareader = CmdRegister.ExecuteReader();
                while (datareader.Read())
                {
                    SickeCellclass datacomments = new SickeCellclass();
                    datacomments.NotesID = Convert.ToInt16(datareader["NotesID"]);
                    datacomments.Comments = datareader["Comments"].ToString();

                    lisRegistered.Add(datacomments);
                }
            }
            catch (Exception err)
            {
                err.Message.ToString();
            }
            connection.Close();
            return Json(lisRegistered, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Integrated(SickeCellclass integratevalue)
        {
            List<SickeCellclass> listIntegrate = new List<SickeCellclass>();
            try
            {
                connection.Open();
                SqlCommand searchclientid = new SqlCommand("SickeCell_Stored_Search_idx", connection);
                searchclientid.CommandType = CommandType.StoredProcedure;
                searchclientid.Parameters.Add("@Clientidx", SqlDbType.VarChar).Value = integratevalue.ClientID;

                SqlDataReader clientidreader = searchclientid.ExecuteReader();
                
                while (clientidreader.Read())
                {
                    SickeCellclass Integrate_Data = new SickeCellclass();
                    Integrate_Data.ClientID = clientidreader["ClientID"].ToString();
                    Integrate_Data.LastName = clientidreader["LastName"].ToString();
                    Integrate_Data.FirstName = clientidreader["FirstName"].ToString();
                    Integrate_Data.Middle_Initial = clientidreader["Middle_Initial"].ToString();
                    Integrate_Data.UniqueID = clientidreader["UniqueID"].ToString();
                    Integrate_Data.DOB = clientidreader["DOB"].ToString();
                    Integrate_Data.Age = clientidreader["Age"].ToString();
                    Integrate_Data.AgeGroup = clientidreader["AgeGroup"].ToString();
                    Integrate_Data.Ageat = clientidreader["Ageat"].ToString();
                    Integrate_Data.Gender = clientidreader["Gender"].ToString();
                    Integrate_Data.Race = clientidreader["Race"].ToString();
                    Integrate_Data.Ethnicity = clientidreader["Ethnicity"].ToString();
                    Integrate_Data.Eligibility = clientidreader["Eligibility"].ToString();
                    Integrate_Data.SSN = clientidreader["SSN"].ToString();
                    Integrate_Data.CountyCode = clientidreader["CountyCode"].ToString();
                    Integrate_Data.CountyCodeDescription = clientidreader["CountyCodeDescription"].ToString();
                    Integrate_Data.PhoneNumber = clientidreader["PhoneNumber"].ToString();
                    Integrate_Data.SickleCellDiagnosis = clientidreader["SickleCellDiagnosis"].ToString();
                    Integrate_Data.FullStreetAddress = clientidreader["FullStreetAddress"].ToString();
                    Integrate_Data.FullStreetAddress2 = clientidreader["FullStreetAddress2"].ToString();
                    Integrate_Data.City = clientidreader["City"].ToString();
                    Integrate_Data.State = clientidreader["State"].ToString();
                    Integrate_Data.ZipCode = clientidreader["ZipCode"].ToString();
                    Integrate_Data.PMPProviderName = clientidreader["PMPProviderName"].ToString();
                    Integrate_Data.CCUCase = clientidreader["CCUCase"].ToString();
                    Integrate_Data.Email_Address = clientidreader["Email_Address"].ToString();
                    Integrate_Data.ClientresideinruralID = clientidreader["ClientresideinruralID"].ToString();
                    Integrate_Data.Nameofmother = clientidreader["Nameofmother"].ToString();
                    Integrate_Data.Address_Of_Mother = clientidreader["Address_Of_Mother"].ToString();
                    Integrate_Data.Telephone_Of_Mother = clientidreader["Telephone_Of_Mother"].ToString();
                    Integrate_Data.Nameoffather = clientidreader["Nameoffather"].ToString();
                    Integrate_Data.Address_Of_Father = clientidreader["Address_Of_Father"].ToString();
                    Integrate_Data.Telephone_Of_Father = clientidreader["Telephone_Of_Father"].ToString();
                    Integrate_Data.Nameofguardian = clientidreader["Nameofguardian"].ToString();
                    Integrate_Data.Address_Of_Guardian = clientidreader["Address_Of_Guardian"].ToString();
                    Integrate_Data.Guardian_Telephone = clientidreader["Guardian_Telephone"].ToString();
                    Integrate_Data.Emergency_Contact1 = clientidreader["Emergency_Contact1"].ToString();
                    Integrate_Data.Emergency_Contact1_HomePhone = clientidreader["Emergency_Contact1_HomePhone"].ToString();
                    Integrate_Data.Emergency_Contact1_CellPhone = clientidreader["Emergency_Contact1_CellPhone"].ToString();
                    Integrate_Data.Emergency_Contact2 = clientidreader["Emergency_Contact2"].ToString();
                    Integrate_Data.Emergency_Contact2_HomePhone = clientidreader["Emergency_Contact2_HomePhone"].ToString();
                    Integrate_Data.Emergency_Contact2_CellPhone = clientidreader["Emergency_Contact2_CellPhone"].ToString();
                    Integrate_Data.SicklecelltypeID = clientidreader["SicklecelltypeID"].ToString();
                    Integrate_Data.HydroxyureaheardID = clientidreader["HydroxyureaheardID"].ToString();
                    Integrate_Data.HydroxyureatakenID = clientidreader["HydroxyureatakenID"].ToString();
                    Integrate_Data.HydroxyureacurrentlyID = clientidreader["HydroxyureacurrentlyID"].ToString();
                    Integrate_Data.HydroxyureapasttakenID = clientidreader["HydroxyureapasttakenID"].ToString();
                    Integrate_Data.Hydroxyureadosage = clientidreader["Hydroxyureadosage"].ToString();
                    Integrate_Data.Hydroxyureadosageunknown = clientidreader["Hydroxyureadosageunknown"].ToString();
                    Integrate_Data.Hydroxyureacapsulescolor = clientidreader["Hydroxyureacapsulescolor"].ToString();
                    Integrate_Data.Pharma1heardID = clientidreader["Pharma1heardID"].ToString();
                    Integrate_Data.Pharma1takenID = clientidreader["Pharma1takenID"].ToString();
                    Integrate_Data.Pharma1currentlyID = clientidreader["Pharma1currentlyID"].ToString();
                    Integrate_Data.Pharma1pasttakenID = clientidreader["Pharma1pasttakenID"].ToString();
                    Integrate_Data.Pharma1dosage = clientidreader["Pharma1dosage"].ToString();
                    Integrate_Data.Pharma1dosageunknown = clientidreader["Pharma1dosageunknown"].ToString();
                    Integrate_Data.Pharma1capsulescolor = clientidreader["Pharma1capsulescolor"].ToString();
                    Integrate_Data.Pharma2heardID = clientidreader["Pharma2heardID"].ToString();
                    Integrate_Data.Pharma2takenID = clientidreader["Pharma2takenID"].ToString();
                    Integrate_Data.Pharma2currentlyID = clientidreader["Pharma2currentlyID"].ToString();
                    Integrate_Data.Pharma2pasttakenID = clientidreader["Pharma2pasttakenID"].ToString();
                    Integrate_Data.Pharma2dosage = clientidreader["Pharma2dosage"].ToString();
                    Integrate_Data.Pharma2dosageunknown = clientidreader["Pharma2dosageunknown"].ToString();
                    Integrate_Data.Pharma2capsulescolor = clientidreader["Pharma2capsulescolor"].ToString();
                    Integrate_Data.Pharma3heardID = clientidreader["Pharma3heardID"].ToString();
                    Integrate_Data.Pharma3takenID = clientidreader["Pharma3takenID"].ToString();
                    Integrate_Data.Pharma3currentlyID = clientidreader["Pharma3currentlyID"].ToString();
                    Integrate_Data.Pharma3pasttakenID = clientidreader["Pharma3pasttakenID"].ToString();
                    Integrate_Data.Pharma3dosage = clientidreader["Pharma3dosage"].ToString();
                    Integrate_Data.Pharma3dosageunknown = clientidreader["Pharma3dosageunknown"].ToString();
                    Integrate_Data.Pharma3capsulescolor = clientidreader["Pharma3capsulescolor"].ToString();

                    Integrate_Data.Comments = clientidreader["Comments"].ToString();
                    listIntegrate.Add(Integrate_Data);
                }           
            }
            catch (Exception err)
            {
                err.Message.ToString();
            }
            connection.Close();
            return Json(listIntegrate, JsonRequestBehavior.AllowGet);
        }

        //POST: api/Savelogin
        [HttpPost]
        public ActionResult Saveloggedin(Savelogged savelogin)
        {
            connection.Open();            

            List<Savelogged> listdata = new List<Savelogged>();
            Savelogged listdataResponse = new Savelogged();            
            try
            {
                SqlCommand logsavecmd = connection.CreateCommand();
                logsavecmd.CommandText = "Execute loginsave_Stored @HistologinId,@FirstName,@LastName,@Role,@Email, @CurrentDate, @Logged_In,@Logged_Out";                
                SqlCommand command2 = new SqlCommand("select top 1 HistologinId from Loggedin_history order by HistologinId DESC", connection);                
                SqlDataReader locatelogsaveReader = command2.ExecuteReader();               

                TimeZone curTimeZone = TimeZone.CurrentTimeZone;
                //TimeSpan currentOffset = curTimeZone.GetUtcOffset(DateTime.Now);
                TimeZone localZone = TimeZone.CurrentTimeZone;
                //DateTime currentDate = DateTime.Now;
                //DateTime CST_time = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");

                //string TimeZonename1 = localZone.StandardName;
                //string TimeZonename2 = curTimeZone.StandardName;

                //TimeSpan DBSigIn2 = DateTime.Now.TimeOfDay;                
                //DateTime b2 = DateTime.Parse(DBSigIn2.ToString());
                //var DBSigIn = b2.ToString("hh: mm:ss tt");

                //var Doftheday = DateTime.Now;
                //var Currdate = Doftheday.Date;

                DateTime CST_time =  TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
                TimeSpan cst_currtime = CST_time.TimeOfDay;
                DateTime cst_parse = DateTime.Parse(cst_currtime.ToString());
                var DBSigIn = cst_parse.ToString("hh: mm:ss tt");                               

                var Doftheday = DateTime.Now;
                var Currdate = CST_time.Date;                                          

                string a = "";
                long b = 0;
          
                if (locatelogsaveReader.HasRows == true)
                {
                    while (locatelogsaveReader.Read())
                    {
                        a = locatelogsaveReader[0].ToString();
                        b = Convert.ToInt64(a);

                        logsavecmd.Parameters.Add("@HistologinId", SqlDbType.BigInt).Value = b + 1;
                        vdata = b + 1;
                        listdataResponse.HistologinId = Convert.ToInt32(vdata);                        

                        if (savelogin.FirstName == "" || savelogin.FirstName == null)
                        {
                            logsavecmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            logsavecmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = savelogin.FirstName;
                        }

                        if (savelogin.LastName == "" || savelogin.LastName == null)
                        {
                            logsavecmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            logsavecmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = savelogin.LastName;
                        }

                        if (savelogin.Role == "" || savelogin.Role == null)
                        {
                            logsavecmd.Parameters.Add("@Role", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            logsavecmd.Parameters.Add("@Role", SqlDbType.VarChar, 50).Value = savelogin.Role;
                        }

                        if (savelogin.Email == "" || savelogin.Email == null)
                        {
                            logsavecmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = DBNull.Value;
                        }
                        else
                        {
                            logsavecmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = savelogin.Email;
                        }
                            logsavecmd.Parameters.Add("@CurrentDate", SqlDbType.Date, 50).Value = Currdate;                       
                            logsavecmd.Parameters.Add("@Logged_In", SqlDbType.VarChar, 50).Value = DBSigIn;                        
                            logsavecmd.Parameters.Add("@Logged_Out", SqlDbType.VarChar, 50).Value = "";                       
                    }

                    locatelogsaveReader.Close();
                    logsavecmd.ExecuteNonQuery();
                    connection.Close();                    
                }
                else
                {
                    logsavecmd.Parameters.Add("@HistologinId", SqlDbType.BigInt).Value = b + 1;
                    vdata = b + 1;
                    listdataResponse.HistologinId = Convert.ToInt32(vdata);                    

                    if (savelogin.FirstName == "" || savelogin.FirstName == null)
                    {
                        logsavecmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        logsavecmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = savelogin.FirstName;
                    }

                    if (savelogin.LastName == "" || savelogin.LastName == null)
                    {
                        logsavecmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        logsavecmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = savelogin.LastName;
                    }

                    if (savelogin.Role == "" || savelogin.Role == null)
                    {
                        logsavecmd.Parameters.Add("@Role", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        logsavecmd.Parameters.Add("@Role", SqlDbType.VarChar, 50).Value = savelogin.Role;
                    }

                    if (savelogin.Email == "" || savelogin.Email == null)
                    {
                        logsavecmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    }
                    else
                    {
                        logsavecmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = savelogin.Email;
                    }

                        logsavecmd.Parameters.Add("@CurrentDate", SqlDbType.Date, 50).Value = Currdate;                    
                        logsavecmd.Parameters.Add("@Logged_In", SqlDbType.VarChar, 50).Value = DBSigIn;                    
                        logsavecmd.Parameters.Add("@Logged_Out", SqlDbType.VarChar, 50).Value = "";
                    
                    locatelogsaveReader.Close();
                    logsavecmd.ExecuteNonQuery();
                    connection.Close();                   
                }

            }
            catch (Exception err)
            {
                err.Message.ToString();
            }
            listdata.Add(listdataResponse);
            return Json(listdata, JsonRequestBehavior.AllowGet);
        }

        //POST: api/Savelogin
        [HttpPost]
        public ActionResult Loggingout(Savelogged datalogout)
        {
            connection.Open();

            List<Savelogged> listdata = new List<Savelogged>();
            Savelogged listdataResponse = new Savelogged();
            try
            {                
                TimeSpan DBSignOut2 = DateTime.Now.TimeOfDay;
                DateTime b3 = DateTime.Parse(DBSignOut2.ToString());
                var DBSignOut = b3.ToString("hh: mm:ss tt");

                var Doftheday = DateTime.Now;
                var Currdate = Doftheday.Date;
                
                SqlCommand logoutexec;
                logoutexec = new SqlCommand("logout_Stored", connection);
                logoutexec.CommandType = CommandType.StoredProcedure;
                logoutexec.Parameters.Add("@Logged_Out", SqlDbType.VarChar).Value = DBSignOut;
                logoutexec.Parameters.Add("@HistologinId", SqlDbType.VarChar).Value = datalogout.HistologinId;

                SqlDataReader overviewreader = logoutexec.ExecuteReader();

                overviewreader.Close();                
                connection.Close();
                return Json(listdata, JsonRequestBehavior.AllowGet);

            }
            catch (Exception err)
            {
                err.Message.ToString();
            }
            return Json(listdata, JsonRequestBehavior.AllowGet);
        }       
        
        [HttpPost]
        public ActionResult History(Savelogged historydataview)
        {            
            List<Savelogged> historylist = new List<Savelogged>();
            Savelogged historydataResponse = new Savelogged();

            connection.Open();
            SqlCommand historyview = new SqlCommand("select HistologinId, FirstName, LastName, Role, Email, CurrentDate, Logged_In from loggedin_history order by HistologinId DESC", connection);
            SqlDataReader historyreader = historyview.ExecuteReader();

            try
            {               
                if (historyreader.HasRows == true)
                {
                    while (historyreader.Read())
                    {
                        Savelogged historydatagroup = new Savelogged();
                        historydatagroup.FirstName = historyreader["FirstName"].ToString();
                        historydatagroup.LastName = historyreader["LastName"].ToString();
                        historydatagroup.Role = historyreader["Role"].ToString();
                        historydatagroup.Email = historyreader["Email"].ToString();                        
                        historydatagroup.CurrentDatehis = historyreader["CurrentDate"].ToString().Substring(0, 10);
                        //historydatagroup.CurrentDatehis = Convert.ToDateTime(historyreader["CurrentDate"]); 
                        historydatagroup.Logged_In = historyreader["Logged_In"].ToString();

                        historylist.Add(historydatagroup);
                    }
                }
                else
                {
                    historyreader.Close();
                    connect.Close();

                    return Json(historylist);
                }                

            }
            catch (Exception err)
            {
                err.Message.ToString();
            }
            return Json(historylist);
        }
    }
};
