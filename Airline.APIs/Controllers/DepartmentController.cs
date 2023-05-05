using AirLine.Core.Entities;
using AirLine.Core.Repositories;
using AirLine.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirLine.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IGenericRepository<Department> _repository;
		private readonly DBAContext _context;

		public DepartmentController(IGenericRepository<Department> repository,DBAContext context)
		{
			_repository = repository;
			_context = context;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IReadOnlyList<Department>>> GetAll()
		{
			var dept = await _repository.GetAllAsync();
			return Ok(dept);
		}

		[HttpGet("Get ById{id}")]
		public async Task<ActionResult<IEnumerable<Department>>> GetById(int id)
		{
			var dept = await _repository.GetByIdAsync(id);
			return Ok(dept);
		}
	}
}
