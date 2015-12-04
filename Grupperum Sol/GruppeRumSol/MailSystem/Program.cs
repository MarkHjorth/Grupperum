using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupperumServer.ModelLayer;

namespace MailSystem
{
    class Mail
    {

        public Mail(List<RequestMatch> reqList)
        {
            PrintRent(reqList);
        }

        public void PrintRent(List<RequestMatch> reqList)
        {
            int length = reqList.Count();

            for (int i = 0; i < length; i++)
            {
                string print = string.Format("Mail sedt til {0}. " +
                "Gruppen har fået lokale {1}", reqList[i].GroupId, reqList[i].ClassroomId);
                Console.WriteLine(print);
            }
            Console.ReadKey();
        }
    }
}
