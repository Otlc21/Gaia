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
            PercentualAereo = item.PercentualAereo;
            PercentualCarro = item.PercentualCarro;
            PercentualHotel = item.PercentualHotel;
        }

        public Markup Convert()
        {
            return new Markup()
            {
                Id = this.Id,
                PercentualAereo = this.PercentualAereo,
                PercentualCarro = this.PercentualCarro,
                PercentualHotel = this.PercentualHotel,
            };
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public float PercentualAereo { get; set; }

        [Required]
        public float PercentualCarro { get; set; }

        [Required]
        public float PercentualHotel { get; set; }
    }
}
