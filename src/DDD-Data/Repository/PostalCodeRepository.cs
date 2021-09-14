using System;
using System.Threading.Tasks;
using DDD_Data.Context;
using DDD_Domain.Entities;
using DDD_Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DDD_Data.Repository
{
    public class PostalCodeRepository : GenericRepository<PostalCodeEntity>, IPostalCodeRepository
    {
        private readonly DbSet<PostalCodeEntity> _dataset;
        public PostalCodeRepository(MySQLContext context) : base(context)
        {
            _dataset = context.Set<PostalCodeEntity>();
        }

        public async Task<PostalCodeEntity> FindByPostalCode(string postalCode)
        {
            try
            {
                return await _dataset.Include(p => p.City)
                                     .ThenInclude(p => p.Uf)
                                     .FirstOrDefaultAsync(p => p.PostalCode.Equals(postalCode));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
