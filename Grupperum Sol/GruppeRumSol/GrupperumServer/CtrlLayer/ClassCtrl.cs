using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupperumServer.ModelLayer;
using GrupperumServer.DBConFold;

namespace GrupperumServer.CtrlLayer
{
    public class ClassCtrl
    {
        DBCtrl dbCtrl = new DBCtrl();
        public ClassCtrl()
        {

        }
        
        public Class GetClassById(int id)
        {
            Class clas = GetClassFromId(id);
            clas = PopulateClass(clas);
            return clas;
        }

        private Class GetClassFromId(int id)
        {
            return dbCtrl.GetClassFromId(id);
        }

        private Class PopulateClass(Class clas)
        {
            int id = clas.Id;
            List<Student> tempList = dbCtrl.GetStudentsFromClassId(id);

            foreach (Student student in tempList)
	        {
                AddStudentToClass(student, clas);
	        }

            return clas;
        }

        public void AddStudentToClass(Student student, Class clas)
        {
            clas.addStudent(student);
        }
    }
}
