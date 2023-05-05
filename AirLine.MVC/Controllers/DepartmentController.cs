using AdminDashbord.MVC.Models;
using AirLine.Core.Entities;
using AirLine.Core.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminDashbord.MVC.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IGenericRepository<Department> _repository;
		private readonly IMapper _mapper;

		public DepartmentController(IGenericRepository<Department> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var department = await _repository.GetAllAsync();
			var mappedDepartment = _mapper.Map<IReadOnlyList<Department> , IReadOnlyList<DepartmentViewModel>>(department);
			return View(mappedDepartment);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(DepartmentViewModel model)
		{
			if (ModelState.IsValid)
			{
				var mappedDepartment = _mapper.Map<DepartmentViewModel, Department>(model);
				await _repository.AddAsync(mappedDepartment);
				await _repository.Complete();
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}

		public async Task<IActionResult> Edit(int Id) 
		{
			var department = await _repository.GetByIdAsync(Id);
			var mappedDepartment = _mapper.Map<Department, DepartmentViewModel>(department);
			return View(mappedDepartment);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int Id , DepartmentViewModel model)
		{
			if (Id != model.Id)
				return NotFound();
			
			else if (ModelState.IsValid)
			{
				var mappedDepartment = _mapper.Map<DepartmentViewModel, Department>(model);
				_repository.Update(mappedDepartment);
				var result = await _repository.Complete();
				if (result > 0)
					return RedirectToAction(nameof(Index));
			}
			return View(model);
		}

		public async Task<IActionResult> Delete(int Id)
		{
			var dapartment = await _repository.GetByIdAsync(Id);
			var mappedDepartment = _mapper.Map<Department , DepartmentViewModel>(dapartment);
			return View(mappedDepartment);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int Id , DepartmentViewModel model)
		{
			if (Id != model.Id)
				return NotFound();

			try
			{
				var department = await _repository.GetByIdAsync(Id);
				_repository.Delete(department);
				await _repository.Complete();
				return RedirectToAction("Index");

			}
			catch (System.Exception)
			{

				return View(model);
			}
		}
	}
}
