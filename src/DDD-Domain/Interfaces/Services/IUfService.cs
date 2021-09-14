using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDD_Domain.DTOs.Uf;

namespace DDD_Domain.Interfaces.Services
{
    public interface IUfService
    {
        Task<UfDTO> Get(Guid id);
        Task<IEnumerable<UfDTO>> GetAll();
    }
}