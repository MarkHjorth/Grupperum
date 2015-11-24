using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Grupperum_Website_Klient.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Selected { get; set; }

        public Student()
        {

        }

        public Student(int id, String name)
        {
            this.Id = id;
            this.Name = name;
            this.Selected = false;
        }
    }
}
