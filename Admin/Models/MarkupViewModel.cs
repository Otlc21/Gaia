using Dominio.Entity;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class MarkupViewModel : BaseViewModel
    {
        public MarkupViewModel()
        {

        }

        public MarkupViewModel(Markup item)
        {
            Id = item.Id;
            PercentualFlight = item.Flight;
            PercentualCar = item.Car;
            PercentualHotel = item.Hotel;
        }

        public Markup Convert()
        {
            return new Markup()
            {
                Id = this.Id,
                Flight = this.PercentualFlight,
                Car = this.PercentualCar,
                Hotel = this.PercentualHotel,
            };
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public float PercentualFlight { get; set; }

        [Required]
        public float PercentualCar { get; set; }

        [Required]
        public float PercentualHotel { get; set; }

        public List<Markup> Itens { get; set; }
    }
}
