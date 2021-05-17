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

namespace Inventory.Controllers
{
    public class UpdateController : ApiController
    {
        public static string con = ConfigurationManager.ConnectionStrings["SickeCellConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(con);
        SqlConnection connect    = new SqlConnection(con);

        Int32 varautocode;
        string strautocode;
        
        string chrstring;

        // GET: api/Update
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Update/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Update
        public string Resetpassword(Verification confirmvalue)
        {
            try
            {
                connect.Open();
                SqlCommand verifypasscmd = new SqlCommand();
                verifypasscmd = new SqlCommand("select * from login where Password = '" + confirmvalue.Password + "' ", connect);
                SqlDataReader verifypassReader = verifypasscmd.ExecuteReader();

                if (verifypassReader.HasRows == true)
                {
                    chrstring = "existed";
                }
                else
                {
                    connection.Open();

                    SqlCommand verifycmd = new SqlCommand();
                    verifycmd = new SqlCommand("update login set Password = '" + confirmvalue.Password + "', Confirm_password = '" + confirmvalue.Password + "', Autocode ='" + confirmvalue.Autocode + "'  where Email = '" + confirmvalue.Email + "' ", connection);
                    SqlDataReader verifyReader = verifycmd.ExecuteReader();

                    verifyReader.Close();
                    connection.Close();

                    chrstring = "updated";
                }                

            }
            catch (Exception mssg)
            {
                chrstring = "failed";
                mssg.Message.ToString();
            }
            return chrstring;            
        }

        // PUT: api/Update/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Update/5
        public void Delete(int id)
        {
        }
    }
}
