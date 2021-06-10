using Newtonsoft.Json;

namespace MTD.SDVTwitch.Models
{
    public class User
    {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }
}