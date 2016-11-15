using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAPB.Models
{
    public class CartOrder
    {
        public string user_address { get; set; }
        public int phone_number { get; set; }
        public string user { get; set; }
        public List<ProductOrder> product { get; set; }
    }

    public class ProductOrder
    {
        public int count { get; set; }
        public Product product { get; set; }
    }
}