using Newtonsoft.Json;

namespace hemopet.Core.Models
{
    public class Usuario
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
