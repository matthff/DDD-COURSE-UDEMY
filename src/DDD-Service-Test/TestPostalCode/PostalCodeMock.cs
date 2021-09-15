using System;
using System.Collections.Generic;
using DDD_Domain.DTOs.PostalCode;
using DDD_Domain.DTOs.City;
using DDD_Domain.DTOs.Uf;

namespace DDD_Service_Test.TestPostalCode
{
    public class PostalCodeMock
    {
        public static Guid PostalCodeId { get; set; }
        public static string PostalCodeZip { get; set; }
        public static string PostalCodeAddress { get; set; }
        public static string PostalCodeStreetNumber { get; set; }
        public static string PostalCodeAddressUpdated { get; set; }
        public static string PostalCodeStreetNumberUpdated { get; set; }
        public static Guid PostalCodeCityId { get; set; }

        public static CityCompleteDTO PostalCodeCity { get; set; }
        public static UfDTO PostalCodeCityUf { get; set; }

        public PostalCodeDTO postalCodeDTO;
        public PostalCodeCreateDTO postalCodeCreateDTO;
        public PostalCodeUpdateDTO postalCodeUpdateDTO;
        public PostalCodeCreateResultDTO postalCodeCreateResultDTO;
        public PostalCodeUpdateResultDTO postalCodeUpdateResultDTO;

        public PostalCodeMock()
        {
            PostalCodeCityUf = new UfDTO
            {
                Id = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                FederatedUnit = "PB",
                Name = "Paraíba"
            };
            PostalCodeCity = new CityCompleteDTO
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.City(),
                IbgeCode = Faker.RandomNumber.Next(1000000, 9999999),
                UfId = PostalCodeCityUf.Id,
                Uf = PostalCodeCityUf
            };

            PostalCodeId = Guid.NewGuid();
            PostalCodeZip = Faker.Address.ZipCode();
            PostalCodeAddress = Faker.Address.StreetAddress();
            PostalCodeStreetNumber = Faker.RandomNumber.Next(1, 2000).ToString();
            PostalCodeCityId = PostalCodeCity.Id;

            PostalCodeAddressUpdated = Faker.Address.StreetAddress();
            PostalCodeStreetNumberUpdated = Faker.RandomNumber.Next(1, 2000).ToString();

            postalCodeDTO = new PostalCodeDTO
            {
                Id = PostalCodeId,
                PostalCode = PostalCodeZip,
                Address = PostalCodeAddress,
                StreetNumber = PostalCodeStreetNumber,
                CityId = PostalCodeCity.Id,
                City = PostalCodeCity
            };

            postalCodeCreateDTO = new PostalCodeCreateDTO
            {
                PostalCode = PostalCodeZip,
                Address = PostalCodeAddress,
                StreetNumber = PostalCodeStreetNumber,
                CityId = PostalCodeCity.Id
            };

            postalCodeUpdateDTO = new PostalCodeUpdateDTO
            {
                Id = PostalCodeId,
                PostalCode = PostalCodeZip,
                Address = PostalCodeAddressUpdated,
                StreetNumber = PostalCodeStreetNumberUpdated,
                CityId = PostalCodeCity.Id
            };

            postalCodeCreateResultDTO = new PostalCodeCreateResultDTO
            {
                Id = PostalCodeId,
                PostalCode = PostalCodeZip,
                Address = PostalCodeAddress,
                StreetNumber = PostalCodeStreetNumber,
                CityId = PostalCodeCity.Id,
                CreatedAt = DateTime.UtcNow
            };

            postalCodeUpdateResultDTO = new PostalCodeUpdateResultDTO
            {
                Id = PostalCodeId,
                PostalCode = PostalCodeZip,
                Address = PostalCodeAddressUpdated,
                StreetNumber = PostalCodeStreetNumberUpdated,
                CityId = PostalCodeCity.Id,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
