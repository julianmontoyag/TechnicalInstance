using TechnicalInstance.Common.Dtos;
using TechnicalInstance.Data.Repositories.Contract;
using TechnicalInstance.Domain.Contract;

namespace TechnicalInstance.Domain.Implementation
{
    public class GetMoviesListService : IGetMoviesListService
    {
        private readonly IMovieRepository _movieRepository;
        public GetMoviesListService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<PaginationDto<MovieDto>> Execute(string containerValue, int pageSize, int currentPage)
        {
            var query = _movieRepository.GetMoviesList(containerValue);
            var result = await _movieRepository.GetDtoList(query, pageSize, currentPage);
            return new PaginationDto<MovieDto>()
            {
                Items = result.Cast<MovieDto>().ToList(),
                TotalItems = _movieRepository.GetTotalDtoRecords(query),
                CurrentPage = currentPage,
                PageSize = pageSize
            };
        }
    }
}
