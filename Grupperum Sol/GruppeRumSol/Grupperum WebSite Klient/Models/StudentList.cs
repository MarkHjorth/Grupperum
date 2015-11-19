using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupperum_Website_Klient.Models
{
    public class StudentList
    {
        public List<Student> studList;

        public StudentList()
        {
            studList = new List<Student>();
        }

        public void Add(Student s)
        {
            studList.Add(s);
        }
    }
}