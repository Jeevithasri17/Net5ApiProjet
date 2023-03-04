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
        /// <param name="employee">Employee object contains name, email, phone</param>
        /// <returns></returns>
        [HttpPost("AddEmployee")]
        public string AddEmployee(Employee employee)
        {
            return employeeservice.AddEmployee(employee);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee">Updates name, email, phone of employee</param>
        /// <returns></returns>
        [HttpPut("UpdateEmployee")]
        public string UpdateEmployee(Employee employee)
        {
            return employeeservice.UpdateEmployee(employee);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId">Deletes employee record</param>
        /// <returns></returns>
        [HttpDelete("DeleteEmployee")]
        public string DeleteEmployee(Guid employeeId)
        {
            return employeeservice.DeleteEmployee(employeeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId">Retrives employee detail for given Id</param>
        /// <returns></returns>
        [HttpGet("GetEmployeeById")]
        public Employee GetEmployeeById(Guid employeeId)
        {
            return employeeservice.GetEmployeeById(employeeId);
        }



    }
}

