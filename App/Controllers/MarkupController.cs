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
    [Authorize(Roles = "ADM")]
    public class MarkupController : Controller
    {
        private readonly IMarkupService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;

        public MarkupController(IMarkupService service, IStringLocalizer<SharedResources> localizer, IMapper mapper)
        {
            _service = service;
            _localizer = localizer;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            MarkupViewModel model = new MarkupViewModel();

            try
            {
                var item = await _service.Get(new Markup(), 0, 1);
                if (item == null)
                    throw new ArgumentException(_localizer["Record not found"]);

                model = _mapper.Map<MarkupViewModel>(item.FirstOrDefault());
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(MarkupViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Update(_mapper.Map<Markup>(model));
                    TempData["SucessMessage"] = _localizer["Record saved successfully."];
                }
                else
                    throw new ArgumentException(_localizer["Invalid data."]);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
