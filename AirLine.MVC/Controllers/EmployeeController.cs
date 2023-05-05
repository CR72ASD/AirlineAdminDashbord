using AdminDashbord.MVC.Models;
using AirLine.Core.Entities;
using AirLine.Core.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminDashbord.MVC.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IGenericRepository<Employee> _repository;
		private readonly IMapper _mapper;

		public EmployeeController(IGenericRepository<Employee> repository , IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var employee = await _repository.GetAllEmployeesAsync();
			var mappedEmployee = _mapper.Map<IReadOnlyList<Employee>, IReadOnlyList<EmployeeViewModel>>(employee);
			return View(mappedEmployee);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(EmployeeViewModel model)
		{
			if (ModelState.IsValid)
			{
				var mappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(model);
				await _repository.AddAsync(mappedEmployee);
				await _repository.Complete();
				return RedirectToAction("Index");
			}
			return View(model);
		}

		public async Task<IActionResult> Edit(int Id)
		{
			var employee = await _repository.GetByIdAsync(Id);
			var mappedEmployee = _mapper.Map<Employee, EmployeeViewModel>(employee);
			return View(mappedEmployee);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id , EmployeeViewModel model)
		{
			if(id != model.Id)
				return NotFound();
			if (ModelState.IsValid)
			{
				var mappedEmployee = _mapper.Map<EmployeeViewModel , Employee>(model);
				_repository.Update(mappedEmployee);
				var result =  await _repository.Complete();
				if(result > 0)
					return RedirectToAction(nameof(Index));
			}
			return View(model);
		}

		public async Task<IActionResult> Delete(int Id)
		{
			var employee = await _repository.GetByIdAsync(Id);
			var mappedEmployee = _mapper.Map<Employee, EmployeeViewModel>(employee);
			return View(mappedEmployee);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int Id , EmployeeViewModel model)
		{
			if(Id != model.Id)
				return NotFound();
			try
			{
				var mappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(model);
				_repository.Delete(mappedEmployee);
				var result = await _repository.Complete();
				if (result > 0)
					return RedirectToAction(nameof(Index));
			}
			catch (System.Exception)
			{
				return View(model);
			}
			return View(model);
		}
	}
}
