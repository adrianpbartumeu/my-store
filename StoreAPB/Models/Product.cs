using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreAPB.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Id")]
        public int productid { get; set; }

        [Required]
        [Display(Name = "Name")]
        public String name_p { get; set; }

        [Display(Name = "Image")]
        public String image { get; set; }

        [Display(Name = "Description")]
        public String description { get; set; }

        //I modified this type because when it shows the price it puts me euro currency by default, I just need to show the amount 
        //[DataType(DataType.Currency)]
        //[Column(TypeName="money")]
        [Display(Name = "Price per Unit")]
        public decimal price { get; set; }

        [Display(Name = "Reduce")]
        public decimal reduce { get; set; }

        [Display(Name = "Amount")]
        public int amount { get; set; }

        [Display(Name = "Type")]
        public String type { get; set; }

        [Display(Name = "Category")]
        public int categoryid { get; set; }
        
        public virtual Category category { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> order { get; set; }

        public decimal Real_Price()
        {
            return price - reduce;
        }
    }
}