using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string City {  get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public bool Active { get; set; }

    }
}
