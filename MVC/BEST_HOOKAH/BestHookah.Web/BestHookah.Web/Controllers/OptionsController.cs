using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BestHookah.DAL;
namespace BestHookah.Web.Controllers
{
    public class OptionsController : Controller
    {
        BestHookahEntities db = new BestHookahEntities();
        // GET: Options
        public ActionResult Options()
        {
            List<UsersForNotifications> users = db.UsersForNotifications.ToList();
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            UsersForNotifications user = db.UsersForNotifications.Find(id);
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            UsersForNotifications user = db.UsersForNotifications.Find(id);
            return View(user);
        }

        public ActionResult Details(int id)
        {
            UsersForNotifications user = db.UsersForNotifications.Find(id);
            return View(user);
        }
    }
}