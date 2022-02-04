
namespace RentacarApi.Business.DtoModels
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public long Jmbg { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        //public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
