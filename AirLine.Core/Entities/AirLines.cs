using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Core.Entities
{
	public class AirLines:BaseEntity
	{
		[Key]
        public int AirLineCode { get; set; }
		public string AirLineName { get; set; }
		public string AirLineImage { get; set; }
		public string AirLineAddress { get; set; }
		public string AirLinePhone { get; set; }
		public string AirLineContactNumber { get; set; }
    }
}
