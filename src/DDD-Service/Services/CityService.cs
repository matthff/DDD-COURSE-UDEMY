using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DDD_Domain.DTOs.City;
using DDD_Domain.Entities;
using DDD_Domain.Interfaces.Repository;
using DDD_Domain.Interfaces.Services;
using DDD_Domain.Models;

namespace DDD_Service.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDTO>> GetAll()
        {
            var listEntity = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<CityDTO>>(listEntity);
        }

        public async Task<CityDTO> GetById(Guid id)
        {
            var entity = await _repository.FindByIdAsync(id);
            return _mapper.Map<CityDTO>(entity);
        }

        public async Task<CityCompleteDTO> GetCompleteByIBGE(int ibgeCode)
        {
            var entity = await _repository.FindCompleteByIBGECode(ibgeCode);
            return _mapper.Map<CityCompleteDTO>(entity);
        }

        public async Task<CityCompleteDTO> GetCompleteById(Guid id)
        {
            var entity = await _repository.FindCompleteByIdAsync(id);
            return _mapper.Map<CityCompleteDTO>(entity);
        }

        public async Task<CityCreateResultDTO> Post(CityCreateDTO city)
        {
            var model = _mapper.Map<CityModel>(city);
            var entity = _mapper.Map<CityEntity>(model);
            var result = await _repository.CreateAsync(entity);

            return _mapper.Map<CityCreateResultDTO>(result);
        }

        public async Task<CityUpdateResultDTO> Put(CityUpdateDTO city)
        {
            var model = _mapper.Map<CityModel>(city);
            var entity = _mapper.Map<CityEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<CityUpdateResultDTO>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
