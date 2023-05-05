using AdminDashbord.MVC.Models;
using AirLine.Core.Entities;
using AirLine.Core.Repositories;
using AirLine.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirLine.MVC.Controllers
{
	public class PriceCategoryController : Controller
	{
		private readonly IGenericRepository<PriceCategory> _repository;
		private readonly IMapper _mapper;

		public PriceCategoryController(IGenericRepository<PriceCategory> repository , IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var data = await _repository.GetAllAsync();
			var mappedData = _mapper.Map<IReadOnlyList<PriceCategory> ,IReadOnlyList<PriceCategoryViewModel>>(data);
			return View(mappedData);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(PriceCategoryViewModel model)
		{
			if (ModelState.IsValid)
			{
				var mappedData = _mapper.Map<PriceCategoryViewModel , PriceCategory>(model);
				await _repository.AddAsync(mappedData);
				await _repository.Complete();
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> Edit(int Id)
		{
			var data = await _repository.GetByIdAsync(Id);
			var mmappedData = _mapper.Map<PriceCategory, PriceCategoryViewModel>(data);
			return View(mmappedData);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int Id , PriceCategoryViewModel model)
		{
			if (Id != model.CategoryNumber)
				return NotFound();
			if (ModelState.IsValid)
			{
				var mappedData = _mapper.Map<PriceCategoryViewModel , PriceCategory>(model);
				_repository.Update(mappedData);
				var result = await _repository.Complete();
				if(result > 0)
					return RedirectToAction("Index");
			}
			return View(model);
		}

		public async Task<IActionResult> Delete(int Id)
		{
			var data = await _repository.GetByIdAsync(Id);
			var mappedData = _mapper.Map<PriceCategory, PriceCategoryViewModel>(data);
			return View(mappedData);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int Id , PriceCategoryViewModel model)
		{
			if (Id != model.CategoryNumber)
				return NotFound();
			try
			{
				var mappedData = _mapper.Map<PriceCategoryViewModel, PriceCategory>(model);
				_repository.Delete(mappedData);
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
