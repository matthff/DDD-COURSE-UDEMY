using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDD_Domain.DTOs.City;

namespace DDD_Domain.Interfaces.Services
{
    public interface ICityService
    {
        Task<CityDTO> Get(Guid id);
        Task<CityCompleteDTO> GetCompleteById(Guid id);
        Task<CityCompleteDTO> GetCompleteByIBGE(int ibgeCode);
        Task<IEnumerable<CityDTO>> GetAll();
        Task<CityCreateResultDTO> Post(CityCreateDTO city);
        Task<CityUpdateResultDTO> Put(CityUpdateDTO city);
        Task<bool> Delete(Guid id);
    }
}