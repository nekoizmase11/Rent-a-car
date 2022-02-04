using RentacarApi.Business.DtoModels;

namespace RentacarApi.Business.Interfaces.ServicesInterfaces
{
    public interface IReservationService
    {
        IEnumerable<ReservationDto> GetAll();
        ReservationDto CreateReservation(ReservationDto reservation);
    }
}
