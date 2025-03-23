using Janson.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class AdminController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();
        // GET: Admin
        public ActionResult Index()
        {
            var values = db.MainTBL.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateMainPage(int id)
        {
            var values = db.MainTBL.Find(id);
            return View("UpdateMainPage",values);
        }
        [HttpPost]
        public ActionResult UpdateMainPages(MainTBL t)
        {
            var value = db.MainTBL.Find(t.ID);
            value.Baslik = t.Baslik;
            value.AltBaslik = t.AltBaslik;
            value.degisen1 = t.degisen1;
            value.degisen2 = t.degisen2;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        

        public PartialViewResult SideBarPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminHeader()
        {
            return PartialView();
        }
    }
}