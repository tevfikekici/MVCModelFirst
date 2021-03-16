using ModelFirst.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ModelFirst.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {

        NorthwindEntities db = new NorthwindEntities();

        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employee employee)
        {

            var user = db.Employees.FirstOrDefault(x => x.FirstName == employee.FirstName && x.LastName == employee.LastName);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.FirstName, false);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                ViewBag.Message = "Incorrect login information !";
                return View();
            }
        }


        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}