using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class MarkupViewModel
    {
        public int Id { get; set; }
        public decimal Car { get; set; }
        public decimal Flight { get; set; }
        public decimal Hotel { get; set; }
    }
}
