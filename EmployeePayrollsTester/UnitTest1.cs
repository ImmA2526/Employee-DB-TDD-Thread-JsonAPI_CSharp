using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrol_DB;
namespace EmployeePayrollsTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckDBConnection()
        {
            EmployeeRepo repo = new EmployeeRepo();
            bool Check = repo.CheckDBConnection();
            bool result = true;
            Assert.AreEqual(result, Check);
        }
    }
}
