using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    class Class
    {
        private int id;
        private List<Student> studentList = new List<Student>();

        public Class(int id)
        {
            this.id = id;
        }

        public void addStudent(Student student)
        {
            this.studentList.Add(student);
        }
    }
}
