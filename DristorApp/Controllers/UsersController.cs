﻿using System;
using DristorApp.Data.DTOs.User;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;
using DristorApp.Repositories.Roles;
using DristorApp.Repositories.UserRepository;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace DristorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _usersRepository;
        private readonly IRoleRepository _rolesRepository;
        private readonly IRepository<Address, int> _addressRepository;

        public UsersController(IUserRepository usersRepository, IRoleRepository rolesRepository, IRepository<Address, int> addressRepository)
        {
            _usersRepository = usersRepository;
            _rolesRepository = rolesRepository;
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = (await _usersRepository.GetAllAsync()).Select(user => new UserDTO()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = user.Roles is not null ? user.Roles.Select(x => x.Name).ToList():null,
                Addresses = user.Roles is not null ?  user.Addresses.Select(x => x.Id).ToList() : null
            });

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _usersRepository.GetUserByIdAndRolesAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = user.Roles.Select(x => x.Name).ToList(),
                Addresses = user.Addresses.Select(x => x.Id).ToList()
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var realUser = await _usersRepository.GetUserByIdAndRolesAsync(id);
            if (realUser is null)
            {
                return NotFound();
            }

            realUser.FirstName = user.FirstName;
            realUser.LastName = user.LastName;
            realUser.Email = user.Email;
            realUser.Roles.Clear();
            realUser.Addresses.Clear();

            foreach (var roleName in user.Roles)
            {
                var role = await _rolesRepository.GetRoleByNameAsync(roleName);
                if (role is null)
                {
                    return NotFound();
                }
                realUser.Roles.Add(role);
            }

            foreach (var addressId in user.Addresses)
            {
                var address = await _addressRepository.GetByIdAsync(addressId);
                if (address is null)
                {
                    return NotFound();
                }
                realUser.Addresses.Add(address);
            }

            await _usersRepository.UpdateAsync(realUser);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] UserDTO dto)
        {
            var roles = (await _rolesRepository.GetAllAsync())
                .Where(role => dto.Roles.Contains(role.Name))
                .ToList();
            var addresses = (await _addressRepository.GetAllAsync())
                .Where(address => dto.Addresses.Contains(address.Id))
                .ToList();

            var user = new User
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Addresses = addresses,
                Roles = roles
            };
            await _usersRepository.CreateAsync(user);

            return CreatedAtAction("GetUser", user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _usersRepository.GetUserByIdAndRolesAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _usersRepository.DeleteAsync(user);

            return NoContent();
        }
    }
}
