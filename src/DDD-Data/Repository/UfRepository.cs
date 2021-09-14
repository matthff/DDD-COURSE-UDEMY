using DDD_Data.Context;
using DDD_Domain.Entities;
using DDD_Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DDD_Data.Repository
{
    public class UfRepository : GenericRepository<UfEntity>, IUfRepository
    {
        private readonly DbSet<UfEntity> _dataset;

        public UfRepository(MySQLContext context) : base(context)
        {
            _dataset = context.Set<UfEntity>();
        }
    }
}
