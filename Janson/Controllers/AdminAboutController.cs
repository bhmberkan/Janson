using Janson.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class AdminAboutController : Controller
    {
      
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();
        // GET: Admin
        public ActionResult Index()
        {
            var values = db.AboutTBL.ToList();
            return View(values);
        }

       

        [HttpGet]
        public ActionResult UpdateAboutPage(int id)
        {
            var values = db.AboutTBL.Find(id);
            return View("UpdateAboutPage", values);
        }
        [HttpPost]
        public ActionResult UpdateAboutPages(AboutTBL t)
        {
            var value = db.AboutTBL.Find(t.ID);
            value.icerik = t.icerik;
            value.icerik2 = t.icerik2;
            value.photo = t.photo;
           
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}