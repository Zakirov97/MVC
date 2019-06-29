using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAtr.DAL;

namespace HotelAtr.AdminEx.Controllers
{
    public class RoomController : Controller
    {
        HotelAtrEntities db = new HotelAtrEntities();

        // GET: Room
        public ActionResult Index()
        {
            List<Rooms> rooms = db.Rooms.ToList();

            //наша пр-ие я-ся строго типизированным
            return View(rooms);
        }

        public ActionResult CreateRoom(Rooms room, string message)
        {
            ViewBag.Message = message;
            return View(room);
        }

        [HttpPost]
        public ActionResult CreateRoom(Rooms room)
        {
            string message = "";

            if(BLL.ServiceRoom.AddRoom(room, out message))
                return RedirectToAction("Index");
            else
                return RedirectToAction("CreateRoom", new { room = room , message = message });         
        }
    }
}