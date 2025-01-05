using Dominio.Entity;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class MarkupViewModel : BaseViewModel
    {
        public MarkupViewModel()
        {

        }

        public MarkupViewModel(Markup item)
        {
            Id = item.Id;
            Flight = item.Flight;
            Car = item.Car;
            Hotel = item.Hotel;
        }

        public Markup Convert()
        {
            return new Markup()
            {
                Id = this.Id,
                Flight = this.Flight,
                Car = this.Car,
                Hotel = this.Hotel,
            };
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public float Flight { get; set; }

        [Required]
        public float Car { get; set; }

        [Required]
        public float Hotel { get; set; }

        public List<Markup> Itens { get; set; }
    }
}
