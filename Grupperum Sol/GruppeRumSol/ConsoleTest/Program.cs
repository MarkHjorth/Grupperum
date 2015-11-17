using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupperumServer;
using GrupperumServer.CtrlLayer;
using GrupperumServer.DBConFold;
using GrupperumServer.ModelLayer;
using System.Data.SqlClient;


namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp;
            string tempstr;
            ClassCtrl classCtrl = new ClassCtrl();
            DBCtrl dbCtrl = new DBCtrl();
            DBCon dbCon = new DBCon();

            int id = 1;

            SqlDataReader rs = dbCon.ExecuteStringGet("SELECT * FROM Class where id=(SELECT classId FROM Student where id=" + id + ");");
            bool tempb = rs.();
            Console.WriteLine(tempb);
            Console.WriteLine(rs.GetInt32(0));
            
            //for (int i = 0; i<10; i++)
            //    {

            //       temp = dbCtrl.GetClassFromStudentId(i).Id;
            //       Console.WriteLine(temp);
            //    }
       
            //    for (int i = 0; i<10; i++)
            //    {
            //        temp = classCtrl.GetClassByStudentId(i).Id;
            //    }

        }
    }
}
