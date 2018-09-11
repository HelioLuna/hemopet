using hemopet.Core.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace hemopet.Core.Models
{
    public class Animal
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("id_dono")]
        public int IdDono { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("dat_nascimento")]
        public DateTime DataNascimento { get; set; }
        [JsonProperty("tipo")]
        public TipoAnimalEnum Tipo { get; set; }
        [JsonIgnore]
        public int Idade { get; set; }
        [JsonIgnore]
        public string DescricaoTipo { get; set; }
        [JsonIgnore]
        public string ImagemAnimal { get; set; }

        public void HandleInfo()
        {
            HandleDescricaoTipo();
            HandleIdadeAnimal();
            HandleImagemAnimal();
        }

        private void HandleImagemAnimal()
        {
            if (Tipo == TipoAnimalEnum.Cachorro)
                ImagemAnimal = "dog_icon.png";

            if (Tipo == TipoAnimalEnum.Gato)
                ImagemAnimal = "cat_icon.png";
        }

        private void HandleIdadeAnimal()
        {
            Idade = DateTime.Now.Year - DataNascimento.Year;
        }

        private void HandleDescricaoTipo()
        {
            DescricaoTipo = EnumHelper.GetDescription(Tipo);
        }
    }
}
