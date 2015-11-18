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
                    tempName = (string)rs.GetValue(1);
                    Student tempStudent = new Student(tempId, tempName);
                    tempList.Add(tempStudent);
                }
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
