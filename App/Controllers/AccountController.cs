using App.Models;
using AutoMapper;
using Domain.Entity;
using Domain.Resource;
using Domain.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;

        public AccountController(IUserService service, IStringLocalizer<SharedResources> localizer, IMapper mapper)
        {
            _service = service;
            _localizer = localizer;
            _mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = await _service.Login(model.Email, model.Password);
                    if (user != null)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Name),
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Role, user.Profile.ToString())
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = model.RememberMe
                        };

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);

                        return RedirectToAction("Home", "Index");
                    }
                }

                throw new ArgumentException(_localizer["Invalid data."]);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                string mensagem = _localizer["Invalid data."];
                if (ModelState.IsValid)
                {
                    (bool sucesso, mensagem) = await _service.Register(model.Name, model.Email, model.Password, model.ConfirmPassword);
                    if (sucesso)
                    {
                        TempData["SucessMessage"] = mensagem;
                        return RedirectToAction("Home", "Index");
                    }
                }

                throw new ArgumentException(mensagem);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
            }

            return View(model);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            try
            {
                string mensagem = _localizer["Invalid data."];
                if (ModelState.IsValid)
                {
                    (bool sucesso, mensagem) = await _service.ForgotPassword(model.Email);
                    if (sucesso)
                    {
                        TempData["SucessMessage"] = mensagem;
                        return View("ForgotPasswordConfirmation", model);
                    }
                }

                throw new ArgumentException(mensagem);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPasswordConfirmation(ForgotPasswordViewModel model)
        {
            try
            {
                string mensagem = _localizer["Invalid data."];
                if (ModelState.IsValid)
                {
                    (bool sucesso, mensagem, Guid id) = await _service.ForgotPasswordConfirmation(model.Email, model.ConfirmCode);
                    if (sucesso)
                    {
                        return RedirectToAction("ChangePassword", new { id = id });
                    }
                }

                throw new ArgumentException(mensagem);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
            }

            return View(model);
        }

        public IActionResult ChangePassword(Guid id)
        {
            return View(new ChangePasswordViewModel() { Id = id });
        }

        [HttpPost]

        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                string mensagem = _localizer["Invalid data."];
                if (ModelState.IsValid)
                {
                    (bool sucesso, mensagem) = await _service.ChangePassword(model.Id, model.Password, model.ConfirmPassword);
                    if (sucesso)
                    {
                        TempData["SucessMessage"] = mensagem;
                        return RedirectToAction("Login");
                    }
                }

                throw new ArgumentException(mensagem);
            }
            catch (Exception ex)
            {
                TempData["ErroMessage"] = ex.Message;
            }

            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
