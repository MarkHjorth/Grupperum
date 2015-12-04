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



        public Mail(List<RequestMatch> reqList, List<int> failList)
        {
            PrintRent(reqList, failList);
        }

        public void PrintRent(List<RequestMatch> reqList, List<int> failList)
        {
            int length = reqList.Count();

            for (int i = 0; i < length; i++)
            {
                string print = string.Format("Mail sedt til GruppeID {0}. " +
                "Gruppen har fået lokaleID {1}", reqList[i].GroupId, reqList[i].ClassroomId);
                Console.WriteLine(print);
            }

            length = failList.Count();

            for (int i = 0; i < length; i++)
            {
                string print = string.Format("Mail sedt til GruppeID {0}. " +
                "Gruppen fik desværre ikke et lokale.", failList[i]);
                Console.WriteLine(print);
            }

            Console.ReadKey();
        }
    }
}
