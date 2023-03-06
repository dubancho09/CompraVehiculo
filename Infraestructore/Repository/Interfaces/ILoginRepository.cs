using Core.Dto;

namespace Infraestructure.Repository.Interfaces
{
    public interface ILoginRepository
    {
        Task<string> Login(UserLogin user);
    }
}
