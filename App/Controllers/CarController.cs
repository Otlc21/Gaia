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
    public class CarController : Controller
    {
        private readonly ICarService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;

        public CarController(ICarService service, IStringLocalizer<SharedResources> localizer, IMapper mapper)
        {
            _service = service;
            _localizer = localizer;
            _mapper = mapper;
        }

        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Index(CarViewModel model)
        {
            if (model == null)
                model = new CarViewModel();
            try
            {
                model.Total = await _service.Count(_mapper.Map<Car>(model));
                model.Itens = await _service.Get(_mapper.Map<Car>(model), model.Skip, model.Take);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
            }
            return View(model);
        }
        public IActionResult Search()
        {
            return View();
        }

        [Authorize(Roles = "ADM")]
        public IActionResult Create()
        {
            return View(new CarViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Create(CarViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Id = await _service.Insert(_mapper.Map<Car>(model));
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
            CarViewModel model = new CarViewModel();

            try
            {
                var item = await _service.Get(id);
                if (item == null)
                    throw new ArgumentException(_localizer["Record not found"]);

                model = _mapper.Map<CarViewModel>(item);
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
        public async Task<IActionResult> Edit(CarViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Update(_mapper.Map<Car>(model));
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
