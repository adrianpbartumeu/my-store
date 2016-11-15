using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAPB.Areas.Admin.Models
{
    public class Result<T>
    {
        public List<T> results { get; set; }
        public int total { get; set; }

        public Result(List<T> results,int total)
        {
            this.results = results;
            this.total = total;
        }
    }
}