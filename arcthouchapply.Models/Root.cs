using System.Collections.Generic;
using Newtonsoft.Json;

namespace arcthouchapply.Models
{
    /// <summary>
    /// Root object.
    /// </summary>
    public class Root : BaseEntity
    {
        /// <summary>
        /// Page index for the search results
        /// </summary>
        [JsonProperty("page")]
        public long Page { get; set; }

        /// <summary>
        /// Search results
        /// </summary>
        [JsonProperty("results")]
        public List<Results> Results { get; set; }

        /// <summary>
        /// Image details
        /// </summary>
        [JsonProperty("images")]
        public Image Images { get; set; }


        [JsonProperty("genres")]
        public List<Genres> Genres { get; set; }

        /// <summary>
        /// Main date for the search result
        /// </summary>
        [JsonProperty("dates")]
        public Date Date { get; set; }

        /// <summary>
        /// Total of page search results
        /// </summary>
        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        /// <summary>
        /// Total of the search results
        /// </summary>
        [JsonProperty("total_results")]
        public long TotalResults { get; set; }
    }
}
