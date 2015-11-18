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

        public Group CreateGroup(string name, List<int> studentId)
        {
            Group group = new Group(name, studentId);
            return group;
        }
    }
}
