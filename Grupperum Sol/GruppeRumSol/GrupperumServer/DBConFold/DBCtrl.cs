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
        public DBCon dbCon = new DBCon();

        public DBCtrl()
        {

        }

        public bool ClearRents()
        {
            string sqlCmd = "DELETE FROM Rent WHERE ClassRoomId != null";
            return dbCon.ExecuteStringPut(sqlCmd);
        }

        public Student GetStudentById(int id)
        {
            SqlDataReader rs = dbCon.ExecuteStringGet("SELECT * FROM Student where id=" + id + ");");
            
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

            Student tempStudent = new Student(tempId, tempName, tempPassword);

            return tempStudent;
        }

        public Class GetClassFromStudentId(int id)
        {
            SqlDataReader rs = dbCon.ExecuteStringGet("SELECT * FROM Class where id=(SELECT classId FROM Student where id=" + id + ");");

            int tempId = 0;
            string tempName = null;
            if(rs.HasRows)
            {
                while (rs.Read())
                {
                    tempId = (int)rs.GetValue(0);
                    tempName = rs.GetString(1);
                }
            }
            
            Class tempClass = new Class(tempId, tempName);
                
            return tempClass;
         }

        public List<Student> GetStudentsFromClassId(int id)
        {
            int tempId = 0;
            string tempName = null;
            List<Student> tempList = new List<Student>();

            SqlDataReader rs = dbCon.ExecuteStringGet("SELECT * FROM student WHERE ClassID = " + id);

            if(rs.HasRows)
            {
                while (rs.Read())
                {
                    tempId = (int)rs.GetValue(0);
                    tempName = (string)rs.GetValue(2);
                    Student tempStudent = new Student(tempId, tempName);
                    tempList.Add(tempStudent);
                }
            }

            return tempList;
        }

        public bool RentGroupRoom(int grouproomId, int groupId, DateTime dateStart, DateTime dateEnd)
        {
            bool isRented = false;

            string sqlCmd = string.Format(
                "INSERT INTO Rent(GroupRoomID, GroupID, StartDate, EndDate) " +
                "OUTPUT INSERTED.id " +
                "VALUES('{0}', '{1}', '{2}', '{3}');", grouproomId, groupId, dateStart, dateEnd);

            SqlDataReader rs = dbCon.ExecuteStringGet(sqlCmd);

            while (rs.Read())
            {
                if (rs.GetValue(0) != null)
                {
                    isRented = true;
                }
            }

            return isRented;
        }

        public bool RentClassRoom(int classRoomId, int groupId, DateTime startDate, DateTime endDate)
        {
            bool rentCreated = false;

            string sqlCmd = string.Format(
                "INSERT INTO Rent(ClassRoomID, GroupID, StartDate, EndDate) " +
                "OUTPUT INSERTED.id " +
                "VALUES('{0}', '{1}', '{2}', '{3}');", classRoomId, groupId, startDate, endDate);

            SqlDataReader rs = dbCon.ExecuteStringGet(sqlCmd);

            while (rs.Read())
            {
                if (rs.GetValue(0) != null)
                {
                    rentCreated = true;
                }
            }
            return rentCreated;

        }

        public bool CanTheyRent(int groupId, DateTime dateStart, DateTime dateEnd)
        {
            bool canTheyRent = true;
            string sqlCmd = string.Format(
                "SELECT GroupID FROM Rent " +
                "WHERE(StartDate BETWEEN '{1}' AND '{2}' " +
                "OR EndDate BETWEEN '{1}' AND '{2}' " +
                "AND GroupId = '{0}');", groupId, dateStart, dateEnd);

            SqlDataReader rs = dbCon.ExecuteStringGet(sqlCmd);

            while (rs.Read())
            {
                if (rs.GetInt32(0) == groupId)
                {
                    canTheyRent = false;
                }
            }

            return canTheyRent;
        }

        public bool TestGroupRoom(int grouproomId, DateTime dateStart, DateTime dateEnd)
        {
            bool isAvailable = false;
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

            SqlDataReader rs = dbCon.ExecuteStringGet(sqlCmd);

            while (rs.Read())
            {
                if(rs.GetInt32(0) == grouproomId)
                {
                    isAvailable = true;
                }
            }

            return isAvailable;
        }

        public List<GroupRoom> GetGroupRoomList(DateTime dateStart, DateTime dateEnd, int grStrl, bool whiteboard, bool monitor)
        {
            List<GroupRoom> roomList = new List<GroupRoom>();

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

            SqlDataReader rs = dbCon.ExecuteStringGet(sqlCmd);

            while(rs.Read())
            {
                roomList.Add(new GroupRoom(rs.GetInt32(0), rs.GetString(1), rs.GetBoolean(2), rs.GetBoolean(3)));
            }

            return roomList;
        }

        internal bool UpdateGroupRoom(string name, bool whiteboard, bool monitor)
        {
            int whiteboardBit = 0;
            int monitorBit = 0;

            if(whiteboard)
            {
                whiteboardBit = 1;
            }
            if(monitor)
            {
                monitorBit = 1;
            }

            string sqlCommand = string.Format("UPDATE GroupRoom SET whiteboard={0}, monitor={1} WHERE name='{2}'", whiteboardBit, monitorBit, name);
            return dbCon.ExecuteStringPut(sqlCommand);
        }

        public List<GroupRoom> GetGroupRooms()
        {
            List<GroupRoom> groupRooms = new List<GroupRoom>();

            string sqlCommand = "SELECT * FROM [GroupRoom]";
            SqlDataReader rs = dbCon.ExecuteStringGet(sqlCommand);

            while(rs.Read())
            {
                bool whiteboard = (bool)rs.GetValue(2);
                bool monitor = (bool)rs.GetValue(2);
                
                GroupRoom room = new GroupRoom(rs.GetInt32(0), rs.GetString(1), whiteboard, monitor);
                groupRooms.Add(room);
            }

            return groupRooms;
        }

        public bool CreateGroup(string name, List<int> studentId)
        {
            int groupId = 0;
            int groupSize = studentId.Count();
            bool done = false;
            SqlDataReader rs = dbCon.ExecuteStringGet("INSERT INTO [Group] (name, size) OUTPUT Inserted.id VALUES('" + name + "', '" + groupSize + "');");

            while (rs.Read())
            {
                groupId = (int)rs.GetValue(0);
                done = true;
            }

            foreach (int id in studentId)
            {
                done = dbCon.ExecuteStringPut("UPDATE Student SET groupId = " + groupId + " WHERE id = " + id + ";");
            }

            return done;
        }

        public bool CreateGroupRoom(string name, bool whiteboard, bool monitor)
        {
            string bitWhiteboard = "0";
            string bitMonitor = "0";

            if(whiteboard)
            {
                bitWhiteboard = "1";
            }
            if(monitor)
            {
                bitMonitor = "1";
            }

            String command = string.Format(
                "insert into GroupRoom (name, whiteboard, monitor) VALUES ('{0}', {1}, {2});", 
                name, bitWhiteboard, bitMonitor);
            return dbCon.ExecuteStringPut(command);
        }
        public List<ClassRoom> GetClassRoomByAttributes(bool whiteboard, bool monitor, bool projector)
        {
            String exString = ("SELECT id FROM ClassRoom WHERE(1=1");
            if(whiteboard)
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

            SqlDataReader rs = dbCon.ExecuteStringGet(exString);

            int classRoomId;
            List<ClassRoom> classRoomList = new List<ClassRoom>();
            while (rs.Read())
            {
                classRoomId = (int)rs.GetValue(0);
                ClassRoom tempClassRoom = new ClassRoom(classRoomId);

                classRoomList.Add(tempClassRoom);
            }
            return classRoomList;
        }

        public bool RequestClassRoom(int groupId, int groupSize, bool whiteboard, bool monitor, bool projector)
        {
            int whiteboardInt = 0, monitorInt = 0, projectorInt = 0;

            if(whiteboard)
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
            return dbCon.ExecuteStringPut(exString);
        }

        //takes boolbits from DB and creates a binary code to int... Denne metode skal bruges når DB-table 
        // over classRoomWaitingList skal omskrives til objekter. Objektet skal dannes som et 
        //  RequestClassroom med denne property requestCode.
        public List<RequestClassroom> GetAllRequests()
        {
            SqlDataReader rs = dbCon.ExecuteStringGet("SELECT * FROM ClassRoomWaitinglist");

            int tempId = 0;
            int tempGroupId = 0;
            int tempSize = 0;
            int requestCode = 0;
            bool bitWhiteboard = false;
            bool bitMonitor = false;
            bool bitProjector = false;
            List<RequestClassroom> stillNotFulfilled = new List<RequestClassroom>();

            if (rs.HasRows)
            {
                while (rs.Read())
                {
                    tempId = (int) rs.GetValue(0);
                    tempGroupId = (int) rs.GetValue(1);
                    tempSize = (int) rs.GetValue(2);
                    bitWhiteboard = (bool) rs.GetValue(3);
                    bitMonitor = (bool)rs.GetValue(4);
                    bitProjector = (bool)rs.GetValue(5);

                    requestCode = CreateBinaryCode(bitWhiteboard, bitMonitor, bitProjector);

                    RequestClassroom requestClassroom = new RequestClassroom(tempGroupId, tempSize, requestCode);
                    stillNotFulfilled.Add(requestClassroom);                   
                }
            }
            return stillNotFulfilled;
        }
      
        public int CreateBinaryCode(bool whiteboard, bool monitor, bool projector)
        {
            int requestCode = 0;

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
            return requestCode;
    
        }
        // Her laves liste LessThanThree med klasselokaler hentet fra DB. Denne liste bruges til 
        // algoritmesammenligningen. LessThanThree refererer til at objekterne kun skal blive på
        // listen så længe groupCount er under 3.       
        public List<ClassRoom> LessThanThree()
        {
            SqlDataReader rs = dbCon.ExecuteStringGet("SELECT * FROM ClassRoom");

            int tempId = 0;
            string tempName = null;
            int tempSize = 0;
            bool bitWhiteboard = false;
            bool bitMonitor = false;
            bool bitProjector = false;
            int requestMatch = 0;
            int groupCount = 0;
            int spaceLeft = 0;
            List<ClassRoom> LessThanThree = new List<ClassRoom>();

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
            return LessThanThree;
        }

        public bool HasGroupRooms()
        {
            string dbCommand = "SELECT GroupRoom.id FROM GroupRoom LEFT JOIN Rent ON GroupRoom.id = Rent.GroupRoomId WHERE Rent.GroupRoomId IS NULL";
            SqlDataReader rs = dbCon.ExecuteStringGet(dbCommand);
            
            while(rs.Read())
            {
                if(rs.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
