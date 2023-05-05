using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Core.Entities
{
	public class FlightSchedule:BaseEntity
	{
		[Key]
        public int FlightAutoNumberKEY { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string AvalibleSiteClassA { get; set; } = string.Empty;
        public string AvalibleSiteClassB { get; set; } = string.Empty;
        public string AvalibleSiteClassC { get; set; } = string.Empty;

        public int FlightNumber { get; set; }
        [ForeignKey("FlightNumber")]
        public Flight Flight { get; set; }
    }
}
