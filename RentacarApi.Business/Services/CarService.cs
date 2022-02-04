using AutoMapper;
using RentacarApi.Business.DtoModels;
using RentacarApi.Business.Interfaces.ServicesInterfaces;
using RentacarApi.Data.Interfaces;
using RentacarApi.Data.Models;
using RentacarApi.Data.Models.Enums;

namespace RentacarApi.Business.Services
{
    internal class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<CarDto> GetAll()
        {
            var CarList = _unitOfWork.Cars.GetAll();

            IEnumerable<CarDto>  CarsDto = new List<CarDto>();
            _mapper.Map(CarList, CarsDto);

            return CarsDto;
        }

        public IEnumerable<CarBrandDto> GetCarBrands()
        {
            var brandsDto = Enum.GetValues(typeof(EBrand))
                .Cast<EBrand>()
                .Select(value => new CarBrandDto { Id = (int)value, Name = value.ToString()})
                .ToList();

            return brandsDto;
        }

        public IEnumerable<CarTypeDto> GetCarModels(int id)
        {
            var result = _unitOfWork.Cars.GetTypesForBrand((EBrand)id).ToList();
            
            List<CarTypeDto> resultsDto = new List<CarTypeDto>();
            _mapper.Map(result, resultsDto);

            return resultsDto;
        }

        public CarDto CreateCar(CarDto car)
        {
            Car carToAdd = _mapper.Map<Car>(car);

            Car created = _unitOfWork.Cars.Add(carToAdd);
            _unitOfWork.Commit();

            return _mapper.Map<CarDto>(created);
        }

        public CarDto GetCarById(int id)
        {
            Car carEntity = _unitOfWork.Cars.GetByID(id);
            if (carEntity != null)
                return _mapper.Map<CarDto>(carEntity);
            return null;

        }
    }
}
