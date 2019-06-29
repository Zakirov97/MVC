using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelAtr.DAL;

namespace HotelAtr.BLL
{
    public class ServiceRoom
    {
        static HotelAtrEntities db = new HotelAtrEntities();

        public static bool AddRoom(Rooms room, out string message)
        {
            try
            {
                db.Rooms.Add(room);
                db.SaveChanges();

                message = "";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
    }
}
