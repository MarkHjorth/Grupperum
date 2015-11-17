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

        public Class GetClassFromStudentId(int id)
        {
            SqlDataReader rs = dbCon.ExecuteStringGet("SELECT * FROM Class where id=(SELECT classId FROM Student where id=" + id + ");");

            int tempId = 0;
            string tempName = null;
            while(rs.NextResult())
            {
                tempId = rs.GetInt32(0);
                tempName = rs.GetString(1);
            }
            Class tempClass = new Class(tempId, tempName);
                
            return tempClass;
         }

        public List<Student> GetStudentsFromClassId(int id)
        {
            int i = 0;
            int tempId = 0;
            string tempName = null;
            List<Student> tempList = new List<Student>();

            SqlDataReader rs = dbCon.ExecuteStringGet("SELECT * FROM student WHERE ClassID = " + id);

            while (rs.HasRows)
            {
                tempId = (int)rs.GetValue(i);
                i++;
                tempName = (string)rs.GetValue(i);
                i++;
                Student tempStudent = new Student(tempId, tempName);
                tempList.Add(tempStudent);
            }

            return tempList;
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
    }
}
