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
	public class AirCraftController : ControllerBase
	{
		private readonly IGenericRepository<AirCraft> _repository;

		public AirCraftController(IGenericRepository<AirCraft> repository)
		{
			_repository = repository;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IReadOnlyList<AirCraft>>> GetAll()
		{
			var airCrafts = await _repository.GetAllAsync();
			return Ok(airCrafts);
		}

		[HttpGet("Get ById{id}")]
		public async Task<ActionResult<IReadOnlyList<AirCraft>>> GetById(int id)
		{
			var airCraft = await _repository.GetByIdAsync(id);
			return Ok(airCraft);
		}
	}
}
