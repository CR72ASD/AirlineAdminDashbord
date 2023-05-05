using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Core.Entities
{
	public class Booking:BaseEntity
	{
		[Key]
        public int BookingID { get; set; }
        public string ClassA { get; set; } = string.Empty;
		public string ClassB { get; set; } = string.Empty;
		public string ClassC { get; set; } = string.Empty;
        
		public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        public int FlightID { get; set; }
		[ForeignKey("FlightID")]
		public Flight Flight { get; set; }
    }
}
