using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace hemopet.Core.Models
{
    public class Clinica
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }

    }
}
