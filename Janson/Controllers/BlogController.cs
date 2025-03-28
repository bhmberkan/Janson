using Janson.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class BlogController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();
        // GET: Blog
        public ActionResult Index()
        {
            /*
            ViewBag.categoryCounts = db.BlogTBL
                                    .GroupBy(x => x.Category)
                                    .Select(g => new
                                    {
                                    Category = g.Key,
                                    Count = g.Count()
                                    }).ToList(); */

            //Categorylerin sayısını çekmeyeceğım

            var values = db.BlogTBL.ToList();
            return View(values);

        }

        public PartialViewResult RecendPartial()
        {
            var values = db.BlogTBL.OrderByDescending(x=>x.ID).Take(4).ToList();
            
            return PartialView(values);
        }

        public PartialViewResult TagPartial()
        {
            var values = db.BlogTBL.OrderByDescending(x => x.ID).Take(4).ToList();

            return PartialView(values);
        }

        public PartialViewResult CategoryPartial()
        {
            var values = db.BlogTBL.ToList();

            return PartialView(values);
        }
    }
}