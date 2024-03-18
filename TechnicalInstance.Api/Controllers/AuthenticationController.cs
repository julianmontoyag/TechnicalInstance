using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalInstance.Common.Dtos;
using TechnicalInstance.Domain.Contract;

namespace TechnicalInstance.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ICreateUserService _createUserService;
        
        public AuthenticationController(ILogger<AuthenticationController> logger, ILoginService loginService, ICreateUserService createUserService)
        {
            _loginService = loginService;
            _createUserService = createUserService;
        }
      
        [HttpPost("Login")]
       
        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = await _loginService.Execute(login);
            if (!result.Success)
            {
                return Unauthorized(result);
            }

            return Ok(new
            {
                result
            });
        }

        [HttpPost("CreateUser")]

        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            var result = await _createUserService.Execute(userDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(new
            {
                result
            });
        }

    }
}