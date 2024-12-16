using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(SignInManager<IdentityUser> signInManager
            , UserManager<IdentityUser> _userManager
            , RoleManager<IdentityRole> _roleManager)
        {
            _signInManager = signInManager;
            userManager = _userManager;
            roleManager = _roleManager;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            //// Criar uma role "Admin" (opcional)
            //if (!await roleManager.RoleExistsAsync("Admin"))
            //{
            //    await roleManager.CreateAsync(new IdentityRole("Admin"));
            //}

            //// Criar o usuário de teste
            //var user = new IdentityUser
            //{
            //    UserName = "admin",
            //    Email = "admin@teste.com",
            //    EmailConfirmed = true // Para evitar validação de email
            //};

            //password = "Teste01*"; // Senha para o usuário

            //var userExists = await userManager.FindByEmailAsync(user.Email);
            //if (userExists == null)
            //{
            //    var result = await userManager.CreateAsync(user, password);
            //    if (result.Succeeded)
            //    {
            //        // Atribuir a role "Admin" ao usuário
            //        await userManager.AddToRoleAsync(user, "Admin");
            //        Console.WriteLine("Usuário de teste criado com sucesso!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Erro ao criar usuário: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            //    }
            //}

            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Login inválido.");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
