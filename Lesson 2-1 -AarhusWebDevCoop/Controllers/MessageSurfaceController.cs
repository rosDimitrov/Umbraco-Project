using Lesson_2_1__AarhusWebDevCoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Lesson_2_1__AarhusWebDevCoop.Controllers
{
    public class MessageSurfaceController : SurfaceController
    {
        public ActionResult Index()
        {
            return PartialView("Message", new Message());
        }

        [HttpPost]
        public ActionResult HandleMessageSubmit(Message model)
        {

            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            //or IContent
            var message = Services.ContentService.CreateContent("message", CurrentPage.Id, "Message");
            message.SetValue("userName", model.Name);
            message.SetValue("userMessage", model.UserMessage);

            Services.ContentService.SaveAndPublishWithStatus(message);

            TempData["success"] = true;

            return RedirectToCurrentUmbracoPage();
        }
    }
}