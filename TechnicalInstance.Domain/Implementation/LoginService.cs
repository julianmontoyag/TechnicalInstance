using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TechnicalInstance.Common.Dtos;
using TechnicalInstance.Data.Entities;
using TechnicalInstance.Data.Repositories.Contract;
using TechnicalInstance.Domain.Contract;

namespace TechnicalInstance.Domain.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public LoginService(IUserRepository userRepository, IConfiguration configuration) 
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<ResponseDto<string>> Execute(LoginDto loginDto)
        {
            ResponseDto<string> result = new();
            User user = await _userRepository.GetUserByEmail(loginDto.Email);

            if (user == null || !VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                result.Success = false;
                result.Message = "Email or password incorrect.";
                return result;
            }

            result.Success = true;
            result.Result = GenerateToken(user);
            return result;
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return !computeHash.Where((t, i) => t != passwordHash[i]).Any();
        }

        private string GenerateToken(User user)
        {
            var claims = new Claim[]
            {
                new(ClaimTypes.NameIdentifier, $"{user.Id}"),
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Surname, user.LastName),
                new(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("ConfigurationJWT:Token").Value));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration.GetSection("ConfigurationJWT:ExpirationTokenHour").Value)),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
