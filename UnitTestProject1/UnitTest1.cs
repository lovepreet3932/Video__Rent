using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Video_Rent;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Database_Class db = new Database_Class();
        [TestMethod]
        public void TestMethod()  // test connection is open or  close 
        {

            {
                string nameDB =db.Checkdb(); /// expected value for database connection
                Assert.AreEqual(nameDB, "Closed"); // actual value for database connection 
            }
        }
    }
}
