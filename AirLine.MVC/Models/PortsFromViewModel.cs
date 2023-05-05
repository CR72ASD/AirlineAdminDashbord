using AirLine.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirLine.MVC.Models
{
    public class PortsFromViewModel
    {
        [Key]
        public int PortIDNumber { get; set; }

        [Required(ErrorMessage =("PortIDCode is Required"))]
        public string PortIDCode { get; set; }

        [Required(ErrorMessage = ("PortName is Required"))]
        public string PortName { get; set; }

        public int CountryCode { get; set; }
        [Required(ErrorMessage = ("Country is Required"))]
        public Country Country { get; set; }
    }
}
