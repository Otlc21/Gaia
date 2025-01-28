using App.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class MarkupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
