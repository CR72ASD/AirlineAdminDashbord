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
	public class CountryController : ControllerBase
	{
		private readonly IGenericRepository<Country> _repository;

		public CountryController(IGenericRepository<Country> repository)
		{
			_repository = repository;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IReadOnlyList<Country>>> GetAll()
		{
			var country = await _repository.GetAllAsync();
			return Ok(country);
		}

		[HttpGet("Get ById{id}")]
		public async Task<ActionResult<IReadOnlyList<Country>>> GetById(int id)
		{
			var country = await _repository.GetByIdAsync(id);
			return Ok(country);
		}
	}
}
