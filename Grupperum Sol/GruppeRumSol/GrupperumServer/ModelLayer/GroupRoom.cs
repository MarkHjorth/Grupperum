using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    [DataContract]
    public class GroupRoom
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool Whiteboard { get; set; }

        [DataMember]
        public bool Monitor { get; set; }

        public GroupRoom(int id, string name, bool whiteboard, bool monitor)
        {
            Id = id;
            Name = name;
            Whiteboard = whiteboard;
            Monitor = monitor;
        }
    }
}
