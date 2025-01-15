using System.Diagnostics;
using Dominio.Resource;
using Dominio.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoomController : Controller
    {

        private readonly IRoomService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public RoomController(IRoomService service, IStringLocalizer<SharedResources> localizer)
        {
            _service = service;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index(RoomViewModel model)
        {
            if (model.Page <= 0) model.Page = 1;

            model.Total = await _service.Count(model.Convert());
            model.Itens = await _service.Get(model.Convert(), model.Skip, model.Take);

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new RoomViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.Insert(model.Convert());
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var location = await _service.Get(id);
            if (location == null) return NotFound();

            return View(new RoomViewModel(location));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(model.Convert());
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Inactivate(int id)
        {
            var location = await _service.Get(id);
            if (location == null) return NotFound();

            await _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
