using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.DBConFold
{
    public class DBCtrl
    {
        public DBCon dbCon = new DBCon();
        public void CreateGroupRoom()
        {
            String command = ("insert into GroupRoom default values;");
            dbCon.ExecuteString(command);
        }
    }
}
