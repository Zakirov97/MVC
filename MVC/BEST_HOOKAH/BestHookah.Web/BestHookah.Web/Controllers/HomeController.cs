using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BestHookah.DAL;
using BestHookah.BLL;

namespace BestHookah.Web.Controllers
{
    public class HomeController : Controller
    {
        BestHookahEntities db = new BestHookahEntities();
        public ActionResult Index()
        {
            Random random = new Random();
            int random1 = 0;
            int random2 = 0;
            while (random1 == random2)
            {
                random1 = random.Next(db.Feedbacks.Count());
                random2 = random.Next(db.Feedbacks.Count());
            }
            List<Feedbacks> feedbacks = new List<Feedbacks>();
            feedbacks.Add(db.Feedbacks.ToList().ElementAt(random1));
            feedbacks.Add(db.Feedbacks.ToList().ElementAt(random2));
            return View(feedbacks);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Reservation()
        {
            return View();
        }

        public ActionResult CreateFeedback()
        {
            return View(new Feedbacks());
        }

        [HttpPost]
        public ActionResult CreateFeedbackPost(Feedbacks feedback)
        {
            string message = "";

            if (BLL.Service.CreateFeedback(feedback, out message))
                return RedirectToAction("Index");
            else
                return RedirectToAction("CreateFeedback", new { feedback = feedback, message = message });
        }
    }
}