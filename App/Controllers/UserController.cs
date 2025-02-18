using App.Models;
using AutoMapper;
using Domain.Entity;
using Domain.Resource;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Web.Controllers
{
    //[Authorize(Roles = "ADM")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IStringLocalizer<SharedResources> localizer, IMapper mapper)
        {
            _service = service;
            _localizer = localizer;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(UserViewModel model)
        {
            if (model == null)
                model = new UserViewModel();
            try
            {
                //model.Total = await _service.Count(_mapper.Map<User>(model));
                //model.Itens = await _service.Get(_mapper.Map<User>(model), model.Skip, model.Take);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
            }
            return View(model);
        }

        public IActionResult Create()
        {
            return View(new UserViewModel());
        }

        [HttpPut]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //model.Id = await _service.Insert(_mapper.Map<User>(model));
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

        public async Task<IActionResult> Edit(Guid id)
        {
            UserViewModel model = new UserViewModel();

            try
            {
                //var item = await _service.Get(id);
                //if (item == null)
                //    throw new ArgumentException(_localizer["Record not found"]);

                //model = _mapper.Map<UserViewModel>(item);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //await _service.Update(_mapper.Map<User>(model));
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
