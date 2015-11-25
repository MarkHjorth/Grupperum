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
        GroupCtrl groupCtrl = new GroupCtrl();
        ClassRoomCtrl classRoomCtrl = new ClassRoomCtrl();

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

        public bool CreateGroup(string name, List<int> studentId)
        {
            return groupCtrl.CreateGroup(name, studentId);
        }

        public bool RequestClassRoom(int groupId, int groupSize, bool whiteboard, bool monitor, bool projector)
        {
           return classRoomCtrl.RequestClassRoom(groupId, groupSize, whiteboard, monitor, projector);
        }

        public List<ClassRoom> GetClassRoomByAttributes(bool whiteboard, bool monitor, bool projector)
        {
            return classRoomCtrl.GetClassRoomByAttributes(whiteboard, monitor, projector);
        }
    }
}
