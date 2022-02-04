using Microsoft.EntityFrameworkCore;
using RentacarApi.Data.Interfaces.RepositoryInterfaces;
using RentacarApi.Data.Models;
using RentacarApi.Data.Models.Enums;

namespace RentacarApi.Data.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly DbContext _context;

        public CarRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<CarType> GetTypesForBrand(EBrand brand)
        {
            var result = _context.Set<BrandType>().AsNoTracking().ToList();
            var filtered = result.Where(x => x.BrandId == brand).ToList();
            var final = filtered.Select(x => new CarType { Id = (int)x.TypeId, Name = x.TypeId.ToString() });

            return final;
        }
    }
}
