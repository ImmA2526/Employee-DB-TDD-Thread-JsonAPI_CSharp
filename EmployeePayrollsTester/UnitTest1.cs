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

        /// <summary>
        /// UC 3 Update Salary
        /// </summary>
        [TestMethod]
        public void UpdateSalary_WhenQueryisGiven()
        {
            decimal Result = 300000;
            EmployeeRepo Check = new EmployeeRepo();
            EmployeeModel Model = new EmployeeModel()
            {
                name = "bob",
                basic_pay = 300000
            };
            decimal salary = Check.UpdateSalary(Model);
            Assert.AreEqual(Result, salary);
        }
    }
}