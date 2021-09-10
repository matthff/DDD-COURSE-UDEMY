using System.Threading.Tasks;
using DDD_Data.Context;
using DDD_Domain.Entities;
using DDD_Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DDD_Data.Repository
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        private readonly DbSet<UserEntity> _dataset;

        public UserRepository(MySQLContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }
        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
