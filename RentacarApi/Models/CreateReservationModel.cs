namespace RentacarApi.Models
{
    public class CreateReservationModel
    {
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }

    }
}
