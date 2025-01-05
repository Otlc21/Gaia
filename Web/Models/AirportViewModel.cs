using Dominio.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Models
{
    public class AirportViewModel : BaseViewModel
    {
        public AirportViewModel()
        {

        }

        public AirportViewModel(Airport item)
        {
            Id = item.Id;
            Code = item.Code;
            Description = item.Description;
            LocationId = item.LocationId;
            Creation = item.Creation;
        }

        public Airport Convert()
        {
            return new Airport()
            {
                Id = this.Id,
                Code = this.Code,
                Description = this.Description,
                LocationId = this.LocationId,
                Creation = this.Creation,
            };
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public bool Active { get; set; }

        public List<Airport> Itens { get; set; }

        public IEnumerable<SelectListItem> Locations { get; set; }

    }
}
