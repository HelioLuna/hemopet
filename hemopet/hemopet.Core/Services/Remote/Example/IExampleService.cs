using MvvmHelpers;
using System.Threading.Tasks;

namespace hemopet.Core.Services.Remote.Example
{
    public interface IExampleService
    {
        Task<ObservableRangeCollection<Models.Example>> Get(int skip, int limit = 50);

        Task<Models.Example> Post(Models.Example example);
    }
}
