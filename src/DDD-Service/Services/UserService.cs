using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DDD_Domain.DTOs.User;
using DDD_Domain.Entities;
using DDD_Domain.Interfaces.Repository;
using DDD_Domain.Interfaces.Services;
using DDD_Domain.Models;

namespace DDD_Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var listEntity = await _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(listEntity);
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            var entity = await _repository.FindByIdAsync(id);
            return _mapper.Map<UserDTO>(entity);
        }

        public async Task<UserCreateResultDTO> Post(UserCreateDTO user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.CreateAsync(entity);

            return _mapper.Map<UserCreateResultDTO>(result);
        }

        public async Task<UserUpdateResultDTO> Put(UserUpdateDTO user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<UserUpdateResultDTO>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
