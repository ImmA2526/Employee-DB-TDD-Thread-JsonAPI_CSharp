using System;

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
        }
    }
}
