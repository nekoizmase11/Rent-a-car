using AutoMapper;
using RentacarApi.Business.DtoModels;
using RentacarApi.Business.Interfaces.ServicesInterfaces;
using RentacarApi.Data.Interfaces;
using RentacarApi.Data.Models;

namespace RentacarApi.Business.Services
{
    internal class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public IEnumerable<ReservationDto> GetAll()
        {
            var ReservationList = _unitOfWork.Reservations.GetAll();
            List<ReservationDto> finalReservationList = new List<ReservationDto>();
            
            foreach (var reservation in ReservationList)
            {
                var user = _unitOfWork.Users.GetByID(reservation.UserId);
                var car = _unitOfWork.Cars.GetByID(reservation.CarId);
                var reservationDto = _mapper.Map<ReservationDto>(reservation);

                reservationDto.User = $"{user.Name} {user.LastName}";
                reservationDto.Car = $"{car.Brand} {car.BodyType}";

                finalReservationList.Add(reservationDto);
            }

            return finalReservationList;

        }

        public ReservationDto CreateReservation(ReservationDto reservation)
        {
            Reservation reservationToAdd = _mapper.Map<Reservation>(reservation);

            int compareResultFrom = DateTime.Compare(reservationToAdd.ReservedFrom, DateTime.Now);
            int compareResultTo = DateTime.Compare(reservationToAdd.ReservedTo, DateTime.Now);

            if (compareResultTo < 0)
            {
                reservationToAdd.Status = "Completed";
            }
            else if(compareResultFrom > 0)
            {
                reservationToAdd.Status = "Pending";
            }
            else { reservationToAdd.Status = "In progress"; }

            Reservation created = _unitOfWork.Reservations.Add(reservationToAdd);  
            _unitOfWork.Commit();

            return _mapper.Map<ReservationDto>(created);
        }

    }
}
