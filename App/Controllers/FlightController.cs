using App.Models;
using AutoMapper;
using Domain.Entity;
using Domain.Resource;
using Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Web.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;

        public FlightController(IFlightService service, IStringLocalizer<SharedResources> localizer, IMapper mapper)
        {
            _service = service;
            _localizer = localizer;
            _mapper = mapper;
        }

        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Index(FlightViewModel model)
        {
            if (model == null)
                model = new FlightViewModel();
            try
            {
                model.Total = await _service.Count(_mapper.Map<Flight>(model));
                model.Itens = await _service.Get(_mapper.Map<Flight>(model), model.Skip, model.Take);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
            }
            return View(model);
        }

        public async Task<IActionResult> Search()
        {
            var model = new FlightSearchViewModel();
            model.Itens = await _service.Get(new Flight(), 0, 30);
            return View(model);
        }

        [Authorize(Roles = "ADM")]
        public IActionResult Create()
        {
            return View(new FlightViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Create(FlightViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Id = await _service.Insert(_mapper.Map<Flight>(model));
                    TempData["SucessMessage"] = _localizer["Record saved successfully."];
                }
                else
                    throw new ArgumentException(_localizer["Invalid data."]);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
            }

            return RedirectToAction("Edit", new { codigo = model.Id });
        }

        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Edit(Guid id)
        {
            FlightViewModel model = new FlightViewModel();

            try
            {
                var item = await _service.Get(id);
                if (item == null)
                    throw new ArgumentException(_localizer["Record not found"]);

                model = _mapper.Map<FlightViewModel>(item);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Edit(FlightViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Update(_mapper.Map<Flight>(model));
                    TempData["SucessMessage"] = _localizer["Record saved successfully."];
                }
                else
                    throw new ArgumentException(_localizer["Invalid data."]);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
            }

            return RedirectToAction("Edit", new { id = model.Id });
        }
    }
}
