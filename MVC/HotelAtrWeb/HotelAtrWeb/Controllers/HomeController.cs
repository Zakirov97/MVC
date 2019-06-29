using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelAtrWeb.Controllers
{
    public class HomeController : Controller
    {
        HotelAtr.DAL.HotelAtrEntities db = new HotelAtr.DAL.HotelAtrEntities();
        public ActionResult Index()
        {
            var data = db.Rooms.ToList();
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
    }
}