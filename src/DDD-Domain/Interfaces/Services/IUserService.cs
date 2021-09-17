using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDD_Domain.DTOs.User;
using DDD_Domain.Entities;

namespace DDD_Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetById(Guid id);
        Task<UserCreateResultDTO> Post(UserCreateDTO user);
        Task<UserUpdateResultDTO> Put(UserUpdateDTO user);
        Task<bool> Delete(Guid id);
    }
}
