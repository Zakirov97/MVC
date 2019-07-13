using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BestHookah.DAL;

namespace BestHookah.Web.Controllers
{
    public class GalleryController : Controller
    {
        BestHookahEntities db = new BestHookahEntities();        
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View(db.Gallery.ToList());
        }
    }
}