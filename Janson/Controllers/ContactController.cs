using Janson.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class ContactController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
    }
}