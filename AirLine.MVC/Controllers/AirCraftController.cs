using AdminDashboard.Helpers;
using AdminDashbord.MVC.Models;
using AirLine.Core.Entities;
using AirLine.Core.Repositories;
using AirLine.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirLine.MVC.Controllers
{
    public class AirCraftController : Controller
    {
        private readonly IGenericRepository<AirCraft> _repository;
        private readonly IMapper _mapper;

        public AirCraftController(IGenericRepository<AirCraft> repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var Data = await _repository.GetAllAsync();
            var mappData = _mapper.Map<IReadOnlyList<AirCraft>, IReadOnlyList<AirCraftViewModel>>(Data);
            return View(mappData);
        }

        public IActionResult Create() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Create(AirCraftViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedAirCrafts = _mapper.Map<AirCraftViewModel, AirCraft>(model);
                await _repository.AddAsync(mappedAirCrafts);
                await _repository.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var Data = await _repository.GetByIdAsync(Id);
            var mappedData = _mapper.Map<AirCraft, AirCraftViewModel>(Data);
            return View(mappedData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, AirCraftViewModel model)
        {
            if (Id != model.Code)
                return NotFound();

            else if (ModelState.IsValid)
            {
                var mappedData = _mapper.Map<AirCraftViewModel, AirCraft>(model);
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
            var mappedData = _mapper.Map<AirCraft, AirCraftViewModel>(Data);
            return View(mappedData);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id, AirCraftViewModel model)
        {
            if (Id != model.Code)
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
