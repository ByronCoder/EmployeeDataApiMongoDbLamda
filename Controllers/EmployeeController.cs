using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeesApiMongoDb.Services;
using EmployeesApiMongoDb.Models;
using MongoDB.Driver;

namespace EmployeesApiMongoDb.Controllers
{
  

    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("api/Employee/Index")]
        public ActionResult<List<Employee>> Index()
        {
            return _employeeService.GetAllEmployees();
        }

        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public ActionResult<Employee> Details(string id)
        {
            var emp = _employeeService.GetEmployeeData(id);

            if(emp == null)
            {
                return NotFound();
            }

            return emp;
        }

        [HttpPost]
        [Route("api/Employee/Create")]
        public ActionResult<Employee> Create(Employee employee)
        {
             return _employeeService.AddEmployee(employee);

            
        }

        

        [HttpPut]
        [Route("api/Employee/Edit")]
        public ReplaceOneResult Edit(string id,  Employee empIn)
        {
            var emp = _employeeService.GetEmployeeData(id);
           
           return _employeeService.UpdateEmployee(id, empIn);

           

        }

        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var emp = _employeeService.GetEmployeeData(id);

            if(emp == null)
            {
                return NotFound();
            }

            _employeeService.DeleteEmployee(emp.id);

            return NoContent();
        }

        [HttpGet]
        [Route("api/Employee/GetCityList")]
        public ActionResult<List<City>> GetCityList()
        {
            return _employeeService.GetCities();
        }
    }
}