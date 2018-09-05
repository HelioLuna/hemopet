using Newtonsoft.Json;
using System;

namespace hemopet.Core.Models
{
    public class Usuario
    {
        [JsonProperty("cpf")]
        public string Cpf { get; set; }
        [JsonProperty("nom_pessoa")]
        public string Nome { get; set; }
        [JsonProperty("dat_nascimento")]
        public DateTime DataNascimento { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("telefone")]
        public string Telefone { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
