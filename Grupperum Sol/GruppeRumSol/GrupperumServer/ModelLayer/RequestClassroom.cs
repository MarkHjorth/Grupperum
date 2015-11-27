using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    public class RequestClassroom
    {
        int groupId, groupSize, requestCode;
        string classroomName;

        public RequestClassroom(int groupId, int groupSize, int requestCode)
        {
            this.groupId = groupId;
            this.groupSize = groupSize;
            this.requestCode = requestCode;
        }
     }
}
