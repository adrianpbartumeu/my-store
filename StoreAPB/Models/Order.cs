using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StoreAPB.Models
{
    public class Order
    {
        [HttpBindNever]
        public int orderid { get; set; }
        public string customer { get; set; }

        [Display(Name = "Date")]
        public DateTime date { get; set; }
        
        /*This field was created to know the cuantities of orders we have in the shop by date. 
         * If you see the data you will see the time too but it's just for bother you
         * In your queries you must omit the time*/
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date_check { get; set; }        

        [Display(Name = "Phone Number")]
        public int phone_number { get; set; }

        [Display(Name = "Delivery Address")]
        public string delivery_Address { get; set; }

        [HttpBindNever]
        public decimal totalCost { get; set; }

        public virtual ICollection<OrderLine> Lines { get; set; }

        //[Display(Name = "Product")]
        //public int productid { get; set; }
        //public virtual Product product { get; set; }       

        //[Display(Name = "Address")]
        //public string addressid { get; set; }
        //public virtual Address address { get; set; }

        //[Display(Name = "User")]
        //public int userid { get; set; }
        //public virtual ApplicationUser user { get; set; }

        //[Display(Name = "Amount")]
        //public decimal amount { get; set; }

        //[Display(Name = "Count")]
        //public int count { get; set; }
    }

    public class OrderLine
    {
        [HttpBindNever]
        public int Id { get; set; }
        [Required]
        [Range(0, 100)]
        public int count { get; set; }
        //[Required]
        public int productid { get; set; }
        [HttpBindNever]
        public int orderid { get; set; }

        //[HttpBindNever]
        public Product product { get; set; }
        [HttpBindNever]
        public Order order { get; set; }
    }

    //public class Order
    //{
    //    [HttpBindNever]
    //    public int Id { get; set; }
    //    [Required]
    //    public string Customer { get; set; }
    //    [Required]
    //    public virtual ICollection<OrderLine> Lines { get; set; }
    //}

   
}