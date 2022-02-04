using RentacarApi.Business.Interfaces.ServicesInterfaces;

namespace RentacarApi.Business.Interfaces
{
    public interface IBusinessLayer
    {
        ICarService CarService { get; }
        IUserService UserService { get; }
        IReservationService ReservationService { get; }
    }
}
