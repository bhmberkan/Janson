using Janson.Models;
using Janson.Models.Entity;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using MailKit.Net.Smtp;


namespace Janson.Controllers
{
    public class MainController : Controller
    {
        JonsonDbMvcEntities db = new JonsonDbMvcEntities(); 
        // GET: Main
        public ActionResult Index()
        {
            var values = db.MainTBL.ToList();
            return View(values);
        }

        public PartialViewResult AboutUsPartial()
        {
            var values = db.AboutTBL.ToList();
            return PartialView(values);
        }
        public PartialViewResult AboutUsPartialprt()
        {
            var values = db.AboutpartTbl.ToList();
            return PartialView(values);
        }
        public PartialViewResult MainExperiencePartial()
        {
            var values = db.ExperienceTBL.ToList();
            return PartialView(values);
        }

        public PartialViewResult MainHobiPartial()
        {
           var values = db.HobilerTBL.ToList();
            return PartialView(values);
        }

        public PartialViewResult MainGaleryPartial()
        {
            var values = db.PhotoTbl.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult ContactPartial()
        {
           
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult ContactPartial(MessageTbl t)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddress = new MailboxAddress(t.Name, t.Mail);
            mimeMessage.From.Add(mailboxAddress); // mesaj kimden

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", "berkanburakturgut@gmail.com");
            mimeMessage.To.Add(mailboxAddressTo); // mesaj kime

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = t.Message + " \n \nGöndere: " + t.Mail; // içerik.
            mimeMessage.Body=bodyBuilder.ToMessageBody();

            mimeMessage.Subject = t.Baslik;


            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false); // 587 port numarası , ssl gereksin mi = fasle istersen true yaparsın
            client.Authenticate("berkanburakturgut@gmail.com", "brbrfhcxozglgegx");
            client.Send(mimeMessage);
            client.Disconnect(true);

           
            db.MessageTbl.Add(t);
            db.SaveChanges();

            return PartialView();
        }

       
    }
}