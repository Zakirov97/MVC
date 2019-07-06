using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAtr.DAL;

namespace HotelAtrWeb.Controllers
{
    public class RoomController : Controller
    {
        HotelAtr.DAL.HotelAtrEntities db = new HotelAtr.DAL.HotelAtrEntities();

        public ActionResult Index()
        {
            List<Rooms> rooms = db.Rooms.ToList();

            //nashe predstavlenie yavlyaetsya strogo tipizirovannoy
            return View(rooms);
        }
    }
}