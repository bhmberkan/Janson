using Janson.Models.Entity;
using PagedList;
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
        public ActionResult Index(string search,int sayfa = 1)
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
            using (var db = new JonsonDbMvcEntities())
            {
                // layz load vardı. ilişkili tabloyu da ekleyince düzdeldi.
               // var query = db.BlogTBL.Include("MesageBlogTBL").AsQueryable();

                var query = db.BlogTBL.Include("MesageBlogTBL").AsNoTracking().AsQueryable();

                if (!string.IsNullOrEmpty(search))
                {
                    query = query
                        .Where(c => c.Baslik.Contains(search) ||
                        c.icerik.Contains(search) ||
                        c.Olusturan.Contains(search) ||
                        c.Tarih.Contains(search)
                        );
                }

                query = query.OrderBy(c => c.ID);

                ViewBag.CurrentFilter = search;

                return View(query.ToPagedList(sayfa,3));
            }



            //var values = db.BlogTBL.ToList().ToPagedList(sayfa,3);
            //return View(values);

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