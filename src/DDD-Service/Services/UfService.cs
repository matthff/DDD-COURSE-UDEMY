using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DDD_Domain.DTOs.Uf;
using DDD_Domain.Interfaces.Repository;
using DDD_Domain.Interfaces.Services;

namespace DDD_Service.Services
{
    public class UfService : IUfService
    {
        private readonly IUfRepository _repository;
        private readonly IMapper _mapper;

        public UfService(IUfRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UfDTO>> GetAll()
        {
            var entity = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<UfDTO>>(entity);
        }

        public async Task<UfDTO> GetById(Guid id)
        {
            var entity = await _repository.FindByIdAsync(id);
            return _mapper.Map<UfDTO>(entity);
        }
    }
}
