using System;
using System.Collections.Generic;
using DDD_Domain.DTOs.User;

namespace DDD_Service_Test.TestUser
{
    public class UserMock
    {
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
        public static string UserNameUpdated { get; set; }
        public static string UserEmailUpdated { get; set; }
        public static Guid UserId { get; set; }

        public List<UserDTO> listUserDTO = new List<UserDTO>();
        public UserDTO userDTO;
        public UserCreateDTO userCreateDTO;
        public UserUpdateDTO userUpdateDTO;
        public UserCreateResultDTO userCreateResultDTO;
        public UserUpdateResultDTO userUpdateResultDTO;

        public UserMock()
        {
            UserId = Guid.NewGuid();
            UserName = Faker.Name.FullName();
            UserEmail = Faker.Internet.Email();
            UserNameUpdated = Faker.Name.FullName();
            UserEmailUpdated = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var userDTO = new UserDTO
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreatedAt = DateTime.UtcNow
                };
                listUserDTO.Add(userDTO);
            }

            userDTO = new UserDTO
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                CreatedAt = DateTime.UtcNow
            };

            userCreateDTO = new UserCreateDTO{
                Name = UserName,
                Email = UserEmail,
            };

            userUpdateDTO = new UserUpdateDTO{
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
            };

            userCreateResultDTO = new UserCreateResultDTO{
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                CreatedAt = DateTime.UtcNow
            };

            userUpdateResultDTO = new UserUpdateResultDTO{
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}