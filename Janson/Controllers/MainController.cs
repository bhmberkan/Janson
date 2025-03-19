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
            return PartialView();
        }
        public PartialViewResult AboutUsPartialprt()
        {
            return PartialView();
        }
        public PartialViewResult MainExperiencePartial()
        {
            return PartialView();
        }

        public PartialViewResult MainHobiPartial()
        {
            return PartialView();
        }

        public PartialViewResult MainGaleryPartial()
        {
            return PartialView();
        }

        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
    }
}