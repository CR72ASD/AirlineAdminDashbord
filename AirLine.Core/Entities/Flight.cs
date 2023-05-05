using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirLine.Core.Entities
{
	public class Flight:BaseEntity
	{
		[Key]
        public int FlightNumber { get; set; }

		public int FromPort { get; set; }
		[ForeignKey("FromPort")]
        public PortsFrom PortsFrom { get; set; }

		public int ToPort { get; set; }
		[ForeignKey("ToPort")]
		public PortsTo PortsTo { get; set; }

		public int AirLineCode { get; set; }
		[ForeignKey("AirLineCode")]
		public AirLines AirLine { get; set; }

        public int AirCraftCode { get; set; }
		[ForeignKey("AirCraftCode")]
        public AirCraft AirCraft { get; set; }
    }
}