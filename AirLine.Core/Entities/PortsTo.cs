using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Core.Entities
{
	public class PortsTo : BaseEntity
	{
		[Key]
		public int PortIDNumber { get; set; }
		public string PortIDCode { get; set; }
		public string PortName { get; set; }

		public int CountryCode { get; set; }
		[ForeignKey("CountryCode")]
        public Country Country { get; set; }
    }
}
