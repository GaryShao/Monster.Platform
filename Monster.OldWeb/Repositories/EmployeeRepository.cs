using Monster.OldWeb.Enums;
using Monster.OldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monster.OldWeb.Repositories
{
    public class EmployeeRepository
    {
        private static IList<Employee> employees;

        static EmployeeRepository()
        {
            employees = new List<Employee>();
            employees.Add(new Employee(Guid.NewGuid().ToString(), "ZhangSan", Gender.Male, new DateTime(1992, 2, 6), "Sales Department"));
            employees.Add(new Employee(Guid.NewGuid().ToString(), "LiSi", Gender.Female, new DateTime(1992, 2, 6), "HR Department"));
            employees.Add(new Employee(Guid.NewGuid().ToString(), "WangWu", Gender.Unknown, new DateTime(1992, 2, 6), "HR Department"));
        }

        public IEnumerable<Employee> GetEmployees(string id = "")
        {
            return employees.Where(e => e.Id == id || string.IsNullOrEmpty(id) || id == "*");
        }
    }
}