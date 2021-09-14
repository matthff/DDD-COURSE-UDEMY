using System;
using System.Threading.Tasks;
using DDD_Domain.Entities;

namespace DDD_Domain.Interfaces.Repository
{
    public interface ICityRepository : IRepository<CityEntity>
    {
        Task<CityEntity> FindCompleteByIdAsync(Guid id);
        Task<CityEntity> FindCompleteByIBGECode(int ibgeCode);
    }
}
