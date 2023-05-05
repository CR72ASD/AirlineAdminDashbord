using AdminDashbord.MVC.Models;
using AirLine.Core.Entities;
using AirLine.MVC.Models;
using AutoMapper;

namespace AdminDashbord.MVC.Helper
{
	public class MapsProfile : Profile
	{
		public MapsProfile()
		{
			CreateMap<Department , DepartmentViewModel>().ReverseMap();
			CreateMap<Employee , EmployeeViewModel >().ReverseMap();
			CreateMap<AirLines, AirLineViewModel>().ReverseMap();
            CreateMap<AirCraft, AirCraftViewModel>().ReverseMap();
            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<PortsTo, PortsToViewModel>().ReverseMap();
            CreateMap<PortsFrom, PortsFromViewModel>().ReverseMap();
            CreateMap<PriceCategory, PriceCategoryViewModel>().ReverseMap();
        }
    }
}
