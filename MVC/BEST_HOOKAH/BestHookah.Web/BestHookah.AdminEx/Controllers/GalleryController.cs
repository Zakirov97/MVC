using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BestHookah.DAL;

namespace BestHookah.AdminEx.Controllers
{
    public class GalleryController : Controller
    {
        BestHookahEntities db = new BestHookahEntities();        
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GalleryList()
        {
            return View(db.Gallery.ToList());
        }

        #region Add/Edit/Delete Image

        public ActionResult AddImage()
        {
            return View(new Gallery());
        }
        [HttpPost]
        public ActionResult AddImagePost(Gallery gallery)
        {
            string message = "";

            if (BLL.Service.AddImageToGallery(gallery, out message))
                return RedirectToAction("GalleryList");
            else
                return RedirectToAction("AddImage", new { gallery = gallery, message = message });
        }


        public ActionResult EditImage(int id)
        {
            Gallery gallery = db.Gallery.ToList().FirstOrDefault(p => p.Id == id);
            return View(gallery);
        }
        [HttpPost]
        public ActionResult EditImagePost(Gallery gallery)
        {
            string message = "";

            if (BLL.Service.EditImageInGallery(gallery, out message))
                return RedirectToAction("GalleryList");
            else
                return RedirectToAction("EditImage", new { gallery = gallery, message = message });
        }


        public ActionResult DeleteImage(int id)
        {
            Gallery gallery = db.Gallery.ToList().FirstOrDefault(p => p.Id == id);
            return View(gallery);
        }
        [HttpPost]
        public ActionResult DeleteImagePost(Gallery gallery)
        {
            string message = "";

            if (BLL.Service.DeleteImageInGallery(gallery, out message))
                return RedirectToAction("GalleryList");
            else
                return RedirectToAction($"DeleteImage/{gallery.Id}", new { gallery = gallery, message = message });
        }

        #endregion
    }
}