using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Core.Entities
{
	public class PriceCategory:BaseEntity
	{
		[Key]
        public int CategoryNumber { get; set; }

		[Required]
		public string CategoryName { get; set; }

		[Required]
		public decimal CategoryPrice { get; set; }
    }
}
