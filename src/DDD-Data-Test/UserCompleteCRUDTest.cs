using System;
using System.Linq;
using System.Threading.Tasks;
using DDD_Data.Context;
using DDD_Data.Repository;
using DDD_Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DDD_Data_Test
{
    public class UserCompleteCRUDTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UserCompleteCRUDTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }


        [Fact(DisplayName = "User CRUD operations")]
        [Trait("CRUD", "UserEntity")]
        public async Task IsPossibleCRUDInUserDatabase()
        {
            using (var context = _serviceProvider.GetService<MySQLContext>())
            {
                UserRepository _repository = new UserRepository(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var _registroCriado = await _repository.CreateAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);

                _entity.Name = Faker.Name.First();
                var _registroAtualizado = await _repository.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Email, _registroAtualizado.Email);
                Assert.Equal(_entity.Name, _registroAtualizado.Name);

                var _registroExiste = await _repository.ExistsAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repository.FindByIdAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Email, _registroSelecionado.Email);
                Assert.Equal(_registroAtualizado.Name, _registroSelecionado.Name);

                var _todosRegistros = await _repository.FindAllAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 1);

                var _removeu = await _repository.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);

                var _usuarioPadrao = await _repository.FindByLogin("admin@mail.com");
                Assert.NotNull(_usuarioPadrao);
                Assert.Equal("admin@mail.com", _usuarioPadrao.Email);
                Assert.Equal("Admin", _usuarioPadrao.Name);
            }
        }
    }
}
