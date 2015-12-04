using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    class RequestMatch
    {
        int groupId;
        int classroomId;

        public RequestMatch(int groupId, int classroomId)
        {
            this.groupId = groupId;
            this.classroomId = classroomId;
        }

        
    }
}
