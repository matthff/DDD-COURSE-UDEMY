using DDD_Data.Mapping;
using DDD_Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DDD_Data.Context
{
    public class MySQLContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = System.Guid.NewGuid(),
                    Name = "Admin",
                    Email = "admin@mail.com",
                    CreatedAt = System.DateTime.UtcNow,
                    UpdatedAt = System.DateTime.UtcNow
                }
            );
        }
    }
}
