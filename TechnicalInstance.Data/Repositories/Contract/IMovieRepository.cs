using TechnicalInstance.Common.Dtos;
using TechnicalInstance.Data.Entities;

namespace TechnicalInstance.Data.Repositories.Contract
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        IQueryable<MovieDto> GetMoviesList(string containValue);
    }
}
