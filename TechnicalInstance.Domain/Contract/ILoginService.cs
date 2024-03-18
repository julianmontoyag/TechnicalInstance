using TechnicalInstance.Common.Dtos;

namespace TechnicalInstance.Domain.Contract
{
    public interface ILoginService
    {
        Task<ResponseDto<string>> Execute(LoginDto loginDto);
    }
}
