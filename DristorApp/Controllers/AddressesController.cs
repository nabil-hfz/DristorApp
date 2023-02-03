using System;
using System.Reflection.Emit;
using DristorApp.Data.DTOs.Address;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;
using DristorApp.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DristorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IRepository<Address, int> _addressRepository;
        private readonly IUserRepository _userRepository;
        public AddressesController(IRepository<Address, int> addressRepository, IUserRepository userRepository)
        {
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            return await _addressRepository.GetAllAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);

            if (address == null)
            {
                return NotFound("Address not found id: "+id);
            }

            return address;
        }


        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        /*public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            await _addressRepository.CreateAsync(address);
            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }*/
        public async Task<ActionResult<Address>> PostAddress(AddressCreateDTO dto)
        {
            var user = await _userRepository.GetByIdAsync(dto.User);
            if (user is null)
            {
                return NotFound("User not found User: "+ dto.User);
            }

            var address = new Address
            {
                Id = dto.Id,
                Country = dto.Country,
                City = dto.City,
                AddressLine = dto.AddressLine,
                PostalCode = dto.PostalCode,
                PhoneNumber = dto.PhoneNumber,
                User = user
            };
            await _addressRepository.CreateAsync(address);

            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound("Address not found id: "+ id);
            }

            await _addressRepository.DeleteAsync(address);

            return NoContent();
        }
    }
}

