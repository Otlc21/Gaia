using Dominio.Entidade;
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
            PercentualFlight = item.PercentualFlight;
            PercentualCar = item.PercentualCar;
            PercentualHotel = item.PercentualHotel;
        }

        public Markup Convert()
        {
            return new Markup()
            {
                Id = this.Id,
                PercentualFlight = this.PercentualFlight,
                PercentualCar = this.PercentualCar,
                PercentualHotel = this.PercentualHotel,
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
