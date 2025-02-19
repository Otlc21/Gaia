using App.Models.Utils;
using Domain.Entity;

namespace App.Models
{
    public class CarSearchViewModel : BaseViewModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Return { get; set; }
        public TimeOnly PickupTime { get; set; }
        public TimeOnly DropoffTime { get; set; }
        public List<Car> Itens { get; set; }
        List<string> Locations { get; set; }
    }
}
