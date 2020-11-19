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
using System.Data.OleDb;

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

        string testing = "";
        string testing1 = "";
        string testing2 = "";
        string concat = "";

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
                    //for (int i = 0; i < files.Count; i++)
                    for (int i = 0; i < files.Count;)
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

                        i = i + 1;

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
          string strdata = " ";
          long longdata = 0;
            try
            {
                connection.Open();
                vfname = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/"), variablePath.Path);

                    //////////////////////////////////////////////////////////////////////////////////////
                    var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + vfname + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text\""; ;
                    using (var conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();

                        var sheets = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                        using (var cmd = conn.CreateCommand())
                        {

                            DataTable dtExcelSchema;
                            dtExcelSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                            cmd.CommandText = "SELECT * From [" + SheetName + "]";
                            var adapter = new OleDbDataAdapter(cmd);
                            var ds = new DataSet();
                            adapter.Fill(ds);

                            int dscounter = ds.Tables[0].Rows.Count;
                            int cnt = 1;

                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {                               
                                SqlCommand commands;
                                commands = connection.CreateCommand();
                                commands.CommandText = "Execute Information_Stored_Uploading @ClientID, @FirstName, @LastName, @DOB, @Age, @AgeGroup, @RACE, @Gender, @Ethnicity, " +
                                         "@FullStreetAddress, @City, @State, @ZipCode, @CountyCode, @CountyCodeDescription, @PhoneNumber, @Eligibility, @SickleCellDiagnosis," +
                                         "@PMPProviderName, @CCUCase, @Email_Address, @Total_Reimbursement_YTD_2020, @No_of_Paid_Inpatient_Claims, @Total_Reimbursement_for_Inpatient_Claims," +
                                         "@No_of_Paid_Dental_Claims, @Total_Reimbursement_for_Dental_Claims, @No_of_Paid_Home_Health_Claims, @Total_Reimbursement_for_Home_Health_Claims," +
                                         "@No_of_Paid_Professional_Claims, @Total_Reimbursement_for_Professional_Claims, @No_of_Paid_Long_term_Care_Claims, @Total_Reimbursement_for_Long_term_Care_Claims," +
                                         "@No_of_Paid_Outpatient_Claims, @Total_Reimbursement_for_Outpatient_Claims, @No_of_Paid_Pharmacy_Claims, @Total_Reimbursement_for_Pharmacy_Claims, " +
                                         "@No_of_Paid_Compound_Drug_Claims, @Total_Reimbursement_for_Compound_Drugs_Claims, @No_of_Paid_Crossover_Claims, @Total_Reimbursement_for_Crossover_Claims, " +
                                         "@Adult_Day_Care, @Advanced_Practice_Nurse, @ADvantage_Home_Delivered_Meals, @Ambulatory_Surgical_Services, @Architectural_Modification, @Audiology_Services," +
                                         "@Capitated_Services, @Chiropractic_Services, @Clinic, @Clinics_OSA_Services, @Dental, @Direct_Support, @Employee_Training_Specialist, @End_Stage_Renal_Disease," +
                                         "@Eye_Care_and_Exams, @Eyewear, @Group_Home, @Home_Health, @Homemaker_Services, @Hospice, @ICF_ID_Services, @Inpatient_Services, @Insure_Oklahoma_ESI_Out_of_Pocket," +
                                         "@Insure_Oklahoma_ESI_Premium, @Laboratory_Services, @Medical_Supplies_DMEPOS, @Medicare_Part_A_and_B_Buy_In_Payments, @Medicare_Part_D_Payments, " +
                                         "@Mid_Level_Practitioner, @Nursing_Facility, @Nursing_Services, @Nutritionist_Services, @Other_Practitioner, @Outpatient_Hospital, @Personal_Care, @Physician," +
                                         "@Podiatry, @Prescribed_Drugs, @Psychiatric_Services, @Residential_Behavior_Mgmt, @Respite_Care, @Room_and_Board, @School_Based_Services, @Self_Directed_Care," +
                                         "@Specialized_Foster_Care_or_ID_Services, @Targeted_Case_Manager, @Therapy_Services, @Transportation_Emergency, @Transportation_Non_Emergency, @X_Ray_Services," +
                                         "@Behavioral_Health_Services, @Community_Mental_Health, @ESI, @Uncategorized_Services, @Other, @Oxbryta, @Adakvedo, @Dual_or_Non_Dual";

                                if (cnt == 7)
                                {
                                    string u = "";
                                }
                                if (cnt > 1 && dr[0].ToString() != "")
                                {
                                    if (dr[0].ToString() == "" || dr[0].ToString() == null)
                                    {
                                        string firstname = dr[0].ToString();
                                        commands.Parameters.Add("@ClientID", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        string firstname = dr[0].ToString();
                                        commands.Parameters.Add("@ClientID", SqlDbType.NVarChar, 255).Value = dr[0].ToString();
                                    }

                                    if (dr[1].ToString() == "" || dr[1].ToString() == null)
                                    {
                                        string firstname = dr[1].ToString();
                                        commands.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        string firstname = dr[1].ToString();
                                        commands.Parameters.Add("@FirstName", SqlDbType.NVarChar, 255).Value = dr[1].ToString() + "" + "."; 
                                    }

                                    if (dr[2].ToString() == "" || dr[2].ToString() == null)
                                    {
                                        string lastname = dr[2].ToString();
                                        commands.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        string lastname = dr[2].ToString();
                                        commands.Parameters.Add("@LastName", SqlDbType.NVarChar, 255).Value = dr[2].ToString();
                                    }

                                    if (dr[3].ToString() == "" || dr[3].ToString() == null)
                                    {
                                        commands.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@DOB", SqlDbType.NVarChar, 255).Value = dr[3].ToString();
                                    }

                                    if (dr[4].ToString() == "" || dr[4].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Age", SqlDbType.VarChar, 50).Value = dr[4].ToString();
                                    }

                                    if (dr[5].ToString() == "" || dr[5].ToString() == null)
                                    {
                                        commands.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@AgeGroup", SqlDbType.NVarChar, 255).Value = dr[5].ToString();
                                    }

                                    if (dr[6].ToString() == "" || dr[6].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Race", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Race", SqlDbType.NVarChar, 255).Value = dr[6].ToString();
                                    }

                                    if (dr[7].ToString() == "" || dr[7].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Gender", SqlDbType.NVarChar, 255).Value = dr[7].ToString();
                                    }

                                    if (dr[8].ToString() == "" || dr[8].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Ethnicity", SqlDbType.NVarChar, 255).Value = dr[8].ToString();
                                    }

                                    if (dr[9].ToString() == "" || dr[9].ToString() == null)
                                    {
                                        commands.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 50).Value = dr[9].ToString();
                                    }

                                    if (dr[10].ToString() == "" || dr[10].ToString() == null)
                                    {
                                        commands.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@City", SqlDbType.NVarChar, 255).Value = dr[10].ToString();
                                    }

                                    if (dr[11].ToString() == "" || dr[11].ToString() == null)
                                    {
                                        commands.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@State", SqlDbType.NVarChar, 255).Value = dr[11].ToString();
                                    }

                                    if (dr[12].ToString() == "" || dr[12].ToString() == null)
                                    {
                                        commands.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@ZipCode", SqlDbType.VarChar, 50).Value = dr[12].ToString();
                                    }

                                    if (dr[13].ToString() == "" || dr[13].ToString() == null)
                                    {
                                        commands.Parameters.Add("@CountyCode", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@CountyCode", SqlDbType.VarChar, 50).Value = dr[13].ToString();
                                    }

                                    if (dr[14].ToString() == "" || dr[14].ToString() == null)
                                    {
                                        commands.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@CountyCodeDescription", SqlDbType.NVarChar, 255).Value = dr[14].ToString();
                                    }

                                    if (dr[15].ToString() == "" || dr[15].ToString() == null)
                                    {
                                        commands.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50).Value = dr[15].ToString();
                                    }

                                    if (dr[16].ToString() == "" || dr[16].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Eligibility", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Eligibility", SqlDbType.NVarChar, 255).Value = dr[16].ToString();
                                    }

                                    if (dr[17].ToString() == "" || dr[17].ToString() == null)
                                    {
                                        commands.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@SickleCellDiagnosis", SqlDbType.NVarChar, 255).Value = dr[17].ToString();
                                    }

                                    if (dr[18].ToString() == "" || dr[18].ToString() == null)
                                    {
                                        commands.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@PMPProviderName", SqlDbType.NVarChar, 255).Value = dr[18].ToString();
                                    }

                                    if (dr[19].ToString() == "" || dr[19].ToString() == null)
                                    {
                                        commands.Parameters.Add("@CCUCase", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@CCUCase", SqlDbType.NVarChar, 255).Value = dr[19].ToString();
                                    }

                                    if (dr[20].ToString() == "" || dr[20].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Email_Address", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Email_Address", SqlDbType.NVarChar, 255).Value = dr[20].ToString();
                                    }

                                    if (dr[21].ToString() == "" || dr[21].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_YTD_2020", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_YTD_2020", SqlDbType.VarChar, 50).Value = dr[21].ToString();
                                    }

                                    if (dr[22].ToString() == "" || dr[22].ToString() == null)
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Inpatient_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Inpatient_Claims", SqlDbType.VarChar, 50).Value = dr[22].ToString();
                                    }

                                    if (dr[23].ToString() == "" || dr[23].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Inpatient_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Inpatient_Claims", SqlDbType.VarChar, 50).Value = dr[23].ToString();
                                    }

                                    if (dr[24].ToString() == "" || dr[24].ToString() == null)
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Dental_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Dental_Claims", SqlDbType.NVarChar, 255).Value = dr[24].ToString();
                                    }

                                    if (dr[25].ToString() == "" || dr[25].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Dental_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Dental_Claims", SqlDbType.NVarChar, 255).Value = dr[25].ToString();
                                    }

                                    if (dr[26].ToString() == "" || dr[26].ToString() == null)
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Home_Health_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Home_Health_Claims", SqlDbType.VarChar, 50).Value = dr[26].ToString();
                                    }

                                    if (dr[27].ToString() == "" || dr[27].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Home_Health_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Home_Health_Claims", SqlDbType.NVarChar, 255).Value = dr[27].ToString();
                                    }

                                    if (dr[28].ToString() == "" || dr[28].ToString() == null)
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Professional_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Professional_Claims", SqlDbType.VarChar, 50).Value = dr[28].ToString();
                                    }

                                    if (dr[29].ToString() == "" || dr[29].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Professional_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Professional_Claims", SqlDbType.VarChar, 50).Value = dr[29].ToString();
                                    }

                                    if (dr[30].ToString() == "" || dr[30].ToString() == null)
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Long_term_Care_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Long_term_Care_Claims", SqlDbType.VarChar, 50).Value = dr[30].ToString();
                                    }

                                    if (dr[31].ToString() == "" || dr[31].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Long_term_Care_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Long_term_Care_Claims", SqlDbType.VarChar, 50).Value = dr[31].ToString();
                                    }

                                    if (dr[32].ToString() == "" || dr[32].ToString() == null)
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Outpatient_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Outpatient_Claims", SqlDbType.VarChar, 50).Value = dr[32].ToString();
                                    }

                                    if (dr[33].ToString() == "" || dr[33].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Outpatient_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Outpatient_Claims", SqlDbType.VarChar, 50).Value = dr[33].ToString();
                                    }

                                    if (dr[34].ToString() == "" || dr[34].ToString() == null)
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Pharmacy_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Pharmacy_Claims", SqlDbType.VarChar, 50).Value = dr[34].ToString();
                                    }

                                    if (dr[35].ToString() == "" || dr[35].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Pharmacy_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Pharmacy_Claims", SqlDbType.VarChar, 50).Value = dr[35].ToString();
                                    }
                                    
                                    if (dr[36].ToString() == "" || dr[36].ToString() == null)
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Compound_Drug_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Compound_Drug_Claims", SqlDbType.NVarChar, 255).Value = dr[36].ToString();
                                    }

                                    if (dr[37].ToString() == "" || dr[37].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Compound_Drugs_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Compound_Drugs_Claims", SqlDbType.NVarChar, 255).Value = dr[37].ToString();
                                    }

                                    if (dr[38].ToString() == "" || dr[38].ToString() == null)
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Crossover_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@No_of_Paid_Crossover_Claims", SqlDbType.NVarChar, 255).Value = dr[38].ToString();
                                    }

                                    if (dr[39].ToString() == "" || dr[39].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Crossover_Claims", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Total_Reimbursement_for_Crossover_Claims", SqlDbType.NVarChar, 255).Value = dr[39].ToString();
                                    }

                                    if (dr[40].ToString() == "" || dr[40].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Adult_Day_Care", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Adult_Day_Care", SqlDbType.NVarChar, 255).Value = dr[40].ToString();
                                    }

                                    if (dr[41].ToString() == "" || dr[41].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Advanced_Practice_Nurse", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Advanced_Practice_Nurse", SqlDbType.NVarChar, 255).Value = dr[41].ToString();
                                    }

                                    if (dr[42].ToString() == "" || dr[42].ToString() == null)
                                    {
                                        commands.Parameters.Add("@ADvantage_Home_Delivered_Meals", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@ADvantage_Home_Delivered_Meals", SqlDbType.VarChar, 50).Value = dr[42].ToString();
                                    }

                                    if (dr[43].ToString() == "" || dr[43].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Ambulatory_Surgical_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Ambulatory_Surgical_Services", SqlDbType.VarChar, 50).Value = dr[43].ToString();
                                    }

                                    if (dr[44].ToString() == "" || dr[44].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Architectural_Modification", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Architectural_Modification", SqlDbType.NVarChar, 255).Value = dr[44].ToString();
                                    }

                                    if (dr[45].ToString() == "" || dr[45].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Audiology_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Audiology_Services", SqlDbType.VarChar, 50).Value = dr[45].ToString();
                                    }

                                    if (dr[46].ToString() == "" || dr[46].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Capitated_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Capitated_Services", SqlDbType.NVarChar, 255).Value = dr[46].ToString();
                                    }

                                    if (dr[47].ToString() == "" || dr[47].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Chiropractic_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Chiropractic_Services", SqlDbType.VarChar, 50).Value = dr[47].ToString();
                                    }

                                    if (dr[48].ToString() == "" || dr[48].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Clinic", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Clinic", SqlDbType.VarChar, 50).Value = dr[48].ToString();
                                    }

                                    if (dr[49].ToString() == "" || dr[49].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Clinics_OSA_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Clinics_OSA_Services", SqlDbType.VarChar, 50).Value = dr[49].ToString();
                                    }                                    

                                    if (dr[50].ToString() == "" || dr[50].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Dental", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Dental", SqlDbType.VarChar, 50).Value = dr[50].ToString();
                                    }

                                    if (dr[51].ToString() == "" || dr[51].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Direct_Support", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Direct_Support", SqlDbType.VarChar, 50).Value = dr[51].ToString();
                                    }

                                    if (dr[52].ToString() == "" || dr[52].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Employee_Training_Specialist", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Employee_Training_Specialist", SqlDbType.VarChar, 50).Value = dr[52].ToString();
                                    }

                                    if (dr[53].ToString() == "" || dr[53].ToString() == null)
                                    {
                                        commands.Parameters.Add("@End_Stage_Renal_Disease", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@End_Stage_Renal_Disease", SqlDbType.VarChar, 50).Value = dr[53].ToString();
                                    }

                                    if (dr[54].ToString() == "" || dr[54].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Eye_Care_and_Exams", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Eye_Care_and_Exams", SqlDbType.NVarChar, 255).Value = dr[54].ToString();
                                    }

                                    if (dr[55].ToString() == "" || dr[55].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Eyewear", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Eyewear", SqlDbType.VarChar, 50).Value = dr[55].ToString();
                                    }

                                    if (dr[56].ToString() == "" || dr[56].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Group_Home", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Group_Home", SqlDbType.NVarChar, 255).Value = dr[56].ToString();
                                    }

                                    if (dr[57].ToString() == "" || dr[57].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Home_Health", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Home_Health", SqlDbType.VarChar, 50).Value = dr[57].ToString();
                                    }

                                    if (dr[58].ToString() == "" || dr[58].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Homemaker_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Homemaker_Services", SqlDbType.NVarChar, 255).Value = dr[58].ToString();
                                    }

                                    if (dr[59].ToString() == "" || dr[59].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Hospice", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Hospice", SqlDbType.VarChar, 50).Value = dr[59].ToString();
                                    }

                                    if (dr[60].ToString() == "" || dr[60].ToString() == null)
                                    {
                                        commands.Parameters.Add("@ICF_ID_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@ICF_ID_Services", SqlDbType.NVarChar, 255).Value = dr[60].ToString();
                                    }

                                    if (dr[61].ToString() == "" || dr[61].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Inpatient_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Inpatient_Services", SqlDbType.VarChar, 50).Value = dr[61].ToString();
                                    }

                                    if (dr[62].ToString() == "" || dr[62].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Insure_Oklahoma_ESI_Out_of_Pocket", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Insure_Oklahoma_ESI_Out_of_Pocket", SqlDbType.VarChar, 50).Value = dr[62].ToString();
                                    }

                                    if (dr[63].ToString() == "" || dr[63].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Insure_Oklahoma_ESI_Premium", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Insure_Oklahoma_ESI_Premium", SqlDbType.VarChar, 50).Value = dr[63].ToString();
                                    }

                                    if (dr[64].ToString() == "" || dr[64].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Laboratory_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Laboratory_Services", SqlDbType.VarChar, 50).Value = dr[64].ToString();
                                    }

                                    if (dr[65].ToString() == "" || dr[65].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Medical_Supplies_DMEPOS", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Medical_Supplies_DMEPOS", SqlDbType.VarChar, 50).Value = dr[65].ToString();
                                    }

                                    if (dr[66].ToString() == "" || dr[66].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Medicare_Part_A_and_B_Buy_In_Payments", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Medicare_Part_A_and_B_Buy_In_Payments", SqlDbType.VarChar, 50).Value = dr[66].ToString();
                                    }

                                    if (dr[67].ToString() == "" || dr[67].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Medicare_Part_D_Payments", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Medicare_Part_D_Payments", SqlDbType.VarChar, 50).Value = dr[67].ToString();
                                    }

                                    if (dr[68].ToString() == "" || dr[68].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Mid_Level_Practitioner", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Mid_Level_Practitioner", SqlDbType.VarChar, 50).Value = dr[68].ToString();
                                    }

                                    if (dr[69].ToString() == "" || dr[69].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Nursing_Facility", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Nursing_Facility", SqlDbType.VarChar, 50).Value = dr[69].ToString();
                                    }

                                    if (dr[70].ToString() == "" || dr[70].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Nursing_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Nursing_Services", SqlDbType.VarChar, 50).Value = dr[70].ToString();
                                    }

                                    if (dr[71].ToString() == "" || dr[71].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Nutritionist_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Nutritionist_Services", SqlDbType.VarChar, 50).Value = dr[71].ToString();
                                    }

                                    if (dr[72].ToString() == "" || dr[72].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Other_Practitioner", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Other_Practitioner", SqlDbType.VarChar, 50).Value = dr[72].ToString();
                                    }

                                    if (dr[73].ToString() == "" || dr[73].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Outpatient_Hospital", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Outpatient_Hospital", SqlDbType.VarChar, 50).Value = dr[73].ToString();
                                    }

                                    if (dr[74].ToString() == "" || dr[74].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Personal_Care", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Personal_Care", SqlDbType.VarChar, 50).Value = dr[74].ToString();
                                    }

                                    if (dr[75].ToString() == "" || dr[75].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Physician", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Physician", SqlDbType.VarChar, 50).Value = dr[75].ToString();
                                    }

                                    if (dr[76].ToString() == "" || dr[76].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Podiatry", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Podiatry", SqlDbType.VarChar, 50).Value = dr[76].ToString();
                                    }

                                    if (dr[77].ToString() == "" || dr[77].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Prescribed_Drugs", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Prescribed_Drugs", SqlDbType.VarChar, 50).Value = dr[77].ToString();
                                    }

                                    if (dr[78].ToString() == "" || dr[78].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Psychiatric_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Psychiatric_Services", SqlDbType.VarChar, 50).Value = dr[78].ToString();
                                    }

                                    if (dr[79].ToString() == "" || dr[79].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Residential_Behavior_Mgmt", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Residential_Behavior_Mgmt", SqlDbType.VarChar, 50).Value = dr[79].ToString();
                                    }

                                    if (dr[80].ToString() == "" || dr[80].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Respite_Care", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Respite_Care", SqlDbType.VarChar, 50).Value = dr[80].ToString();
                                    }                                    

                                    if (dr[81].ToString() == "" || dr[81].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Room_and_Board", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Room_and_Board", SqlDbType.NVarChar, 255).Value = dr[81].ToString();
                                    }

                                    if (dr[82].ToString() == "" || dr[82].ToString() == null)
                                    {
                                        commands.Parameters.Add("@School_Based_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@School_Based_Services", SqlDbType.NVarChar, 255).Value = dr[82].ToString();
                                    }

                                    if (dr[83].ToString() == "" || dr[83].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Self_Directed_Care", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Self_Directed_Care", SqlDbType.NVarChar, 255).Value = dr[83].ToString();
                                    }

                                    if (dr[84].ToString() == "" || dr[84].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Specialized_Foster_Care_or_ID_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Specialized_Foster_Care_or_ID_Services", SqlDbType.NVarChar, 255).Value = dr[84].ToString();
                                    }

                                    if (dr[85].ToString() == "" || dr[85].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Targeted_Case_Manager", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Targeted_Case_Manager", SqlDbType.VarChar, 50).Value = dr[85].ToString();
                                    }

                                    if (dr[86].ToString() == "" || dr[86].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Therapy_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Therapy_Services", SqlDbType.VarChar, 50).Value = dr[86].ToString();
                                    }

                                    if (dr[87].ToString() == "" || dr[87].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Transportation_Emergency", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Transportation_Emergency", SqlDbType.VarChar, 50).Value = dr[87].ToString();
                                    }

                                    if (dr[88].ToString() == "" || dr[88].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Transportation_Non_Emergency", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Transportation_Non_Emergency", SqlDbType.NVarChar, 255).Value = dr[88].ToString();
                                    }

                                    if (dr[89].ToString() == "" || dr[89].ToString() == null)
                                    {
                                        commands.Parameters.Add("@X_Ray_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@X_Ray_Services", SqlDbType.VarChar, 50).Value = dr[89].ToString();
                                    }

                                    if (dr[90].ToString() == "" || dr[90].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Behavioral_Health_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Behavioral_Health_Services", SqlDbType.VarChar, 50).Value = dr[90].ToString();
                                    }

                                    if (dr[91].ToString() == "" || dr[91].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Community_Mental_Health", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Community_Mental_Health", SqlDbType.NVarChar, 255).Value = dr[91].ToString();
                                    }

                                    if (dr[92].ToString() == "" || dr[92].ToString() == null)
                                    {
                                        commands.Parameters.Add("@ESI", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@ESI", SqlDbType.NVarChar, 255).Value = dr[92].ToString();
                                    }

                                    if (dr[93].ToString() == "" || dr[93].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Uncategorized_Services", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Uncategorized_Services", SqlDbType.NVarChar,255).Value = dr[93].ToString();
                                    }

                                    if (dr[94].ToString() == "" || dr[94].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Other", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Other", SqlDbType.NVarChar,255).Value = dr[94].ToString();
                                    }

                                    if (dr[95].ToString() == "" || dr[95].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Oxbryta", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Oxbryta", SqlDbType.NVarChar, 255).Value = dr[95].ToString();
                                    }

                                    if (dr[96].ToString() == "" || dr[96].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Adakvedo", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Adakvedo", SqlDbType.NVarChar,255).Value = dr[96].ToString();
                                    }

                                    if (dr[97].ToString() == "" || dr[97].ToString() == null)
                                    {
                                        commands.Parameters.Add("@Dual_or_Non_Dual", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        commands.Parameters.Add("@Dual_or_Non_Dual", SqlDbType.NVarChar, 255).Value = dr[97].ToString();
                                    }                                                                        
                                }
                                if (cnt > 1)
                                {
                                    commands.ExecuteNonQuery();
                                }
                                cnt = cnt + 1;
                            }
                        }
                    }
                    //////////////////////////////////////////////////////////////////////////////////////                                    
                variablePath.Path = "";
                connection.Close();
                return Json(variablePath.Jresult);
            }
            catch(Exception err)
            {
                counter2 = counter;
                err.Message.ToString();

                variablePath.Path = "";
                variablePath.Path = err.Message.ToString().Substring(0,23);
                connection.Close();
                return Json(variablePath.Path);

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
                        combine = overviewreader["FirstName"].ToString();
                        valcounter = combine.Length - 1;                        
                        if (valcounter >= 1)
                        {                          
                            //emailvalidate = overviewreader["Email_Address"].ToString().Substring(valcounter, 1).Trim();
                            emailvalidate = overviewreader["FirstName"].ToString().Substring(valcounter, 1).Trim();

                            if (emailvalidate != "m")
                            {
                                string a = emailvalidate;
                            }
                            else{}
                        }
                        else{Console.WriteLine("");}

                        if (emailvalidate != "")
                        //if (emailvalidate == ".")
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
                string period = ".";
                //SqlCommand cmdkeep = new SqlCommand("update information set Email_Address = Substring(Email_Address, 1, len(Email_Address)-1) where Comments is null", connection);
                SqlCommand cmdkeep = new SqlCommand("update Reference set FirstName = Substring(FirstName, 1, len(FirstName)-1) where right(FirstName,1) = '" + period + "' ", connection);
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
                //SqlCommand cmdremove = new SqlCommand("delete from information where Right(Email_Address,1)='.'", connection);
                SqlCommand cmdremove = new SqlCommand("delete from Reference where Right(FirstName,1)='.'", connection);
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

        public ActionResult Information()
        {
            return View();
        }
    }
}
