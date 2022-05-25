﻿using System;
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

        
        public async void AddEmployee(Employee employee)
        {
            EmployeeList.Add(employee);
            await DbService.AddObjectAsync(employee);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return EmployeeList;
        }
        // Returnere listen af employees

        public Employee GetEmployee(int employeeId)
        {
            foreach (Employee employee in EmployeeList)
            {
                if (employee.EmployeeID == employeeId) return employee;

            }

            return null;
        }
        public async Task UpdateEmployeeAsync(Employee e)
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
                        i.Phone = e.Phone;
                        i.Email = e.Email;
                    }
                }
                await DbService.UpdateObjectAsync(e);
            }
        }

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
