using Dominio.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Models
{
    public class CarViewModel : BaseViewModel
    {
        public CarViewModel()
        {

        }

        public CarViewModel(Car item)
        {
            Id = item.Id;
            Model = item.Model;
            Brand = item.Brand;
            Year = item.Year;
            Category = item.Category;
            LocationId = item.LocationId;
            Price = item.Price;
            Amount = item.Amount;
            Creation = item.Creation;
        }

        public Car Convert()
        {
            return new Car()
            {
                Id = this.Id,
                Model = this.Model,
                Brand = this.Brand,
                Year = this.Year,
                Category = this.Category,
                LocationId = this.LocationId,
                Price = this.Price,
                Amount = this.Amount,
                Creation = this.Creation,
            };
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public short Year { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public bool Active { get; set; }
        public List<Car> Itens { get; set; }

        public IEnumerable<SelectListItem> Locations { get; set; }

    }
}
