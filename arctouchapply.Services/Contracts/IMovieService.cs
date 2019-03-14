using System.Threading.Tasks;

namespace arctouchapply.Services.Contracts
{
    public interface IMovieService
    {
        /// <summary>
        /// Get the list of movies
        /// </summary>
        /// <returns></returns>
        Task<string> GetMovieListAsync();

        /// <summary>
        /// Get the list of movies paged
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        Task<string> GetMovieListPagedAsync(long pageNumber);

        /// <summary>
        /// Search for a specific movie
        /// </summary>
        /// <returns></returns>
        Task<string> SearchMovieAsync(string parameters, long page);

        /// <summary>
        /// Get the list os Genres
        /// </summary>
        /// <returns></returns>
        Task<string> GetGenresAsync();

        /// <summary>
        /// Get the user configuration
        /// </summary>
        /// <returns></returns>
        Task<string> GetConfigurationAsync();
    }
}
