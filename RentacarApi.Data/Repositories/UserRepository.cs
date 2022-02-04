using Microsoft.EntityFrameworkCore;
using RentacarApi.Data.Interfaces.RepositoryInterfaces;
using RentacarApi.Data.Models;

namespace RentacarApi.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
