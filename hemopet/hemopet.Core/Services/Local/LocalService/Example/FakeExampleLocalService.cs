
using System;
using System.Threading.Tasks;
using MvvmHelpers;
using System.Linq;

namespace hemopet.Core.Services.Local.Example
{
    public class FakeExampleLocalService : IExampleLocalService
    {
        ObservableRangeCollection<Models.Example> examples = new ObservableRangeCollection<Models.Example> {
            new Models.Example{ id = 0, texto = "João"},
            new Models.Example{ id = 1, texto = "Edvaldo"},
            new Models.Example{ id = 2, texto = "Clevil"},
            new Models.Example{ id = 3, texto = "Detona"},
        };

        public async Task<ObservableRangeCollection<Models.Example>> ReadAll(string token = "")
        {
            await Task.Delay(10);

            return examples;
        }

        public async Task<Models.Example> Insert(Models.Example example, TimeSpan expireIn, string token = "")
        {
            await Task.Delay(10);

            int newId = examples.Last().id + 1;
            example.id = newId;

            examples.Add(example);

            return example;
        }
    }
}
