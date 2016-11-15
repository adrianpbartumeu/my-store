using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreAPB.Models
{
    public class Electrical_Appliance : Product
    {
        //public enum Condition
        //{New,Used}
        [Required]
        [Display(Name = "Brand")]
        public String brand { get; set; }
    }
}