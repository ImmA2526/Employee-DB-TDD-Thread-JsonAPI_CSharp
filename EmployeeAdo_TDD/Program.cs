using System;

namespace EmployeePayrol_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************Welcome To EmployeeDataBase************");
            EmployeeRepo Repo = new EmployeeRepo();
            //Repo.GetAllEmployee();
            EmployeeModel Add = new EmployeeModel();
            Add.Id=131;
            Add.name = "Pratibha";
            Add.basic_pay = 405040;
            Add.start_Date=new DateTime(2011,05,02);
            Add.gender = 'F';
            Add.phoneNumber = "9734560009";
            Add.department = "ITI";
            Add.address = "Mumbai";
            Add.deduction = 4500.00;
            Add.taxable = 45678;
            Add.netpay = 420000;
            Add.income_tax = 6577;
            //Repo.AggregateOperations();
            //Repo.GetPerticularEmployeeData();
            //Repo.AddRecord(Add);
            Console.WriteLine(".....Inserted Record......");
            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", Add.Id, Add.name, Add.basic_pay, Add.start_Date, Add.gender, Add.phoneNumber, Add.department, Add.address, Add.deduction, Add.taxable, Add.netpay, Add.income_tax);
        
        }
    }
}
