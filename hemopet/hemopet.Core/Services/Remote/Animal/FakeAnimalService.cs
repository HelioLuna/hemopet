using System;
using System.Threading.Tasks;
using hemopet.Core.Models;
using MvvmHelpers;

namespace hemopet.Core.Services.Remote.Animal
{
    public class FakeAnimalService : IAnimalService
    {
        ObservableRangeCollection<Models.Animal> animais = new ObservableRangeCollection<Models.Animal>()
        {
            new Models.Animal
            {
                Id = 1,
                Nome = "Max",
                DataNascimento = new DateTime(2016,04,01),
                Tipo = TipoAnimalEnum.Cachorro
            },
            new Models.Animal
            {
                Id = 2,
                Nome = "Floquinho",
                DataNascimento = new DateTime(2015,04,01),
                Tipo = TipoAnimalEnum.Gato
            },
            new Models.Animal
            {
                Id = 3,
                Nome = "Bolota",
                DataNascimento = new DateTime(2013,04,01),
                Tipo = TipoAnimalEnum.Cachorro
            }

        };
        public async Task<ObservableRangeCollection<Models.Animal>> Get(int skip, int limit = 50, string token = "")
        {
            await Task.Delay(10);

            return animais;
        }

        public async Task<Models.Animal> Remove(Models.Animal animal, string token = "")
        {
            await Task.Delay(10);

            animais.Remove(animal);

            return null;
        }
    }
}
