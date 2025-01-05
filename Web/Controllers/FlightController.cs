using System.Diagnostics;
using Dominio.Entity;
using Dominio.Resource;
using Dominio.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Web.Models;

namespace Web.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService _service;
        private readonly IAirportService _airportService;
        private readonly IAirlineService _airlineService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public FlightController(IFlightService service, IAirportService airportService, IAirlineService airlineService, IStringLocalizer<SharedResources> localizer)
        {
            _service = service;
            _airportService = airportService;
            _airlineService = airlineService;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index(FlightViewModel model)
        {
            if (model.Page <= 0) model.Page = 1;

            model.Total = await _service.Count(model.Convert());
            model.Itens = await _service.Get(model.Convert(), model.Skip, model.Take);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new FlightViewModel();

            await InitializeViewModelAsync(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FlightViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.Insert(model.Convert());
                return RedirectToAction("Index");
            }

            await InitializeViewModelAsync(model);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var flight = await _service.Get(id);
            if (flight == null) return NotFound();

            var model = new FlightViewModel(flight);

            await InitializeViewModelAsync(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FlightViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(model.Convert());
                return RedirectToAction("Index");
            }

            await InitializeViewModelAsync(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Inactivate(int id)
        {
            var flight = await _service.Get(id);
            if (flight == null) return NotFound();

            await _service.Delete(id);
            return RedirectToAction("Index");
        }

        private async Task InitializeViewModelAsync(FlightViewModel model)
        {
            model.Airports = (await _airportService.Get(null, 0, 20))
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.Description
                    })
                    .Prepend(new SelectListItem
                    {
                        Value = "",
                        Text = _localizer["Select"]
                    })
                    .ToList();

            model.Airlines = (await _airlineService.Get(null, 0, 20))
                    .Select(a => new SelectListItem
                    {
                        Value = a.Id.ToString(),
                        Text = a.Name
                    })
                    .Prepend(new SelectListItem
                    {
                        Value = "",
                        Text = _localizer["Select"]
                    })
                    .ToList();
        }
    }
}
