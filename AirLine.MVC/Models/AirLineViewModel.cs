using Microsoft.AspNetCore.Http;

namespace AdminDashbord.MVC.Models
{
	public class AirLineViewModel
	{
		public int AirLineCode { get; set; }
		public string AirLineName { get; set; }
		public IFormFile Image { get; set; }
		public string AirLineImage { get; set; }
		public string AirLineAddress { get; set; }
		public string AirLinePhone { get; set; }
		public string AirLineContactNumber { get; set; } 
	}
}
