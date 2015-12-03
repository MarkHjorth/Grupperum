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
        /* Vi kigger på en request og gennemgår lokaler for at finde et match. Når vi finder et match 
        opretter vi et nyt objekt med gruppeid og klasseid og lægger på en liste matchedRequests. 
        Konkret: 
        int i sættes til 0. Hvis listen af stillNotfulfilled er længere end 0 OG  listen af lokaler er 
        større end 0 så undersøg for requestCode = requestMatch.
        (Finder kun == og ikke de lokaler som er større som matcher, da det ikke er alle lokaler med en større 
        kode, der vil matche) Findes et match så dannes det ny objekt og lægges på en liste og lokalets
        requestMatch nedskrives, size nedskrives og groupcount tælles op. Hvis GroupCount er >= 3 fjernes 
        dette lokale fra lokalelisten. (Oprindelig var kravet at der ikke måtte være flere end 3 grupper 
        eller flere end 18 mennesker i et klasselokale, men da vi har sat max på gruppestørrelser til 7 (en 
        dropdown) vil det ikke være relevant at tælle på antal personer. Til sidst sættes i til 0 så alle lokaler 
        igen køres igennem. Hvis der ikke fandtes match så i++ så næste lokale tjekkes.
        */
        public void doTheFunkyAlgorythm(List<RequestClassroom> stillNotFulfilled, List<ClassRoom> lessThanThree)
        {
            List<RequestMatch> matchedRequests = new List<RequestMatch>();
            int i = 0;
            while (lessThanThree.Count > 0 && stillNotFulfilled.Count > 0)
            {
                if (stillNotFulfilled[0].RequestCode == lessThanThree[i].RequestMatch)
                {
                    RequestMatch requestMatch = new RequestMatch(stillNotFulfilled[0].GroupId, lessThanThree[i].Id);
                    matchedRequests.Add(requestMatch);
                    lessThanThree[i].RequestMatch -= stillNotFulfilled[0].RequestCode;
                    lessThanThree[i].Size -= stillNotFulfilled[0].GroupSize;
                    stillNotFulfilled.Remove(stillNotFulfilled[0]);
                    lessThanThree[i].GroupCount++;
                    if (lessThanThree[i].GroupCount >= 3 || lessThanThree[i].Size )
                    {
                        lessThanThree.Remove(lessThanThree[i];
                    }
                    i = 0;
                }
                else i++;
            }
        }
    } //Slut på klasse
} // Slut på namespace
