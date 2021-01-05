using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrol_DB
{
    public class EmployeePayrollOperation
    {
        public List<EmployeeModel> modelList = new List<EmployeeModel>();
        EmployeeRepo payrollRepo = new EmployeeRepo();

        /// <summary>
        /// Adds the employee to payroll.
        /// </summary>
        /// <param name="employeelist">The employeelist.</param>
        public void AddEmployeeToPayroll(List<EmployeeModel> employeelist)
        {
            employeelist.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added = " + employeeData.name);
                this.AddEmployeeToPayroll(employeeData);
                Console.WriteLine("Employee added =" + employeeData.name);
            });
            Console.WriteLine(this.modelList.ToString());
        }

        /// <summary>
        /// Adds the employee to payroll.
        /// </summary>
        /// <param name="employeeData">The employee data.</param>
        public void AddEmployeeToPayroll(EmployeeModel employeeData)
        {
            modelList.Add(employeeData);

        }
    }
}