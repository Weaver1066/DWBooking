using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWBooking.Model;
using Microsoft.EntityFrameworkCore;

namespace DWBooking.Services
{
    public class EmployeeService
    {
        public GenericDbService<Employee> DbService;
        public List<Employee> EmployeeList { get; set; }

        public EmployeeService(GenericDbService<Employee> dbService)
        {
            DbService = dbService;
            //EmployeeList = MockData.MockEmployees.GetMockEmployees();
            //foreach (Employee e in EmployeeList)
            //{
            //    DbService.AddObjectAsync(e);
            //}
            EmployeeList = DbService.GetObjectsAsync().Result.ToList();
        }

        /// <summary>
        /// Add a new employee to the database and to the Employee list.
        /// </summary>
        /// <param name="employee"></param>
        public async void AddEmployee(Employee employee)
        {
            EmployeeList.Add(employee);
            await DbService.AddObjectAsync(employee);
        }
        /// <summary>
        /// Gets the entire list of Employees and returns it.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployees()
        {
            return EmployeeList;
        }
        // Returnere listen af employees

        /// <summary>
        /// Finds a specific Employee using the Employee Id to go through
        /// all the employees until it finds a matching ID and returns it.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public Employee GetEmployee(int employeeId)
        {
            foreach (Employee employee in EmployeeList)
            {
                if (employee.EmployeeID == employeeId) return employee;

            }

            return null;
        }

        /// <summary>
        /// Takes a Employee object and finds the corresponding Employee in the list
        /// using the Id and then updates the Information attached to that Employee
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task UpdateEventAsync(Employee e)
        {
            if (e != null)
            {
                foreach (Employee i in EmployeeList)
                {
                    if (i.EmployeeID == e.EmployeeID)
                    {
                        i.Name = e.Name;
                        i.Address = e.Address;
                        i.Age = e.Age;
                    }
                }
                await DbService.UpdateObjectAsync(e);
            }
        }
        /// <summary>
        /// Gets a list of Employees and their corresponding Users.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployeesAndUsers()
        {
            List<Employee> templist = new List<Employee>();

            using (var context = new DWBookingDbContext())
            {
                templist = context.Employees.Include(u => u.User).ToList();
            }

            return templist;
        }


    }
}
