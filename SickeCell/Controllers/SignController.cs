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
//using System.Web.Script.Serialization;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization;
using System.Configuration;
using System.Net.Mail;

namespace modularexpress.Controllers
{
    public class SignController : ApiController
    {
        public static string con = ConfigurationManager.ConnectionStrings["SickeCellConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(con);

        public class Signup
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Role { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Confirmpass { get; set; }
            public string Link { get; set; }
        }  

        //GET: api/Sign
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Sign/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sign
        public string Sign_Post(Signup datasigned)
        {
          try
            {               
                connection.Open();

                Checkemail();

                string Checkemail()
                {
                    SqlCommand searchcommand = new SqlCommand("loginsearch_Stored", connection);
                    searchcommand.CommandType = CommandType.StoredProcedure;
                    searchcommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = datasigned.Email;
                    SqlDataReader searchreader = searchcommand.ExecuteReader();

                    if (searchreader.HasRows == true)
                    {
                        while (searchreader.Read())
                        {
                            datasigned.Email = searchreader["Email"].ToString();
                        }
                        connection.Close();
                        return datasigned.Email;
                    }
                    else
                    {
                        searchreader.Close();
                        string a = "";
                        long b = 0;

                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = "Execute login_stored @LoginId, @FirstName, @LastName, @Role, @Email, @Password, @Confirm_Password, @Confirmed";

                        SqlCommand command2 = new SqlCommand("select top 1 LoginId from login order by LoginId DESC", connection);
                        SqlDataReader dataReader = command2.ExecuteReader();

                        if (dataReader.HasRows == true)
                        {
                            while (dataReader.Read())
                            {
                                a = dataReader[0].ToString();
                                b = Convert.ToInt64(a);

                                command.Parameters.Add("@LoginId", SqlDbType.BigInt).Value = b + 1;

                                if (datasigned.FirstName == "" || datasigned.FirstName == null)
                                {
                                    command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = datasigned.FirstName;
                                }

                                if (datasigned.LastName == "" || datasigned.LastName == null)
                                {
                                    command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = datasigned.LastName;
                                }

                                if (datasigned.Role == "" || datasigned.Role == null)
                                {
                                    command.Parameters.Add("@Role", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Role", SqlDbType.VarChar, 50).Value = datasigned.Role;
                                }

                                if (datasigned.Email == "" || datasigned.Email == null)
                                {
                                    command.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = datasigned.Email;                                  
                                }

                                if (datasigned.Password == "" || datasigned.Password == null)
                                {
                                    command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = datasigned.Password;
                                }

                                if (datasigned.Confirmpass == "" || datasigned.Confirmpass == null)
                                {
                                    command.Parameters.Add("@Confirm_Password", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Confirm_Password", SqlDbType.VarChar, 50).Value = datasigned.Confirmpass;
                                }

                                if (datasigned.Confirmpass == "" || datasigned.Confirmpass == null)
                                {
                                    command.Parameters.Add("@Confirmed", SqlDbType.VarChar, 50).Value = DBNull.Value;
                                }
                                else
                                {
                                    command.Parameters.Add("@Confirmed", SqlDbType.VarChar, 50).Value = "No";
                                }
                            }
                            //var smtp = new System.Net.Mail.SmtpClient();
                            var smtp = new System.Net.Mail.SmtpClient("noreply_verification@primeshire.tech");
                            {
                                //smtp.Host = "smtp.gmail.com";
                                //smtp.Port = 587;
                                //smtp.EnableSsl = true;
                                //smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                                //smtp.Credentials = new NetworkCredential("sugaryleonard@gmail.com", "seth2016");
                                //smtp.Timeout = 10000;

                                smtp.Host = "smtp.ipage.com";
                                smtp.Port = 587;
                                smtp.EnableSsl = true;
                                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                                smtp.Credentials = new NetworkCredential("noreply_verification@primeshire.tech", "Development2019$!");
                                smtp.Timeout = 20000;
                            }

                            MailMessage message = new MailMessage();
                            message.From = new MailAddress("noreply_verification@primeshire.tech");
                            //message.From = new MailAddress("voicecontact@yahoo.com");

                            message.Subject = "Email Verification";
                            //message.Body = "Thank you for verifying your email address. Please click <a style=\"color:slategray;font-weight:800;font-size:12px;\" href=\"http://localhost:59791/Home/Login2\">here</a> to login";
                            message.Body = "Thank you for verifying your email address. Please click <a style=\"color:darkslategray;font-weight:800;font-size:12px;\" href=\"https://sicklecell.primeshiretechnologies.com/home/login2\">here</a> to login";
                            message.IsBodyHtml = true;
                            message.To.Add(datasigned.Email);
                            smtp.Send(message);

                            dataReader.Close();

                        }
                        else
                        {
                            command.Parameters.Add("@LoginId", SqlDbType.BigInt).Value = b + 1;

                            if (datasigned.FirstName == "" || datasigned.FirstName == null)
                            {
                                command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = datasigned.FirstName;
                            }

                            if (datasigned.LastName == "" || datasigned.LastName == null)
                            {
                                command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = datasigned.LastName;
                            }

                            if (datasigned.Role == "" || datasigned.Role == null)
                            {
                                command.Parameters.Add("@Role", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Role", SqlDbType.VarChar, 50).Value = datasigned.Role;
                            }

                            if (datasigned.Email == "" || datasigned.Email == null)
                            {
                                command.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = datasigned.Email;                                                             
                            }

                            if (datasigned.Password == "" || datasigned.Password == null)
                            {
                                command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = datasigned.Password;
                            }

                            if (datasigned.Confirmpass == "" || datasigned.Confirmpass == null)
                            {
                                command.Parameters.Add("@Confirm_Password", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Confirm_Password", SqlDbType.VarChar, 50).Value = datasigned.Confirmpass;
                            }

                            if (datasigned.Confirmpass == "" || datasigned.Confirmpass == null)
                            {
                                command.Parameters.Add("@Confirmed", SqlDbType.VarChar, 50).Value = DBNull.Value;
                            }
                            else
                            {
                                command.Parameters.Add("@Confirmed", SqlDbType.VarChar, 50).Value = "No";
                            }

                            //var smtp = new System.Net.Mail.SmtpClient();
                            var smtp = new System.Net.Mail.SmtpClient("noreply_verification@primeshire.tech");
                            {
                                //smtp.Host = "smtp.gmail.com";
                                //smtp.Port = 587;
                                //smtp.EnableSsl = true;
                                //smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                                //smtp.Credentials = new NetworkCredential("sugaryleonard@gmail.com", "seth2016");
                                //smtp.Timeout = 10000;

                                smtp.Host = "smtp.ipage.com";
                                smtp.Port = 587;
                                smtp.EnableSsl = true;
                                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                                smtp.Credentials = new NetworkCredential("noreply_verification@primeshire.tech", "Development2019$!");
                                smtp.Timeout = 20000;
                            }
                            
                            MailMessage message = new MailMessage();
                            message.From = new MailAddress("noreply_verification@primeshire.tech");
                            //message.From = new MailAddress("voicecontact@yahoo.com");

                            message.Subject = "Email Verification";
                            //message.Body = "Thank you for verifying your email address. Please click <a style=\"color:slategray;font-weight:800;font-size:12px;\" href=\"http://localhost:59791/Home/Login2\">here</a> to login";
                            message.Body = "Thank you for verifying your email address. Please click <a style=\"color:darkslategray;font-weight:800;font-size:12px;\" href=\"https://sicklecell.primeshiretechnologies.com/home/login2\">here</a> to login";
                            message.IsBodyHtml = true;
                            message.To.Add(datasigned.Email);
                            smtp.Send(message);
                           
                            dataReader.Close();                            
                        }
                        command.ExecuteNonQuery();
                        connection.Close();
                        datasigned.Email = "";
                        return datasigned.Email;
                    }
                }
                //return datasigned.Email.ToString();
            }
            catch (Exception mess) { mess.ToString(); }

            return datasigned.Email;
        }                   
    }
}
