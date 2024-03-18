using Microsoft.Extensions.Configuration;
using TechnicalInstance.Common.Dtos;
using TechnicalInstance.Data.Entities;
using TechnicalInstance.Data.Repositories.Contract;
using TechnicalInstance.Domain.Contract;
using TMDbLib.Client;
using TMDbLib.Objects.Discover;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace TechnicalInstance.Domain.Implementation
{
    public class GetMoviesService : IGetMoviesService
    {
        private readonly IConfiguration _configuration;
        private readonly IMovieRepository _movieRepository;
        public GetMoviesService(IConfiguration configuration, IMovieRepository movieRepository)
        {
            _configuration = configuration;
            _movieRepository = movieRepository;
        }

        public async Task<ResponseDto<bool>> Execute()
        {
            ResponseDto<bool> result = new();
            TMDbClient client = new(_configuration.GetSection("TMDBKey").Value);
            DiscoverMovie discoverTv = client.DiscoverMoviesAsync()
                .WhereReleaseDateIsBefore(new DateTime(2023, 01, 01));
            SearchContainer<SearchMovie> container = await discoverTv.Query();
            List<Movie> movies = new();
            container.Results.ForEach(r =>
            {
                movies.Add(new Movie
                {
                    Title = r.Title,
                    Id = r.Id,
                    OriginalTitle = r.OriginalTitle,
                    OverView  = r.Overview,
                    ReleaseDate = r.ReleaseDate,
                    VoteCount = r.VoteCount
                });
            });

            await _movieRepository.CreateBulkAsync(movies);
            return result;
        }
    }

    
}
