﻿using Manero_backend.Models.UserEntities;
using Manero_backend.Models;
using Manero_backend.Models.OrderEntities;
using Microsoft.AspNetCore.Identity;

namespace Manero_backend.Interfaces.Users.Models
{
    public interface IUserEntity 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreatedBy { get; set; }
      
    }
}
