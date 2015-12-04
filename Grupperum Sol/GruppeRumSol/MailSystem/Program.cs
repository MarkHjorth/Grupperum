using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class Mail
    {
        public Mail(List<int> reqListGroupId, List<int> reqListClassRoomId, List<int> failList)
        {
            PrintRent(reqListGroupId, reqListClassRoomId, failList);
        }

        public void PrintRent(List<int> reqListGroupId, List<int> reqListClassRoomId, List<int> failList)
        {
            int length = reqListGroupId.Count();

            for (int i = 0; i < length; i++)
            {
                string print = string.Format("Mail sedt til GruppeID {0}. " +
                "Gruppen har fået lokaleID {1}", reqListGroupId[i], reqListClassRoomId[i]);
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
