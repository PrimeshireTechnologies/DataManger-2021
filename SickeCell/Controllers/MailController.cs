using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
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
using SickeCell.Models;

namespace SickeCell.Controllers
{
    public class MailController : ApiController
    {
        public static string con = ConfigurationManager.ConnectionStrings["SickeCellConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(con);       

        // GET: api/Mail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mail
        [HttpPost]
        public string SearchEmail(Signup datasearch)
        {
            try
            {
                connection.Open();

                SqlCommand searchcommand = new SqlCommand("loginsearch_Stored", connection);
                searchcommand.CommandType = CommandType.StoredProcedure;
                searchcommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = datasearch.Email;
                SqlDataReader searchreader = searchcommand.ExecuteReader();

                if (searchreader.HasRows == true)
                {
                    while (searchreader.Read())
                    {
                        var smtp2 = new System.Net.Mail.SmtpClient("noreply_verification@primeshire.tech");
                        {
                            smtp2.Host = "smtp.ipage.com";
                            smtp2.Port = 587;
                            smtp2.EnableSsl = true;
                            smtp2.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                            smtp2.Credentials = new NetworkCredential("noreply_verification@primeshire.tech", "Development2019$!");
                            smtp2.Timeout = 15000;
                        }

                        MailMessage message2 = new MailMessage();
                        message2.From = new MailAddress("noreply_verification@primeshire.tech");

                        message2.Subject = "Change Password Verification";
                        //message2.Body = "You have requested to change your Password, so Please click this <a style=\"color:slategray;font-weight:800;font-size:12px;\" href=\"http://localhost:59791/Home/Changepassword\">LINK</a> to change password";
                        message2.Body = "You have requested to change your Password, so Please click this <a style=\"color:slategray;font-weight:800;font-size:12px;\" href=\"https://sicklecell.primeshiretechnologies.com/home/Changepassword\">LINK</a> to change password";
                        //message.Body = "Thank you for verifying your email address. Please click <a style=\"color:darkslategray;font-weight:800;font-size:12px;\" href=\"https://sicklecell.primeshiretechnologies.com/home/login2\">here</a> to login";
                        message2.IsBodyHtml = true;
                        message2.To.Add(datasearch.Email);
                        smtp2.Send(message2);                        
                    }
                }
                else
                {
                    searchreader.Close();
                    connection.Close();

                    datasearch.Email = "";
                    return datasearch.Email;
                }
                searchreader.Close();
                connection.Close();
                return datasearch.Email;

            }
            catch (Exception mess) {
                mess.ToString();
            }
            return datasearch.Email;
        }             

        // PUT: api/Mail/5
        [HttpPut]
        public string Updatepassword(Signup updatepass)
        {
            try
            {
                connection.Open();
                SqlCommand searchcommand = new SqlCommand("update login set Password = '" + updatepass.Password + "', Confirm_password = '" + updatepass.Confirmpass + "' where Email = '" + updatepass.Email + "' ", connection);
                SqlDataReader searchreader = searchcommand.ExecuteReader();

                searchreader.Close();
                connection.Close();

                //updatepass.Email = "";
                return updatepass.Email;

            }
            catch (Exception mess)
            {
                updatepass.Email = "";
                mess.ToString();
            }

            connection.Close();
            return updatepass.Email;
        }
    }
}
