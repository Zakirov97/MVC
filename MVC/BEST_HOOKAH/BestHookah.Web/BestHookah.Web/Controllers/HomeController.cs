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
            return View();
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

        public ActionResult ReserveList()
        {
            List<Reserve> reserves = db.Reserve.ToList();
            return View(reserves);
        }
    }
}