using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAPB.Models
{
    public class Home
    {
        public List<Meat> meat { get; set; }  
        public List<Electrical_Appliance> electrical { get; set; }
        public string user { get; set; } 
    }
}