using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    class RequestClassroom
    {
        int groupId, groupSize, requestCode;
        string classroomName;

        public RequestClassroom(int groupId, int groupSize, int requestCode, String classroomName)
        {
            this.groupId = groupId;
            this.groupSize = groupSize;
            this.requestCode = requestCode;
            

        }
    }
}
