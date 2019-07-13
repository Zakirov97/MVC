using BestHookah.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestHookah.Web.Controllers
{
    public class AboutUsController : Controller
    {
        BestHookahEntities db = new BestHookahEntities();

        // GET: AboutUs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }

        public ActionResult HookahBarDrinks()
        {
            List<HookahBarDrinks> bar = db.HookahBarDrinks.ToList();
            return View(bar);
        }

        public ActionResult Blog()
        {
            List<EventsOnSite> events = db.EventsOnSite.ToList();
            if (RouteData.Values["id"] == null)
            {
                ViewBag.RouteId = 1;
                return View(events);
            }
            else
            {
                int id = Int32.Parse(RouteData.Values["id"].ToString());
                ViewBag.RouteId = id;
                return View(events);
            }
        }

        public ActionResult BlogButtonReadMore(int id)
        {
            List<EventsOnSite> events = db.EventsOnSite.ToList();
            ViewBag.EventsOnSite = events;
            if (events.ElementAtOrDefault(id - 1) != null)
            {
                return View(events.ElementAt(id - 1));
            }
            else
            {
                return RedirectToAction("Blog");
            }
        }
    }
}