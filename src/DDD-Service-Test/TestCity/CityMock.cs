using System;
using System.Collections.Generic;
using DDD_Domain.DTOs.City;
using DDD_Domain.DTOs.Uf;

namespace DDD_Service_Test.TestCity
{
    public class CityMock
    {
        public static Guid CityId { get; set; }
        public static string CityName { get; set; }
        public static int CityIbgeCode { get; set; }
        public static string CityNameUpdated { get; set; }
        public static int CityIbgeCodeUpdated { get; set; }
        public static Guid CityUfId { get; set; }
        public static UfDTO CityUf { get; set; }

        public CityDTO cityDTO;
        public CityCompleteDTO cityCompleteDTO;
        public List<CityDTO> listCityDTO = new List<CityDTO>();
        public CityCreateDTO cityCreateDTO;
        public CityUpdateDTO cityUpdateDTO;
        public CityCreateResultDTO cityCreateResultDTO;
        public CityUpdateResultDTO cityUpdateResultDTO;

        public CityMock()
        {
            CityId = Guid.NewGuid();
            CityName = Faker.Address.City();
            CityIbgeCode = Faker.RandomNumber.Next(1000000, 9999999);
            CityUfId = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee");
            CityUf = new UfDTO
            {
                Id = CityUfId,
                FederatedUnit = "PB",
                Name = "Paraíba"
            };

            CityNameUpdated = Faker.Address.City();
            CityIbgeCodeUpdated = Faker.RandomNumber.Next(1000000, 9999999);

            cityDTO = new CityDTO
            {
                Id = CityId,
                Name = CityName,
                IbgeCode = CityIbgeCode,
                UfId = CityUfId
            };

            cityCompleteDTO = new CityCompleteDTO
            {
                Id = CityId,
                Name = CityName,
                IbgeCode = CityIbgeCode,
                UfId = CityUfId,
                Uf = CityUf
            };

            for (int i = 0; i < 10; i++)
            {
                var cityDTO = new CityDTO
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.City(),
                    IbgeCode = Faker.RandomNumber.Next(1000000, 9999999),
                    UfId = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee")
                };
                listCityDTO.Add(cityDTO);
            }

            cityCreateDTO = new CityCreateDTO
            {
                Name = CityName,
                IbgeCode = CityIbgeCode,
                UfId = CityUfId
            };

            cityUpdateDTO = new CityUpdateDTO
            {
                Id = CityId,
                Name = CityNameUpdated,
                IbgeCode = CityIbgeCodeUpdated,
                UfId = CityUfId
            };

            cityCreateResultDTO = new CityCreateResultDTO
            {
                Id = CityId,
                Name = CityName,
                IbgeCode = CityIbgeCode,
                UfId = CityUfId,
                CreatedAt = DateTime.UtcNow
            };

            cityUpdateResultDTO = new CityUpdateResultDTO
            {
                Id = CityId,
                Name = CityNameUpdated,
                IbgeCode = CityIbgeCodeUpdated,
                UfId = CityUfId,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
