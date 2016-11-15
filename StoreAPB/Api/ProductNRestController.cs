using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using StoreAPB.Models;
using StoreAPB.DAL;
using System.Web;

namespace StoreAPB.Api
{
    public class ProductNRestController : ApiController
    {
        private StoreDbContext db = new StoreDbContext();
      

        /*
          This is an example of usig my own asynchronous method. 
          I commented it because my RestAPI will have 2 get method
         */
        //public async Task<List<Meat>> GetProduct2()
        //{
        //   ProductRepository p=new ProductRepository();
        //   return await p.AllMeatAsync();
        //}
        [HttpGet]
        public Home HomePage()
        {            
            ProductRepository products = new ProductRepository();           
            return products.GetHomePage();
        }

        [HttpGet]
        public List<Meat> MeatType(string id)
        {
            //id <=> Type I needed o change it because   
           // config.Routes.MapHttpRoute(
           //    name: "NonRestRoute",
           //    routeTemplate: "nonrest/{controller}/{action}/{id}",
           //    defaults: new { id = RouteParameter.Optional }
           //);
            ProductRepository products = new ProductRepository();
            return products.MeatbyType(id);
        }

        [HttpGet]
        public List<Electrical_Appliance> ElectricalType(string id)
        {          
            ProductRepository products = new ProductRepository();
            return products.ElectricalbyType(id);
        }


        [HttpGet]
        public async Task<List<Electrical_Appliance>> ElectricalSpecial()
        {
            ProductRepository products = new ProductRepository();
            return await products.AllSpecialElectricalAsync();
        }

        [HttpGet]
        public async Task<List<Meat>> MeatSpecial()
        {
            ProductRepository products = new ProductRepository();
            return await products.AllSpecialMeatAsync();
        }

        [HttpGet]
        public List<Product> Search(string id)
        {
            ProductRepository products = new ProductRepository();
            return products.SearchProduct(id);
        }

        [HttpGet]
        public void AddtoCart([FromUri]Cart cart)
        {
            CartRepository cart_ = new CartRepository();
            cart_.AddtoCart(cart);           
        }

        [HttpGet]
        public List<Cart> GetCart(string id)
        {
            CartRepository cart_ = new CartRepository();         
            return cart_.GetCart(id);
        }

        [HttpGet]
        public void DelProduct([FromUri]DeleteProduct prod)
        {
            CartRepository cart_ = new CartRepository();
            cart_.DelProd(prod);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public void CartOrder([FromBody]Order order)//[FromUri]Order This does not work here
        {
            CartRepository cart_ = new CartRepository();
            cart_.CreateOrder(order);
        }        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }      
    }
}