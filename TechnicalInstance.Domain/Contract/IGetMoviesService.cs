using TechnicalInstance.Common.Dtos;

namespace TechnicalInstance.Domain.Contract
{
    public interface IGetMoviesService
    {
        Task<ResponseDto<bool>> Execute();
    }
}
