using System;
using RentacarApi.Data.Models.Enums;

namespace RentacarApi.Data.Models
{
    public partial class Car
    {
        public Car()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public EBrand Brand { get; set; }
        public EType Type { get; set; }
        public string BodyType { get; set; } = null!;
        public DateTime ManifactureDate { get; set; }
        public int Kilometrage { get; set; }
        public string Color { get; set; } = null!;
        public int Power { get; set; }
        public bool AutomaticTransmission { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
