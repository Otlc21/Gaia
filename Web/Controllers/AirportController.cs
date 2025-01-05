using System.Diagnostics;
using Dominio.Resource;
using Dominio.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using RegraNegocio.Servico;
using Web.Models;

namespace Web.Controllers
{
    public class AirportController : Controller
    {

        private readonly IAirportService _service;
        private readonly ILocationService _locationService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public AirportController(IAirportService service, ILocationService locationService, IStringLocalizer<SharedResources> localizer)
        {
            _service = service;
            _locationService = locationService;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index(AirportViewModel model)
        {
            if (model.Page <= 0) model.Page = 1;

            model.Total = await _service.Count(model.Convert());
            model.Itens = await _service.Get(model.Convert(), model.Skip, model.Take);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new AirportViewModel();

            await InitializeViewModelAsync(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AirportViewModel model)
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
            var airport = await _service.Get(id);
            if (airport == null) return NotFound();

            var model = new AirportViewModel(airport);
            await InitializeViewModelAsync(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AirportViewModel model)
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
            var airport = await _service.Get(id);
            if (airport == null) return NotFound();

            await _service.Delete(id);
            return RedirectToAction("Index");
        }

        private async Task InitializeViewModelAsync(AirportViewModel model)
        {
            model.Locations = (await _locationService.Get(null, 0, 20))
                .Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = $"{l.City} {l.State}, {l.Country}"
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
