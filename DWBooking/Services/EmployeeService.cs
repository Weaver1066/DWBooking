using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;

namespace DWBooking.Services
{
    public class EmployeeService
    {
        public List<Employee> Employees { get; set; }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return Employees;
        }
        // Returnere listen af employees

        public Employee GetEmployee(int employeeId)
        {
            foreach (Employee employee in Employees)
            {
                if (employee.EmployeeID == employeeId) return employee;
            }

            return null;
        }


    }
}
