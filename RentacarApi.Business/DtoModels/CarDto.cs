
using RentacarApi.Data.Models.Enums;

namespace RentacarApi.Business.DtoModels
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string BodyType { get; set; } = null!;
        public DateTime ManifactureDate { get; set; }
        public int Kilometrage { get; set; }
        public string Color { get; set; } = null!;
        public int Power { get; set; }
        public bool AutomaticTransmission { get; set; }

    }
}
