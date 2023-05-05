﻿using AirLine.Core.Entities;
using AirLine.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirLine.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PortsToController : ControllerBase
	{
		private readonly IGenericRepository<PortsTo> _repository;

		public PortsToController(IGenericRepository<PortsTo> repository)
		{
			_repository = repository;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IReadOnlyList<PortsTo>>> GetAll()
		{
			var ports = await _repository.GetAllAsync();
			return Ok(ports);
		}

		[HttpGet("Get ById{id}")]
		public async Task<ActionResult<IReadOnlyList<PortsTo>>> GetById(int id)
		{
			var ports = await _repository.GetByIdAsync(id);
			return Ok(ports);
		}
	}
}
