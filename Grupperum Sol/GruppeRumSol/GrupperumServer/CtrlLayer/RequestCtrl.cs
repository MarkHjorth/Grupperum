using GrupperumServer.DBConFold;
using GrupperumServer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer.CtrlLayer
{
    // requestCtrl sammenligner lister af objekterne RequestClassroom og ClassRoom. (De dannes i 
    // modellaget og som lister på DBCtrl ved navn stillNotFulfilled og LessThanThree)
    public class RequestCtrl
    {
        public List<RequestClassroom> stillNotFulfilled { get; set; }
        public List<ClassRoom> lessThanThree { get; set; }
        DBCtrl dBCtrl = new DBCtrl();


        public RequestCtrl()
        {
            RequestClassroom requestClassroom;
            stillNotFulfilled = new List<RequestClassroom>();
            ClassRoom classRoom;
            List<ClassRoom> lessThanThree = new List<ClassRoom>();
        }
        // Det er denne metode der skal kaldes når man vil have fat i listen af requestClassrooms som også er sorteret.
        public List<RequestClassroom> GetAllRequests()
        {
            stillNotFulfilled = dBCtrl.GetAllRequests();
            stillNotFulfilled = sortRequestList(stillNotFulfilled);
            return stillNotFulfilled;
        }
            
        // List<> har en metode OrderByDescending som bruger en lambda til at sortere på en 
        //enkelt attribut, med højeste først.
        public List<RequestClassroom> sortRequestList(List<RequestClassroom> stillNotFulfilled)
        {           
            return stillNotFulfilled.OrderByDescending(x => x.RequestCode).ToList();               
        }

        // List<> har metoden OrderBy som sorterer listen på en enkelt 
        //attribut med mindste først.
        public List<ClassRoom> sortClassroomList(List<ClassRoom> lessThanThree)
        {
            return lessThanThree.OrderBy(x => x.RequestMatch).ToList();
        }

        public void doTheFunkyAlgorythm(List<RequestClassroom> stillNotFulfilled, List<ClassRoom> lessThanThree)
        {
            List<>
            bool STOP = false;
            while (stillNotFulfilled.Count > 0 && !STOP)
            {
                while (lessThanThree.Count > 0)
                {
                    int i = 0;
                    if (stillNotFulfilled[0].RequestCode == lessThanThree[i].RequestMatch)
                    {
                    
                    
                    }
                }
        }
        /*
        public void doTheFunkyAlgorythm(RequestClassroom requestClassroom, List<RequestClassroom> stillNotFulfilled, List<ClassRoom> lessThanThree)
        {
            foreach (RequestClassroom rc in stillNotFulfilled)
            {
                if (rc.RequestCode == 7)
                {
                    //kald metode                       
                }
            }

        }*/
        /*public void CycleLessThanThree()
        {
            foreach (ClassRoom c in lessThanThree)
            {
                for (int y = 0; y <= 7; y++)
                {
                    if (c.RequestMatch == y)
                    {
                        rc.ClassroomName = c.Name;
                        stillNotFulfilled.Remove(rc);
                        c.SpaceLeft -= rc.GroupSize;
                        c.RequestMatch -= rc.RequestCode;
                        c.GroupCount++;
                        y = 10;
                    }
                }
            }
        }*/
    } //Slut på klasse
} // Slut på namespace
