using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace arcthouchapply.Models
{
    /// <summary>
    /// The Result of the search
    /// </summary>
    public class Results : BaseEntity
    {
        /// <summary>
        /// Movie poster path
        /// </summary>
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        /// <summary>
        /// Movie is flagged for adults only
        /// </summary>
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        /// <summary>
        /// Movie overview
        /// </summary>
        [JsonProperty("overview")]
        public string Overview { get; set; }

        /// <summary>
        /// Movire release date
        /// </summary>
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        /// <summary>
        /// Gets the release date formatted string.
        /// </summary>
        [JsonIgnore]
        public string ReleaseDateFormattedString
        {
            get
            {
                if (!string.IsNullOrEmpty(ReleaseDate))
                    return Convert.ToDateTime(ReleaseDate).Year.ToString();

                return "Undefined";
            }
        }

        /// <summary>
        /// Movie original title
        /// </summary>
        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        /// <summary>
        /// Movie original language
        /// </summary>
        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        /// <summary>
        /// Movie genres ids
        /// </summary>
        [JsonProperty("genre_ids")]
        public List<long> GenresIds { get; set; }

        /// <summary>
        /// Movie genres (object)
        /// </summary>
        public List<Genres> Genres { get; set; }

        /// <summary>
        /// Movie title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Movie backdrop path
        /// </summary>
        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        /// <summary>
        /// Movie popularity
        /// </summary>
        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        /// <summary>
        /// Movie vote counts
        /// </summary>
        [JsonProperty("vote_count")]
        public long VoteCount { get; set; }

        /// <summary>
        /// Movie flagged for video
        /// </summary>
        [JsonProperty("video")]
        public bool Video { get; set; }

        /// <summary>
        /// Movie averange vote
        /// </summary>
        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        /// <summary>
        /// Movie full image path
        /// </summary>
        public string FullImagePath { get; set; }

        /// <summary>
        /// Gets the genres formatted string.
        /// </summary>
        public string GenresFormattedString
        {
            get
            {
                return Genres != null && Genres.Count > 0 ? Genres.Select(g => g.Name).Aggregate((c, n) => $"{c.ToUpper()}, {n.ToUpper()}")
                             : "UNDEFINED";
            }
        }
    }
}
