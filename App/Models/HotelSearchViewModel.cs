using Domain.Entity;

namespace App.Models
{
    public class HotelSearchViewModel
    {
        public string Location { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Guest { get; set; }
        public string Price { get; set; }

        List<string> Locations { get; set; }
    }
}
