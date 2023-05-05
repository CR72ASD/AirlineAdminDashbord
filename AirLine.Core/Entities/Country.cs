using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine.Core.Entities
{
	public class Country:BaseEntity
	{
		[Key]
        public int CountryCode { get; set; }
		public string CountryName { get; set; }
    }
}
