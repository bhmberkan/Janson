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

      
       
    }
}