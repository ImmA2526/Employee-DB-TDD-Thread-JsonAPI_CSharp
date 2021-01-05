using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrol_DB;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePayrollsTester
{
    [TestClass]
    public class EmployeeMultithreading
    {
        /// <summary>
        /// UC 1 Multithreding
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            List<EmployeeModel> modelList = new List<EmployeeModel>();
            modelList.Add(new EmployeeModel() { Id = 1, name = "Imran", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable =4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 2, name = "shaikh", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable =4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 4, name = "nijam", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable =4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 3, name = "sayaad", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable =4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 5, name = "amit", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable =4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 8, name = "tambe", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable =4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 7, name = "amol", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable =4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 9, name = "prajaapti", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable =4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 10, name = "wankhede", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable =4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 11, name = "suraj", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable =4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 12, name = "Dhiraj", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable =4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 14, name = "siraj", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 15, name = "simran", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'F', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });

            EmployeePayrollOperation employeePayroll = new EmployeePayrollOperation();
            DateTime startTime = DateTime.Now;
            employeePayroll.AddEmployeeToPayroll(modelList);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Duration without thread = " + (endTime - startTime));
            EmployeeRepo payrollRepo = new EmployeeRepo();
            EmployeeModel employeeModel = new EmployeeModel
            {
                Id = 15,
                name = "Simran",
                basic_pay = 850000,
                start_Date = new DateTime(2020, 01, 04),
                gender = 'M',
                phoneNumber = "0045676655",
                department = "Finance",
                address = "Pune",
                deduction = 4500,
                taxable =8500,
                netpay = 5760,
                income_tax = 12000.00
            };
            DateTime startTimes = DateTime.Now;
            payrollRepo.AddRecord(employeeModel);
            DateTime endTimes = DateTime.Now;
            Console.WriteLine("Duration without thread = " + (endTimes - startTimes));

            ///UC 2 with Thread
            DateTime startTimeWithThread = DateTime.Now;
            employeePayroll.AddEmployee_WithThread(modelList);
            DateTime endTimeWithThread = DateTime.Now;
            Console.WriteLine("Duration with thread = " + (startTimeWithThread - endTimeWithThread));
        }
    }
}

