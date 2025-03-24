using Janson.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class AdminHobiesController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();
        // GET: Admin
        public ActionResult Index()
        {
            var values = db.HobilerTBL.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult InsertHobiesPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertHobiesPage(HobilerTBL t)
        {
            if (!ModelState.IsValid)
            {
                return View("InsertHobiesPage");
            }
            db.HobilerTBL.Add(t);
            db.SaveChanges();
            return RedirectToAction("InsertHobiesPage");

        }


        [HttpGet]
        public ActionResult UpdateHobiesPage(int id)
        {
            var values = db.HobilerTBL.Find(id);
            return View("UpdateHobiesPage", values);
        }

        [HttpPost]
        public ActionResult UpdateHobiesPages(HobilerTBL t)
        {
            var value = db.HobilerTBL.Find(t.ID);
            value.Baslik = t.Baslik;
            value.İcerik = t.İcerik;

            db.SaveChanges();
            return RedirectToAction("Index", "AdminHobies");


        }

        public ActionResult DeleteHobiesPage(int id)
        {
            var prt = db.HobilerTBL.Find(id);
            db.HobilerTBL.Remove(prt);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminHobies");
        }

        
    }
}