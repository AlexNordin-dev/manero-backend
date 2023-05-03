﻿using Manero_backend.DTOs.User;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;

        public UserController(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfileRequest profileRequest)
        {
            UserEntity userEntity = profileRequest;

            if (ModelState.IsValid)
            {
                var res = await _userManager.CreateAsync(userEntity);
                if (res.Succeeded)
                    return Created("", res);
            }
            return BadRequest();
        }
    }
}
