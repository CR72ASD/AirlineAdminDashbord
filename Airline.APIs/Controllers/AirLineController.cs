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
	public class AirLineController : ControllerBase
	{
		private readonly IGenericRepository<AirLines> _repository;

		public AirLineController(IGenericRepository<AirLines> repository)
		{
			_repository = repository;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IReadOnlyList<AirLines>>> GetAll()
		{
			var airLines = await _repository.GetAllAsync();
			return Ok(airLines);
		}

		[HttpGet("Get ById{id}")]
		public async Task<ActionResult<IReadOnlyList<AirLines>>> GetById(int id)
		{
			var airLines = await _repository.GetByIdAsync(id);
			return Ok(airLines);
		}
	}
}
