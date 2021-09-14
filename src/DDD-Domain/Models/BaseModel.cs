using System;

namespace DDD_Domain.Models
{
    public class BaseModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set
            {
                _createdAt = value;
            }
        }

        private DateTime _updatedAt;
        public DateTime UpdatedAt
        {
            get { return _updatedAt; }
            set { _updatedAt = value; }
        }
    }
}