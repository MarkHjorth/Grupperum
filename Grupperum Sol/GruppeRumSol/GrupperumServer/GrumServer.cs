using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupperumServer.ModelLayer;
using GrupperumServer.CtrlLayer;
using GrupperumServer.DBConFold;

namespace GrupperumServer
{
    public class GrumServer : IGrumServer
    {
        DBCtrl dbCtrl = new DBCtrl();
        public Class getClassByStudentId(int id)
        {
            ClassCtrl classCtrl = new ClassCtrl();
            return classCtrl.GetClassByStudentId(id);
        }

        public bool CreateGroupRoom(string name, bool whiteboard, bool monitor)
        {
            DBCtrl dbCtrl = new DBCtrl();
            return dbCtrl.CreateGroupRoom(name, whiteboard, monitor);
        }
    }
}
