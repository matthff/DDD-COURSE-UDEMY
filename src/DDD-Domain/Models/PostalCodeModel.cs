using System;
using DDD_Domain.Entities;

namespace DDD_Domain.Models
{
    public class PostalCodeModel : BaseModel
    {
        private string _postalCode;
        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _streetNumber;
        public string StreetNumber
        {
            get { return _streetNumber; }
            set { _streetNumber = string.IsNullOrEmpty(value) ? "S/N" : value; }
        }

        private Guid _cityId;
        public Guid CityId
        {
            get { return _cityId; }
            set { _cityId = value; }
        }
    }
}