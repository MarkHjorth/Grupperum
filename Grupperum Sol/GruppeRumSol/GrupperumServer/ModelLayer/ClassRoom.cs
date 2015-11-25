using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    public class ClassRoom
    {
        int id, size;
        bool whiteboard, monitor, projector;

        public ClassRoom(int id, int size, bool whiteboard, bool monitor, bool projector)
        {
            this.id = id;
            this.size = size;
            this.whiteboard = whiteboard;
            this.monitor = monitor;
            this.projector = projector;
        }

        public ClassRoom(int id)
        {
            this.id = id;
        }
    }
}
