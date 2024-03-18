using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TechnicalInstance.Domain.Contract;

namespace TechnicalInstance.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IGetMoviesService _getMoviesService;
        private readonly IGetMoviesListService _getMoviesListService;
        public MovieController(IGetMoviesService getMoviesService, IGetMoviesListService getMoviesListService)
        {
            _getMoviesService = getMoviesService;
            _getMoviesListService = getMoviesListService;
        }

        [HttpPost("LoadMovies")]
        public async Task<IActionResult> LoadMoviesByGenre()
        {
            var result = await _getMoviesService.Execute();
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(new
            {
                result
            });
        }

        [HttpPost("GetMoviesList")]
        public async Task<IActionResult> GetMoviesList([Optional] string containerValue, int pageSize, int currentPage)
        {
            var result = await _getMoviesListService.Execute(containerValue, pageSize, currentPage);
            return Ok(new
            {
                result
            });
        }

    }
}