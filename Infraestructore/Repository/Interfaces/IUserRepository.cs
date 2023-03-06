using Core.Dto;
using Core.Entities;

namespace Infraestructure.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> insertUser(User user);
        Task<bool> valitateUser(UserDto user);
    }
}
