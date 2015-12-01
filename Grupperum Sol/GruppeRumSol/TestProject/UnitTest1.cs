using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GrupperumServer.CtrlLayer;
using TestData.TestContainer;
using GrupperumServer.ModelLayer;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        TestContainer tc = new TestContainer();
        RequestCtrl reqCtrl = new RequestCtrl();

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

        // Undersøger om Requestkoderne er sorteret efter højest først i listen requests[]. 
        //Dvs at den requestkode vi undersøger på er mindre end den vi lige havde.
        [TestMethod]
        public void AreListsSorted()
        {
            System.Diagnostics.Debug.WriteLine(tc.requests[0].RequestCode);
            tc.requests = reqCtrl.sortRequestList(tc.requests);
            bool isSorted = true;
            int i = tc.requests[0].RequestCode;
            int index = 0;
            int length = tc.requests.Count;
            while (index < length && isSorted == true)
            {
                if (tc.requests[index].RequestCode < i)
                {
                    i = tc.requests[index].RequestCode;                   
                }

                if(tc.requests[index].RequestCode > i)
                {
                    isSorted = false;              
                }
                index++;
            }

            Assert.IsTrue(isSorted);
        }
       

        //var classList = Unittest.Testmodel.GetClassRoomList();
        // var grouproomList = Unittest.TestmodelGetGroupRoomList();
        // ControlLayer.GrooupRoomControler ctlr = new ControlLayer.GrooupRoomControler(new TestContainer());

        // ctlr.Add()..
    }
}
