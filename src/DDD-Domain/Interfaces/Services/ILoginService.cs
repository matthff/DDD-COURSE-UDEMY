using System.Threading.Tasks;
using DDD_Domain.DTOs;

namespace DDD_Domain.Interfaces.Services
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDTO user);
    }
}
