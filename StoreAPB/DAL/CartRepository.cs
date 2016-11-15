using StoreAPB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoreAPB.DAL
{
    public class CartRepository
    {
        private StoreDbContext db = new StoreDbContext();

        public void AddtoCart(Cart cart)
        {
            //Cart cart_ = db.Cart.SingleOrDefault(q => q.cartid == cart.cartid && q.productid == cart.productid);
           List<Cart> cart_ = db.Cart.Where(q => q.cartid == cart.cartid && q.productid == cart.productid).ToList();
            if (cart_.Count==0)
            {
               Cart newcart = new Cart
                {
                    cartid = cart.cartid,
                    productid = cart.productid,
                    count = cart.count,
                    date = DateTime.Now
                };
               db.Cart.Add(newcart);
            }
            else
            {
                cart_[0].count++;
            }
            db.SaveChangesAsync();


            //if (cart_ == null)
            //{
            //    cart_ = new Cart
            //    {
            //        cartid = cart.cartid,
            //        productid = cart.productid,
            //        count = cart.count,
            //        date = DateTime.Now
            //    };
            //    db.Cart.Add(cart_);
            //}
            //else
            //{
            //    cart_.count++;
            //}
            //db.SaveChangesAsync(); 
        }

        public List<Cart> GetCart(string cartid)
        {
            return db.Cart.Include("product").Include("product.category").Where(q => q.cartid == cartid).ToList();    
            //var hhh= db.Cart.Include("product").Include("product.category")
            //                        .Where(q => q.cartid == cartid)
            //                        .GroupBy(q=>q.productid)
            //                        .ToList();

            //var g = db.Cart.Include("product").Include("product.category").Where(q => q.cartid == cartid).ToList(); 
            //return g;
        }

        public void DelProd(DeleteProduct prod)
        {
            Cart cart=db.Cart.SingleOrDefault(q=>q.cartid==prod.cartid && q.productid==prod.productid);
            if (cart!=null)
	        {
                 db.Cart.Remove(cart);
                 db.SaveChangesAsync();
	        }            
        }

        public void CreateOrder(Order order)
        {
            IEnumerable<Cart> carts = db.Cart.Include("product").Where(q => q.cartid == order.customer);
             
            if (carts.Count() != 0)
            {                
                //The line below calculate the totalCost of the Order
                order.totalCost = carts.Sum(q => q.count * (q.product.price - q.product.reduce));
                DateTime date=DateTime.Now;

                int year = date.Year;
                int month = date.Month;
                int day = date.Day;

                DateTime date_check = new DateTime(year, month, day); 

                order.date = date;
                order.date_check = date_check;

                //The order.Lines bring the product too, so, with the line below everything run Ok
                IEnumerable<OrderLine> finalLines = order.Lines.Select(q => new OrderLine { count = q.count, productid = q.productid });
                order.Lines = finalLines.ToList();

                foreach (OrderLine item in finalLines)
                {
                    Product product=db.Product.Single(q => q.productid == item.productid);
                    product.amount -= item.count;
                    db.Entry(product).State = EntityState.Modified;
                }

                db.Order.Add(order);
                db.Cart.RemoveRange(carts);
                db.SaveChangesAsync();
            }
        }

        public void MigrateCart(string name,string new_name)
        {
           IEnumerable<Cart> cart_ = db.Cart.Where(q => q.cartid == name);

           if (cart_.Count()!=0)
           {
               foreach (Cart item in cart_)
               {
                   item.cartid = new_name;
               }
               db.SaveChangesAsync();
           }            
        } 
    }
}