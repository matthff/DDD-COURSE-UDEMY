using System;
using System.Collections.Generic;
using DDD_Domain.DTOs.Uf;

namespace DDD_Service_Test.TestUf
{
    public class UfMock
    {
        public static Guid UfId { get; set; }
        public static string UfFederatedUnit { get; set; }
        public static string UfName { get; set; }

        public static UfDTO ufDTO;
        public static List<UfDTO> listUfDTO = new List<UfDTO>{
            new UfDTO()
            {
                Id = new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                FederatedUnit = "AC",
                Name = "Acre"
            },
            new UfDTO()
            {
                Id = new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                FederatedUnit = "AL",
                Name = "Alagoas"
            },
            new UfDTO()
            {
                Id = new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                FederatedUnit = "AM",
                Name = "Amazonas"
            },
            new UfDTO()
            {
                Id = new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                FederatedUnit = "AP",
                Name = "Amapá",
            },
            new UfDTO()
            {
                Id = new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                FederatedUnit = "BA",
                Name = "Bahia",
            },
            new UfDTO()
            {
                Id = new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                FederatedUnit = "CE",
                Name = "Ceará",
            },
            new UfDTO()
            {
                Id = new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"),
                FederatedUnit = "DF",
                Name = "Distrito Federal",
            },
            new UfDTO()
            {
                Id = new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"),
                FederatedUnit = "ES",
                Name = "Espírito Santo",
            },
            new UfDTO()
            {
                Id = new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"),
                FederatedUnit = "GO",
                Name = "Goiás",
            },
            new UfDTO()
            {
                Id = new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"),
                FederatedUnit = "MA",
                Name = "Maranhão",
            },
            new UfDTO()
            {
                Id = new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"),
                FederatedUnit = "MG",
                Name = "Minas Gerais",
            },
            new UfDTO()
            {
                Id = new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                FederatedUnit = "MS",
                Name = "Mato Grosso do Sul",
            },
            new UfDTO()
            {
                Id = new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"),
                FederatedUnit = "MT",
                Name = "Mato Grosso",
            },
            new UfDTO()
            {
                Id = new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"),
                FederatedUnit = "PA",
                Name = "Pará",
            },
            new UfDTO()
            {
                Id = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                FederatedUnit = "PB",
                Name = "Paraíba",
            },
            new UfDTO()
            {
                Id = new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                FederatedUnit = "PE",
                Name = "Pernambuco",
            },
            new UfDTO()
            {
                Id = new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"),
                FederatedUnit = "PI",
                Name = "Piauí",
            },
            new UfDTO()
            {
                Id = new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"),
                FederatedUnit = "PR",
                Name = "Paraná",
            },
            new UfDTO()
            {
                Id = new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"),
                FederatedUnit = "RJ",
                Name = "Rio de Janeiro",
            },
            new UfDTO()
            {
                Id = new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"),
                FederatedUnit = "RN",
                Name = "Rio Grande do Norte",
            },
            new UfDTO()
            {
                Id = new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"),
                FederatedUnit = "RO",
                Name = "Rondônia",
            },
            new UfDTO()
            {
                Id = new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"),
                FederatedUnit = "RR",
                Name = "Roraima",
            },
            new UfDTO()
            {
                Id = new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                FederatedUnit = "RS",
                Name = "Rio Grande do Sul",
            },
            new UfDTO()
            {
                Id = new Guid("b81f95e0-f226-4afd-9763-290001637ed4"),
                FederatedUnit = "SC",
                Name = "Santa Catarina",
            },
            new UfDTO()
            {
                Id = new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"),
                FederatedUnit = "SE",
                Name = "Sergipe",
            },
            new UfDTO()
            {
                Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                FederatedUnit = "SP",
                Name = "São Paulo",
            },
            new UfDTO()
            {
                Id = new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                FederatedUnit = "TO",
                Name = "Tocantins",
            }
        };

        public UfMock()
        {
            UfId = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee");
            UfFederatedUnit = "PB";
            UfName = "Paraíba";

            ufDTO = new UfDTO()
            {
                Id = UfId,
                FederatedUnit = UfFederatedUnit,
                Name = UfName
            };
        }
    }
}