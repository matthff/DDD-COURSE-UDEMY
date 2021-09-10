using System;

namespace DDD_Domain.DTOs.User
{
    public class UserCreateResultDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
