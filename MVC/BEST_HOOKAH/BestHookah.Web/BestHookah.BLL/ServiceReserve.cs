using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestHookah.DAL;

namespace BestHookah.BLL
{
    public class Service
    {
        static BestHookahEntities db = new BestHookahEntities();

        #region Create/Delete/Edit MenuItems

        public static bool CreateHookahBarDrinks(HookahBarDrinks hookahBarDrinks, out string message)
        {
            try
            {
                db.HookahBarDrinks.Add(hookahBarDrinks);
                db.SaveChanges();
                message = $"{hookahBarDrinks.Name} Created";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool EditHookahBarDrinks(HookahBarDrinks hookahBarDrinks, out string message)
        {
            try
            {
                HookahBarDrinks old = db.HookahBarDrinks.ToList().FirstOrDefault(p => p.Id == hookahBarDrinks.Id);
                old.ImgPath = hookahBarDrinks.ImgPath;
                old.Name = hookahBarDrinks.Name;
                old.Price = hookahBarDrinks.Price;
                old.TableName = hookahBarDrinks.TableName;
                old.Description = hookahBarDrinks.Description;
                db.SaveChanges();
                message = $"{hookahBarDrinks.Name} Edited";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool DeleteHookahBarDrinks(HookahBarDrinks hookahBarDrinks, out string message)
        {
            try
            {
                db.HookahBarDrinks.Attach(hookahBarDrinks);
                db.HookahBarDrinks.Remove(hookahBarDrinks);
                db.SaveChanges();
                message = $"Deleted {hookahBarDrinks.Name}";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        #endregion

        #region Create/Delete/Edit MenuSection

        public static bool CreateMenuSection(MenuSections menuSections, out string message)
        {
            try
            {
                db.MenuSections.Add(menuSections);
                db.SaveChanges();
                message = $"{menuSections.Name} Created";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool EditMenuSection(MenuSections menuSections, out string message)
        {
            try
            {
                MenuSections old = db.MenuSections.ToList().FirstOrDefault(p => p.Id == menuSections.Id);
                string oldNameMenuSection = old.Name;
                old.Name = menuSections.Name;
                List<HookahBarDrinks> oldBar = db.HookahBarDrinks.ToList().Where(p => p.TableName == oldNameMenuSection).ToList();
                foreach (var item in oldBar)
                {
                    item.TableName = menuSections.Name;
                }
                message = $"{menuSections.Name} Edited";
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool DeleteMenuSection(MenuSections menuSections, out string message)
        {
            try
            {
                db.MenuSections.Attach(menuSections);
                db.MenuSections.Remove(menuSections);

                List<HookahBarDrinks> bar = db.HookahBarDrinks.ToList().Where(p => p.TableName == menuSections.Name).ToList();
                foreach (var item in bar)
                {
                    db.HookahBarDrinks.Attach(item);
                    db.HookahBarDrinks.Remove(item);
                }
                db.SaveChanges();
                message = $"Deleted {menuSections.Name}";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        #endregion

        public static void NotifyEmployers()
        {
            //Notify Empl
        }

        public static bool CreateFeedback(Feedbacks feedback, out string message)
        {
            try
            {
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                message = $"{feedback.Name} Created";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool AddReserve(Reserve reserve, out string message)
        {
            try
            {
                db.Reserve.Add(reserve);
                db.SaveChanges();
                message = $"{reserve.Name} Created";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool CreateEventOnSite(EventsOnSite eventsOnSite, out string message)
        {
            try
            {
                db.EventsOnSite.Add(eventsOnSite);
                db.SaveChanges();
                message = $"{eventsOnSite.EventName} Created";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;

                return false;
            }
        }

        public static bool CreateOffer(Offers offer, out string message)
        {
            try
            {
                db.Offers.Add(offer);
                db.SaveChanges();
                message = $"{offer.Name} Created";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        #region Create/Delete/Edit Branch

        public static bool CreateBranch(Branches branches, out string message)
        {
            try
            {
                db.Branches.Add(branches);
                db.SaveChanges();
                message = $"{branches.BranchName} Created";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool EditBranch(Branches branches, out string message)
        {
            try
            {
                Branches old = db.Branches.ToList().FirstOrDefault(p => p.Id == branches.Id);
                old.BranchName = branches.BranchName;
                old.Description = branches.Description;
                old.Address = branches.Address;
                old.Phone = branches.Phone;
                old.HoursOfOperations = branches.HoursOfOperations;
                message = $"{branches.BranchName} Edited";
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool DeleteBranch(Branches branches, out string message)
        {
            try
            {
                db.Branches.Attach(branches);
                db.Branches.Remove(branches);
                db.SaveChanges();
                message = $"Deleted {branches.BranchName}";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        #endregion

        #region Gallery
        public static bool AddImageToGallery(Gallery gallery, out string message)
        {
            try
            {
                db.Gallery.Add(gallery);
                db.SaveChanges();
                message = $"{gallery.ImageName} Created";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool EditImageInGallery(Gallery gallery, out string message)
        {
            try
            {
                Gallery old = db.Gallery.ToList().FirstOrDefault(p => p.Id == gallery.Id);
                old.ImageName = gallery.ImageName;
                old.ImageDescription = gallery.ImageDescription;
                old.ImagePath = gallery.ImagePath;
                message = $"{gallery.ImageName} Edited";
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public static bool DeleteImageInGallery(Gallery gallery, out string message)
        {
            try
            {
                db.Gallery.Attach(gallery);
                db.Gallery.Remove(gallery);
                db.SaveChanges();
                message = $"Deleted {gallery.ImageName}";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
        #endregion Gallery
    }
}