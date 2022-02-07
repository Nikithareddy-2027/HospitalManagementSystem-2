using HMS.DAL.Data;
using HMS.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMS.DAL.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        HMSDbContext _hMSDbContext;
        public EmployeeRepository(HMSDbContext hMSDbContext)
        {
            _hMSDbContext = hMSDbContext;
        }
        public void AddEmployee(Employee employee)
        {
            _hMSDbContext.employee.Add(employee);
            _hMSDbContext.SaveChanges();
        }

        public void DeleteEmployee(int EmployeeId)
        {
            var employee = _hMSDbContext.employee.Find(EmployeeId);
            _hMSDbContext.employee.Remove(employee);
            _hMSDbContext.SaveChanges();

        }


        public Employee GetEmployeeById(int EmployeeId)
        {
            return _hMSDbContext.employee.Find(EmployeeId);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _hMSDbContext.employee.ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            _hMSDbContext.Entry(employee).State = EntityState.Modified;
            _hMSDbContext.SaveChanges();
        }
    }
}
