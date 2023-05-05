using System.ComponentModel.DataAnnotations;

namespace AdminDashbord.MVC.Models
{
	public class DepartmentViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "The Name Is Required")]
		public string Name { get; set; } = string.Empty;
	}
}
