using AutoMapper;
using RentacarApi.Business.Interfaces;
using RentacarApi.Business.Interfaces.ServicesInterfaces;
using RentacarApi.Business.Services;
using RentacarApi.Data.Interfaces;

namespace RentacarApi.Business
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private ICarService carService;
        private IUserService userService;
        private IReservationService reservationService;

        public BusinessLayer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ICarService CarService
        {
            get
            {
                if(carService == null)
                {
                    carService = new CarService(_unitOfWork, _mapper);
                }
                return carService;
            }
        }

        public IUserService UserService
        {
            get
            {
                if (userService == null)
                {
                    userService = new UserService(_unitOfWork, _mapper);
                }
                return userService;
            }
        }

        public IReservationService ReservationService
        {
            get
            {
                if (reservationService == null)
                {
                    reservationService = new ReservationService(_unitOfWork, _mapper);
                }
                return reservationService;
            }
        }
    }
}
