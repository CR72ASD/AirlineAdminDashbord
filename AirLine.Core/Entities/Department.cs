using System.ComponentModel.DataAnnotations;

namespace AirLine.Core.Entities
{
	public class Department: BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
    }
}