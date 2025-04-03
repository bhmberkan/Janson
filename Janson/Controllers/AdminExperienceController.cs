using Janson.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class AdminExperienceController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();
       
        public ActionResult Index()
        {
            var values = db.ExperienceTBL.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult InsertExperiencePage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertExperiencePage(ExperienceTBL t)
        {
            if (!ModelState.IsValid)
            {
                return View("InsertExperiencePage");
            }
            db.ExperienceTBL.Add(t);
            db.SaveChanges();
            return RedirectToAction("InsertExperiencePage");

        }


        [HttpGet]
        public ActionResult UpdateExperiencePage(int id)
        {
            var values = db.ExperienceTBL.Find(id);
            return View("UpdateExperiencePage", values);
        }

        [HttpPost]
        public ActionResult UpdateExperiencePages(ExperienceTBL t)
        {
            var value = db.ExperienceTBL.Find(t.ID);
            value.baslik = t.baslik;
            value.Aralık = t.Aralık;
            value.LinkYolu=t.LinkYolu;
            value.LinkYolu = t.LinkYolu; // örn // http://instagram.com/bhmberkan // mantık bu 
            value.Link=t.Link; // instagram

            db.SaveChanges();
            return RedirectToAction("Index", "AdminExperience");


        }

        public ActionResult DeleteExperiencePage(int id)
        {
            var prt = db.ExperienceTBL.Find(id);
            db.ExperienceTBL.Remove(prt);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminExperience");
        }
    }
}