namespace App.Models
{
    public class CarSearchViewModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Return { get; set; }
        public TimeOnly PickupTime { get; set; }
        public TimeOnly DropoffTime { get; set; }

        List<string> Locations { get; set; }
    }
}
