using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InventoryManagement.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        MyContextDb db = new MyContextDb();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User obj)
        {
            var count = db.Users.Where(u => u.UserName == obj.UserName && u.Password == obj.Password).Count();
            if (count <= 0)
            {
                ViewBag.message = "Invalide User Name or Password";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(obj.UserName, false);
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}