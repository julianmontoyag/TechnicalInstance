using TechnicalInstance.Common.Dtos;

namespace TechnicalInstance.Domain.Contract
{
    public interface ICreateUserService
    {
        Task<ResponseDto<bool>> Execute(UserDto userDto);
    }
}
