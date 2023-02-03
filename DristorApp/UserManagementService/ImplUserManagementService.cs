using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DristorApp.Data.DTOs.User;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;
using DristorApp.Repositories.Roles;
using DristorApp.Repositories.UserRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace DristorApp.UserManagementService
{
    public class ImplUserManagementService : IUserManagementService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Token, string> _tokenRepository;
        private readonly IRoleRepository _roleRepository;

        public ImplUserManagementService(
            IConfiguration configuration,
            UserManager<User> userManager,
            IUserRepository userRepository,
            IRepository<Token, string> tokenRepository,
            IRoleRepository roleRepository)
        {
            _configuration = configuration;
            _userManager = userManager;
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
            _roleRepository = roleRepository;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterUserDTO dto)
        {
            var customerRole = await _roleRepository.GetRoleByNameAsync("Customer");
            if (customerRole is null)
            {
                throw new Exception("Customer role not found.");
            }

            var user = new User
            {
                Email = dto.Email,
                UserName = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Roles = new List<Role> { customerRole }
            };

            return await _userManager.CreateAsync(user, dto.Password);
        }

        public async Task<string?> LoginUserAsync(LoginUserDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is null) return null;

            if (!await _userManager.CheckPasswordAsync(user, dto.Password)) return null;

            user = await _userRepository.GetUserByIdAndRolesAsync(user.Id);

            var jti = Guid.NewGuid().ToString();
            var tokenHandler = new JwtSecurityTokenHandler();
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Secret").Value));

            var token = GenerateJwtToken(signingKey, user, user.Roles, tokenHandler, jti);

            var tokenModel = new Token
            {
                Jti = jti,
                User = user,
                ExpirationDate = token.ValidTo
            };
            await _tokenRepository.CreateAsync(tokenModel);

            return tokenHandler.WriteToken(token);
        }

        private SecurityToken GenerateJwtToken(SymmetricSecurityKey signingKey, User user, IEnumerable<Role> roles,
            JwtSecurityTokenHandler tokenHandler, string jti)
        {
            var subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Jti, jti)
            });

            foreach (var role in roles)
            {
                subject.AddClaim(new Claim(ClaimTypes.Role, role.Name));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            };

            return tokenHandler.CreateToken(tokenDescriptor);
        }
    }
}