using hemopet.Core.Models;
using hemopet.Core.Services.Remote.Autenticacao;
using MvvmHelpers;
using System;
using System.Threading.Tasks;

namespace hemopet.Core.Services.Remote.Animal
{
    public class AnimalService : IAnimalService
    {
        public Task<ObservableRangeCollection<Models.Animal>> Get(int skip, int limit = 50, string token = "")
        {
            throw new NotImplementedException();
        }

        public Task<Models.Animal> Remove(Models.Animal animal, string token = "")
        {
            throw new NotImplementedException();
        }
    }
}
