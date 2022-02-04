
namespace RentacarApi.Business.DtoModels
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string User { get; set; } = null!;
        public string Car { get; set; } = null!;
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }
        public string Status { get; set; } = null!;

        //public virtual Car Car { get; set; } = null!;
        //public virtual User User { get; set; } = null!;
    }
}
