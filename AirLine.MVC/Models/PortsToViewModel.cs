using AirLine.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirLine.MVC.Models
{
    public class PortsToViewModel
    {
        public int PortIDNumber { get; set; }

        [Required(ErrorMessage = ("PortIDCode is Required"))]
        public string PortIDCode { get; set; }

        [Required(ErrorMessage = ("PortName is Required"))]
        public string PortName { get; set; }

        public int CountryCode { get; set; }
        [Required(ErrorMessage = ("Country is Required"))]
        public Country Country { get; set; }
    }
}
