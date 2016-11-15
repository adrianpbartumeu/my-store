using StoreAPB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreAPB.Areas.Admin.Models;

namespace StoreAPB.Areas.Admin.DAL
{
    public class ProductRepository
    {
         private StoreDbContext db = new StoreDbContext();    

        public Result<Meat> PagingMeat(Paging pag)
         {
             int total = db.Meat.Count();
             List<Meat> meats = db.Meat.OrderBy(q => q.name_p).Skip((pag.page - 1) * pag.pageSize).Take(pag.pageSize).ToList();
             Result<Meat> results = new Result<Meat>(meats, total);
             return results;
         }

        public ResultModal<Category> meatModalData()
         {
             List<string> type = db.Meat.Select(q => q.type).Distinct().ToList();
             List<Category> categories = db.Category.ToList();
             ResultModal<Category> result = new ResultModal<Category>(categories, type);
             return result; 
         }

        public List<string> electricalType()
        {
            return db.Electrical_Appliance.Select(q => q.type).Distinct().ToList();
        }
    }
}