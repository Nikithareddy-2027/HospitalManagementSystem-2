using HMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.DAL.Repository
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int EmployeeId);
        Employee GetEmployeeById(int EmployeeId);
        IEnumerable<Employee> GetEmployees();
    }
}
