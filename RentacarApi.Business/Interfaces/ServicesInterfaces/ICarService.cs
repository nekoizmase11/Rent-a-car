using RentacarApi.Business.DtoModels;

namespace RentacarApi.Business.Interfaces.ServicesInterfaces
{
    public interface ICarService
    {
        IEnumerable<CarDto> GetAll();
        CarDto CreateCar(CarDto car);
        public CarDto GetCarById(int id);
        IEnumerable<CarBrandDto> GetCarBrands();
        IEnumerable<CarTypeDto> GetCarModels(int id);
    }
}
