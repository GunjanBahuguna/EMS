using System;
using System.Collections.Generic;
using System.Linq;
using WebApi_Training_Playground_Day03.Data;
using WebApi_Training_Playground_Day03.Models;

namespace WebApi_Training_Playground_Day03.Repositories
{
	public class DepartmentRepository : IDepartmentRepository
	{
		public IEnumerable<Department> GetDepartments()
		{
			using (WebApiTrainingDbContext _context = new WebApiTrainingDbContext())
			{
				return _context.Departments.ToList();
			}
		}
	}

	public interface IDepartmentRepository
	{
		IEnumerable<Department> GetDepartments();
	}
}
