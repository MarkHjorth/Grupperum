using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    public class Student
    {
        private int id;
        private String name, password;
        public Student(int id, String name)
        {
            this.id = id;
            this.name = name;
        }
        public Student(int id, String name, String password)
        {
            this.id = id;
            this.name = name;
            this.password = password;
        }

    }
}
