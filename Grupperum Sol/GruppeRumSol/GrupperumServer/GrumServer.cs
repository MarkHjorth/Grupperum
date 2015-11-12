using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupperumServer.ModelLayer;
using GrupperumServer.CtrlLayer;

namespace GrupperumServer
{
    public class GrumServer : IGrumServer
    {
        public Class getClassByStudentId(int id)
        {
            ClassCtrl classCtrl = new ClassCtrl();
            return classCtrl.GetClassByStudentId(id);
        }
    }
}
