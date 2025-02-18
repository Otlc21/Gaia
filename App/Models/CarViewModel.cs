using App.Models.Utils;
using Domain.Entity;

namespace App.Models
{
    public class CarViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public string Mileage { get; set; }
        public string Year { get; set; }
        public string Location { get; set; }
        public byte Rating { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public int AvailableSpots { get; set; }

        public string Image { get; set; }
        public bool Active { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public List<Car> Itens { get; set; } = new List<Car>();
    }
}
