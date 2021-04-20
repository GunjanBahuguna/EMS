using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Training_Playground_Day03.Models
{
	[Table("Employees")]
    public class Employee
    {
	    [Key]
		public int Id { get; set; }

	    public string FirstName { get; set; }

	    public string LastName { get; set; }

	    public DateTime HireDate { get; set; }

	    public string EmployeeNumber { get; set; }

		public int DepartmentId { get; set; }

		[ForeignKey(nameof(DepartmentId))]
		public Department Department { get; set; }
	}
}
