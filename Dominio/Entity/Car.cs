using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entity
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Model {  get; set; }

        [Required]
        public string Brand {  get; set; }

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
        public int Path { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public bool Active { get; set; }

    }
}
