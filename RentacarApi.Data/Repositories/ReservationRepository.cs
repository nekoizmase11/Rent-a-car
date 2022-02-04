using Microsoft.EntityFrameworkCore;
using RentacarApi.Data.Interfaces.RepositoryInterfaces;
using RentacarApi.Data.Models;

namespace RentacarApi.Data.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(DbContext context) : base(context)
        {
        }
    }
}
