﻿using Manero_backend.DTOs.User;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Users.Models;
using Manero_backend.Interfaces.Users.Repositories;
using Manero_backend.Interfaces.Users.Service;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Manero_backend.Services
{
    public class AuthServices : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly TokenService _tokenService;

        public AuthServices(IUserRepository userRepo, RoleManager<IdentityRole> roleManager, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, TokenService tokenService)
        {
            _userRepo = userRepo;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }


        public async Task<bool> CheckEmailAsync(string email)
        {
               return await _userManager.Users.AnyAsync(x => x.Email == email);
        }
        public async Task<UserResponse> CreateUserAsync(UserRequest userRequest)
        {
            
            
            var entity = UserFactory.CreateUserEntity();

            entity.Email = userRequest.Email;
            entity.FirstName = userRequest.FirstName;
            entity.LastName = userRequest.LastName;
            entity.PhoneNumber = userRequest.PhoneNumber;
            entity.UserName = userRequest.Email;

            var result = await _userManager.Users.AnyAsync();
            if (!result)
            {
                try
                {
                    await _roleManager.CreateAsync(IdentityRoleFactory.CreateRole("User"));
                    await _roleManager.CreateAsync(IdentityRoleFactory.CreateRole("Admin"));
                    await _userManager.CreateAsync(entity, userRequest.Password);
                    await _userManager.AddToRoleAsync(entity, "Admin");
                    return entity;
                }
                catch { }
            } else
            {
                try
                {
                var saveResult = await _userManager.CreateAsync(entity, userRequest.Password);
                    if (saveResult.Succeeded)
                    {
                            await _userManager.AddToRoleAsync(entity, "User");
                            return entity;
                    }
                    else
                        {
                        return UserFactory.CreateUserResponse(saveResult.Errors.FirstOrDefault()!.Description ?? "Error",true, userRequest);
                        }
                }
                catch { }
            }
            return null!;
        }

        public async Task<string> LogInAsync(LogInReq req)
        {
            try
            {
                var entity = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == req.Email);
                if (entity != null!)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(entity, req.Password, false, false);
                if(signInResult.Succeeded)
                    {
                        var token = _tokenService.CreateToken(entity, "User");
                        return token;
                    }
                }

            }
            catch { }
            return null!;
        }
    }
}