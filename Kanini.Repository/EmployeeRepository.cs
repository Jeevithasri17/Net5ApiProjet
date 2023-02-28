using Kanini.Model;
using Kanini.Repository.Interface;
using Kanini.Service;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;


namespace Kanini.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Employee> GetAllEmployees()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedure.GetAllEmployees, connection);
                command.CommandType = CommandType.StoredProcedure;

                List<Employee> employees = new List<Employee>();

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = (Guid)reader["Id"];
                    employee.Name = (string)reader["Name"];
                    employee.Email = (string)reader["Email"];
                    employee.Phone = (string)reader["Phone"];

                    employees.Add(employee);
                }

                reader.Close();

                return employees;
            }
        }

        public string AddEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(StoredProcedure.AddEmployee, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = employee.Name;
                command.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = employee.Email;
                command.Parameters.Add("@Phone", SqlDbType.VarChar, 20).Value = employee.Phone;

                connection.Open();
                var rowsAffected = command.ExecuteNonQuery();

                return "Employee Added Successfully";
            }
        }

        public string UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedure.UpdateEmployee, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Phone", employee.Phone);

                connection.Open();
                command.ExecuteNonQuery();

                return "Employee Updated Successfully";
            }
        }

        public string DeleteEmployee(Guid employeeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedure.DeleteEmployee, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", employeeId);

                connection.Open();
                command.ExecuteNonQuery();

                return "Employee Deleted Successfully";
            }
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            Employee employee = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedure.GetEmployeeById, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", employeeId);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                            Id = reader.GetGuid(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            Phone = reader.GetString(3)
                        };
                    }
                }
            }

            return employee;
        }


    }

}
