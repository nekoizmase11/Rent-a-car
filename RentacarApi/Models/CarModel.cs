using System.ComponentModel.DataAnnotations;

namespace RentacarApi.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; } = null!;
        [Required]
        public string Type { get; set; } = null!;
        [Required]
        public string BodyType { get; set; } = null!;
        [Required]
        public DateTime ManifactureDate { get; set; }
        [Required]
        public int Kilometrage { get; set; }
        [Required]
        public string Color { get; set; } = null!;
        [Required]
        public int Power { get; set; }
        [Required]
        public bool AutomaticTransmission { get; set; }
    }
}
