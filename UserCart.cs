using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_Kaya_Fashions.Models
{
    public class UserCart
    {
        public int userID { get; set; }
        public int product_id { get; set; }
        public int buy_quantity { get; set; }
    }
}