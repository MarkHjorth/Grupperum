using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupperumServer.ModelLayer;
using GrupperumServer.DBConFold;

namespace GrupperumServer.CtrlLayer
{
    class StudentCtrl
    {
        DBCtrl dbCtrl = new DBCtrl();
        public StudentCtrl()
        {
        }

        public Student GetSudentById(int id)
        {
            return dbCtrl.GetStudentById(id);
        }
    }
}
