using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrol_DB;
using System;
using System.Linq;

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
            int result = 13;
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

        /// <summary>
        /// 4 Returns the count when query given.
        /// </summary>
        [TestMethod]
        public void ReturnCount_WhenQueryGiven()
        {
            int countResult = 15;
            EmployeeRepo Check = new EmployeeRepo();
            int result = Check.RetriveParticualrRecord();
            Assert.AreEqual(countResult, result);

        }
        /// <summary>
        /// Givens the employee names when update salary then return expected sum salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenUpdateSalary_ThenReturnExpectedSumSalary()
        {
            int expected = 700000;
            EmployeeRepo emprepo = new EmployeeRepo();
            int sum = emprepo.getAggrigateSumSalary();
            Assert.AreEqual(expected, sum);
        }

        /// <summary>
        /// Givens the employee names when average salary then return expected average salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenAvgSalary_ThenReturnExpectedAvgSalary()
        {
            int expected = 341666;
            EmployeeRepo emprepo = new EmployeeRepo();
            int avg = emprepo.getAvragSalary();
            Assert.AreEqual(expected, avg);
        }

        /// <summary>
        /// Givens the employee names when minimum salary then return expected minimum salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenMinSalary_ThenReturnExpectedMinSalary()
        {
            int expected = 100000;
            EmployeeRepo emprepo = new EmployeeRepo();
            int min = emprepo.getMinSalary();
            Assert.AreEqual(expected, min);
        }

        /// <summary>
        /// Givens the employee names when maximum then return expected maximum salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenMax_ThenReturnExpectedMaxSalary()
        {
            int expected = 300000;
            EmployeeRepo emprepo = new EmployeeRepo();
            int max = emprepo.getMaxSalary();
            Assert.AreEqual(expected, max);
        }

        /// <summary>
        /// Givens the employee names when count by salary then return expected count by salary.
        /// </summary>
        [TestMethod]
        public void GivenEmployeeNames_WhenCountBySalary_ThenReturnExpectedCountBySalary()
        {
            int expected = 3;
            EmployeeRepo emprepo = new EmployeeRepo();
            int count = emprepo.getCountSalary();
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Uc 6 Add Record
        /// UC 7 Add with Salary Deduction
        /// </summary>
        [TestMethod]
        public void Add_RecordWhen_QueryGiven()
        {
            bool expected = true;
            EmployeeRepo employeePayrollRepo = new EmployeeRepo();
            EmployeeModel model = new EmployeeModel
            {
                Id = 108,
                name = "Ashsih",
                basic_pay = 450000,
                start_Date = new DateTime(2016, 07, 04),
                gender = 'M',
                phoneNumber = "3216549870",
                address = "golai",
                department = "Finance",
                deduction = 6600,
                taxable = 5500,
                netpay = 4000,
                income_tax = 5000,
            };
            bool result = employeePayrollRepo.AddRecord(model);
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Uc 11 Add Record
        /// </summary>
        [TestMethod]
        public void Delete_RecordByID()
        {
            bool expected = true;
            EmployeeRepo employeePayrollRepo = new EmployeeRepo();
            EmployeeModel model = new EmployeeModel
            {
                Id = 108,
            };
            bool result = employeePayrollRepo.DeleteEmployeeUsingID(model);
            Assert.AreEqual(expected, result);
        }
    }
}