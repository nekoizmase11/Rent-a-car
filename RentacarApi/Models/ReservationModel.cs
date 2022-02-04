namespace RentacarApi.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public string User { get; set; } = null!;
        public string Car { get; set; } = null!;
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }

        public string Status { get; set; } = null!;

    }
}
