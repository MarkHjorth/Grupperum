using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GrupperumServer.ModelLayer
{
    [DataContract]
    public class ClassRoom
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Size { get; set; }

        [DataMember]
        public bool Whiteboard { get; set; }

        [DataMember]
        public bool Monitor { get; set; }

        [DataMember]
        public bool Projector { get; set; }

        public ClassRoom(int id, int size, bool whiteboard, bool monitor, bool projector)
        {
            this.Id = id;
            this.Size = size;
            this.Whiteboard = whiteboard;
            this.Monitor = monitor;
            this.Projector = projector;
        }

        public ClassRoom(int id)
        {
            this.Id = id;
        }
    }
}
