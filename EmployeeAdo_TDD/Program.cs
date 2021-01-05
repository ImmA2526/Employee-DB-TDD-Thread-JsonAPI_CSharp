using System;
using System.Collections.Generic;
namespace EmployeePayrol_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************Welcome To EmployeeDataBase************");
            EmployeeRepo Repo = new EmployeeRepo();
            EmployeeModel Model = new EmployeeModel();
            //Repo.GetAllEmployee();
            Repo.UpdateSalary(Model);
            
            List<EmployeeModel> modelList = new List<EmployeeModel>();
            modelList.Add(new EmployeeModel() { Id = 1, name = "Imran", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 2, name = "shaikh", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 4, name = "nijam", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 3, name = "sayaad", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 5, name = "amit", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 8, name = "tambe", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 7, name = "amol", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 9, name = "prajaapti", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 10, name = "wankhede", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 11, name = "suraj", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 12, name = "Dhiraj", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 14, name = "siraj", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'M', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });
            modelList.Add(new EmployeeModel() { Id = 15, name = "simran", basic_pay = 450000, start_Date = new DateTime(2020, 01, 04), gender = 'F', phoneNumber = "2345676655", department = "HR", address = "Pune", deduction = 4000, taxable = 4500, netpay = 5600, income_tax = 546.00 });

            EmployeePayrollOperation employeePayroll = new EmployeePayrollOperation();
            DateTime startTime = DateTime.Now;
            employeePayroll.AddEmployeeToPayroll(modelList);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Duration for Insertion Without Thread is : "+ (endTime - startTime));

            DateTime startTimeWithThread = DateTime.Now;
            employeePayroll.AddEmployee_WithThread(modelList);
            DateTime endTimeWithThread = DateTime.Now;
            Console.WriteLine("Duration with thread = " + (startTimeWithThread - endTimeWithThread));
        }
    }
}
