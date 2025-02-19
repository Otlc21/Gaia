using App.Models;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService _carService;
        private readonly IFlightService _flightService;
        private readonly IHotelService _hotelService;

        public HomeController(ILogger<HomeController> logger,
            ICarService carService,
            IFlightService flightService,
            IHotelService hotelService)
        {
            _logger = logger;
            _carService = carService;
            _flightService = flightService;
            _hotelService = hotelService;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.TrendingHotel = await _hotelService.GetTrending();
            model.TrendingCar = await _carService.GetTrending();
            model.TrendingFlight = await _flightService.GetTrending();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Term()
        {
            return View();
        }
    }
}
