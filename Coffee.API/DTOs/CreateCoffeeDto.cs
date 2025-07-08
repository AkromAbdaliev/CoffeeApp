using System.ComponentModel.DataAnnotations;

namespace Coffee.API.DTOs
{
    public class CreateCoffeeDto
    {
        [Required]
        public string Type { get; set; } = null!;

        public string? Bean { get; set; }

        [Required]
        public string Location { get; set; } = null!;

        [Range(0, 10)]
        public int NoOfShots { get; set; }

        [Range(0, 100)]
        public int? Score { get; set; }

        [Range(0.01, 100)]
        public decimal Price { get; set; }
    }
}
