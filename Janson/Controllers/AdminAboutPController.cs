using Janson.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class AdminAboutPController : Controller
    {
        // GET: AdminAboutP
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();
        // GET: Admin
        public ActionResult Index()
        {
            var values = db.AboutpartTbl.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult InsertAboutPPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertAboutPPage(AboutpartTbl t)
        {
            if (!ModelState.IsValid)
            {
                return View("InsertAboutPPage");
            }
            db.AboutpartTbl.Add(t);
            db.SaveChanges();
            return RedirectToAction("InsertAboutPPage");

        }


        [HttpGet]
        public ActionResult UpdateAboutPPage(int id)
        {
            var values = db.AboutpartTbl.Find(id);
            return View("UpdateAboutPPage", values);
        }

        [HttpPost]
        public ActionResult UpdateAboutPPages(AboutpartTbl t)
        {
            var value = db.AboutpartTbl.Find(t.ID);
            value.Baslik = t.Baslik;
            value.icerik = t.icerik;

            db.SaveChanges();
            return RedirectToAction("Index","AdminAbout");


        }

        public ActionResult DeleteAboutPPage(int id)
        {
            var prt = db.AboutpartTbl.Find(id);
            db.AboutpartTbl.Remove(prt);
            db.SaveChanges();
            return RedirectToAction("Index","AdminAbout");
        }

        public PartialViewResult AdminAboutPPartial()
        {
            var values = db.AboutpartTbl.ToList();
            return PartialView(values);
        }
    }
}