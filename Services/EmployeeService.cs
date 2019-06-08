using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesApiMongoDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace EmployeesApiMongoDb.Services
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;
        private readonly IMongoCollection<City> _cities;

        public EmployeeService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("EmployeeDb"));
            var database = client.GetDatabase("employees");
            _employees = database.GetCollection<Employee>("Employees");
            _cities = database.GetCollection<City>("Cities");

        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                Console.WriteLine(_employees.Find(employee => true).ToList());
                return _employees.Find(employee => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        public Employee GetEmployeeData(string id)
        {
            try
            {
                return _employees.Find<Employee>(employee => employee.id == id).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public Employee AddEmployee(Employee employee)
        {
            try
            {
                _employees.InsertOne(employee);
                return employee;
            }
            catch
            {
                throw;
            }
        }

        public ReplaceOneResult UpdateEmployee(string id, Employee employeeIn)
        {
            try
            {
               return  _employees.ReplaceOne(employee => employee.id == id, employeeIn);
            }
            catch
            {
                throw;
            }
            
        }

        public void DeleteEmployee(string id)
        {

            try
            {
                _employees.DeleteOne(employee => employee.id == id);
            }
            catch
            {
                throw;
            }
            
        }

        public List<City> GetCities()
        {
            List<City> listCity = new List<City>();
            listCity = _cities.Find(city => true).ToList();

            return listCity;
        }


    }
}
