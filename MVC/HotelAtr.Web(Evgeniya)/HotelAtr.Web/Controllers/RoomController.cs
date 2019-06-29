using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAtr.DAL;

namespace HotelAtr.Web.Controllers
{
    public class RoomController : Controller
    {
       HotelAtrEntities db = new HotelAtrEntities();

        // GET: Room
        public ActionResult Index()
        {
            ViewBag.test = "";

            List<Rooms> rooms = db.Rooms.ToList();

            //наша пр-ие я-ся строго типизированным
            return View(rooms);
        }
    }
}