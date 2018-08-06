using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MonkeyCache.FileStore;
using MvvmHelpers;
using hemopet.Core.Services.Local.LocalService;
using static Newtonsoft.Json.JsonConvert;

namespace hemopet.Core.Services.Local.Example
{
    public class ExampleLocalService : IExampleLocalService
    {
        public Task<ObservableRangeCollection<Models.Example>> ReadAll(string token = "")
        {
            FileStore fileStore = FileStore.EXAMPLES();

            ObservableRangeCollection<Models.Example> examples =
                Barrel.Current.Get<ObservableRangeCollection<Models.Example>>(fileStore.Value + token) ?? new ObservableRangeCollection<Models.Example>();

            return Task.Run(() => examples);
        }

        public Task<Models.Example> Insert(Models.Example example, TimeSpan expireIn, string token = "")
        {
            FileStore fileStore = FileStore.EXAMPLES();

            ObservableRangeCollection<Models.Example> examples =
                Barrel.Current.Get<ObservableRangeCollection<Models.Example>>(fileStore.Value + token) ?? new ObservableRangeCollection<Models.Example>();

            examples.Add(example);

            Barrel.Current.Add(fileStore.Value, SerializeObject(examples), expireIn);

            return Task.Run(() => example);
        }
    }
}
