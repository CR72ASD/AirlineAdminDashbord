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
	public class PriceCategoryController : ControllerBase
	{
		private readonly IGenericRepository<PriceCategory> _repository;

		public PriceCategoryController(IGenericRepository<PriceCategory> repository)
		{
			_repository = repository;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IReadOnlyList<PriceCategory>>> GetAll()
		{
			var prices = await _repository.GetAllAsync();
			return Ok(prices);
		}

		[HttpGet("Get ById{id}")]
		public async Task<ActionResult<IReadOnlyList<PriceCategory>>> GetById(int id)
		{
			var price = await _repository.GetByIdAsync(id);
			return Ok(price);
		}
	}
}
