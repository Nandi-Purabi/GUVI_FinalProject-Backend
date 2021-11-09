using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using E_Commerce_Kaya_Fashions.Models;

namespace E_Commerce_Kaya_Fashions.Controllers
{
    public class ProductsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select * from products;";
            DataTable table = new DataTable();
            using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["E_Commerce_Kaya_Fashions_DB"].ConnectionString))
                using(var cmd = new SqlCommand(query,con))
                using(var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public HttpResponseMessage Get([FromUri] int pro_id)
        {
            string query = @"select product_id,price,discount_percent,product_img_src,product_info from products where product_id=" + pro_id + @";";
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

        public string Put(Products pr)
        {
            try
            {
                string query = @"update products set quantity_available = "+pr.quantity_available+ @" where product_id="+pr.product_id+@"";

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

    }
}
