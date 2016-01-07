using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GrupperumServer.CtrlLayer;
using TestData.TestContainer;
using GrupperumServer.ModelLayer;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        TestContainer tc = new TestContainer();
        RequestCtrl reqCtrl = new RequestCtrl();
        ClassRoomCtrl classRoomCtrl = new ClassRoomCtrl();
        List<RequestClassroom> requests = new List<RequestClassroom>();
        List<ClassRoom> classRooms = new List<ClassRoom>();

        [TestMethod]
        public void DoesTestContainerExist()
        {
            Assert.IsNotNull(tc);
        }

        [TestMethod]
        public void IsClassRoomsCreated()
        {
            Assert.AreEqual<int>(tc.classRooms.Count, 50);
        }

        [TestMethod]
        public void IsGroupsCreated()
        {
            Assert.AreEqual<int>(tc.groups.Count, 100);
        }

        [TestMethod]
        public void IsRequestsCreated()
        {
            Assert.AreEqual<int>(tc.requests.Count, 100);
        }

        //Test at lokaler modeleres korrekt til algoritmen
        [TestMethod]
        public void CheckClassRoomValues()
        {
            List<ClassRoom> zero = new List<ClassRoom>();
            List<ClassRoom> one = new List<ClassRoom>();
            List<ClassRoom> two = new List<ClassRoom>();
            List<ClassRoom> three = new List<ClassRoom>();
            List<ClassRoom> four = new List<ClassRoom>();
            List<ClassRoom> five = new List<ClassRoom>();
            List<ClassRoom> six = new List<ClassRoom>();
            List<ClassRoom> seven = new List<ClassRoom>();
            
            foreach (ClassRoom c in tc.FetchClassRooms())
            {
                switch (c.RequestMatch)
                {
                    case 0:
                        zero.Add(c);
                        break;
                    case 1:
                        one.Add(c);
                        break;
                    case 2:
                        two.Add(c);
                        break;
                    case 3:
                        three.Add(c);
                        break;
                    case 4:
                        four.Add(c);
                        break;
                    case 5:
                        five.Add(c);
                        break;
                    case 6:
                        six.Add(c);
                        break;
                    case 7:
                        seven.Add(c);
                        break;
                    default:
                        break;
                }
            }

            Assert.AreEqual(zero.Count, 2);
            Assert.AreEqual(one.Count, 2);
            Assert.AreEqual(two.Count, 2);
            Assert.AreEqual(three.Count, 2);
            Assert.AreEqual(four.Count, 2);
            Assert.AreEqual(five.Count, 2);
            Assert.AreEqual(six.Count, 2);
            Assert.AreEqual(seven.Count, 2);
        }

        //Test at requests modeleres korrekt til algoritmen
        [TestMethod]
        public void CheckRequestValues()
        {

        }

        // Undersøger om Requestkoderne er sorteret efter højest først i listen requests[]. 
        //Dvs at den requestkode vi undersøger på er mindre end den vi lige havde.
        [TestMethod]
        public void AreListsSortedByDescending()
        {
            tc.requests = reqCtrl.sortRequestList(tc.requests);
            bool isSorted = true;
            int i = tc.requests[0].RequestCode;
            int index = 0;
            int length = tc.requests.Count;
            while (index < length && isSorted == true)
            {
                if (tc.requests[index].RequestCode <= i)
                {
                    i = tc.requests[index].RequestCode;
                }

                if (tc.requests[index].RequestCode > i)
                {
                    isSorted = false;
                }
                index++;
            }

            Assert.IsTrue(isSorted);
        }
        // Undersøger om klasselokalerne er sorteret på requestmatch efter laveste først i listen af classrooms. 
        //Dvs at den requestkode vi undersøger på er mindre end den vi lige havde.
        [TestMethod]
        public void AreListSorted()
        {
            tc.classRooms = reqCtrl.sortClassroomList(tc.classRooms);
            bool isSorted = true;
            int i = tc.classRooms[0].RequestMatch;
            int index = 0;
            int length = tc.classRooms.Count;
            while (index < length && isSorted == true)
            {
                if (tc.classRooms[index].RequestMatch >= i)
                {
                    i = tc.classRooms[index].RequestMatch;
                }
                if (tc.classRooms[index].RequestMatch < i)
                {
                    isSorted = false;
                }
                index++;
            }
            Assert.IsTrue(isSorted);
        }

// TESTS OF ACTUAL ALGORITHM:::

        //Test where there are more rooms than groups
        [TestMethod]
        public void TestAlgorithmOne()
        {
            classRooms.Clear();
            classRooms.AddRange(tc.GetClassRooms(1, 1));
            classRooms.AddRange(tc.GetClassRooms(2, 1));
            classRooms.AddRange(tc.GetClassRooms(3, 1));
            classRooms.AddRange(tc.GetClassRooms(4, 1));
            classRooms.AddRange(tc.GetClassRooms(5, 1));
            classRooms.AddRange(tc.GetClassRooms(6, 1));
            classRooms.AddRange(tc.GetClassRooms(7, 1));
            classRooms.AddRange(tc.GetClassRooms(0, 1));

            requests.Clear();
            requests.AddRange(tc.GetRequests(1, 0, 1));
            requests.AddRange(tc.GetRequests(2, 0, 1));
            requests.AddRange(tc.GetRequests(1, 0, 1));
            requests.AddRange(tc.GetRequests(3, 0, 1));
            requests.AddRange(tc.GetRequests(1, 0, 1));

            reqCtrl.doTheFunkyAlgorythm(requests, classRooms);
            Assert.IsTrue(true);
        }

        //Test where just enough rooms
        [TestMethod]
        public void TestAlgorithmTwo()
        {

        }

        //Test where all rooms are filled
        [TestMethod]
        public void TestAlgorithmThree()
        {

        }

        //Test where not enough rooms
        [TestMethod]
        public void TestAlgorithmFour()
        {

        }
    }
}
