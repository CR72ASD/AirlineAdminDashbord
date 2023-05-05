using System.ComponentModel.DataAnnotations;

namespace AirLine.MVC.Models
{
	public class PriceCategoryViewModel
	{
		public int CategoryNumber { get; set; }

		[Required(ErrorMessage = "The Category Name is Required")]
		public string CategoryName { get; set; }

		[Required(ErrorMessage = "The Category Price is Required")]
		public decimal CategoryPrice { get; set; }
	}
}
