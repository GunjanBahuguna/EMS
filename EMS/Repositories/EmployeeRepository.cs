using System;
using System.Collections.Generic;
using System.Linq;
using WebApi_Training_Playground_Day03.Data;
using WebApi_Training_Playground_Day03.Models;

namespace WebApi_Training_Playground_Day03.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly WebApiTrainingDbContext _context;

		public EmployeeRepository(WebApiTrainingDbContext context)
		{
			this._context = context;
		}

		public IEnumerable<Employee> GetEmployees()
		{
			return this._context.Employees.ToList();
		}

		public Employee GetEmployee(int employeeId)
		{
			return this._context.Employees.FirstOrDefault(e => e.Id == employeeId);
		}

		public Employee AddEmployee(Employee employee)
		{
			var result = this._context.Employees.Add(employee);
			_context.SaveChanges();
			return result;
		}

		public Employee UpdateEmployee(Employee employee)
		{
			var result = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);

			if (result != null)
			{
				result.FirstName = employee.FirstName;
				result.LastName = employee.LastName;
				result.HireDate = employee.HireDate;
				result.DepartmentId = employee.DepartmentId;

				_context.SaveChanges();

				return result;
			}

			return null;
		}

		public bool DeleteEmployee(int employeeId)
		{
			var result = _context.Employees.FirstOrDefault(e => e.Id == employeeId);
			if (result != null)
			{
				_context.Employees.Remove(result);
				_context.SaveChanges();
				return true;
			}

			return false;
		}
	}

	public interface IEmployeeRepository
	{
		IEnumerable<Employee> GetEmployees();

		Employee GetEmployee(int employeeId);

		Employee AddEmployee(Employee employee);

		Employee UpdateEmployee(Employee employee);

		bool DeleteEmployee(int employeeId);
	}
}
