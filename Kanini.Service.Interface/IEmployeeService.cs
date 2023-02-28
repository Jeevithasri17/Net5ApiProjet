using System;
using System.Collections.Generic;

namespace Kanini.Service.Interface
{
    public interface IEmployeeService
    {
        public List<Employee> GetAllEmployees();
        public string AddEmployee(Employee employee);
        public string UpdateEmployee(Employee employee);
        public string DeleteEmployee(Guid employeeId);
        public Employee GetEmployeeById(Guid employeeId);
    }
}
