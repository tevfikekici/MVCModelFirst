using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelFirst.Models.EntityFramework;

namespace ModelFirst.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {

        NorthwindEntities db = new NorthwindEntities();

        public ActionResult Index()
        {
            var model = db.Categories.ToList();
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Sales Representative, Sales Manager")]
        public ActionResult Create()
        {                   
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category categoryInfo)
        {           
            db.Categories.Add(categoryInfo);
            db.SaveChanges();

            return RedirectToAction("Index", "Category");
        }

       

        
        public ActionResult Update(int CategoryID)
        {
            var model = db.Categories.Find(CategoryID);
            if (model==null)
            {
                return HttpNotFound();
                
            }
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveUpdate(Category categoryInfo)
        {
            var dataToUpdate = db.Categories.Find(categoryInfo.CategoryID);

            dataToUpdate.CategoryName = categoryInfo.CategoryName;
            if (dataToUpdate!=null)
            {
                db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }


            return RedirectToAction("Index", "Category");
        }

        public ActionResult Delete (int CategoryID)
        {

            var dataToDelete = db.Categories.Find(CategoryID);
            if (dataToDelete!=null)
            {
                db.Categories.Remove(dataToDelete);
                db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index", "Category");
        }

        public ActionResult ListByCategory(int CategoryID)
        {
            var model = db.Products.Where(x => x.CategoryID == CategoryID).ToList();
            return View(model);
            //return View();
        }   
    }
}
