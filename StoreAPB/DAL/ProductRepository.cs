using StoreAPB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace StoreAPB.DAL
{
    public class ProductRepository
    {
        private StoreDbContext db = new StoreDbContext();

        public Task<List<Meat>> AllMeatAsync()
        {
            return Task.Run(()=>AllMeat());
        }

        public List<Meat> AllMeat()
        {
            return db.Meat.ToList();
        }

        public List<Meat> FirstSpecialMeat()
        {
            return db.Meat.Include("category").Where(q=>q.reduce!=0).Take(3).ToList();
        }
        public Task<List<Meat>> AllSpecialMeatAsync()
        {
            return Task.Run(() => AllSpecialMeat());
        }
        public List<Meat> AllSpecialMeat()
        {
            return db.Meat.Where(q=>q.reduce!=0).ToList();
        }

        public List<Meat> MeatbyType(string type)
        {
            return db.Meat.Where(q => q.type == type).ToList();
        }

        public List<Electrical_Appliance> FirstSpecialElectrical()
        {
            return db.Electrical_Appliance.Include("category").Where(q => q.reduce != 0).Take(3).ToList();
        }

        public Task<List<Electrical_Appliance>> AllSpecialElectricalAsync()
        {
            return Task.Run(() => AllSpecialElectrical());
        }

        public List<Electrical_Appliance> AllSpecialElectrical()
        {
            return db.Electrical_Appliance.Where(q => q.reduce != 0).ToList();
        }

        public List<Electrical_Appliance> ElectricalbyType(string type)
        {
            return db.Electrical_Appliance.Where(q => q.type == type).ToList();
        }

        public List<Product> SearchProduct(string search)
        {
            return db.Product.Where(q => q.type.Contains(search) ||q.name_p.Contains(search)).ToList();
        }

        public Home GetHomePage()
        {
            Home homepage = new Home();
            LoggedUser user = new LoggedUser();

            homepage.meat = FirstSpecialMeat();
            homepage.electrical = FirstSpecialElectrical();           
            return homepage;
        }
    }
}