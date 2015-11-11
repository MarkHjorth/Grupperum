using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.DBConFold
{

    public class DBCon
    {
        SqlConnection con;
        string conString = "user id=dmaa0914_3Sem_2_Grupperum;" +
                                   "password=IsAllowed;server=kraka.ucn.dk;" +
                                   "database=dmaa0914_3Sem_2_Grupperum; " +
                                   "connection timeout=30";

        public SqlDataReader ExecuteString(string command)
        {
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            SqlCommand sc = new SqlCommand(command);
            SqlDataReader resultSet = sc.ExecuteReader();

            con.Close();
            return resultSet;
        }
    }
}
