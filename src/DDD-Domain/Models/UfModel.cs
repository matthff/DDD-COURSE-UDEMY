using System;
using System.Collections.Generic;
using DDD_Domain.Entities;

namespace DDD_Domain.Models
{
    public class UfModel : BaseModel
    {
        private string _federatedUnit;
        public string FederatedUnit
        {
            get { return _federatedUnit; }
            set { _federatedUnit = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
