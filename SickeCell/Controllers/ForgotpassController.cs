using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
//using System.Web.Services;
using System.Globalization;
using System.Text;
using System.Net;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization;
using System.Configuration;
using System.Net.Mail;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using SickeCell.Models;
using SickeCell.Interfaces;

namespace Inventory.Controllers
{
    public class ForgotpassController : ApiController
    {
        public static string con = ConfigurationManager.ConnectionStrings["SickeCellConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(con);

        Int32 varautocode;
        string strautocode;
               
        //string chrstring;        

        // GET: api/Forgotpass
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Forgotpass/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Forgotpass
        public string Verifyemail(Verification verifyvalue)
        {           ;
            List<IVerification> Verificationlist = new List<IVerification>();
            Verification Verificationrecord = new Verification();
            try
            {
                connection.Open();                

                SqlCommand verifycmd = new SqlCommand();
                verifycmd = new SqlCommand("select * from login where Email = '" + verifyvalue.Email + "' ", connection);
                SqlDataReader verifyReader = verifycmd.ExecuteReader();
                if (verifyReader.HasRows == true)
                {
                    while (verifyReader.Read())
                    {
                        varautocode  = Convert.ToInt32(verifyReader["Autocode"]);

                        var generator = new RandomGenerator(); 
                        var randomNumber = generator.RandomNumber(Convert.ToInt32(varautocode), 9999999);
                        
                        long rendomresult = randomNumber;
                        strautocode = rendomresult.ToString();

                        break;
                    }

                    var smtp = new System.Net.Mail.SmtpClient("noreply_verification@primeshire.tech");
                    {
                        smtp.Host = "smtp.ipage.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        //smtp.Credentials = new NetworkCredential("noreply_verification@primeshire.tech", "Development2019$!");
                        smtp.Credentials = new NetworkCredential("noreply_verification@primeshire.tech", "Development2020#!");
                        smtp.Timeout = 20000;
                    }
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("noreply_verification@primeshire.tech");

                    message.Subject = "Verification code";
                    //message.Body = "<span style=\"color:#f37946;font-weight:800;font-size:12px;\">here</span>";
                    message.Body = "Your code is <span style=\"color:#f37946;font-weight:900;font-size:15px;\">"+ strautocode +"</span>";
                    message.IsBodyHtml = true;
                    message.To.Add(verifyvalue.Email);

                    smtp.Send(message);                                       

                    //chrstring = "existed";
                    Verificationrecord.Stringautocode = strautocode;
                    Verificationrecord.Email = verifyvalue.Email;
                    Verificationlist.Add(Verificationrecord);

                    verifyReader.Close();
                }
                else
                {
                    strautocode = "";
                    verifyvalue.Email = "";
                    Verificationrecord.Stringautocode = strautocode;                    
                    Verificationlist.Add(Verificationrecord);
                }
      
            }
            catch (Exception mssg)
            {                
                mssg.Message.ToString();
                verifyvalue.Email = mssg.Message.ToString();
            }            
            return verifyvalue.Email + "," + strautocode;
        }

        public class RandomGenerator
        {
            private readonly Random _random = new Random();

            // Generates a random number within a range.      
            public int RandomNumber(int min, int max)
            {
                return _random.Next(min, max);
            }
        }

        // PUT: api/Forgotpass/5       
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Forgotpass/5
        public void Delete(int id)
        {
        }       
    }
}
