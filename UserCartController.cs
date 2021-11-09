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
    public class UserCartController : ApiController
    {
        
        public HttpResponseMessage Get([FromUri] int login_id)
        {
            string query = @"select * from user_cart where userID='" + login_id + @"';";
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


        public string Post(UserCart usc)
        {
            try
            {
                string query = @"insert into user_cart values(" + usc.userID + @"," + usc.product_id + @","+usc.buy_quantity+@")";

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
        public string Put(UserCart usc)
        {
            try
            {
                string query = @"update user_cart set buy_quantity = " + usc.buy_quantity + @" where userID =" + usc.userID + @" and product_id=" + usc.product_id + @"";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["E_Commerce_Kaya_Fashions_DB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Successfully!!";
            }
            catch (Exception)
            {
                return "Failed to Update!!";
            }
        }

        public string Delete([FromUri] int userID, int product_id)
        {
            try
            {
                string query = @"delete from user_cart where userID =" + userID + @" and product_id=" + product_id + @"";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["E_Commerce_Kaya_Fashions_DB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully!!";
            }
            catch (Exception)
            {
                return "Failed to Delete!!";
            }
        }
    }
}
