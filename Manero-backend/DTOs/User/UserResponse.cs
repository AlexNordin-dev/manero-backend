﻿using Manero_backend.Interfaces.Product.Models;

namespace Manero_backend.DTOs.User
{
    public class UserResponse : IUserResponse
    {
        public string Id {  get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
