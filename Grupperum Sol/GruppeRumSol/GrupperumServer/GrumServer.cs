using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupperumServer.ModelLayer;
using GrupperumServer.CtrlLayer;
using GrupperumServer.DBConFold;

namespace GrupperumServer
{
    public class GrumServer : IGrumServer
    {
        DBCtrl dbCtrl = new DBCtrl();
        ClassCtrl classCtrl = new ClassCtrl();
        LoginCtrl loginCtrl = new LoginCtrl();

        public Class getClassByStudentId(int id)
        {
            return classCtrl.GetClassByStudentId(id);
        }

        public bool CreateGroupRoom(string name, bool whiteboard, bool monitor)
        {
            return dbCtrl.CreateGroupRoom(name, whiteboard, monitor);
        }

        public Student GetStudentById(int id)
        {
            StudentCtrl studentCtrl = new StudentCtrl();
            return studentCtrl.GetSudentById(id);
        }

        public bool Authenticate(int user, string password)
        {
            return loginCtrl.Authenticate(user, password);
        }
    }
}
