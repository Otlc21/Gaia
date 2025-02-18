namespace App.Models
{
    public class FlightSearchViewModel
    {
        public bool OneWay { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Return { get; set; }
        public int Spots { get; set; }

        List<string> Locations { get; set; }
    }
}
