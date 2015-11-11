using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GrupperumServer.ModelLayer;
using GrupperumServer.CtrlLayer;
using GrupperumServer.DBConFold;

namespace TestGrupperum
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetClassById()
        {

            Class clazz = new Class(1);

            ClassCtrl classCtrl = new ClassCtrl();

            Class returnClass = classCtrl.PopulateClass(clazz);

            Class exptecedClass = new Class(1);
            exptecedClass.addStudent(new Student(1, "Hans"));
            
            Assert.AreEqual<int>(returnClass.StudentList.Count, exptecedClass.StudentList.Count);
        }




    }
}
