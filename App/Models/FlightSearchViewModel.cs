using App.Models.Utils;
using Domain.Entity;

namespace App.Models
{
    public class FlightSearchViewModel : BaseViewModel
    {
        public bool OneWay { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Return { get; set; }
        public int Spots { get; set; }
        public List<Flight> Itens { get; set; }
        List<string> Locations { get; set; }
    }
}
