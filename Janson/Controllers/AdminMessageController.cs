using Janson.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class AdminMessageController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();
        // GET: AdminMessage
        public ActionResult Index()
        {
            var values = db.MessageTbl.ToList();
            return View(values);
        }

        public ActionResult MessageDetails(int id)
        {
            var value = db.MessageTbl.Find(id);
            return View(value);
        }

        public ActionResult RemoveMessage(int id)
        {
            var value = db.MessageTbl.Find(id);
            db.MessageTbl.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}