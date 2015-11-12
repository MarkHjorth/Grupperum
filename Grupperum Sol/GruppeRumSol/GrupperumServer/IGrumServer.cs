using GrupperumServer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer
{
    public interface IGrumServer
    {
        Class getClassByStudentId(int id);
        void CreateGroupRoom(string name, bool whiteboard, bool monitor);
    }
}
