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
        public int GroupId { get; set; }
        [DataMember]
        public int GroupSize { get; set; }
        [DataMember]
        public int RequestCode { get; set; }
        [DataMember]
        public string ClassroomName { get; set; }

        public RequestClassroom(int groupId, int groupSize, int requestCode)
        {
            this.GroupId = groupId;
            this.GroupSize = groupSize;
            this.RequestCode = requestCode;
        }        
    }
}
