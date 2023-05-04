﻿using Manero_backend.DTOs.User;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Interfaces.Product.Services;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Services
{
    public class RegisterServices : IRegisterService
    {
        private readonly IUserRepository _userRepo;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterServices(IUserRepository userRepo, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _userRepo = userRepo;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<UserResponse> CreateUserAsync(UserRequest userRequest)
        {
            var entity = UserFactory.CreateUserEntity();

            entity.Email = userRequest.Email;
            entity.FirstName = userRequest.FirstName;
            entity.LastName = userRequest.LastName;
            entity.PhoneNumber = userRequest.PhoneNumber;

            var result = await _userRepo.CheckAsync();
            if (!result)
            {
                try
                {
                    await _roleManager.CreateAsync(IdentityRoleFactory.CreateRole("User"));
                    await _roleManager.CreateAsync(IdentityRoleFactory.CreateRole("Admin"));
                    await _userRepo.CreateAsync(entity);
                    await _userManager.AddToRoleAsync(entity, "Admin");

                }
                catch { }
            } 
            return entity;
        }

        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> UpdateUserAsync(int id, UserRequest userRequest)
        {
            throw new NotImplementedException();
        }

    }
}