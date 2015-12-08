using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.DBConFold
{
    public class DBCon : IDisposable
    {
        static string conString = "user id=dmaa0914_3Sem_2_Grupperum;" +
                                   "password=IsAllowed;server=kraka.ucn.dk;" +
                                   "database=dmaa0914_3Sem_2_Grupperum; " +
                                   "connection timeout=30";
        SqlConnection con = new SqlConnection(conString);

        public void Dispose()
        {
            con.Close();
        }

        public SqlDataReader ExecuteStringGet(string command)
        {
            SqlDataReader resultSet = null;

            try
            {
                con.Open();
            }
            catch (Exception e)
            {
            }

            SqlCommand sc = new SqlCommand(command, con);
            try
            {
                resultSet = sc.ExecuteReader();
            }
            catch (SqlException e)
            {
                e.ToString();
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
                return true;
            }
            catch (SqlException e)
            {
                e.ToString();
                return false;
            }
            finally
            {
               // con.Close();
            }
        }
    }
}
