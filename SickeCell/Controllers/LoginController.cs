using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
// System.Web.Services;
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
using SickeCell.Models;
using SickeCell.Interfaces;

namespace modularexpress.Controllers
{
    public class LoginController : ApiController
    {
        public static string con = ConfigurationManager.ConnectionStrings["SickeCellConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(con);             

        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public IEnumerable<ILoggedIn> Validate(LoggedIn datalogin)
        {
            connection.Open();

            List<ILoggedIn> listdata = new List<ILoggedIn>();
            ILoggedIn listdataResponse = new LoggedIn();           

            try {

                Checkexistingmail();

                string Checkexistingmail()
                 {
                    SqlCommand locateEmailcmd = new SqlCommand("loginsearch_Stored", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    locateEmailcmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = datalogin.Email;
                     SqlDataReader locateEmailReader = locateEmailcmd.ExecuteReader();

                     if (locateEmailReader.HasRows == true)
                     {
                         while (locateEmailReader.Read())
                         {
                             listdataResponse.Email = locateEmailReader["Email"].ToString();

                             if (datalogin.Password == locateEmailReader["Password"].ToString())
                             {
                                 listdataResponse.Password  = locateEmailReader["Password"].ToString();
                                 listdataResponse.FirstName = locateEmailReader["FirstName"].ToString();
                                 listdataResponse.LastName  = locateEmailReader["LastName"].ToString();
                                 listdataResponse.Role      = locateEmailReader["Role"].ToString();
                                 listdata.Add(listdataResponse);

                                 locateEmailReader.Close();
                                 connection.Close();

                                 return listdata.ToString();
                             }
                             else
                             {
                                 listdataResponse.Password = "";
                                 listdata.Add(listdataResponse);

                                 locateEmailReader.Close();
                                 connection.Close();

                                 return listdata.ToString();
                             }

                         }
                     }
                     else
                     {
                         locateEmailReader.Close();
                         connection.Close();

                         listdata.Add(listdataResponse);
                         return listdata.ToString();
                     }
                     return listdata.ToString();
                 }                 
            }
            catch (Exception err)
            {
                err.Message.ToString();
            }
            return listdata;
        }        

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
