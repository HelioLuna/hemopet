using Newtonsoft.Json;

namespace hemopet.Core.Models
{
    public class Example
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("nome_do_campo")]
        public string texto { get; set; }
    }
}
