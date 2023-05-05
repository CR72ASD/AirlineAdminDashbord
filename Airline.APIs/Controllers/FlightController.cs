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
	public class FlightController : ControllerBase
	{
		private readonly IGenericRepository<Flight> _repository;

		public FlightController(IGenericRepository<Flight> repository)
		{
			_repository = repository;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IReadOnlyList<Flight>>> GetAll()
		{
			var flight = await _repository.GetAllAsync();
			return Ok(flight);
		}

		[HttpGet("Get ById{id}")]
		public async Task<ActionResult<IReadOnlyList<Flight>>> GetById(int id)
		{
			var flight = await _repository.GetByIdAsync(id);
			return Ok(flight);
		}
	}
}
