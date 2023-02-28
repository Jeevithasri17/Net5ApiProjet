using Kanini.Service.Interface;
using Kanini.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Kanini.Model;
using Kanini.Repository.Interface;

namespace Kanini.Service
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }
        public string AddEmployee(Employee employee)
        {
            return employeeRepository.AddEmployee(employee);
        }

        public string UpdateEmployee(Employee employee)
        {
            return employeeRepository.UpdateEmployee(employee);

        }

        public string DeleteEmployee(Guid employeeId)
        {
            return employeeRepository.DeleteEmployee(employeeId);
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            return employeeRepository.GetEmployeeById(employeeId);

        }


    }

}
