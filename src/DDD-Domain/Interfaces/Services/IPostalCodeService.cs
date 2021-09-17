using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDD_Domain.DTOs.PostalCode;

namespace DDD_Domain.Interfaces.Services
{
    public interface IPostalCodeService
    {
        Task<PostalCodeDTO> GetById(Guid id);
        Task<PostalCodeDTO> GetByPostalCode(string postalCode);
        Task<PostalCodeCreateResultDTO> Post(PostalCodeCreateDTO postalCode);
        Task<PostalCodeUpdateResultDTO> Put(PostalCodeUpdateDTO postalCode);
        Task<bool> Delete(Guid id);        
    }
}