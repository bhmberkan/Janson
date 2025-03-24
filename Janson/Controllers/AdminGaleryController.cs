using Janson.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class AdminGaleryController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();
        // GET: Admin
        public ActionResult Index()
        {
            var values = db.PhotoTbl.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult InsertGaleryPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertGaleryPage(PhotoTbl t)
        {
            if (!ModelState.IsValid)
            {
                return View("InsertGaleryPage");
            }
            db.PhotoTbl.Add(t);
            db.SaveChanges();
            return RedirectToAction("InsertGaleryPage");

        }


        [HttpGet]
        public ActionResult UpdateGaleryPage(int id)
        {
            var values = db.PhotoTbl.Find(id);
            return View("UpdateGaleryPage", values);
        }

        [HttpPost]
        public ActionResult UpdateGaleryPages(PhotoTbl t)
        {
            var value = db.PhotoTbl.Find(t.ID);
            value.photo = t.photo;

            db.SaveChanges();
            return RedirectToAction("Index", "AdminGalery");


        }

        public ActionResult DeleteGaleryPage(int id)
        {
            var prt = db.PhotoTbl.Find(id);
            db.PhotoTbl.Remove(prt);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminGalery");
        }

    }
}