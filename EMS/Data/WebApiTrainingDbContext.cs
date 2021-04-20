using System.Data.Entity;
using WebApi_Training_Playground_Day03.Models;

namespace WebApi_Training_Playground_Day03.Data
{
	public class WebApiTrainingDbContext : DbContext
	{
		public WebApiTrainingDbContext()
			: base("name=WebApiTrainingDb")
		{
		}

		public DbSet<Employee> Employees { get; set; }

		public DbSet<Department> Departments { get; set; }

		
	}
}
