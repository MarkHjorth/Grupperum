using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GrupperumServer;
using GrupperumServer.DBConFold;

namespace WcfGrumService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class GrumService : IGrumService
    {
        private static IGrumServer grumServer = new GrumServer();
        private static DBCon dbCon = new DBCon();

        public void CreateGroupRoom()
        {
            dbCon.connect();
        }

        public string SayHello()
        {
            return grumServer.SayHello();
        }
    }
}
