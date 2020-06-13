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
    public class UploadController : Controller
    {
        public static string con = ConfigurationManager.ConnectionStrings["SickeCellConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(con);

        public class SickeCellclass
        {
            public string Clientidx { get; set; }
            public int ClientID { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Mi { get; set; }
            public string UniqueID { get; set; }
            public string DOB { get; set; }
            public string Age { get; set; }
            public string AgeGroup { get; set; }
            public string Ageat { get; set; }
            public string Gender { get; set; }
            public string Race { get; set; }
            public string Ethnicity { get; set; }
            public string Eligibility { get; set; }
            public string SSSno { get; set; }
            public string CountryCode { get; set; }
            public string CountyCodeDescription { get; set; }
            public string CpNumber { get; set; }
            public string SickleCellDiagnosis { get; set; }
            public string FullStreetAddress { get; set; }
            public string FullStreetAddress2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
            public string PMPProviderName { get; set; }
            public string CCUCase { get; set; }
            public string Email_Address { get; set; }
            public string Email_Address2 { get; set; }
            public string ClientresideinruralID { get; set; }
            public string Nameofmother { get; set; }
            public string Motheraddress { get; set; }
            public string Mothertel { get; set; }
            public string Nameoffather { get; set; }
            public string Fatheraddress { get; set; }
            public string Fathertel { get; set; }
            public string Nameofguardian { get; set; }
            public string Guardianaddress { get; set; }
            public string Guardiantel { get; set; }
            public string Emercont1 { get; set; }
            public string Emercont1homephone { get; set; }
            public string Emercont1cellphone { get; set; }
            public string Emercont2 { get; set; }
            public string Emercont2homephone { get; set; }
            public string Emercont2cellphone { get; set; }
            public string SicklecelltypeID { get; set; }
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
        }

        public class SickleCelloverviewclass
        {
            public string Clientidx { get; set; }
            public int ClientID { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string DOB { get; set; }
            public string Gender { get; set; }
            public string FullStreetAddress { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Email_Address { get; set; }
        }

        string vfname = "";
        int counter;
        //int counter1;

        string combine = "";
        string validate;        

        string[] b;
        
        List<string> listcolllected     = new List<string>();
        List<string> listcolllectfilter = new List<string>();
        List<string> listcolllected2    = new List<string>();

        public class Conversion
        {
            public string Path { get; set; }
            public object Jresult { get; set; }
        }

        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        // GET: Upload/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        ///This is to open and save file
        public ActionResult Open(object data)
        {
            ViewBag.Title = "Open CSV File";

            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        // Get the complete folder path and store the file inside it.                         
                        fname = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/"), fname);
                        data = fname;
                        file.SaveAs(fname);

                        break;
                    }
                    return Json(data);
                }
                catch (Exception Error)
                {
                    return Json("Error occurred. Error details: " + Error.Message);
                }
            }
            else
            {
                //return Json("No files selected.",JsonRequestBehavior.AllowGet);
                return View();
            }
        }

        // POST: Upload/Create
        [HttpPost]
        public ActionResult CsvExtraction(Conversion variablePath)
        {
          if (variablePath.Path != null) {
          int counter = 0;   
          int counter2 = 0;   
            try
            {
                vfname = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/"), variablePath.Path);
                string textXML = System.IO.File.ReadAllText(vfname);
                var x = Json(textXML);

                string[] a = new string[] { textXML };
                b = a[0].Split(',');
                
                int countfilter = 0;
                string filter = "";

                for (var s = 0; s < b.Length; s++)
                {
                    //validate2 = Convert.ToString(b[s].Substring(b[s].Length - 4));                                 
                    if (b[s].ToString().Length >=4)
                    {                        
                        validate = b[s].Substring(b[s].Length - 2);
                    }
                    else { validate = b[s].ToString();}

                    if (validate != "\r\n" && counter < 53)
                    {
                        if (s == 0)
                        {
                            combine = combine + b[s].ToString();
                        }
                        else
                        {                            
                            combine = combine + "  " + b[s].ToString();
                            listcolllected.Add(b[s].ToString());
                        }                        
                    }
                    else
                    {
                        if (validate== "\r\n")
                        {
                            if (s <=53)
                            {
                                countfilter = b[s].ToString().Length - 2;
                                filter = b[s].ToString().Substring(0, countfilter);
                                listcolllected.Add(filter);
                                listcolllected.Add("break");                                
                            }
                            else
                            {
                                countfilter = b[s].ToString().Length - 2;
                                filter = b[s].ToString().Substring(0, countfilter);
                                listcolllectfilter.Add(filter);
                                //listcolllectfilter.Add("break");                               
                            }
                        }
                        else
                        {
                            listcolllectfilter.Add(b[s]);
                        }                        
                    }
                    counter = counter + 1;
                }

                for (var j = 0; j < listcolllectfilter.Count; j++)
                {
                    if (listcolllectfilter[j] != "break")
                    {
                        listcolllected2.Add(listcolllectfilter[j].ToString());
                    }
                }

                Console.WriteLine(listcolllected2);
                //this is to insert into the Information table
                string strdata = " ";
                long longdata = 0;
                connection.Open();     
                                

                for(var k = 0; k < listcolllected2.Count; k = k + 52) {
                    
                    SqlCommand command2 = new SqlCommand("select top 1 ClientID from Information order by ClientID DESC", connection);
                    SqlDataReader clientidreader = command2.ExecuteReader();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "Execute Information_Stored_Save @ClientID,@LastName, @FirstName, @Mi, @UniqueID, @DOB, @Age, @AgeGroup, @Ageat, @Gender,@Race, @Ethnicity, @Eligibility, @SSSno, @CountryCode, @CountyCodeDescription, @CpNumber, @SickleCellDiagnosis, @FullStreetAddress, @FullStreetAddress2, @City, @State, @ZipCode, @PMPProviderName, @CCUCase, @Email_Address, @ClientresideinruralID, @Nameofmother, @Motheraddress, @Mothertel, @Nameoffather, @Fatheraddress, @Fathertel, @Nameofguardian, @Guardianaddress, @Guardiantel, @Emercont1, @Emercont1homephone , @Emercont1cellphone, @Emercont2, @Emercont2homephone, @Emercont2cellphone,  @SicklecelltypeID, @HydroxyureaheardID, @HydroxyureatakenID, @HydroxyureacurrentlyID, @HydroxyureapasttakenID";

                    if (clientidreader.HasRows == true)
                    {
                      while (clientidreader.Read())
                      {
                          strdata = clientidreader[0].ToString();
                          longdata = Convert.ToInt64(strdata);

                          command.Parameters.Add("@ClientID", SqlDbType.Int).Value = longdata + 1;                                                   

                          if (listcolllected2[k] == "" || listcolllected2[k] == null)
                          {
                                string firstname = listcolllected2[k + 1].ToString();
                                command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;                                
                          }
                          else
                          {
                                string firstname = listcolllected2[k + 1].ToString();
                                command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = listcolllected2[k];                                
                          }

                          if (listcolllected2[k + 1] == "" || listcolllected2[k + 1] == null)
                          {
                                string lastname = listcolllected2[k + 2].ToString();
                                command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = DBNull.Value;                                
                          }
                          else
                          {
                                string lastname = listcolllected2[k + 2].ToString();
                                command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = listcolllected2[k + 1];                                
                          }

                          if (listcolllected2[k + 2] == "" || listcolllected2[k + 2] == null)
                          {
                                command.Parameters.Add("@Mi", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@Mi", SqlDbType.VarChar, 50).Value = listcolllected2[k + 2];
                          }

                          if (listcolllected2[k + 3] == "" || listcolllected2[k + 3] == null)
                          {
                                command.Parameters.Add("@UniqueID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@UniqueID", SqlDbType.VarChar, 50).Value = listcolllected2[k + 3];
                          }

                          if (listcolllected2[k + 4] == "" || listcolllected2[k + 4] == null)
                          {
                                command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = listcolllected2[k + 4];
                          }

                          if (listcolllected2[k + 5] == "" || listcolllected2[k + 5] == null)
                          {
                                command.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = listcolllected2[k + 5];
                          }

                          if (listcolllected2[k + 6] == "" || listcolllected2[k + 6] == null)
                          {
                                command.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 50).Value = listcolllected2[k + 6];
                          }

                          if (listcolllected2[k + 7] == "" || listcolllected2[k + 7] == null)
                          {
                                command.Parameters.Add("@Ageat", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@Ageat", SqlDbType.VarChar, 50).Value = listcolllected2[k + 7];
                          }

                          if (listcolllected2[k + 8] == "" || listcolllected2[k + 8] == null)
                          {
                                command.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = listcolllected2[k + 8];
                          }

                          if (listcolllected2[k + 9] == "" || listcolllected2[k + 9] == null)
                          {
                                command.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = listcolllected2[k + 9];
                          }

                          if (listcolllected2[k + 10] == "" || listcolllected2[k + 10] == null)
                          {
                                command.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 50).Value = listcolllected2[k + 10];
                          }

                          if (listcolllected2[k + 11] == "" || listcolllected2[k + 11] == null)
                          {
                                command.Parameters.Add("@SSSno", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@SSSno", SqlDbType.VarChar, 50).Value = listcolllected2[k + 11];
                          }

                          if (listcolllected2[k + 12] == "" || listcolllected2[k + 12] == null)
                          {
                                command.Parameters.Add("@CpNumber", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@CpNumber", SqlDbType.VarChar, 50).Value = listcolllected2[k + 12];
                          }

                          if (listcolllected2[k + 13] == "" || listcolllected2[k + 13] == null)
                          {
                                command.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 50).Value = listcolllected2[k + 13];
                          }                          

                          if (listcolllected2[k + 14] == "" || listcolllected2[k + 14] == null)
                          {
                                command.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 50).Value = listcolllected2[k + 14];
                          }                          

                          if (listcolllected2[k + 15] == "" || listcolllected2[k + 15] == null)
                          {
                                command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = listcolllected2[k + 15];
                          }

                          if (listcolllected2[k + 16] == "" || listcolllected2[k + 16] == null)
                          {
                                command.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                                command.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = listcolllected2[k + 16];
                          }

                          if (listcolllected2[k + 17] == "" || listcolllected2[k + 17] == null)
                          {
                            command.Parameters.Add("@CountryCode", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@CountryCode", SqlDbType.VarChar, 50).Value = listcolllected2[k + 17];
                          }

                          if (listcolllected2[k + 18] == "" || listcolllected2[k + 18] == null)
                          {
                            command.Parameters.Add("@FullStreetAddress2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@FullStreetAddress2", SqlDbType.VarChar, 50).Value = listcolllected2[k + 18];
                          }                          

                          if (listcolllected2[k + 19] == "" || listcolllected2[k + 19] == null)
                          {
                            command.Parameters.Add("@Eligibility", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Eligibility", SqlDbType.VarChar, 50).Value = listcolllected2[k + 19];
                          }

                          if (listcolllected2[k + 20] == "" || listcolllected2[k + 20] == null)
                          {
                             command.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                             command.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 50).Value = listcolllected2[k + 20];
                          }

                          if (listcolllected2[k + 21] == "" || listcolllected2[k + 21] == null)
                          {
                            command.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = listcolllected2[k + 21];
                          }

                          if (listcolllected2[k + 22] == "" || listcolllected2[k + 22] == null)
                          {
                            command.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 50).Value = listcolllected2[k + 22];
                          }

                          if (listcolllected2[k + 23] == "" || listcolllected2[k + 23] == null)
                          {
                            command.Parameters.Add("@CCUCase", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@CCUCase", SqlDbType.VarChar, 50).Value = listcolllected2[k + 23];
                          }

                          if (listcolllected2[k + 24] == "" || listcolllected2[k + 24] == null)
                          {
                             command.Parameters.Add("@ClientresideinruralID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                             command.Parameters.Add("@ClientresideinruralID", SqlDbType.VarChar, 50).Value = listcolllected2[k + 24];
                          }

                          if (listcolllected2[k + 25] == "" || listcolllected2[k + 25] == null)
                          {
                            command.Parameters.Add("@Email_Address", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Email_Address", SqlDbType.VarChar, 50).Value = listcolllected2[k + 25] + "" + ".";
                          }                          

                          if (listcolllected2[k + 26] == "" || listcolllected2[k + 26] == null)
                          {
                            command.Parameters.Add("@Nameofmother", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Nameofmother", SqlDbType.VarChar, 50).Value = listcolllected2[k + 26];
                          }

                          if (listcolllected2[k + 27] == "" || listcolllected2[k + 27] == null)
                          {
                            command.Parameters.Add("@Motheraddress", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Motheraddress", SqlDbType.VarChar, 50).Value = listcolllected2[k + 27];
                          }

                          if (listcolllected2[k + 28] == "" || listcolllected2[k + 28] == null)
                          {
                            command.Parameters.Add("@Mothertel", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Mothertel", SqlDbType.VarChar, 50).Value = listcolllected2[k + 28];
                          }

                          if (listcolllected2[k + 29] == "" || listcolllected2[k + 29] == null)
                          {
                            command.Parameters.Add("@Nameoffather", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Nameoffather", SqlDbType.VarChar, 50).Value = listcolllected2[k + 29];
                          }

                          if (listcolllected2[k + 30] == "" || listcolllected2[k + 30] == null)
                          {
                            command.Parameters.Add("@Fatheraddress", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Fatheraddress", SqlDbType.VarChar, 50).Value = listcolllected2[k + 30];
                          }

                          if (listcolllected2[k + 31] == "" || listcolllected2[k + 31] == null)
                          {
                            command.Parameters.Add("@Fathertel", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Fathertel", SqlDbType.VarChar, 50).Value = listcolllected2[k + 31];
                          }

                          if (listcolllected2[k + 32] == "" || listcolllected2[k + 32] == null)
                          {
                            command.Parameters.Add("@Nameofguardian", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Nameofguardian", SqlDbType.VarChar, 50).Value = listcolllected2[k + 32];
                          }

                          if (listcolllected2[k + 33] == "" || listcolllected2[k + 33] == null)
                          {
                            command.Parameters.Add("@Guardianaddress", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Guardianaddress", SqlDbType.VarChar, 50).Value = listcolllected2[k + 33];
                          }

                          if (listcolllected2[k + 34] == "" || listcolllected2[k + 34] == null)
                          {
                            command.Parameters.Add("@Guardiantel", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Guardiantel", SqlDbType.VarChar, 50).Value = listcolllected2[k + 34];
                          }

                          if (listcolllected2[k + 35] == "" || listcolllected2[k + 35] == null)
                          {
                            command.Parameters.Add("@Emercont1", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Emercont1", SqlDbType.VarChar, 50).Value = listcolllected2[k + 35];
                          }

                          if (listcolllected2[k + 36] == "" || listcolllected2[k + 36] == null)
                          {
                            command.Parameters.Add("@Emercont1homephone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Emercont1homephone", SqlDbType.VarChar, 50).Value = listcolllected2[k + 36];
                          }

                          if (listcolllected2[k + 37] == "" || listcolllected2[k + 37] == null)
                          {
                            command.Parameters.Add("@Emercont1cellphone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Emercont1cellphone", SqlDbType.VarChar, 50).Value = listcolllected2[k + 37];
                          }

                          if (listcolllected2[k + 38] == "" || listcolllected2[k + 38] == null)
                          {
                            command.Parameters.Add("@Emercont2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Emercont2", SqlDbType.VarChar, 50).Value = listcolllected2[k + 38];
                          }

                          if (listcolllected2[k + 39] == "" || listcolllected2[k + 39] == null)
                          {
                            command.Parameters.Add("@Emercont2homephone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Emercont2homephone", SqlDbType.VarChar, 50).Value = listcolllected2[k + 39];
                          }

                          if (listcolllected2[k + 40] == "" || listcolllected2[k + 40] == null)
                          {
                            command.Parameters.Add("@Emercont2cellphone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@Emercont2cellphone", SqlDbType.VarChar, 50).Value = listcolllected2[k + 40];
                          }

                          if (listcolllected2[k + 41] == "" || listcolllected2[k + 41] == null)
                          {
                            command.Parameters.Add("@SicklecelltypeID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@SicklecelltypeID", SqlDbType.VarChar, 50).Value = listcolllected2[k + 41];
                          }

                          if (listcolllected2[k + 42] == "" || listcolllected2[k + 42] == null)
                          {
                            command.Parameters.Add("@HydroxyureaheardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@HydroxyureaheardID", SqlDbType.VarChar, 50).Value = listcolllected2[k + 42];
                          }

                          if (listcolllected2[k + 43] == "" || listcolllected2[k + 43] == null)
                          {
                            command.Parameters.Add("@HydroxyureatakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@HydroxyureatakenID", SqlDbType.VarChar, 50).Value = listcolllected2[k + 43];
                          }

                          if (listcolllected2[k + 44] == "" || listcolllected2[k + 44] == null)
                          {
                            command.Parameters.Add("@HydroxyureacurrentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@HydroxyureacurrentlyID", SqlDbType.VarChar, 50).Value = listcolllected2[k + 44];
                          }

                          if (listcolllected2[k + 45] == "" || listcolllected2[k + 45] == null)
                          {
                            command.Parameters.Add("@HydroxyureapasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                          }
                          else
                          {
                            command.Parameters.Add("@HydroxyureapasttakenID", SqlDbType.VarChar, 50).Value = listcolllected2[k + 45];
                          }
                      }                      
                    }
                    //this is ThemeableAttribute condition for the first entry
                    else
                    {
                            command.Parameters.Add("@ClientID", SqlDbType.Int).Value = longdata + 1;

                            if (listcolllected2[k] == "" || listcolllected2[k] == null)
                            {
                                string firstname = listcolllected2[k + 1].ToString();
                                command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                string firstname = listcolllected2[k + 1].ToString();
                                command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = listcolllected2[k];
                            }

                            if (listcolllected2[k + 1] == "" || listcolllected2[k + 1] == null)
                            {
                                string lastname = listcolllected2[k + 2].ToString();
                                command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                string lastname = listcolllected2[k + 2].ToString();
                                command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = listcolllected2[k + 1];
                            }

                            if (listcolllected2[k + 2] == "" || listcolllected2[k + 2] == null)
                            {
                                command.Parameters.Add("@Mi", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Mi", SqlDbType.VarChar, 50).Value = listcolllected2[k + 2];
                            }

                            if (listcolllected2[k + 3] == "" || listcolllected2[k + 3] == null)
                            {
                                command.Parameters.Add("@UniqueID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@UniqueID", SqlDbType.VarChar, 50).Value = listcolllected2[k + 3];
                            }

                            if (listcolllected2[k + 4] == "" || listcolllected2[k + 4] == null)
                            {
                                command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = listcolllected2[k + 4];
                            }

                            if (listcolllected2[k + 5] == "" || listcolllected2[k + 5] == null)
                            {
                                command.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = listcolllected2[k + 5];
                            }

                            if (listcolllected2[k + 6] == "" || listcolllected2[k + 6] == null)
                            {
                                command.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 50).Value = listcolllected2[k + 6];
                            }

                            if (listcolllected2[k + 7] == "" || listcolllected2[k + 7] == null)
                            {
                                command.Parameters.Add("@Ageat", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Ageat", SqlDbType.VarChar, 50).Value = listcolllected2[k + 7];
                            }

                            if (listcolllected2[k + 8] == "" || listcolllected2[k + 8] == null)
                            {
                                command.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = listcolllected2[k + 8];
                            }

                            if (listcolllected2[k + 9] == "" || listcolllected2[k + 9] == null)
                            {
                                command.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = listcolllected2[k + 9];
                            }

                            if (listcolllected2[k + 10] == "" || listcolllected2[k + 10] == null)
                            {
                                command.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 50).Value = listcolllected2[k + 10];
                            }

                            if (listcolllected2[k + 11] == "" || listcolllected2[k + 11] == null)
                            {
                                command.Parameters.Add("@SSSno", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@SSSno", SqlDbType.VarChar, 50).Value = listcolllected2[k + 11];
                            }

                            if (listcolllected2[k + 12] == "" || listcolllected2[k + 12] == null)
                            {
                                command.Parameters.Add("@CpNumber", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@CpNumber", SqlDbType.VarChar, 50).Value = listcolllected2[k + 12];
                            }

                            if (listcolllected2[k + 13] == "" || listcolllected2[k + 13] == null)
                            {
                                command.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 50).Value = listcolllected2[k + 13];
                            }

                            if (listcolllected2[k + 14] == "" || listcolllected2[k + 14] == null)
                            {
                                command.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 50).Value = listcolllected2[k + 14];
                            }

                            if (listcolllected2[k + 15] == "" || listcolllected2[k + 15] == null)
                            {
                                command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = listcolllected2[k + 15];
                            }

                            if (listcolllected2[k + 16] == "" || listcolllected2[k + 16] == null)
                            {
                                command.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = listcolllected2[k + 16];
                            }

                            if (listcolllected2[k + 17] == "" || listcolllected2[k + 17] == null)
                            {
                                command.Parameters.Add("@CountryCode", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@CountryCode", SqlDbType.VarChar, 50).Value = listcolllected2[k + 17];
                            }

                            if (listcolllected2[k + 18] == "" || listcolllected2[k + 18] == null)
                            {
                                command.Parameters.Add("@FullStreetAddress2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@FullStreetAddress2", SqlDbType.VarChar, 50).Value = listcolllected2[k + 18];
                            }

                            if (listcolllected2[k + 19] == "" || listcolllected2[k + 19] == null)
                            {
                                command.Parameters.Add("@Eligibility", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Eligibility", SqlDbType.VarChar, 50).Value = listcolllected2[k + 19];
                            }

                            if (listcolllected2[k + 20] == "" || listcolllected2[k + 20] == null)
                            {
                                command.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 50).Value = listcolllected2[k + 20];
                            }

                            if (listcolllected2[k + 21] == "" || listcolllected2[k + 21] == null)
                            {
                                command.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = listcolllected2[k + 21];
                            }

                            if (listcolllected2[k + 22] == "" || listcolllected2[k + 22] == null)
                            {
                                command.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 50).Value = listcolllected2[k + 22];
                            }

                            if (listcolllected2[k + 23] == "" || listcolllected2[k + 23] == null)
                            {
                                command.Parameters.Add("@CCUCase", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@CCUCase", SqlDbType.VarChar, 50).Value = listcolllected2[k + 23];
                            }

                            if (listcolllected2[k + 24] == "" || listcolllected2[k + 24] == null)
                            {
                                command.Parameters.Add("@ClientresideinruralID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@ClientresideinruralID", SqlDbType.VarChar, 50).Value = listcolllected2[k + 24];
                            }

                            if (listcolllected2[k + 25] == "" || listcolllected2[k + 25] == null)
                            {
                                command.Parameters.Add("@Email_Address", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Email_Address", SqlDbType.VarChar, 50).Value = listcolllected2[k + 25] + "" + ".";
                            }

                            if (listcolllected2[k + 26] == "" || listcolllected2[k + 26] == null)
                            {
                                command.Parameters.Add("@Nameofmother", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Nameofmother", SqlDbType.VarChar, 50).Value = listcolllected2[k + 26];
                            }

                            if (listcolllected2[k + 27] == "" || listcolllected2[k + 27] == null)
                            {
                                command.Parameters.Add("@Motheraddress", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Motheraddress", SqlDbType.VarChar, 50).Value = listcolllected2[k + 27];
                            }

                            if (listcolllected2[k + 28] == "" || listcolllected2[k + 28] == null)
                            {
                                command.Parameters.Add("@Mothertel", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Mothertel", SqlDbType.VarChar, 50).Value = listcolllected2[k + 28];
                            }

                            if (listcolllected2[k + 29] == "" || listcolllected2[k + 29] == null)
                            {
                                command.Parameters.Add("@Nameoffather", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Nameoffather", SqlDbType.VarChar, 50).Value = listcolllected2[k + 29];
                            }

                            if (listcolllected2[k + 30] == "" || listcolllected2[k + 30] == null)
                            {
                                command.Parameters.Add("@Fatheraddress", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Fatheraddress", SqlDbType.VarChar, 50).Value = listcolllected2[k + 30];
                            }

                            if (listcolllected2[k + 31] == "" || listcolllected2[k + 31] == null)
                            {
                                command.Parameters.Add("@Fathertel", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Fathertel", SqlDbType.VarChar, 50).Value = listcolllected2[k + 31];
                            }

                            if (listcolllected2[k + 32] == "" || listcolllected2[k + 32] == null)
                            {
                                command.Parameters.Add("@Nameofguardian", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Nameofguardian", SqlDbType.VarChar, 50).Value = listcolllected2[k + 32];
                            }

                            if (listcolllected2[k + 33] == "" || listcolllected2[k + 33] == null)
                            {
                                command.Parameters.Add("@Guardianaddress", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Guardianaddress", SqlDbType.VarChar, 50).Value = listcolllected2[k + 33];
                            }

                            if (listcolllected2[k + 34] == "" || listcolllected2[k + 34] == null)
                            {
                                command.Parameters.Add("@Guardiantel", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Guardiantel", SqlDbType.VarChar, 50).Value = listcolllected2[k + 34];
                            }

                            if (listcolllected2[k + 35] == "" || listcolllected2[k + 35] == null)
                            {
                                command.Parameters.Add("@Emercont1", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Emercont1", SqlDbType.VarChar, 50).Value = listcolllected2[k + 35];
                            }

                            if (listcolllected2[k + 36] == "" || listcolllected2[k + 36] == null)
                            {
                                command.Parameters.Add("@Emercont1homephone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Emercont1homephone", SqlDbType.VarChar, 50).Value = listcolllected2[k + 36];
                            }

                            if (listcolllected2[k + 37] == "" || listcolllected2[k + 37] == null)
                            {
                                command.Parameters.Add("@Emercont1cellphone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Emercont1cellphone", SqlDbType.VarChar, 50).Value = listcolllected2[k + 37];
                            }

                            if (listcolllected2[k + 38] == "" || listcolllected2[k + 38] == null)
                            {
                                command.Parameters.Add("@Emercont2", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Emercont2", SqlDbType.VarChar, 50).Value = listcolllected2[k + 38];
                            }

                            if (listcolllected2[k + 39] == "" || listcolllected2[k + 39] == null)
                            {
                                command.Parameters.Add("@Emercont2homephone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Emercont2homephone", SqlDbType.VarChar, 50).Value = listcolllected2[k + 39];
                            }

                            if (listcolllected2[k + 40] == "" || listcolllected2[k + 40] == null)
                            {
                                command.Parameters.Add("@Emercont2cellphone", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Emercont2cellphone", SqlDbType.VarChar, 50).Value = listcolllected2[k + 40];
                            }

                            if (listcolllected2[k + 41] == "" || listcolllected2[k + 41] == null)
                            {
                                command.Parameters.Add("@SicklecelltypeID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@SicklecelltypeID", SqlDbType.VarChar, 50).Value = listcolllected2[k + 41];
                            }

                            if (listcolllected2[k + 42] == "" || listcolllected2[k + 42] == null)
                            {
                                command.Parameters.Add("@HydroxyureaheardID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@HydroxyureaheardID", SqlDbType.VarChar, 50).Value = listcolllected2[k + 42];
                            }

                            if (listcolllected2[k + 43] == "" || listcolllected2[k + 43] == null)
                            {
                                command.Parameters.Add("@HydroxyureatakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@HydroxyureatakenID", SqlDbType.VarChar, 50).Value = listcolllected2[k + 43];
                            }

                            if (listcolllected2[k + 44] == "" || listcolllected2[k + 44] == null)
                            {
                                command.Parameters.Add("@HydroxyureacurrentlyID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@HydroxyureacurrentlyID", SqlDbType.VarChar, 50).Value = listcolllected2[k + 44];
                            }

                            if (listcolllected2[k + 45] == "" || listcolllected2[k + 45] == null)
                            {
                                command.Parameters.Add("@HydroxyureapasttakenID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@HydroxyureapasttakenID", SqlDbType.VarChar, 50).Value = listcolllected2[k + 45];
                            }
                    }

                    counter = k;
                    clientidreader.Close();
                    command.ExecuteNonQuery();                                       
                }
                variablePath.Path = "";
                connection.Close();
                return Json(variablePath.Jresult);
            }
            catch(Exception err)
            {
                    counter2 = counter;
                err.Message.ToString();
            }            
            //return Json(variablePath.Jresult);
          }
            variablePath.Path = "";
            return Json(variablePath.Jresult);
        }

        [HttpPost]
        public ActionResult PatientView(SickleCelloverviewclass patientdataview)
        {
            connection.Open();

            var x = patientdataview;
            string emailvalidate = "";
            int valcounter;
            string combine = "";
            
            List<SickleCelloverviewclass> overviewdata = new List<SickleCelloverviewclass>();
            List<SickleCelloverviewclass> overviewdata2 = new List<SickleCelloverviewclass>();            

            try
            {
                SqlCommand searchoverview = new SqlCommand("Information_Stored_Overview", connection);
                searchoverview.CommandType = CommandType.StoredProcedure;
                SqlDataReader overviewreader = searchoverview.ExecuteReader();

                if (overviewreader.HasRows == true)
                {
                    while (overviewreader.Read())
                    {
                        SickleCelloverviewclass overviewddatagroup = new SickleCelloverviewclass();
                        overviewddatagroup.ClientID = Convert.ToInt32(overviewreader["ClientID"].ToString());
                        overviewddatagroup.LastName = overviewreader["LastName"].ToString();
                        overviewddatagroup.FirstName = overviewreader["FirstName"].ToString();
                        overviewddatagroup.DOB = overviewreader["DOB"].ToString();
                        overviewddatagroup.Gender = overviewreader["Gender"].ToString();
                        overviewddatagroup.FullStreetAddress = overviewreader["FullStreetAddress"].ToString();
                        overviewddatagroup.City = overviewreader["City"].ToString();
                        overviewddatagroup.State = overviewreader["State"].ToString();
                        overviewddatagroup.Email_Address = overviewreader["Email_Address"].ToString();
                        combine = overviewreader["Email_Address"].ToString();
                        valcounter = combine.Length - 1;                        
                        if (valcounter >= 1)
                        {
                            emailvalidate = overviewreader["Email_Address"].ToString().Substring(valcounter, 1).Trim();

                            if (emailvalidate != "m")
                            {
                                string a = emailvalidate;
                            }
                            else{}
                        }
                        else{Console.WriteLine("");}                        

                        if (emailvalidate == ".")
                        {                            
                            overviewdata.Add(overviewddatagroup);
                        }
                        else{Console.WriteLine("");}                        
                    }
                }
                else
                {
                    overviewreader.Close();
                    connection.Close();
                    return Json(overviewdata);
                }
                overviewreader.Close();
                connection.Close();
                return Json(overviewdata);
            }
            catch (Exception ab)
            {
                ab.Message.ToString();
            }
            return Json(overviewdata);
        }


        // This is to keep the newly uploaded CSV file
        public ActionResult Keep(SickeCellclass keepstr)
        {
            connection.Open();
            try
            {
                SqlCommand cmdkeep = new SqlCommand("update information set comments='' where Comments is null", connection);
                SqlDataReader keepdreader = cmdkeep.ExecuteReader();

                keepdreader.Close();
            }
            catch (Exception err)
            {
                err.Message.ToString();
            }
            
            connection.Close();
            return Json("");
        }

        // This is to keep the newly uploaded CSV file
        public ActionResult Remove(SickeCellclass removestr)
        {
            connection.Open();
            try
            {
                SqlCommand cmdremove = new SqlCommand("delete from Information where Comments is null", connection);
                SqlDataReader removereader = cmdremove.ExecuteReader();

                removereader.Close();
            }
            catch (Exception err)
            {
                err.Message.ToString();
            }

            connection.Close();
            return Json("");
        }


        // GET: Upload/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Upload/Edit/5
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

        // GET: Upload/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Upload/Delete/5
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
