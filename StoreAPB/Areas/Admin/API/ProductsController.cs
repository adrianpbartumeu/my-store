using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StoreAPB.Models;
using StoreAPB.Areas.Admin.DAL;
using StoreAPB.Areas.Admin.Models;

namespace StoreAPB.Areas.Admin.API
{
    public class ProductsController : ApiController
    {
        private StoreDbContext db = new StoreDbContext();

        [HttpGet]
        public Result<Meat> PagingMeat([FromUri]Paging pag)
        {
            ProductRepository prod = new ProductRepository();
            return prod.PagingMeat(pag);
        }

         [HttpGet]
        public ResultModal<Category> meatModalData()
        {
            ProductRepository prod = new ProductRepository();
            return prod.meatModalData();           
        }

         [HttpPost]
         public IHttpActionResult PostProduct([FromBody]Meat product)//[FromBody]Meat product, System.Web.HttpPostedFileBase file , [FromBody]string fileName
         {
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }
             return StatusCode(HttpStatusCode.NoContent);
             //db.Product.Add(product);

             //try
             //{
             //    db.SaveChanges();
             //}
             //catch (DbUpdateException)
             //{
             //    if (ProductExists(product.productid))
             //    {
             //        return Conflict();
             //    }
             //    else
             //    {
             //        throw;
             //    }
             //}

             //return CreatedAtRoute("DefaultApi", new { id = product.productid }, product);
            
         }
        
        
        
        // GET: api/Products
        public IQueryable<Product> GetProduct()
        {
            return db.Product;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.productid)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
       

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Product.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Product.Count(e => e.productid == id) > 0;
        }
    }
}