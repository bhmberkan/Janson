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