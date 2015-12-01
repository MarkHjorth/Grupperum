using GrupperumServer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer
{
    public interface IGrumServer
    {
        Class getClassByStudentId(int id);
        bool CreateGroupRoom(string name, bool whiteboard, bool monitor);
        Student GetStudentById(int id);
        bool Authenticate(int user, string password);
        bool CreateGroup(string name, List<int> studentId);
        bool RequestClassRoom(int groupId, int groupSize, bool whiteboard, bool monitor, bool projector);
        List<ClassRoom> GetClassRoomByAttributes(bool whiteboard, bool monitor, bool projector);
        List<GroupRoom> GetGroupRooms();
        bool UpdateGroupRoom(string name, bool whiteboard, bool monitor);
        bool HasGroupRooms();
    }
}
