using TechnicalInstance.Common.Dtos;

namespace TechnicalInstance.Domain.Contract
{
    public interface IGetMoviesListService
    {
        Task<PaginationDto<MovieDto>> Execute(string containerValue, int pageSize, int currentPage);
    }
}
