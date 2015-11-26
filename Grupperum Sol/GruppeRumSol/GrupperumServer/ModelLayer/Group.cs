using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    [DataContract]
    public class Group
    {
        private String name;
        private List<int> StudentId;
        public Group(String name, List<int> studentId)
        {
            this.name = name;
            this.StudentId = studentId;
        }
    }
}
