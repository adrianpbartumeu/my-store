using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreAPB.DAL
{
    public class LoggedUser
    {
        public void GetUser(HttpContextBase context)
        {
            string user = context.User.Identity.Name;
            var session = context.Session["CartId"];
            if (user=="" && session==null)
            {
                Guid tempCartId = Guid.NewGuid();
                user = tempCartId.ToString();

                context.Session.Add("CartId", user); 
            }
            else
            {
                context.Session["CartId"] = user;
            }
        }

        public void UpdateCartId(HttpContextBase context,string new_name)
        {
            CartRepository cart = new CartRepository();
            cart.MigrateCart(context.Session["CartId"].ToString(), new_name);
        }
    }
}