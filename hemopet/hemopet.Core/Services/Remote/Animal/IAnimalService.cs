using MvvmHelpers;
using System.Threading.Tasks;

namespace hemopet.Core.Services.Remote.Animal
{
    public interface IAnimalService
    {
        Task<ObservableRangeCollection<Models.Animal>> Get(int skip, int limit = 50, string token = "");
        Task<Models.Animal> Remove(Models.Animal animal, string token = "");

    }
}
