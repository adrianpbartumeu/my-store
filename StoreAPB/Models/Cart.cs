using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreAPB.Models
{
    public class Cart
    {
        public string cartid { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int recordid { get; set; }
        [Display(Name = "Count")]
        public int count { get; set; }
        public DateTime date { get; set; }
        public int productid { get; set; }
        public virtual Product product { get; set; }
        public decimal Total_per_Unit()
        {
            return product.Real_Price() * count;
        }      
    }
}