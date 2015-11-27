using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    public class ClassRoom
    {
        int id, size, requestMatch, spaceLeft, groupCount;
        string name;
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

        public ClassRoom(int id, int size, string name, int requestMatch, int spaceLeft, int groupCount)
        {
            this.id = id;
            this.size = size;
            this.Name = name;
            this.RequestMatch = requestMatch;
            this.SpaceLeft = spaceLeft;
            this.GroupCount = groupCount;
        }

        public int RequestMatch { get; set; }
        public string Name { get; set; }
        public int SpaceLeft { get; set; }
        public int GroupCount { get; set; }
    }
}
