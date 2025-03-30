using Janson.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Janson.Controllers
{
    public class AdminBlogController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();
        // GET: AdminBlog
        public ActionResult Index(string search,int sayfa =1)
        {
            using (var db = new JonsonDbMvcEntities())
            {
                var query = db.BlogTBL.AsQueryable();

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

                return View(query.ToPagedList(sayfa,7));
            }



        }


        [HttpGet]
        public ActionResult InsertBlogPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertBlogPage(BlogTBL t)
        {
            if (!ModelState.IsValid)
            {
                return View("InsertBlogPage");
            }

            if (t.Tarih==null)
            {
                t.Tarih = DateTime.Now.ToString("dd MM yyyy");

            }
          
            db.BlogTBL.Add(t);
            db.SaveChanges();
            return RedirectToAction("InsertBlogPage");

        }


        [HttpGet]
        public ActionResult UpdateBlogPage(int id)
        {
            var values = db.BlogTBL.Find(id);
            return View("UpdateBlogPage", values);
        }

        [HttpPost]
        public ActionResult UpdateBlogPages(BlogTBL t)
        {
            var value = db.BlogTBL.Find(t.ID);
            value.Photo = t.Photo;
            value.Tarih = DateTime.Now.ToString("dd MM yyyy");
            value.Baslik=t.Baslik;
            value.icerik = t.icerik;
            value.Olusturan = t.Olusturan;
            value.Category = t.Category;
            value.Tag = t.Tag;
            value.OlusturanYorum = t.OlusturanYorum;
            value.OlusturanPhoto = t.OlusturanPhoto;

            db.SaveChanges();
            return RedirectToAction("Index", "AdminBlog");


        }

        public ActionResult DeleteBlogPage(int id)
        {
            var prt = db.BlogTBL.Find(id);
            db.BlogTBL.Remove(prt);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminBlog");
        }
    }
}