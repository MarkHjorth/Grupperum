using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program(10);

        }

        public Program(int length)
        {
            DateTime startDate = new DateTime(2015, 12, 3);
            DateTime endDate = new DateTime(2015, 12, 3);
            PrintRent(1, 1, 1, startDate, endDate);
        }

        public void PrintRent(int length, int groupId, int classRoomId, DateTime startDate, DateTime endDate)
        {
            string print = string.Format("Mail sedt til {0}. " +
                "Gruppen har fået lokale {1} " +
                "fra d. {2} til den {3}", groupId, classRoomId, startDate, endDate);
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(print);
            }
            Console.ReadKey();
        }
    }
}
