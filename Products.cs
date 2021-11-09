using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Kaya_Fashions.Models
{
    public class Products
    {
        public int product_id { get; set; }
        public string product_code { get; set; }
        public string product_type { get; set; }
        public string category { get; set; }
        public int quantity_available { get; set; }
        public float price { get; set; }
        public int discount_percent { get; set; }
        public string product_img_src { get; set; }
        public string product_info { get; set; }



    }
}