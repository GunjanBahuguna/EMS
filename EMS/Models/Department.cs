using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Training_Playground_Day03.Models
{
	[Table("Departments")]
    public class Department
    {
		[Key]
	    public int Id { get; set; }

	    public string Name { get; set; }

	    public string Location { get; set; }
    }
}
