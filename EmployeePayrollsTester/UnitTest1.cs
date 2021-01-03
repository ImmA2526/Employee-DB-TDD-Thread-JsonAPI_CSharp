using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrol_DB;
namespace EmployeePayrollsTester
{
    /// <summary>
    /// Uc 1 Check Connection
    /// </summary>
    
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

        /// <summary>
        /// Uc 2 Retrive Record
        /// </summary>
        [TestMethod]
        public void RetriveData_whenQueryGiven()
        {
            EmployeeRepo retrive = new EmployeeRepo();
            int retrives = retrive.GetAllEmployee();
            int result = 12;
            Assert.AreEqual(retrives, result);
        }
    }


}
