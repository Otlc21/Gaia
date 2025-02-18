using Domain.Entity;

namespace App.Models
{
    public class HomeViewModel
    {
        public CarSearchViewModel CarSearchViewModel { get; set; }
        public HotelSearchViewModel HotelSearchViewModel { get; set; }
        public FlightSearchViewModel FlightSearchViewModel { get; set; }

        public string Email { get; set; }

        public List<Hotel> TrendingHotel { get; set; }
        public List<Flight> TrendingFlight { get; set; }
        public List<Car> TrendingCar { get; set; }

    }
}
