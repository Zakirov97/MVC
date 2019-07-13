using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BestHookah.DAL;

namespace BestHookah.AdminEx.Controllers
{
    public class OffersController : Controller
    {
        BestHookahEntities db = new BestHookahEntities();
        // GET: Offers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateOffer()
        {
            Offers offer = new Offers();
            offer.OfferExpirationDate = DateTime.Now;
            return View(offer);
        }
        [HttpPost]
        public ActionResult CreateOfferPost(Offers offer)
        {
            string message = "";

            if (BLL.Service.CreateOffer(offer, out message))
                return RedirectToAction("CreateOffer");
            else
                return RedirectToAction("CreateOffer", new { offer = offer, message = message });
        }
    }
}