using System;
using System.Threading.Tasks;
using AutoMapper;
using DDD_Domain.DTOs.PostalCode;
using DDD_Domain.Entities;
using DDD_Domain.Interfaces.Services;
using DDD_Domain.Interfaces.Repository;
using DDD_Domain.Models;

namespace DDD_Service.Services
{
    public class PostalCodeService : IPostalCodeService
    {
        private readonly IPostalCodeRepository _repository;
        private readonly IMapper _mapper;

        public PostalCodeService(IPostalCodeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PostalCodeDTO> Get(Guid id)
        {
            var entity = await _repository.FindByIdAsync(id);
            return _mapper.Map<PostalCodeDTO>(entity);
        }

        public async Task<PostalCodeDTO> Get(string postalCode)
        {
            var entity = await _repository.FindByPostalCode(postalCode);
            return _mapper.Map<PostalCodeDTO>(entity);
        }

        public async Task<PostalCodeCreateResultDTO> Post(PostalCodeCreateDTO postalCode)
        {
            var model = _mapper.Map<PostalCodeModel>(postalCode);
            var entity = _mapper.Map<PostalCodeEntity>(model);
            var result = await _repository.CreateAsync(entity);

            return _mapper.Map<PostalCodeCreateResultDTO>(result);
        }

        public async Task<PostalCodeUpdateResultDTO> Put(PostalCodeUpdateDTO postalCode)
        {
            var model = _mapper.Map<PostalCodeModel>(postalCode);
            var entity = _mapper.Map<PostalCodeEntity>(model);
            var result = await _repository.CreateAsync(entity);

            return _mapper.Map<PostalCodeUpdateResultDTO>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
