using App.Models.Utils;
using Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class HotelViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public byte Rating { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ValidFrom { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ValidUntil { get; set; }
        public int AvailableSpots { get; set; }

        public string Image { get; set; }
        public bool Active { get; set; } = true;
        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Hotel> Itens { get; set; } = new List<Hotel>();
    }
}
