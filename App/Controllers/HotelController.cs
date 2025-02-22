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
    public class HotelController : Controller
    {
        private readonly IHotelService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;

        public HotelController(IHotelService service, IStringLocalizer<SharedResources> localizer, IMapper mapper)
        {
            _service = service;
            _localizer = localizer;
            _mapper = mapper;
        }

        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Index(HotelViewModel model)
        {
            if (model == null)
                model = new HotelViewModel();
            try
            {
                model.Total = await _service.Count(_mapper.Map<Hotel>(model));
                model.Itens = await _service.Get(_mapper.Map<Hotel>(model), model.Skip, model.Take);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
            }
            return View(model);
        }

        public async Task<IActionResult> Search()
        {
            var model = new HotelSearchViewModel();
            model.Itens = await _service.Get(new Hotel(), 0, 30);
            return View(model);
        }

        [Authorize(Roles = "ADM")]
        public IActionResult Create()
        {
            return View(new HotelViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Create(HotelViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Id = await _service.Insert(_mapper.Map<Hotel>(model));
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
            HotelViewModel model = new HotelViewModel();

            try
            {
                var item = await _service.Get(id);
                if (item == null)
                    throw new ArgumentException(_localizer["Record not found"]);

                model = _mapper.Map<HotelViewModel>(item);
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
        public async Task<IActionResult> Edit(HotelViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Update(_mapper.Map<Hotel>(model));
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
