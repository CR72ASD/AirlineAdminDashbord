using AdminDashboard.Helpers;
using AdminDashbord.MVC.Models;
using AirLine.Core.Entities;
using AirLine.Core.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminDashbord.MVC.Controllers
{
	public class AirlineController : Controller
	{
		private readonly IGenericRepository<AirLines> _repository;
		private readonly IMapper _mapper;

		public AirlineController(IGenericRepository<AirLines> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var Data = await _repository.GetAllAsync();
			var mappData = _mapper.Map<IReadOnlyList<AirLines>, IReadOnlyList<AirLineViewModel>>(Data);
			return View(mappData);
		}

		public IActionResult Create() { return View(); }

		[HttpPost]
		public async Task<IActionResult> Create(AirLineViewModel model)
		{
			if (ModelState.IsValid)
			{
				if(model.AirLineImage == null)
					model.AirLineImage = PictureSettings.UploadFile(model.Image, "AirLines");
                var mappedAirLines = _mapper.Map<AirLineViewModel, AirLines>(model);
				await _repository.AddAsync(mappedAirLines);
				await _repository.Complete();
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}

        public async Task<IActionResult> Edit(int Id)
        {
            var Data = await _repository.GetByIdAsync(Id);
            var mappedData = _mapper.Map<AirLines, AirLineViewModel>(Data);
            return View(mappedData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, AirLineViewModel model)
        {
            if (Id != model.AirLineCode)
                return NotFound();

            else if (ModelState.IsValid)
            {
                var mappedData = _mapper.Map<AirLineViewModel, AirLines>(model);
                _repository.Update(mappedData);
                var result = await _repository.Complete();
                if (result > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var Data = await _repository.GetByIdAsync(Id);
            var mappedData = _mapper.Map<AirLines, AirLineViewModel>(Data);
            return View(mappedData);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id, AirLineViewModel model)
        {
            if (Id != model.AirLineCode)
                return NotFound();

            try
            {
                var Data = await _repository.GetByIdAsync(Id);
                _repository.Delete(Data);
                await _repository.Complete();
                return RedirectToAction(nameof(Index));

            }
            catch (System.Exception)
            {

                return View(model);
            }
        }
    }
}
