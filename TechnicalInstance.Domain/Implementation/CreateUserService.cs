using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;
using TechnicalInstance.Common.Dtos;
using TechnicalInstance.Data.Entities;
using TechnicalInstance.Data.Repositories.Contract;
using TechnicalInstance.Data.Repositories.Implementation;
using TechnicalInstance.Domain.Contract;

namespace TechnicalInstance.Domain.Implementation
{
    public class CreateUserService : ICreateUserService
    {
        private readonly IUserRepository _userRepository;
        public CreateUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseDto<bool>> Execute(UserDto userDto)
        {
            ResponseDto<bool> result = new();
            User user = await _userRepository.GetUserByEmail(userDto.Email.ToLower());
            if (user != null)
            {
                result.Success = false;
                result.Message = "Already exist a user with the same email";
                return result;
            }

            CreatePasswordHash(userDto.Password, out var passwordHash, out var passwordSalt);
            user = new User
            {
                CreationDate = DateTime.Now,
                Email = userDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                LastName = userDto.LastName,
                Name = userDto.Name
            };

            await _userRepository.AddAsync(user);
            result.Success = true;
            result.Result = true;
            return result;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
