using Microsoft.EntityFrameworkCore;
using RentacarApi.Data.Interfaces;
using RentacarApi.Data.Interfaces.RepositoryInterfaces;
using RentacarApi.Data.Repositories;

namespace RentacarApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        private ICarRepository cars;
        private IUserRepository users;
        private IReservationRepository reservations;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public ICarRepository Cars
        {
            get
            {
                if(cars == null)
                {
                    cars = new CarRepository(_context);
                }
                return cars;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if(users == null)
                {
                    users = new UserRepository(_context);
                }
                return users;
            }
        }

        public IReservationRepository Reservations
        {
            get
            {
                if (reservations == null)
                {
                    reservations = new ReservationRepository(_context);
                }
                return reservations;
            }
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
