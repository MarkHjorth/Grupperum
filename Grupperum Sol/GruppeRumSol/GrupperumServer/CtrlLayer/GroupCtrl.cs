using GrupperumServer.DBConFold;
using GrupperumServer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.CtrlLayer
{
    public class GroupCtrl
    {
        DBCtrl dbCtrl = new DBCtrl();
        public GroupCtrl()
        {
        }

        public bool CreateGroup(string name, List<int> studentId)
        {
            Group group = new Group(name, studentId);
            return dbCtrl.CreateGroup(name, studentId);
        }
    }
}
