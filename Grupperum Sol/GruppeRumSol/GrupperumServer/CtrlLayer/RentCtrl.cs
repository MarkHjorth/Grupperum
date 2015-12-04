using GrupperumServer.DBConFold;
using GrupperumServer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.CtrlLayer
{
    public class RentCtrl
    {
        DBCtrl dbCtrl = new DBCtrl();

        public bool RentGroupRoom(int grouproomId, int groupId, DateTime dateStart, DateTime dateEnd)
        {
            bool isRented = false;
            if (TestGroupRoom(grouproomId, dateStart, dateEnd))
            {
                if (dbCtrl.CanTheyRent(groupId, dateStart, dateEnd))
                {
                    isRented = dbCtrl.RentGroupRoom(grouproomId, groupId, dateStart, dateEnd);
                }
            }
            return isRented;
        }

        public bool TestGroupRoom(int grouproomId, DateTime dateStart, DateTime dateEnd)
        {
            return dbCtrl.TestGroupRoom(grouproomId, dateStart, dateEnd);
        }

        public bool RentClassRooms(List<RequestMatch> requests)
        {
            bool didWork = true;
            foreach(RequestMatch rm in requests)
            {
                TimeSpan ts = new TimeSpan(7, 0, 0, 0);
                bool t = dbCtrl.RentClassRoom(rm.ClassroomId, rm.GroupId, DateTime.Now, DateTime.Now.Add(ts));
                if (!t)
                {
                    didWork = false;
                }
            }
            return didWork;
        }
    }
}
