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
	public class BooKingController : ControllerBase
	{
		private readonly IGenericRepository<Booking> _repository;

		public BooKingController(IGenericRepository<Booking> repository)
		{
			_repository = repository;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IReadOnlyList<Booking>>> GetAll()
		{
			var booking = await _repository.GetAllAsync();
			return Ok(booking);
		}

		[HttpGet("Get ById{id}")]
		public async Task<ActionResult<IReadOnlyList<Booking>>> GetById(int id)
		{
			var booking = await _repository.GetByIdAsync(id);
			return Ok(booking);
		}
	}
}
