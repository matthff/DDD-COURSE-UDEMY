using System;
using System.Collections.Generic;
using DDD_Domain.Entities;

namespace DDD_Domain.Models
{
    public class CityModel : BaseModel
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _ibgeCode;
        public int IbgeCode
        {
            get { return _ibgeCode; }
            set { _ibgeCode = value; }
        }

        private Guid _ufId;
        public Guid UfId
        {
            get { return _ufId; }
            set { _ufId = value; }
        }
    }
}