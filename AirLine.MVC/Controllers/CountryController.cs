using AirLine.Core.Entities;
using AirLine.Core.Repositories;
using AirLine.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirLine.MVC.Controllers
{
    public class CountryController : Controller
    {
        private readonly IGenericRepository<Country> _repository;
        private readonly IMapper _mapper;

        public CountryController(IGenericRepository<Country> repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var Data = await _repository.GetAllAsync();
            var mappData = _mapper.Map<IReadOnlyList<Country>, IReadOnlyList<CountryViewModel>>(Data);
            return View(mappData);
        }

        public IActionResult Create() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Create(CountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedCountries = _mapper.Map<CountryViewModel, Country>(model);
                await _repository.AddAsync(mappedCountries);
                await _repository.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var Data = await _repository.GetByIdAsync(Id);
            var mappedData = _mapper.Map<Country, CountryViewModel>(Data);
            return View(mappedData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, CountryViewModel model)
        {
            if (Id != model.CountryCode)
                return NotFound();

            else if (ModelState.IsValid)
            {
                var mappedData = _mapper.Map<CountryViewModel, Country>(model);
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
            var mappedData = _mapper.Map<Country, CountryViewModel>(Data);
            return View(mappedData);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id, CountryViewModel model)
        {
            if (Id != model.CountryCode)
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
