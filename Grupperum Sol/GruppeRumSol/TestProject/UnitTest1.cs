using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using controllayer;
using unittest.Testmodel;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var classList = Unittest.Testmodel.GetClassRoomList();
            // var grouproomList = Unittest.TestmodelGetGroupRoomList();
            // ControlLayer.GrooupRoomControler ctlr = new ControlLayer.GrooupRoomControler(new TestContainer());

            // ctlr.Add()..

            Assert.AreEqual<int>(classList.First().Groups.Count, 5);
        }
    }
}
