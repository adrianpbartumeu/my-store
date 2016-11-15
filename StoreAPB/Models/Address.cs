using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreAPB.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string addressid { get; set; }

        [Display(Name = "User Address")]
        public string user_addres { get; set; }

        [Display(Name = "Phone")]
        public int phone { get; set; }

        //[Display(Name = "Country")]
        //public string country { get; set; }

        //[Display(Name = "Postal Code")]
        //public int postal_code { get; set; }     
    }
}