using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupperumServer.ModelLayer;

namespace GrupperumServer.CtrlLayer
{
    class ClassCtrl
    {
        public ClassCtrl()
        {
        }
        
        public void addStudentToClass(Student student, Class clas)
        {
            clas.addStudent(student);
        }
    }
}
