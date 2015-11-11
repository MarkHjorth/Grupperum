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
        DBCon dbc = new DBCon();
        public DBCtrl()
        {

        }

        public Class GetClassFromId(int id)
        {
            SqlDataReader rs = dbc.ExecuteString("SELECT * FROM [Class] WHERE ID = " + id);

            int tempId = 0;
            string tempName = null;
            while(rs.HasRows)
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

            SqlDataReader rs = dbc.ExecuteString("SELECT * FROM student WHERE ClassID = " + id);

            while (rs.HasRows)
            {
                tempId = (int) rs.GetValue(i);
                i++;
                tempName = (string) rs.GetValue(i);
                i++;
                Student tempStudent = new Student(tempId, tempName);
                tempList.Add(tempStudent);
            }
            
            return tempList;

        public DBCon dbCon = new DBCon();
        public void CreateGroupRoom()
        {
            String command = ("insert into GroupRoom default values;");
            dbCon.ExecuteString(command);
        }
    }
}
