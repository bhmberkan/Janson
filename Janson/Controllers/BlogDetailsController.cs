using Janson.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class BlogDetailsController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();

        // GET: BlogDetails
        public ActionResult Index(int id)
        {
            //var blogno = db.MesageBlogTBL.Where(x => x.ID == id).Select(x => x.BlogID);
            //var values = db.MesageBlogTBL.Where(x => blogno.Contains(x.BlogID)).ToList();

            var values = db.BlogTBL.Find(id);
            return View(values);

        }

        public PartialViewResult NextPostPartial(int id)
        {
            var values = db.BlogTBL.Find(id);

            ViewBag.MaxID = db.BlogTBL.Max(x => x.ID);

            var previousBlog = db.BlogTBL
                .Where(x => x.ID < id)
                .OrderByDescending(x => x.ID)
                .FirstOrDefault();

            var nextBlog = db.BlogTBL
                .Where(x => x.ID > id)
                .OrderBy(x => x.ID)
                .FirstOrDefault();

            if (previousBlog != null)
            {
                ViewBag.PreviousTitle = previousBlog.Baslik; // Başlık değerini ViewBag ile taşıyoruz
                ViewBag.PreviusPhoto = previousBlog.Photo;


            }
            else
            {
                ViewBag.PreviousTitle = "Önceki yazı bulunamadı"; // Önceki blog yoksa hata vermesin
                ViewBag.PreviusPhoto = db.BlogTBL.Where(x => x.ID == 1).Select(x => x.Photo).FirstOrDefault();


            }

            if (nextBlog != null)
            {
                ViewBag.NextTitle = nextBlog.Baslik;   // Sonraki blogun başlığını taşıyoruz
                ViewBag.NextPhoto = nextBlog.Photo;
            }
            else
            {
                ViewBag.NextTitle = "Sonraki Yazı bulunamdaı";   // Sonraki blogun başlığını taşıyoruz
                ViewBag.NextPhoto = db.BlogTBL.OrderByDescending(x => x.ID).Select(x => x.Photo).FirstOrDefault();
            }

            return PartialView(values);
        }


        public PartialViewResult CreatorPartial(int id)
        {
            var values = db.BlogTBL.Find(id);
            return PartialView(values);
        }

        public PartialViewResult BlogCommentsPartial(int id)
        {
            var values = db.MesageBlogTBL.Where(x => x.BlogID == id).ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult CreateBlogComment()
        {
            return PartialView();
        }
        
        [HttpPost]
        public PartialViewResult CreateBlogComment(MesageBlogTBL t, int id)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(t);
            }
           
            t.BlogID = id;
            db.MesageBlogTBL.Add(t);
            db.SaveChanges();

         
            return PartialView();
        }
    }
}