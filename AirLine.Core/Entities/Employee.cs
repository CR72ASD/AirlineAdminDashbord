using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Core.Entities
{
	public class Employee : BaseEntity
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }

		public string Gender { get; set; }
		public string Phone { get; set; } 
		[EmailAddress]
		public string Email { get; set; }
		public string Age { get; set; } 
		public decimal Salary { get; set; } 

		public int emp_DeptID { get; set; }
		[ForeignKey("emp_DeptID")]
        public Department Department { get; set; }
    }
}
