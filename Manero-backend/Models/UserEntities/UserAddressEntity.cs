﻿using Manero_backend.Interfaces.Users.Models;

namespace Manero_backend.Models.UserEntities
{
    public class UserAddressEntity 
    {
        public Guid Id { get; set; }
        public int AddressId { get; set; }
        public string Userid { get; set; } = null!;
        public bool BillingAddress { get; set; }
        public string TagName { get; set; } = null!;
        public DateTime Created { get; set; }
        public bool Active { get; set; }
        public DateTime InActivated { get; set; }
    }
}
