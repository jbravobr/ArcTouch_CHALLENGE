using Newtonsoft.Json;

namespace arcthouchapply.Models
{
    /// <summary>
    /// Movie Date
    /// </summary>
    public class Date : BaseEntity
    {
        [JsonProperty("maximum")]
        public string Maximum { get; set; }

        [JsonProperty("minimum")]
        public string Minimum { get; set; }
    }
}
