using System;
using System.Threading.Tasks;
using DDD_Data.Context;
using DDD_Domain.Entities;
using DDD_Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DDD_Data.Repository
{
    public class CityRepository : GenericRepository<CityEntity>, ICityRepository
    {
        private readonly DbSet<CityEntity> _dataset;
        public CityRepository(MySQLContext context) : base(context)
        {
            _dataset = context.Set<CityEntity>();
        }

        public async Task<CityEntity> FindCompleteByIBGECode(int ibgeCode)
        {
            try
            {
                return await _dataset.Include(c => c.Uf)
                                     .FirstOrDefaultAsync(c => c.IbgeCode.Equals(ibgeCode));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CityEntity> FindCompleteByIdAsync(Guid id)
        {
            try
            {
                return await _dataset.Include(c => c.Uf)
                                     .FirstOrDefaultAsync(c => c.Id.Equals(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
