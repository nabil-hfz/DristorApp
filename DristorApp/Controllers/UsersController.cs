using System;
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
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IRepository<Address, int> _addressRepository;

        public UsersController(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IRepository<Address, int> addressRepository
            )
        {
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
            this._addressRepository = addressRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var result = await _userRepository.GetAllAsync();
            var users = result.Select(user => new UserDTO()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = user.Roles.Select(role => role.Name).ToList(),
                Addresses = user.Addresses.Select(address => address.Id).ToList(),

            }); ;

            return Ok(users);
        }

        /*[HttpGet("{id")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var result = await _userRepository.GetByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }


            var users = new UserDTO()
            {
                Id = result.Id,
                Email = result.Email,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Roles = result.Roles.Select(role => role.Name).ToList(),
                Addresses = result.Addresses.Select(address => address.Id).ToList(),
            }; ;

            return Ok(users);
        }*/

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] UserDTO userDTO)
        {
            var roles = (await _roleRepository.GetAllAsync())
                .Where(role => userDTO.Roles.Contains(role.Name)).
                ToList();

            var adresses = (await _addressRepository.GetAllAsync())
                .Where(address => userDTO.Addresses.Contains(address.Id))
                .ToList();

            var user = new User
            {

                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Addresses = adresses,
                Roles = roles,
            };
            await _userRepository.CreateAsync(user);
            return CreatedAtAction("AddUser", user);

        }

        /*[HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, UserDTO userDTO)
        {

            if (id != userDTO.Id)
            {

                return BadRequest();
            }

            var currentUser = await _userRepository.GetByIdAsync(id);
            if (currentUser is null)
            {
                return NotFound("User not found");
            }

            currentUser.FirstName = userDTO.FirstName;
            currentUser.LastName = userDTO.LastName;
            currentUser.Email = userDTO.Email;
            currentUser.Roles.Clear();
            currentUser.Addresses.Clear();

            foreach (var roleName in userDTO.Roles)
            {

                var role = await _roleRepository.GetRoleByNameAsync(roleName);
                if (role is null)
                {
                    return NotFound("Role " + roleName + " not found");

                }
                currentUser.Roles.Add(role);

            }

            foreach (var addressId in userDTO.Addresses)
            {

                var address = await _addressRepository.GetByIdAsync(addressId);
                if (address is null)
                {
                    return NotFound("Address " + address + " not found");

                }
                currentUser.Addresses.Add(address);

            }

            await _userRepository.UpdateAsync(currentUser);
            return CreatedAtAction("UpdateUser", currentUser);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null)
            {
                return NotFound();

            }
            await _userRepository.DeleteAsync(user);

            return NoContent();
        }
    }*/
    }
}

