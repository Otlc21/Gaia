using App.Models;
using AutoMapper;
using Domain.Entity;
using Domain.Resource;
using Domain.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace Web.Controllers
{
    public class AirportController : Controller
    {
        private readonly IAirportService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;

        public AirportController(IAirportService service, IStringLocalizer<SharedResources> localizer, IMapper mapper)
        {
            _service = service;
            _localizer = localizer;
            _mapper = mapper;
        }

        public async Task<IActionResult> Get(string text)
        {
            try
            {
                var cookie = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];

                if (cookie != null)
                {
                    var requestCulture = CookieRequestCultureProvider.ParseCookieValue(cookie);
                    var cultureName = requestCulture.Cultures.FirstOrDefault().Value.ToString();
                    var result = await _service.Get(text, cultureName);
                    return Json(result);
                }
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
            }

            return BadRequest();
        }
    }
}
