using AirLine.Core.Entities;
using AirLine.Core.Repositories;
using AirLine.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirLine.MVC.Controllers
{
    public class PortsFromController : Controller
    {
        private readonly IGenericRepository<PortsFrom> _repository;
        private readonly IMapper _mapper;

        public PortsFromController(IGenericRepository<PortsFrom> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var Data = await _repository.GetAllPortsFromAsync();
            var mappData = _mapper.Map<IReadOnlyList<PortsFrom>, IReadOnlyList<PortsFromViewModel>>(Data);
            return View(mappData);
        }

        public IActionResult Create() 
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(PortsFromViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mappedData = _mapper.Map<PortsFromViewModel, PortsFrom>(model);
                await _repository.AddAsync(mappedData);
                await _repository.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var Data = await _repository.GetByIdAsync(Id);
            var mappedData = _mapper.Map<PortsFrom, PortsFromViewModel>(Data);
            return View(mappedData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, PortsFromViewModel model)
        {
            if (Id != model.PortIDNumber)
                return NotFound();

            else if (ModelState.IsValid)
            {
                var mappedData = _mapper.Map<PortsFromViewModel, PortsFrom>(model);
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
            var mappedData = _mapper.Map<PortsFrom, PortsFromViewModel>(Data);
            return View(mappedData);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id, PortsFromViewModel model)
        {
            if (Id != model.PortIDNumber)
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
