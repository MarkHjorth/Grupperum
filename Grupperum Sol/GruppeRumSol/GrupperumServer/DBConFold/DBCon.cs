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
        string conString = "user id=dmaa0914_3Sem_2_Grupperum;" +
                                   "password=IsAllowed;server=kraka.ucn.dk;" +
                                   "database=dmaa0914_3Sem_2_Grupperum; " +
                                   "connection timeout=30";

        public SqlDataReader ExecuteStringGet(string command)
        {
            SqlDataReader resultSet = null;
            SqlConnection con = new SqlConnection(conString);

            con.Open();
            
            SqlCommand sc = new SqlCommand(command, con);
            try
            {
                resultSet = sc.ExecuteReader();
            }
            catch (SqlException e)
            {
                
            }
            finally
            {
                con.Close();
            }
            
            return resultSet;
        }

        public bool ExecuteStringPut(string command)
        {
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            SqlCommand sc = new SqlCommand(command, con);
            try
            {
                sc.ExecuteReader();
            }
            catch (SqlException e)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }
    }
}
