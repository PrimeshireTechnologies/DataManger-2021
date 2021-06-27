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

using OfficeOpenXml;
//using OfficeOpenXml.Style;
using ClosedXML.Excel;
using SickeCell.Models;

namespace SickeCell.Controllers
{
    public class UploadController : Controller
    {
        public static string con = ConfigurationManager.ConnectionStrings["SickeCellConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(con);               
                             
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
        string currsheet;

        string sheetname0 = "";
        int cntworksheet;

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
            ViewBag.Title = "Open File";

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
                        string fname2 = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/"), fname);
                        data = fname;                        
                        file.SaveAs(fname2);                      

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
            if (variablePath.Path != null)
            {
                int counter = 0;
                int counter2 = 0;

                try
                {
                    connection.Open();                    
                    vfname = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/"), variablePath.Path);                    

                    //var xlWorkbook = new ExcelPackage(new FileInfo(vfname));

                    //FileInfo existingFile = new FileInfo(vfname);                    
                    FileInfo existingFile = new FileInfo(vfname);
                    //using (var xlWorkbook = new ExcelPackage(new FileInfo(vfname)))
                    using (ExcelPackage package = new ExcelPackage(existingFile))
                    {
                        //ExcelWorkbook workBook = xlWorkbook.Workbook;
                        ////ExcelWorksheet ws = workBook.Worksheets[1];

                        ////ExcelWorksheet worksheet = workBook.Worksheets[1];
                        ////ExcelWorksheet worksheet = xlWorkbook.Workbook.Worksheets[1];

                        //ExcelWorksheet worksheet = workBook.Worksheets[1];   

                        //ExcelWorksheet worksheet = package.Workbook.Worksheets[1]; // 1 is the position of the worksheet
                        cntworksheet = package.Workbook.Worksheets.Count;

                        ExcelWorksheet worksheet = package.Workbook.Worksheets[1];                        

                        sheetname0 = worksheet.Name;
                        
                        int colCount = worksheet.Dimension.End.Column;
                        int rowCount = worksheet.Dimension.End.Row;
                        for (int row = 2; row <= rowCount; row++)
                        {
                          SqlCommand commands;
                          commands = connection.CreateCommand();
                          commands.CommandText = "Execute Information_Stored_Uploading @ClientID, @FirstName, @LastName, @DOB, @Age, @AgeGroup, @Race, @Gender, @Ethnicity, " +
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
                          
                          if (worksheet.Cells[row, 1].Value?.ToString().Trim() != null)
                          {
                                for (int col = 1; col <= colCount; col++)
                                {                                    
                                    if (col == 1)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            string firstname = worksheet.Cells[row, col].Value?.ToString().Trim();
                                            commands.Parameters.Add("@ClientID", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            string firstname = worksheet.Cells[row, col].Value?.ToString().Trim();
                                            commands.Parameters.Add("@ClientID", SqlDbType.VarChar, 25).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 2)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            string firstname = worksheet.Cells[row, col].Value?.ToString().Trim();
                                            commands.Parameters.Add("@FirstName", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            string firstname = worksheet.Cells[row, col].Value?.ToString().Trim();
                                            commands.Parameters.Add("@FirstName", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim() + "" + ".";
                                        }
                                    }
                                    if (col == 3)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            string lastname = worksheet.Cells[row, col].Value?.ToString().Trim();
                                            commands.Parameters.Add("@LastName", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            string lastname = worksheet.Cells[row, col].Value?.ToString().Trim();
                                            commands.Parameters.Add("@LastName", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }

                                    if (row==5 && col==4)
                                    {
                                        string j = "";
                                    }

                                    if (col == 4)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@DOB", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            string dstr = worksheet.Cells[row, col].Value?.ToString().Trim();
                                            int date_length = dstr.Length;
                                            if(date_length > 10)
                                            {
                                                commands.Parameters.Add("@DOB", SqlDbType.VarChar, 10).Value = DBNull.Value;
                                            }
                                            else
                                            {
                                                //commands.Parameters.Add("@DOB", SqlDbType.VarChar, 10).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                                //commands.Parameters.Add("@DOB", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Substring(0,10).Trim(); 
                                                //DateTime datevalue = Convert.ToDateTime(worksheet.Cells[row, col].Value?.ToString().Substring(0, 10).Trim());                                               

                                                commands.Parameters.Add("@DOB", SqlDbType.VarChar, 10).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                            }                                            
                                        }
                                    }
                                    if (col == 5)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Age", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {                                            
                                            commands.Parameters.Add("@Age", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 6)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@AgeGroup", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 7)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Race", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Race", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 8)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Gender", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Gender", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 9)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Ethnicity", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 10)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@FullStreetAddress", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 11)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@City", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@City", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 12)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@State", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@State", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 13)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@ZipCode", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@ZipCode", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 14)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@CountyCode", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@CountyCode", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 15)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@CountyCodeDescription", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 16)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 17)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Eligibility", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Eligibility", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 18)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@SickleCellDiagnosis", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 19)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@PMPProviderName", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 20)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@CCUCase", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@CCUCase", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 21)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Email_Address", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Email_Address", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 22)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_YTD_2020", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_YTD_2020", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 23)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Inpatient_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Inpatient_Claims", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 24)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Inpatient_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Inpatient_Claims", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 25)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Dental_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Dental_Claims", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 26)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Dental_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Dental_Claims", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 27)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Home_Health_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Home_Health_Claims", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 28)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Home_Health_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Home_Health_Claims", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 29)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Professional_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Professional_Claims", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 30)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Professional_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Professional_Claims", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 31)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Long_term_Care_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Long_term_Care_Claims", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 32)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Long_term_Care_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Long_term_Care_Claims", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 33)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Outpatient_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Outpatient_Claims", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 34)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Outpatient_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Outpatient_Claims", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 35)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Pharmacy_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Pharmacy_Claims", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 36)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Pharmacy_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Pharmacy_Claims", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 37)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Compound_Drug_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Compound_Drug_Claims", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 38)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Compound_Drugs_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Compound_Drugs_Claims", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 39)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Crossover_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@No_of_Paid_Crossover_Claims", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 40)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Crossover_Claims", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Total_Reimbursement_for_Crossover_Claims", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 41)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Adult_Day_Care", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Adult_Day_Care", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 42)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Advanced_Practice_Nurse", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Advanced_Practice_Nurse", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 43)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@ADvantage_Home_Delivered_Meals", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@ADvantage_Home_Delivered_Meals", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 44)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Ambulatory_Surgical_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Ambulatory_Surgical_Services", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 45)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Architectural_Modification", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Architectural_Modification", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 46)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Audiology_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Audiology_Services", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 47)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Capitated_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Capitated_Services", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 48)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Chiropractic_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Chiropractic_Services", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 49)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Clinic", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Clinic", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 50)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Clinics_OSA_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Clinics_OSA_Services", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 51)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Dental", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Dental", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 52)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Direct_Support", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Direct_Support", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 53)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Employee_Training_Specialist", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Employee_Training_Specialist", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 54)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@End_Stage_Renal_Disease", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@End_Stage_Renal_Disease", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 55)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Eye_Care_and_Exams", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Eye_Care_and_Exams", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 56)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Eyewear", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Eyewear", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 57)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Group_Home", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Group_Home", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 58)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Home_Health", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Home_Health", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 59)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Homemaker_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Homemaker_Services", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 60)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Hospice", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Hospice", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 61)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@ICF_ID_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@ICF_ID_Services", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 62)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Inpatient_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Inpatient_Services", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 63)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Insure_Oklahoma_ESI_Out_of_Pocket", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Insure_Oklahoma_ESI_Out_of_Pocket", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 64)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Insure_Oklahoma_ESI_Premium", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Insure_Oklahoma_ESI_Premium", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 65)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Laboratory_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Laboratory_Services", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 66)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Medical_Supplies_DMEPOS", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Medical_Supplies_DMEPOS", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 67)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Medicare_Part_A_and_B_Buy_In_Payments", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Medicare_Part_A_and_B_Buy_In_Payments", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 68)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Medicare_Part_D_Payments", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Medicare_Part_D_Payments", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 69)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Mid_Level_Practitioner", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Mid_Level_Practitioner", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 70)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Nursing_Facility", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Nursing_Facility", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 71)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Nursing_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Nursing_Services", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 72)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Nutritionist_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Nutritionist_Services", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 73)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Other_Practitioner", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Other_Practitioner", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 74)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Outpatient_Hospital", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Outpatient_Hospital", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 75)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Personal_Care", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Personal_Care", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 76)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Physician", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Physician", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 77)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Podiatry", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Podiatry", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 78)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Prescribed_Drugs", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Prescribed_Drugs", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 79)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Psychiatric_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Psychiatric_Services", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 80)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Residential_Behavior_Mgmt", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Residential_Behavior_Mgmt", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 81)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Respite_Care", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Respite_Care", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 82)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Room_and_Board", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Room_and_Board", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 83)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@School_Based_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@School_Based_Services", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 84)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Self_Directed_Care", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Self_Directed_Care", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 85)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Specialized_Foster_Care_or_ID_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Specialized_Foster_Care_or_ID_Services", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 86)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Targeted_Case_Manager", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Targeted_Case_Manager", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 87)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Therapy_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Therapy_Services", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 88)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Transportation_Emergency", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Transportation_Emergency", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 89)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Transportation_Non_Emergency", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Transportation_Non_Emergency", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 90)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@X_Ray_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@X_Ray_Services", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 91)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Behavioral_Health_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Behavioral_Health_Services", SqlDbType.VarChar, 100).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 92)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Community_Mental_Health", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Community_Mental_Health", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 93)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@ESI", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@ESI", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 94)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Uncategorized_Services", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Uncategorized_Services", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 95)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Other", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Other", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 96)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Oxbryta", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Oxbryta", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 97)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Adakvedo", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Adakvedo", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                    if (col == 98)
                                    {
                                        if (worksheet.Cells[row, col].Value?.ToString().Trim() == "" || worksheet.Cells[row, col].Value?.ToString().Trim() == null)
                                        {
                                            commands.Parameters.Add("@Dual_or_Non_Dual", SqlDbType.VarChar, 100).Value = DBNull.Value;
                                        }
                                        else
                                        {
                                            commands.Parameters.Add("@Dual_or_Non_Dual", SqlDbType.VarChar, 255).Value = worksheet.Cells[row, col].Value?.ToString().Trim();
                                        }
                                    }
                                }
                                if (row > 1)
                                {
                                    commands.ExecuteNonQuery();
                                }
                          }
                          else
                          {
                                break;
                          }
                        }
                    }
                    variablePath.Path = "";
                    connection.Close();
                    return Json(variablePath.Jresult + sheetname0.ToString().Trim() + "  " + cntworksheet.ToString());
                }
                catch (Exception err)
                {
                    counter2 = counter;
                    err.Message.ToString();

                        variablePath.Path = "";
                        variablePath.Path = err.Message.ToString().Trim() + sheetname0.ToString().Trim() + "  " + cntworksheet.ToString();                        
                        //variablePath.Path = err.Message.ToString().Substring(0,23);                        
                        connection.Close();
                        return Json(variablePath.Path);
                }                
            }
            variablePath.Path = ""; 
            return Json(variablePath.Jresult + sheetname0.ToString().Trim() + "  " + cntworksheet.ToString());
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
                        SickleCelloverviewclass overviewddatagroup = new SickleCelloverviewclass
                        {
                            ClientID = overviewreader["ClientID"].ToString(),
                            LastName = overviewreader["LastName"].ToString(),
                            FirstName = overviewreader["FirstName"].ToString(),
                            DOB = overviewreader["DOB"].ToString(),
                            Gender = overviewreader["Gender"].ToString(),
                            FullStreetAddress = overviewreader["FullStreetAddress"].ToString(),
                            City = overviewreader["City"].ToString(),
                            State = overviewreader["State"].ToString(),
                            Email_Address = overviewreader["Email_Address"].ToString()
                        };
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
                SqlCommand cmdkeep = new SqlCommand("update Information set FirstName = Substring(FirstName, 1, len(FirstName)-1) where right(FirstName,1) = '" + period + "' ", connection);
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
                SqlCommand cmdremove = new SqlCommand("delete from Information where Right(FirstName,1)='.'", connection);
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
