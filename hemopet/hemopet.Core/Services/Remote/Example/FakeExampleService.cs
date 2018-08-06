using MvvmHelpers;
using System.Linq;
using System.Threading.Tasks;

namespace hemopet.Core.Services.Remote.Example
{
    public class FakeExampleService : IExampleService
    {
        ObservableRangeCollection<Models.Example> examples = new ObservableRangeCollection<Models.Example>()
        {
            new Models.Example{ id=1, texto = "Primeiro texto"},
            new Models.Example{ id=2, texto = "Segundo texto"}
        };

        public async Task<ObservableRangeCollection<Models.Example>> Get(int skip, int limit = 50)
        {
            await Task.Delay(10);

            return examples;
        }

        public async Task<Models.Example> Post(Models.Example example)
        {
            await Task.Delay(10);
            
            int newId = examples.Last().id + 1;
            example.id = newId;

            examples.Add(example);

            return example;
        }
    }
}
