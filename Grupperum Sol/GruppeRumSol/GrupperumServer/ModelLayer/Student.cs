using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.ModelLayer
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public int Id { get; }

        [DataMember]
        public string Name { get; }

        [DataMember]
        private string Password { get; }

        
        public Student(int id, String name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Student(int id, String name, String password)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
        }

    }
}
