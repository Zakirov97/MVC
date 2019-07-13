using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BestHookah.DAL;

namespace BestHookah.Web.Controllers
{
    public class OffersController : Controller
    {
        BestHookahEntities db = new BestHookahEntities();
        // GET: Offers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Offers()
        {
            List<Offers> offers = db.Offers.ToList().Where(p=>p.OfferExpirationDate>DateTime.Now).ToList();
            return View(offers);
        }
    }
}