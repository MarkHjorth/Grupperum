using GrupperumServer.DBConFold;
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
                isRented = dbCtrl.RentGroupRoom(grouproomId, groupId, dateStart, dateEnd);
            }
            return isRented;
        }

        public bool TestGroupRoom(int grouproomId, DateTime dateStart, DateTime dateEnd)
        {
            return dbCtrl.TestGroupRoom(grouproomId, dateStart, dateEnd);
        }

    }
}
