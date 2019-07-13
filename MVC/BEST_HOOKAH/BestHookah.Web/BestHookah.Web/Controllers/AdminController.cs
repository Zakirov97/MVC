using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BestHookah.DAL;
using BestHookah.BLL;
namespace BestHookah.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reservation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateReserve(Reserve reserve)
        {
            string message = "";

            if (Service.AddReserve(reserve, out message))
            {
                //Уведомляем сотрудников по резервированию 
                Service.NotifyEmployers();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index", new { reserve = reserve, message = message });
        }
    }
}