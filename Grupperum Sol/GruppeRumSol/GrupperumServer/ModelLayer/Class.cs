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
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public List<Student> StudentList { get ; set; }

        public Class(int id)
        {
            if(StudentList == null)
            {
                StudentList = new List<Student>();
            }
            this.Id = id;
        }

        public Class(int tempId, string tempName)
        {
            if (StudentList == null)
            {
                StudentList = new List<Student>();
            }
            this.Id = tempId;
        }
        
        public void addStudent(Student student)
        {
            this.StudentList.Add(student);
        }
        
        public Student getStudent(int index)
        {
            return StudentList[index];
        }

        
    }
}
