using Newtonsoft.Json;
using System;

namespace hemopet.Core.Models
{
    public class Agendamento
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("animal")]
        public Animal Animal { get; set; }
        [JsonProperty("clinica")]
        public Clinica Clinica { get; set; }
        [JsonProperty("data_doacao")]
        public DateTime DataDoacao { get; set; }


    }
}
