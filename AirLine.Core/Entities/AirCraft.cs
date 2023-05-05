using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Core.Entities
{
	public class AirCraft: BaseEntity
	{
		[Key]
        public int Code { get; set; }
		public string AircraftModel { get; set; } = string.Empty ;
		public int NoOfSeatClassA { get; set; }
		public int NoOfSeatClassB { get; set; }
		public int NoOfSeatClassC { get; set; }
	}
}
