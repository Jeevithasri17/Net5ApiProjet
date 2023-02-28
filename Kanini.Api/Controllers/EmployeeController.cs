using Kanini.Service;
using Kanini.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Kanini.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeservice;

        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeservice = _employeeService;
        }

        /// <summary>
        /// To get all employee details
        /// </summary>
        /// <returns>List of employee details</returns>
        [HttpGet("GetAllEmployees")]
        public List<Employee> GetAllEmployees()
        {
            return employeeservice.GetAllEmployees();
        }

        /// <summary>
        /// To insert a employee detail
        /// </summary>
        /// <param name="employee">Employee objec contains Fname, Lname, role</param>
        /// <returns></returns>
        [HttpPost("AddEmployee")]
        public string AddEmployee(Employee employee)
        {
            return employeeservice.AddEmployee(employee);
        }

        [HttpPut("UpdateEmployee")]
        public string UpdateEmployee(Employee employee)
        {
            return employeeservice.UpdateEmployee(employee);
        }

        [HttpDelete("DeleteEmployee")]
        public string DeleteEmployee(Guid employeeId)
        {
            return employeeservice.DeleteEmployee(employeeId);
        }

        [HttpGet("GetEmployeeById")]
        public Employee GetEmployeeById(Guid employeeId)
        {
            return employeeservice.GetEmployeeById(employeeId);
        }



    }
}

