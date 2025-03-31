using Janson.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class LoginController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminTbl t)
        {
           
            // şu anlık rol yok 
            var value = db.AdminTbl.FirstOrDefault(x => x.Kullanıcı == t.Kullanıcı && x.Sifre == t.Sifre);
            if (value != null)
            {
                return RedirectToAction("Index", "Admin");

            }
            else
                ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre";
            return View();
        }
    }
}