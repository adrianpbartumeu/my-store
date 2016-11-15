using StoreAPB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreAPB.Areas.Admin.Models;

namespace StoreAPB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class PrincipalController : Controller
    {
        private StoreDbContext db = new StoreDbContext();
        // GET: Admin/Principal
        public ActionResult Index()
        {
            return View();
        }

        [HttpPut]
        public PartialViewResult Edit(Meat meat_, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file != null && Path.GetExtension(file.FileName)==".jpg")
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var deletefile = Path.Combine(Server.MapPath("~/Images/Meat/" + meat_.type + "/"), meat_.image);
                    if (System.IO.File.Exists(deletefile))
                    {
                        System.IO.File.Delete(deletefile);
                    }

                    var path = Path.Combine(Server.MapPath("~/Images/Meat/" + meat_.type + "/"), fileName);
                    meat_.image = fileName;
                    file.SaveAs(path);  
                }
                db.Entry(meat_).State = EntityState.Modified;
                db.SaveChanges();

                return PartialView("_Ok");
            }

            return PartialView("_Invalid");
        }

        [HttpPost]
        public PartialViewResult Create(Meat meat_, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file != null && Path.GetExtension(file.FileName) == ".jpg")
                {
                    var fileName = Path.GetFileName(file.FileName);
                   
                    var path = Path.Combine(Server.MapPath("~/Images/Meat/" + meat_.type + "/"), fileName);
                    meat_.image = fileName;
                    file.SaveAs(path);
                }
                try
                {
                    db.Meat.Add(meat_);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    if (file != null && Path.GetExtension(file.FileName) == ".jpg")
                    {
                        var path = Path.Combine(Server.MapPath("~/Images/Meat/" + meat_.type + "/"), Path.GetFileName(file.FileName));
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                    }                   
                    return PartialView("_Invalid");
                }
               

                return PartialView("_Ok");
            }

            return PartialView("_Invalid");
        }

        [HttpDelete]
        public PartialViewResult Delete(DeleteMeat meat_)
        {
            if (ModelState.IsValid)
            {
                Meat deleteMeat = db.Meat.Find(meat_.productid);
                var path = Path.Combine(Server.MapPath("~/Images/Meat/" + meat_.type + "/"), Path.GetFileName(meat_.image));
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                db.Meat.Remove(deleteMeat);
                db.SaveChanges();

                return PartialView("_Ok");
            }

            return PartialView("_Invalid");
        }
    }
}