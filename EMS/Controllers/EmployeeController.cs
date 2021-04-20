using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi_Training_Playground_Day03.Data;
using WebApi_Training_Playground_Day03.Models;
using WebApi_Training_Playground_Day03.Repositories;

namespace WebApi_Training_Playground_Day03.Controllers
{
	public class EmployeeController : ApiController
	{
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeeController()
		{
			this._employeeRepository = new EmployeeRepository(new WebApiTrainingDbContext());
		}

		// GET: Employee
		//[Authorize(Roles = "SuperAdmin, Admin, User")]
		public IHttpActionResult GetEmployees()
		{
			IEnumerable<Employee> employees = null;

			employees = this._employeeRepository.GetEmployees().ToList();

			if (!employees.Any())
			{
				return NotFound();
			}

			return Ok(employees);
		}



		// GET: Employee
		//[Authorize(Roles = "SuperAdmin, Admin, User")]
		public IHttpActionResult GetEmployee(int id)
		{
			Employee employee = null;
			employee = this._employeeRepository.GetEmployee(id);

			if (employee == null)
			{
				return NotFound();
			}

			return Ok(employee);
		}
		[HttpPost]
		//[Authorize(Roles = "SuperAdmin, Admin")]
		public IHttpActionResult AddEmployee([FromBody]Employee employee)
		{
			if (!ModelState.IsValid)
				return BadRequest("Invalid data.");

			employee = this._employeeRepository.AddEmployee(employee);

			return Ok(employee);
		}
		[HttpPut]
		//[Authorize(Roles = "SuperAdmin, Admin")]
		public IHttpActionResult UpdateEmployee(Employee employee)
		{
			if (!ModelState.IsValid)
				return BadRequest("Invalid data.");

			employee = this._employeeRepository.UpdateEmployee(employee);

			return Ok(employee);
		}
		/*
		  Content-Type: application/json
		 {
  "id": 1,
  "firstName": 'Rohit',
  "lastName": 'Kumar',
  "hireDate": "0001-01-01T00:00:00",
  "employeeNumber": 'EP005',
  "departmentId": 4
}
		 */
		[HttpDelete]
		//[Authorize(Roles = "SuperAdmin")]
		public IHttpActionResult DelEmployee(Employee employee)
		{
			if (!ModelState.IsValid)
				return BadRequest("Invalid data.");
			if (employee.Id <= 0)
				return BadRequest("Not a valid student id");

			var isDeleted = this._employeeRepository.DeleteEmployee(employee.Id);
			if (isDeleted)
			{
				return Ok(employee);
			}
			else
			{
				return BadRequest("Invalid data");
			}
		}
	}
}