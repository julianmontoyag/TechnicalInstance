using TechnicalInstance.Common.Dtos;
using TechnicalInstance.Data.Context;
using TechnicalInstance.Data.Entities;
using TechnicalInstance.Data.Repositories.Contract;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TechnicalInstance.Data.Repositories.Implementation
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<MovieDto> GetMoviesList(string containValue)
        {
            var query = from movie in _context.Movies
                        select new MovieDto
                        {
                            Title = movie.Title,
                            Id = movie.Id,
                            OriginalTitle = movie.OriginalTitle,
                            OverView = movie.OverView,
                            ReleaseDate = movie.ReleaseDate,
                            VoteCount = movie.VoteCount
                        };

            if (!string.IsNullOrEmpty(containValue))
            {
                query = query.Where(m => m.OriginalTitle.Contains(containValue) || m.OverView.Contains(containValue) || m.Title.Contains(containValue));
            }

            return query;
        }
    }
}
