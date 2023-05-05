using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Core.Entities
{
	public class Customer : BaseEntity
	{
		[Key]
		public int CustCode { get; set; }

		[Required(ErrorMessage = "The CustName Is Required")]
		public string CustName { get; set; } = string.Empty;

		[Required(ErrorMessage = "The CustDateOfBirth Is Required")]
		public DateTime CustDateOfBirth { get; set; } = DateTime.Now; 

		[Required(ErrorMessage = "The CustPassportNumber Is Required")]
		public string CustPassportNumber { get; set; } = string.Empty;

		[Required(ErrorMessage = "The CustAddress Is Required")]
		public string CustAddress { get; set; } = string.Empty;

		[Required(ErrorMessage = "The CustPhoneNumber Is Required")]
		[MaxLength(11)]
		[MinLength(11)]
		public string CustPhoneNumber { get; set; } = string.Empty;

		[Required(ErrorMessage = "The CustEmailAddress Is Required")]
		[EmailAddress]
		public string CustEmailAddress { get; set; } = string.Empty;

		[Required(ErrorMessage = "The CustPassword Is Required")]
		public string CustPassword { get; set; } = string.Empty;
		
    }
}
