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

        public RequestClassroom(int groupId, int groupSize, int requestCode)
        {
            this.groupId = groupId;
            this.GroupSize = groupSize;
            this.RequestCode = requestCode;
            
        }
        public int RequestCode { get; set; }
        public string ClassroomName { get; set; }
        public int GroupSize { get; set; }
    }
}
