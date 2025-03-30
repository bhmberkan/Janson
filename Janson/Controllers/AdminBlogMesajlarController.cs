using Janson.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Janson.Controllers
{
    public class AdminBlogMesajlarController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities();
        // GET: AdminBlogMesajlarMesajlar
        public ActionResult Index(string search,int sayfa=1)
        {

            var query = db.MesageBlogTBL.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                if (int.TryParse(search, out int blogIdSearch))
                {
                    query = query.Where(x => x.BlogID == blogIdSearch);
                }
                else
                {

                    query = query
                        .Where(c => c.İsim.Contains(search) ||
                        c.icerik.Contains(search) ||
                        c.Mail.Contains(search) ||
                        c.CreateAt.Contains(search)
                        );
                }
            }

            query = query.OrderBy(c => c.ID);

            ViewBag.CurrentFilter = search;

            return View(query.ToPagedList(sayfa, 7));
        }

         [HttpGet]
        public ActionResult UpdateBlogMesajlarPage(int id)
        {
            var values = db.MesageBlogTBL.Find(id);
            return View("UpdateBlogMesajlarPage", values);
        }

        [HttpPost]
        public ActionResult UpdateBlogMesajlarPages(MesageBlogTBL t)
        {
            var value = db.MesageBlogTBL.Find(t.ID);
            value.Photo = t.Photo;
            value.İsim = t.İsim;
            value.CreateAt = DateTime.Now.ToString("dd MM yyyy");
            value.Mail = t.Mail;
            value.icerik = t.icerik;

            db.SaveChanges();
            return RedirectToAction("Index", "AdminBlogMesajlar");


        }

        public ActionResult DeleteBlogMesajlarPage(int id)
        {
            var prt = db.MesageBlogTBL.Find(id);
            db.MesageBlogTBL.Remove(prt);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminBlogMesajlar");
        }
    }
}