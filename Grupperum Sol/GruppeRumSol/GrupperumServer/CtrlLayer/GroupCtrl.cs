using GrupperumServer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.CtrlLayer
{
    class GroupCtrl
    {
        public GroupCtrl()
        {
        }

        public Group CreateGroup(int id, string name)
        {
            Group group = new Group(id, name);
            return group;
        }
        public Group CreateGroup(string name)
        {
            Group group = new Group(name);
            return group;
        }
    }
}
