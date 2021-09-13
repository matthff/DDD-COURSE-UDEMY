using System;
using Newtonsoft.Json;

namespace DDD_Domain.DTOs.Login
{
    public class LoginResultDTO
    {
        [JsonProperty("authenticated")]
        public bool Authenticated { get; set; }
        
        [JsonProperty("create")]
        public DateTime Create { get; set; }
        
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }
        
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        
        [JsonProperty("userName")]
        public string UserName { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}