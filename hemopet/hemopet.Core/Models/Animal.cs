using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace hemopet.Core.Models
{
    public class Animal
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("dat_nascimento")]
        public DateTime DataNascimento { get; set; }
        [JsonProperty("tipo")]
        public TipoAnimalEnum Tipo { get; set; }
    }
}
