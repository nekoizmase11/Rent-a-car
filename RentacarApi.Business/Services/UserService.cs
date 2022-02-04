using AutoMapper;
using RentacarApi.Business.DtoModels;
using RentacarApi.Business.Interfaces.ServicesInterfaces;
using RentacarApi.Data.Interfaces;
using RentacarApi.Data.Models;

namespace RentacarApi.Business.Services
{
    internal class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<UserDto> GetAll()
        {
            var UserList = _unitOfWork.Users.GetAll();

            IEnumerable<UserDto> UsersDto = new List<UserDto>();
            _mapper.Map(UserList, UsersDto);
            return UsersDto;

        }

        public UserDto CreateUser(UserDto user)
        {
            User userToAdd = _mapper.Map<User>(user);

            User created = _unitOfWork.Users.Add(userToAdd);
            _unitOfWork.Commit();

            return _mapper.Map<UserDto>(created);
        }

        public UserDto GetUserById(int id)
        {
            User userEntity = _unitOfWork.Users.GetByID(id);
            if (userEntity != null)
                return _mapper.Map<UserDto>(userEntity);
            return null;

        }

    }
}
