using ModelFirst.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelFirst.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public int TotalOrderQuantity()
        {
            return db.Order_Details.Sum(x => x.Quantity);
        }
    }
}