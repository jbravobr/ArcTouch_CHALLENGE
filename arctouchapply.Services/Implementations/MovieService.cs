using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using arctouchapply.Services.Contracts;
using arctouchapply.Services.Helpers;
using Flurl.Http;

namespace arctouchapply.Services.Implementations
{
    public class MovieService : BaseServices, IMovieService
    {
        /// <summary>
        /// Return the user's configuration
        /// </summary>
        public async Task<string> GetConfigurationAsync()
        {
            try
            {
                this.CreateHttpCallForApi(new[] { "configuration" }, new Dictionary<string, string> { { "api_key", Secrets.IMDBApiKey } });

                var response = await this._url.AllowHttpStatus(HttpStatusCode.NotFound).GetAsync();
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Return Movies Genres list
        /// </summary>
        public async Task<string> GetGenresAsync()
        {
            try
            {
                this.CreateHttpCallForApi(new[] { "genre", "movie", "list" }, new Dictionary<string, string> { { "api_key", Secrets.IMDBApiKey } });

                var response = await this._url.AllowHttpStatus(HttpStatusCode.NotFound).GetAsync();
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Return the list of Movies
        /// </summary>
        public async Task<string> GetMovieListAsync()
        {
            try
            {
                this.CreateHttpCallForApi(new[] { "movie", "upcoming" }, new Dictionary<string, string> { { "api_key", Secrets.IMDBApiKey } });

                var response = await this._url.AllowHttpStatus(HttpStatusCode.NotFound).GetAsync();
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetMovieListPagedAsync(long pageNumber)
        {
            try
            {
                this.CreateHttpCallForApi(new[] { "movie", "upcoming" }, new Dictionary<string, string> { { "api_key", Secrets.IMDBApiKey },
                    {"page", pageNumber.ToString() } });

                var response = await this._url.AllowHttpStatus(HttpStatusCode.NotFound).GetAsync();
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Search for a movie
        /// </summary>
        public async Task<string> SearchMovieAsync(string parameters, long page)
        {
            try
            {
                this.CreateHttpCallForApi(new[] { "search", "movie" }, new Dictionary<string, string> { { "api_key", Secrets.IMDBApiKey }, { "query", parameters.ToLower() }, { "page", page.ToString() } });

                var response = await this._url.AllowHttpStatus(HttpStatusCode.NotFound).GetAsync();
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
