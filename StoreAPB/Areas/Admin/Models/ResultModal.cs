using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAPB.Areas.Admin.Models
{
    public class ResultModal<T>
    {
        public List<T> results { get; set; }
        public List<string> type { get; set; }

        public ResultModal(List<T> results, List<string> type)
        {
            this.results = results;
            this.type = type;
        }
    }
}