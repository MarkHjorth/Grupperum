using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GrupperumServer.ModelLayer
{
    [DataContract]
    public class Class
    {
        //[DataMember]
        //private int id;
        //[DataMember]
        //private List<Student> studentList = new List<Student>();
        
        public Class(int id)
        {
            this.Id = id;
        }

        public Class(int tempId, string tempName)
        {
            this.Id = tempId;
        }
        
        public void addStudent(Student student)
        {
            this.StudentList.Add(student);
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public List<Student> StudentList { get; set; }
    }
}
