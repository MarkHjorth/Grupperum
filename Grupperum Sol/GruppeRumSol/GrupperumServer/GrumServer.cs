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
        public DBCtrl dbCtrl = new DBCtrl();

        public Class getClassById(int id)
        {
            ClassCtrl classCtrl = new ClassCtrl();
            return classCtrl.GetClassById(id);
        }

        public void CreateGroupRoom(string name, bool whiteboard, bool monitor)
        {
            dbCtrl.CreateGroupRoom(name, whiteboard, monitor);
        }
    }
}
