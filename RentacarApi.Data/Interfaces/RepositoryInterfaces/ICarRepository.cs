using RentacarApi.Data.Models;
using RentacarApi.Data.Models.Enums;

namespace RentacarApi.Data.Interfaces.RepositoryInterfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<CarType> GetTypesForBrand(EBrand brand);
    }
}
