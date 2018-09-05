using Newtonsoft.Json;

namespace hemopet.Core.Models
{
    public class Credencial
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("senha")]
        public string Senha { get; set; }
    }
}
