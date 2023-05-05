using AirLine.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdminDashbord.MVC.Models
{
	public class EmployeeViewModel
	{ 
		public int Id { get; set; }
		public string Name { get; set; } 
		public string Gender { get; set; } 
		public string Phone { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		public string Age { get; set; }
		public decimal Salary { get; set; }
		public int emp_DeptID { get; set; }
		public Department Department { get; set; }
    }
}
