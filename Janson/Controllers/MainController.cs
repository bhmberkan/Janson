using Janson.Models;
using Janson.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class MainController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities(); 
        // GET: Main
        public ActionResult Index()
        {
            var values = db.MainTBL.ToList();
            return View(values);
        }

        public PartialViewResult AboutUsPartial()
        {
            var values = db.AboutTBL.ToList();
            return PartialView(values);
        }
        public PartialViewResult AboutUsPartialprt()
        {
            var values = db.AboutpartTbl.ToList();
            return PartialView(values);
        }
        public PartialViewResult MainExperiencePartial()
        {
            var values = db.ExperienceTBL.ToList();
            return PartialView(values);
        }

        public PartialViewResult MainHobiPartial()
        {
           var values = db.HobilerTBL.ToList();
            return PartialView(values);
        }

        public PartialViewResult MainGaleryPartial()
        {
            var values = db.PhotoTbl.ToList();
            return PartialView(values);
        }

        public PartialViewResult ContactPartial()
        {
            // başka kodlar gelecek.
            var values = db.MessageTbl.ToList();
            return PartialView(values);
        }
    }
}