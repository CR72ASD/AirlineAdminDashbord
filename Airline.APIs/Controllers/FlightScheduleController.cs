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
	public class FlightScheduleController : ControllerBase
	{
		private readonly IGenericRepository<FlightSchedule> _repository;

		public FlightScheduleController(IGenericRepository<FlightSchedule> repository)
		{
			_repository = repository;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IReadOnlyList<FlightSchedule>>> GetAll()
		{
			var flight = await _repository.GetAllAsync();
			return Ok(flight);
		}

		[HttpGet("Get ById{id}")]
		public async Task<ActionResult<IReadOnlyList<FlightSchedule>>> GetById(int id)
		{
			var flight = await _repository.GetByIdAsync(id);
			return Ok(flight);
		}
	}
}
