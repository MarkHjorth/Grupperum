using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    public class RequestClassroom
    {
        public int GroupId { get; set; } 
        public int GroupSize { get; set; }
        public int RequestCode { get; set; }

        public RequestClassroom(int groupId, int groupSize, int requestCode)
        {
            this.GroupId = groupId;
            this.GroupSize = groupSize;
            this.RequestCode = requestCode;            
        }        
    }
}
