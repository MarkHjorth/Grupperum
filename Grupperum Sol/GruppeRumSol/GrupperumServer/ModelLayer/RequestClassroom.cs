using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    [DataContract]
    public class RequestClassroom
    {
        [DataMember]
        int groupId, groupSize, requestCode;

        public RequestClassroom(int groupId, int groupSize, int requestCode)
        {
            this.groupId = groupId;
            this.GroupSize = groupSize;
            this.RequestCode = requestCode;
            
        }
        [DataMember]
        public int RequestCode { get; set; }

        [DataMember]
        public string ClassroomName { get; set; }

        [DataMember]
        public int GroupSize { get; set; }
    }
}
