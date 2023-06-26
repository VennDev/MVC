using System;
using System.Web.Mvc;
using _03_22_2023.Models;

namespace _03_22_2023.Controllers
{
    public class LoginController : Controller
    {
        // GET
        public ActionResult Login()
        {
            return View();
        }
        
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string user_name_dh, string password)
        {
            var db = new AccountEntities();
            var model = db.users.Find(user_name_dh);
            if (model != null)
            {
                if (model.password == password)
                {
                    Console.Out.WriteLine("Login success");
                    Session["login"] = model;
                    return RedirectToAction("Index", "KhaNang");
                }
            }
            return View();
        }
        
        public ActionResult Logout()
        {
            Session["login"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}