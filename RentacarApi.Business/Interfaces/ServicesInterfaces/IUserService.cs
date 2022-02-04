using RentacarApi.Business.DtoModels;

namespace RentacarApi.Business.Interfaces.ServicesInterfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        UserDto CreateUser(UserDto user);
        UserDto GetUserById(int id);
    }
}
