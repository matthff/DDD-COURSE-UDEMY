using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDD_Domain.Entities;

namespace DDD_Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> FindByIdAsync(Guid id);
        Task<IEnumerable<T>> FindAllAsync();
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
