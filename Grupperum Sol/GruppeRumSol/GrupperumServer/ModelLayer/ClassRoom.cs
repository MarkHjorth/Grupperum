using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    class ClassRoom
    {
        int size;
        bool whiteboard, monitor, projector;

        public ClassRoom(int size, bool whiteboard, bool monitor, bool projector)
        {
            this.size = size;
            this.whiteboard = whiteboard;
            this.monitor = monitor;
            this.projector = projector;
        }
    }
}
