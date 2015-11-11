using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    public class Class
    {
        private int id;
        private List<Student> studentList = new List<Student>();
        
        public Class(int id)
        {
            this.id = id;
        }

        public Class(int tempId, string tempName)
        {
              
        }

        public void addStudent(Student student)
        {
            this.studentList.Add(student);
        }

        public int Id { get; set; }
        public List<Student> StudentList { get; set; }
    }
}
