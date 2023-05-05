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
	public class CustomerController : ControllerBase
	{
		private readonly IGenericRepository<Customer> _repository;

		public CustomerController(IGenericRepository<Customer> repository)
		{
			_repository = repository;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IReadOnlyList<Customer>>> GetAll()
		{
			var customer = await _repository.GetAllAsync();
			return Ok(customer);
		}

		[HttpGet("Get ById{id}")]
		public async Task<ActionResult<IReadOnlyList<Customer>>> GetById(int id)
		{
			var customer = await _repository.GetByIdAsync(id);
			return Ok(customer);
		}
	}
}
