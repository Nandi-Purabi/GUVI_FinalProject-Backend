using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using E_Commerce_Kaya_Fashions.Models;


namespace E_Commerce_Kaya_Fashions.Controllers
{
    public class UsersController : ApiController
    {
        
        public HttpResponseMessage Get()
        {
            string query = @"select * from users;";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["E_Commerce_Kaya_Fashions_DB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        public HttpResponseMessage Get([FromUri] string login_email)
        {
            string query = @"select * from users where userEmail='"+login_email+@"';";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["E_Commerce_Kaya_Fashions_DB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Users us)
        {
            try
            {
                string query = @"insert into users values('" + us.userName + @"','" + us.userEmail + @"','" + us.userPassword + @"')";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["E_Commerce_Kaya_Fashions_DB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully!!";
            }
            catch (Exception)
            {
                return "Failed to Add!!";
            }
        }
    }
    
}
