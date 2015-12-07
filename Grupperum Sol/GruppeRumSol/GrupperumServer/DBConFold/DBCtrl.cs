using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupperumServer.ModelLayer;

namespace GrupperumServer.DBConFold
{
    public class DBCtrl
    {

        public DBCtrl()
        {
        }

        public bool ClearRents()
        {
            bool didClear = false;
            using (var con = new DBCon())
            {
                string sqlCmd = "DELETE FROM Rent WHERE ClassRoomId is not null";
                didClear = con.ExecuteStringPut(sqlCmd);
            }
            return didClear;
        }

        public Student GetStudentById(int id)
        {
            Student tempStudent = null;
            using (var con = new DBCon())
            {
                SqlDataReader rs = con.ExecuteStringGet("SELECT * FROM Student where id=" + id + ");");

                int tempId = 0;
                string tempName = null;
                string tempPassword = null;
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        tempId = (int)rs.GetValue(0);
                        tempName = rs.GetString(1);
                        tempPassword = rs.GetString(2);
                    }
                }

                tempStudent = new Student(tempId, tempName, tempPassword);
            }
            return tempStudent;
        }

        public Class GetClassFromStudentId(int id)
        {
            Class tempClass = null;
            using (var con = new DBCon())
            {
                SqlDataReader rs = con.ExecuteStringGet("SELECT * FROM Class where id=(SELECT classId FROM Student where id=" + id + ");");

                int tempId = 0;
                string tempName = null;
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        tempId = (int)rs.GetValue(0);
                        tempName = rs.GetString(1);
                    }
                }

                tempClass = new Class(tempId, tempName);

            }
            return tempClass;
         }

        public List<Student> GetStudentsFromClassId(int id)
        {
            List<Student> tempList = new List<Student>();
            using (var con = new DBCon())
            {
                int tempId = 0;
                string tempName = null;
                

                SqlDataReader rs = con.ExecuteStringGet("SELECT * FROM student WHERE ClassID = " + id);

                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        tempId = (int)rs.GetValue(0);
                        tempName = (string)rs.GetValue(2);
                        Student tempStudent = new Student(tempId, tempName);
                        tempList.Add(tempStudent);
                    }
                }
            }

            return tempList;
        }

        public bool RentGroupRoom(int grouproomId, int groupId, DateTime dateStart, DateTime dateEnd)
        {
            bool isRented = false;
            using (var con = new DBCon())
            {
                string sqlCmd = string.Format(
                    "INSERT INTO Rent(GroupRoomID, GroupID, StartDate, EndDate) " +
                    "OUTPUT INSERTED.id " +
                    "VALUES('{0}', '{1}', '{2}', '{3}');", grouproomId, groupId, dateStart, dateEnd);

                SqlDataReader rs = con.ExecuteStringGet(sqlCmd);

                while (rs.Read())
                {
                    if (rs.GetValue(0) != null)
                    {
                        isRented = true;
                    }
                }
            }
            return isRented;
        }

        public bool RentClassRoom(int classRoomId, int groupId, DateTime startDate, DateTime endDate)
        {
            bool rentCreated = false;
            using (var con = new DBCon())
            {
                string sqlCmd = string.Format(
                    "INSERT INTO Rent(ClassRoomID, GroupID, StartDate, EndDate) " +
                    "OUTPUT INSERTED.id " +
                    "VALUES('{0}', '{1}', '{2}', '{3}');", classRoomId, groupId, startDate, endDate);

                SqlDataReader rs = con.ExecuteStringGet(sqlCmd);

                while (rs.Read())
                {
                    if (rs.GetValue(0) != null)
                    {
                        rentCreated = true;
                    }
                }
            }
            return rentCreated;
        }

        public bool CanTheyRent(int groupId, DateTime dateStart, DateTime dateEnd)
        {
            bool canTheyRent = true;
            using (var con = new DBCon())
            {
                string sqlCmd = string.Format(
                    "SELECT GroupID FROM Rent " +
                    "WHERE(StartDate BETWEEN '{1}' AND '{2}' " +
                    "OR EndDate BETWEEN '{1}' AND '{2}' " +
                    "AND GroupId = '{0}');", groupId, dateStart, dateEnd);

                SqlDataReader rs = con.ExecuteStringGet(sqlCmd);

                while (rs.Read())
                {
                    if (rs.GetInt32(0) == groupId)
                    {
                        canTheyRent = false;
                    }
                }
            }
            return canTheyRent;
        }

        public bool TestGroupRoom(int grouproomId, DateTime dateStart, DateTime dateEnd)
        {
            bool isAvailable = false;
            using (var con = new DBCon())
            {
                
                List<GroupRoom> roomList = new List<GroupRoom>();
                string sqlCmd = string.Format(
                    "SELECT [GroupRoom].id FROM [GroupRoom] " +
                    "LEFT JOIN Rent ON GroupRoom.id = Rent.GroupRoomId " +
                    "WHERE(StartDate NOT BETWEEN '{0}' AND '{1}' " +
                    "AND EndDate NOT BETWEEN '{0}' AND '{1}' " +
                    "AND '{0}' NOT BETWEEN StartDate AND EndDate " +
                    "AND '{1}' NOT BETWEEN StartDate AND EndDate) " +
                    "OR Rent.GroupRoomId IS NULL " +
                    "AND[GroupRoom].id = '{2}';", dateStart, dateEnd, grouproomId);

                SqlDataReader rs = con.ExecuteStringGet(sqlCmd);

                while (rs.Read())
                {
                    if (rs.GetInt32(0) == grouproomId)
                    {
                        isAvailable = true;
                    }
                }
            }
            return isAvailable;
        }

        public List<GroupRoom> GetGroupRoomList(DateTime dateStart, DateTime dateEnd, int grStrl, bool whiteboard, bool monitor)
        {
            List<GroupRoom> roomList = new List<GroupRoom>();
            using (var con = new DBCon())
            {
                //Her kunne man have brugt en 'SELECT x FROM (SELECT y FROM...)'
                //For at lette overskuelighed
                string sqlCmd = string.Format(
                    "SELECT * FROM [GroupRoom] " +
                    "LEFT JOIN Rent ON GroupRoom.id = Rent.GroupRoomId " +
                    "WHERE ((StartDate NOT BETWEEN '{0}' AND '{1}' " +
                        "AND EndDate NOT BETWEEN '{0}' AND '{1}' " +
                        "AND '{0}' NOT BETWEEN StartDate AND EndDate " +
                        "AND '{1}' NOT BETWEEN StartDate AND EndDate) " +
                        "OR Rent.GroupRoomId IS NULL) " +
                    "AND ([GroupRoom].whiteboard = '{2}' " +
                        "OR [GroupRoom].whiteboard = '1') " +
                    "AND ([GroupRoom].monitor = '{3}' " +
                        "OR [GroupRoom].monitor = '1'); ", dateStart, dateEnd, whiteboard, monitor);

                SqlDataReader rs = con.ExecuteStringGet(sqlCmd);

                List<GroupRoom> tempList = new List<GroupRoom>();

                while (rs.Read())
                {
                    tempList.Add(new GroupRoom(rs.GetInt32(0), rs.GetString(1), rs.GetBoolean(2), rs.GetBoolean(3)));
                }

                while (tempList.Count > 0)
                {
                    roomList.Add(tempList[0]);
                    tempList.Remove(tempList[0]);
                    foreach (GroupRoom g in tempList)
                    {
                        if ((roomList.Count > 0) && (g.Id == (roomList[roomList.Count - 1].Id)))
                        {
                            roomList.Remove(roomList[roomList.Count - 1]);
                        }
                    }
                }
            }
            return roomList;
        }

        internal bool UpdateGroupRoom(string name, bool whiteboard, bool monitor)
        {
            bool didUpdate = false;
            using (var con = new DBCon())
            {
                int whiteboardBit = 0;
                int monitorBit = 0;

                if (whiteboard)
                {
                    whiteboardBit = 1;
                }
                if (monitor)
                {
                    monitorBit = 1;
                }

                string sqlCommand = string.Format("UPDATE GroupRoom SET whiteboard={0}, monitor={1} WHERE name='{2}'", whiteboardBit, monitorBit, name);
                didUpdate = con.ExecuteStringPut(sqlCommand);
            }
            return didUpdate;
        }

        public List<GroupRoom> GetGroupRooms()
        {
            List<GroupRoom> groupRooms = new List<GroupRoom>();
            using (var con = new DBCon())
            {
                string sqlCommand = "SELECT * FROM [GroupRoom]";
                SqlDataReader rs = con.ExecuteStringGet(sqlCommand);

                while (rs.Read())
                {
                    bool whiteboard = (bool)rs.GetValue(2);
                    bool monitor = (bool)rs.GetValue(2);

                    GroupRoom room = new GroupRoom(rs.GetInt32(0), rs.GetString(1), whiteboard, monitor);
                    groupRooms.Add(room);
                }
            }
            return groupRooms;
        }

        public bool CreateGroup(string name, List<int> studentId)
        {
            int groupId = 0;
            int groupSize = studentId.Count();
            bool done = false;
            using (var con = new DBCon())
            {
                SqlDataReader rs = con.ExecuteStringGet("INSERT INTO [Group] (name, size) OUTPUT Inserted.id VALUES('" + name + "', '" + groupSize + "');");

                while (rs.Read())
                {
                    groupId = (int)rs.GetValue(0);
                    done = true;
                }
            }
            using (var con = new DBCon())
            {

                foreach (int id in studentId)
                {
                    done = con.ExecuteStringPut("UPDATE Student SET groupId = " + groupId + " WHERE id = " + id + ";");
                }
            }
            return done;
        }

        public bool CreateGroupRoom(string name, bool whiteboard, bool monitor)
        {
            bool didCreate = false;
            using (var con = new DBCon())
            {
                string bitWhiteboard = "0";
                string bitMonitor = "0";

                if (whiteboard)
                {
                    bitWhiteboard = "1";
                }
                if (monitor)
                {
                    bitMonitor = "1";
                }

                String command = string.Format(
                    "insert into GroupRoom (name, whiteboard, monitor) VALUES ('{0}', {1}, {2});",
                    name, bitWhiteboard, bitMonitor);
                didCreate = con.ExecuteStringPut(command);
            }
            return didCreate;
        }
        public List<ClassRoom> GetClassRoomByAttributes(bool whiteboard, bool monitor, bool projector)
        {
            List<ClassRoom> classRoomList = new List<ClassRoom>();
            using (var con = new DBCon())
            {
                String exString = ("SELECT id FROM ClassRoom WHERE(1=1");
                if (whiteboard)
                {
                    exString = exString + " AND whiteboard = 1";
                }

                if (monitor)
                {
                    exString = exString + " AND monitor = 1";
                }

                if (projector)
                {
                    exString = exString + " AND projector = 1";
                }
                exString = exString + ");";

                SqlDataReader rs = con.ExecuteStringGet(exString);

                int classRoomId;
                while (rs.Read())
                {
                    classRoomId = (int)rs.GetValue(0);
                    ClassRoom tempClassRoom = new ClassRoom(classRoomId);

                    classRoomList.Add(tempClassRoom);
                }
            }
            return classRoomList;
        }

        public bool RequestClassRoom(int groupId, int groupSize, bool whiteboard, bool monitor, bool projector)
        {
            bool didRequest = false;
            using (var con = new DBCon())
            {
                int whiteboardInt = 0, monitorInt = 0, projectorInt = 0;

                if (whiteboard)
                {
                    whiteboardInt = 1;
                }

                if (monitor)
                {
                    monitorInt = 1;
                }

                if (projector)
                {
                    projectorInt = 1;
                }

                string exString = string.Format("INSERT INTO ClassRoomWaitingList(groupId, size, whiteboard, monitor, projector) VALUES ({0}, {1}, {2}, {3}, {4});", groupId, groupSize, whiteboardInt, monitorInt, projectorInt);
                didRequest = con.ExecuteStringPut(exString);
            }
            return didRequest;
        }

        //takes boolbits from DB and creates a binary code to int... Denne metode skal bruges når DB-table 
        // over classRoomWaitingList skal omskrives til objekter. Objektet skal dannes som et 
        //  RequestClassroom med denne property requestCode.
        public List<RequestClassroom> GetAllRequests()
        {
            List<RequestClassroom> stillNotFulfilled = new List<RequestClassroom>();
            using (var con = new DBCon())
            {
                SqlDataReader rs = con.ExecuteStringGet("SELECT * FROM ClassRoomWaitinglist");

                int tempId = 0;
                int tempGroupId = 0;
                int tempSize = 0;
                int requestCode = 0;
                bool bitWhiteboard = false;
                bool bitMonitor = false;
                bool bitProjector = false;

                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        tempId = (int)rs.GetValue(0);
                        tempGroupId = (int)rs.GetValue(1);
                        tempSize = (int)rs.GetValue(2);
                        bitWhiteboard = (bool)rs.GetValue(3);
                        bitMonitor = (bool)rs.GetValue(4);
                        bitProjector = (bool)rs.GetValue(5);

                        requestCode = CreateBinaryCode(bitWhiteboard, bitMonitor, bitProjector);

                        RequestClassroom requestClassroom = new RequestClassroom(tempGroupId, tempSize, requestCode);
                        stillNotFulfilled.Add(requestClassroom);
                    }
                }
            }
            return stillNotFulfilled;
        }
      
        public int CreateBinaryCode(bool whiteboard, bool monitor, bool projector)
        {
            int requestCode = 0;
            using (var con = new DBCon())
            {
                
                if (whiteboard)
                {
                    requestCode += 4;
                    if (monitor)
                    {
                        requestCode += 2;
                        if (projector)
                        {
                            requestCode += 1;
                        }
                    }
                }
            }
            return requestCode;
        }
        // Her laves liste LessThanThree med klasselokaler hentet fra DB. Denne liste bruges til 
        // algoritmesammenligningen. LessThanThree refererer til at objekterne kun skal blive på
        // listen så længe groupCount er under 3.       
        public List<ClassRoom> LessThanThree()
        {
            List<ClassRoom> LessThanThree = new List<ClassRoom>();
            using (var con = new DBCon())
            {
                SqlDataReader rs = con.ExecuteStringGet("SELECT * FROM ClassRoom");

                int tempId = 0;
                string tempName = null;
                int tempSize = 0;
                bool bitWhiteboard = false;
                bool bitMonitor = false;
                bool bitProjector = false;
                int requestMatch = 0;
                int groupCount = 0;
                int spaceLeft = 0;

                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        tempId = (int)rs.GetValue(0);
                        tempName = rs.GetString(1);
                        tempSize = (int)rs.GetValue(2);
                        bitWhiteboard = (bool)rs.GetValue(3);
                        bitMonitor = (bool)rs.GetValue(4);
                        bitProjector = (bool)rs.GetValue(5);

                        requestMatch = CreateBinaryCode(bitWhiteboard, bitMonitor, bitProjector);

                        ClassRoom classroom = new ClassRoom(tempId, tempSize, tempName, requestMatch, spaceLeft, groupCount);
                        LessThanThree.Add(classroom);

                    }
                }
            }
            return LessThanThree;
        }

        public bool HasGroupRooms()
        {
            bool hasRooms = false;
            using (var con = new DBCon())
            {
                string dbCommand = "SELECT GroupRoom.id FROM GroupRoom LEFT JOIN Rent ON GroupRoom.id = Rent.GroupRoomId WHERE Rent.GroupRoomId IS NULL";
                SqlDataReader rs = con.ExecuteStringGet(dbCommand);

                while (rs.Read())
                {
                    if (rs.HasRows)
                    {
                        hasRooms = true;
                    }
                    else
                    {
                        hasRooms = false;
                    }
                }
            }
            return hasRooms;
        }
    }
}
