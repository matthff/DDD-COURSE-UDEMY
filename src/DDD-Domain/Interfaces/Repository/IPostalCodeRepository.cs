using System.Threading.Tasks;
using DDD_Domain.Entities;

namespace DDD_Domain.Interfaces.Repository
{
    public interface IPostalCodeRepository : IRepository<PostalCodeEntity>
    {
        Task<PostalCodeEntity> FindByPostalCode(string postalCode);
    }
}
