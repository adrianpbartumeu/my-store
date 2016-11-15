using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Runtime.Serialization;
using System.Xml;

namespace StoreAPB.Models
{
    //[DataContract()]
    public class Category
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int categoryid { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        //[DataMember]
        [JsonIgnore]       
        public virtual ICollection<Product> product { get; set; }
    }
}