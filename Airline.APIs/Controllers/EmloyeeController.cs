using AirLine.Core.Entities;
using AirLine.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirLine.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmloyeeController : ControllerBase
	{
		private readonly IGenericRepository<Employee> _repository;

		public EmloyeeController(IGenericRepository<Employee> repository)
		{
			_repository = repository;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IReadOnlyList<Employee>>> GetAll()
		{
			var employees = await _repository.GetAllEmployeesAsync();
			return Ok(employees);
		}

		[HttpGet("Get ById{id}")]
		public async Task<ActionResult<IReadOnlyList<Employee>>> GetById(int id)
		{
			var employee = await _repository.GetByIdAsync(id);
			return Ok(employee);
		}
	}
}
