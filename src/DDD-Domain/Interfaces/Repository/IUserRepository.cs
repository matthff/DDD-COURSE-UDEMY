using System.Threading.Tasks;
using DDD_Domain.Entities;
using DDD_Domain.Interfaces;

namespace DDD_Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}
