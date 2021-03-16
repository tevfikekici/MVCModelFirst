using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelFirst.Models.EntityFramework;
using System.Data.Entity;
using ModelFirst.ViewModels;

namespace ModelFirst.Controllers
{
    [HandleError]
    public class ProductController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();



        // GET: Product
        [OutputCache(Duration = 300)]
        public ActionResult Index()
        {
            {
                var model = db.Products.Include(x=>x.Category).ToList();
                return View(model);
            }
        }

       
        public ActionResult Create()
        {

            var model = new ProductViewModel()
            {
                Categories = db.Categories.ToList(),
                Suppliers= db.Suppliers.ToList()
            };
            return View("Create",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel productInfo)
        {
            MessageViewModel MessageModel = new MessageViewModel();

            if (!ModelState.IsValid)
            {
                var model = new ProductViewModel()
                {
                    Categories = db.Categories.ToList(),
                    Suppliers = db.Suppliers.ToList()
                };

                //return View("Create", model);
                MessageModel.Message = " Please enter all information to create a product!";
                MessageModel.Status = false;
                return View("_Message", MessageModel);
            }
            else
            {
                db.Products.Add(productInfo.Product);
                db.SaveChanges();

                MessageModel.Message = productInfo.Product.ProductName + " Created successfully !";
                MessageModel.Status = true;
                MessageModel.LinkText = "Product List";
                MessageModel.URL = "/Product/Index";
                return View("_Message",MessageModel);
            }
          
        }

        public ActionResult Update(int ProductID)
        {

            var model = new ProductViewModel()
            {
                Categories = db.Categories.ToList(),
                Suppliers = db.Suppliers.ToList(),
                Product= db.Products.Find(ProductID)
            };
            return View("Update", model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductViewModel productInfo)
        {
            var dataToUpdate = db.Products.Find(productInfo.Product.ProductID);
            dataToUpdate.ProductName = productInfo.Product.ProductName;

          

            if (dataToUpdate != null)
            {
                db.SaveChanges();

                // you must enter all values of the table from view
                //db.Entry(productInfo.Product).State = System.Data.Entity.EntityState.Modified;

            }
            else
            {
                return HttpNotFound();
            }


            return RedirectToAction("Index", "Product");
        }


        public ActionResult Delete(int ProductID)
        {

            var dataToDelete = db.Products.Find(ProductID);
            if (dataToDelete != null)
            {
                db.Products.Remove(dataToDelete);
                db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index", "Product");
        }
    }
}