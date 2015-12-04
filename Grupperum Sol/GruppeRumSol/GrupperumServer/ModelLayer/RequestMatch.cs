using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    public class RequestMatch
    {
        public int GroupId { get; set; }
        public int ClassroomId { get; set; }

        public RequestMatch(int groupId, int classroomId)
        {
            this.GroupId = groupId;
            this.ClassroomId = classroomId;
        }

        
    }
}
