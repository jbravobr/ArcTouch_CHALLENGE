using System.Collections.Generic;
using Newtonsoft.Json;

namespace arcthouchapply.Models
{
    /// <summary>
    /// Image.
    /// </summary>
    public class Image : BaseEntity
    {
        /// <summary>
        /// Base URL for the image
        /// </summary>
        [JsonProperty("base_url")]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Secure base url for the image
        /// </summary>
        [JsonProperty("secure_base_url")]
        public string SecureBaseUrl { get; set; }

        /// <summary>
        /// Backdrop sizes for the image
        /// </summary>
        [JsonProperty("backdrop_sizes")]
        public IEnumerable<string> BackdropSizes { get; set; }

        /// <summary>
        /// Logo sizes for the image
        /// </summary>
        [JsonProperty("logo_sizes")]
        public IEnumerable<string> LogoSizes { get; set; }

        /// <summary>
        /// Poster sizes for the image
        /// </summary>
        [JsonProperty("poster_sizes")]
        public IEnumerable<string> PosterSizes { get; set; }

        /// <summary>
        /// Profile sizes for the image
        /// </summary>
        [JsonProperty("profile_sizes")]
        public IEnumerable<string> ProfileSizes { get; set; }

        /// <summary>
        /// Still sizes for the image
        /// </summary>
        [JsonProperty("still_sizes")]
        public IEnumerable<string> StillSizes { get; set; }
    }
}
