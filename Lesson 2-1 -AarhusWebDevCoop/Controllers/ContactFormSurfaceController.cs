using Lesson_2_1__AarhusWebDevCoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Lesson_2_1__AarhusWebDevCoop.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            return PartialView("ContactForm",new ContactForm());
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {

            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            //or IContent
            var comment = Services.ContentService.CreateContent(model.Subject, CurrentPage.Id, "Comment");
            comment.SetValue("firstName", model.Name);
            comment.SetValue("email", model.Email);
            comment.SetValue("subject", model.Subject);
            comment.SetValue("message", model.Message);

            Services.ContentService.Save(comment);

            TempData["success"] = true;
           
            return RedirectToCurrentUmbracoPage();
        }
    }
}