using AutoMapper;
using RentacarApi.Business.DtoModels;
using RentacarApi.Data.Models;
using RentacarApi.Models;

namespace RentacarApi.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Models.CarModel, CarDto>().ReverseMap().ForMember(x => x.ManifactureDate, opt => opt.Ignore());

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserModel, UserDto>().ReverseMap();

            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<ReservationModel, ReservationDto>().ReverseMap();
            CreateMap<CreateReservationModel, ReservationDto>().ReverseMap();

            CreateMap<CarType, CarTypeDto>().ReverseMap();
            CreateMap<CarTypeModel, CarTypeDto>().ReverseMap();
        }
    }
}
