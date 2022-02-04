using RentacarApi.Data.Interfaces.RepositoryInterfaces;

namespace RentacarApi.Data.Interfaces
{
    public interface IUnitOfWork
    {
        ICarRepository Cars { get; }
        IUserRepository Users { get; }
        IReservationRepository Reservations { get; }

        int Commit();
        void Dispose();
    }
}
