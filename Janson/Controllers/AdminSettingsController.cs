using Janson.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class AdminSettingsController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();

        public ActionResult Index()
        {
            var values = db.AdminTbl.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult InsertSettingPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertSettingPage(AdminTbl t)
        {
            if (!ModelState.IsValid)
            {
                return View("InsertSettingPage");
            }
            db.AdminTbl.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminSettings");

        }


        [HttpGet]
        public ActionResult UpdateSettingPage(int id)
        {
            var values = db.AdminTbl.Find(id);
            return View("UpdateSettingPage", values);
        }

        [HttpPost]
        public ActionResult UpdateSettingPages(AdminTbl t)
        {
            var value = db.AdminTbl.Find(t.ID);
            value.Kullanıcı = t.Kullanıcı;
            value.Sifre = t.Sifre;

            db.SaveChanges();
            return RedirectToAction("Index", "AdminSettings");


        }

        public ActionResult DeleteSettingPage(int id)
        {
            var kayıt = db.AdminTbl.Count();

            if (kayıt > 1)
            {
                var value = db.AdminTbl.Find(id);
                db.AdminTbl.Remove(value);
                db.SaveChanges();
                return RedirectToAction("Index", "AdminSettings");
            }
           

            return RedirectToAction("Index", "AdminSettings");
        }

    }
}