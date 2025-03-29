using Janson.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class AdminBlogController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();
        // GET: AdminBlog
        public ActionResult Index()
        {
            var values = db.BlogTBL.ToList();
            return View(values);
        }
    }
}