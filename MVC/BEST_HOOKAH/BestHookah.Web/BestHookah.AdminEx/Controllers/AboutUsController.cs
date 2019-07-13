using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BestHookah.DAL;

namespace BestHookah.AdminEx.Controllers
{
    public class AboutUsController : Controller
    {
        BestHookahEntities db = new BestHookahEntities();
        // GET: AboutUs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        //NormalView
        public ActionResult Contacts()
        {
            return View(db.Branches.ToList());
        }

        #region Branches
        public ActionResult BranchList()
        {
            List<Branches> branches = db.Branches.ToList();
            return View(branches);
        }

        public ActionResult CreateBranch()
        {
            Branches branches = new Branches();
            return View(branches);
        }
        [HttpPost]
        public ActionResult CreateBranchPost(Branches branches)
        {
            string message = "";

            if (BLL.Service.CreateBranch(branches, out message))
                return RedirectToAction("BranchList");
            else
                return RedirectToAction("CreateBranch", new { branches = branches, message = message });
        }


        public ActionResult EditBranch(int id)
        {
            Branches branches = db.Branches.ToList().First(p => p.Id == id);
            return View(branches);
        }
        [HttpPost]
        public ActionResult EditBranchPost(Branches branches)
        {
            string message = "";

            if (BLL.Service.EditBranch(branches, out message))
                return RedirectToAction("BranchList");
            else
                return RedirectToAction($"EditBranch/{branches.Id}", new { branches = branches, message = message });
        }


        public ActionResult DeleteBranch(int id)
        {
            Branches branches = db.Branches.ToList().First(p => p.Id == id);
            return View(branches);
        }
        [HttpPost]
        public ActionResult DeleteBranchPost(Branches branches)
        {
            string message = "";

            if (BLL.Service.DeleteBranch(branches, out message))
                return RedirectToAction("BranchList");
            else
                return RedirectToAction($"DeleteBranch/{branches.Id}", new { branches = branches, message = message });
        }

        #endregion

        #region Blog/Events
        //Normal View
        public ActionResult Blog()
        {
            List<EventsOnSite> events = db.EventsOnSite.ToList();
            if (RouteData.Values["id"] == null)
            {
                ViewBag.RouteId = 1;
                return View(events);
            }
            else
            {
                int id = Int32.Parse(RouteData.Values["id"].ToString());
                ViewBag.RouteId = id;
                return View(events);
            }
        }

        public ActionResult BlogButtonReadMore(int id)
        {
            List<EventsOnSite> events = db.EventsOnSite.ToList();
            ViewBag.EventsOnSite = events;
            if (events.ElementAtOrDefault(id - 1) != null)
            {
                return View(events.ElementAt(id - 1));
            }
            else
            {
                return RedirectToAction("Blog");
            }
        }

        //Create Blog
        public ActionResult CreateEventOnSite()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEventOnSitePost(EventsOnSite eventsOnSite)
        {
            string message = "";

            if (BLL.Service.CreateEventOnSite(eventsOnSite, out message))
                return RedirectToAction("Blog");
            else
                return RedirectToAction("CreateEventOnSite", new { hookahBarDrinks = eventsOnSite, message = message });
        }
        #endregion

        #region HookahBar
        //Normal View
        public ActionResult HookahBarDrinks()
        {
            List<HookahBarDrinks> bar = db.HookahBarDrinks.ToList();
            ViewData["MenuSections"] = db.MenuSections.ToList();
            return View(bar);
        }

        //MenuItems View
        public ActionResult HookahBarDrinksList()
        {
            List<HookahBarDrinks> bar = db.HookahBarDrinks.ToList();
            return View(bar);
        }

        //MenuSections View
        public ActionResult HookahBarDrinksMenuSections()
        {
            List<MenuSections> bar = db.MenuSections.ToList();
            return View(bar);
        }

        #region Create/Delete/Edit MenuItems
        ////////////////////////////////////
        public ActionResult CreateHookahBarDrinks()
        {
            HookahBarDrinks HookahBarDrinks = new HookahBarDrinks();
            return View(HookahBarDrinks);
        }

        [HttpPost]
        public ActionResult CreateMenuItem(HookahBarDrinks hookahBarDrinks)
        {
            string message = "";

            if (BLL.Service.CreateHookahBarDrinks(hookahBarDrinks, out message))
                return RedirectToAction("HookahBarDrinksList");
            else
                return RedirectToAction("CreateMenuItem", new { hookahBarDrinks = hookahBarDrinks, message = message });
        }

        ////////////////////////////////////
        public ActionResult EditHookahBarDrinks(int id)
        {
            HookahBarDrinks HookahBarDrinks = db.HookahBarDrinks.ToList().FirstOrDefault(p => p.Id == id);
            return View(HookahBarDrinks);
        }

        [HttpPost]
        public ActionResult EditMenuItem(HookahBarDrinks hookahBarDrinks)
        {
            string message = "";

            if (BLL.Service.EditHookahBarDrinks(hookahBarDrinks, out message))
                return RedirectToAction("HookahBarDrinksList");
            else
                return RedirectToAction($"EditMenuItem/{hookahBarDrinks.Id}", new { hookahBarDrinks = hookahBarDrinks, message = message });
        }

        ////////////////////////////////////
        public ActionResult DeleteHookahBarDrinks(int id)
        {
            HookahBarDrinks HookahBarDrinks = db.HookahBarDrinks.ToList().FirstOrDefault(p => p.Id == id);
            return View(HookahBarDrinks);
        }

        [HttpPost]
        public ActionResult DeleteMenuItem(HookahBarDrinks hookahBarDrinks)
        {
            string message = "";

            if (BLL.Service.DeleteHookahBarDrinks(hookahBarDrinks, out message))
                return RedirectToAction("HookahBarDrinksList");
            else
                return RedirectToAction($"DeleteMenuItem/{hookahBarDrinks.Id}", new { hookahBarDrinks = hookahBarDrinks, message = message });
        }

        public ActionResult DescriptionMenuItem(int id)
        {
            HookahBarDrinks HookahBarDrinks = db.HookahBarDrinks.ToList().FirstOrDefault(p => p.Id == id);
            return View(HookahBarDrinks);
        }
        #endregion

        #region Create/Delete/Edit MenuSections

        public ActionResult CreateMenuSection()
        {
            MenuSections menuSections = new MenuSections();
            return View(menuSections);
        }
        [HttpPost]
        public ActionResult CreateMenuSectionPost(MenuSections menuSections)
        {
            string message = "";

            if (BLL.Service.CreateMenuSection(menuSections, out message))
                return RedirectToAction("HookahBarDrinksMenuSections");
            else
                return RedirectToAction("CreateMenuSectionsPost", new { menuSections = menuSections, message = message });
        }

        ////////////////////////////////////
        public ActionResult EditMenuSection(int id)
        {
            MenuSections MenuSections = db.MenuSections.ToList().FirstOrDefault(p => p.Id == id);
            return View(MenuSections);
        }
        [HttpPost]
        public ActionResult EditMenuSectionPost(MenuSections menuSections)
        {
            string message = "";

            if (BLL.Service.EditMenuSection(menuSections, out message))
                return RedirectToAction("HookahBarDrinksMenuSections");
            else
                return RedirectToAction($"EditMenuSectionsPost/{menuSections.Id}", new { menuSections = menuSections, message = message });
        }

        ////////////////////////////////////
        public ActionResult DeleteMenuSection(int id)
        {
            MenuSections MenuSections = db.MenuSections.ToList().FirstOrDefault(p => p.Id == id);
            return View(MenuSections);
        }
        [HttpPost]
        public ActionResult DeleteMenuSectionPost(MenuSections menuSections)
        {
            string message = "";

            if (BLL.Service.DeleteMenuSection(menuSections, out message))
                return RedirectToAction("HookahBarDrinksMenuSections");
            else
                return RedirectToAction($"DeleteMenuSectionsPost/{menuSections.Id}", new { menuSections = menuSections, message = message });
        }

        ////////////////////////////////////
        public ActionResult DescriptionMenuSection(int id)
        {
            MenuSections MenuSections = db.MenuSections.ToList().FirstOrDefault(p => p.Id == id);
            return View(MenuSections);
        }

        #endregion

        #endregion
    }
}