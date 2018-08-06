using MonkeyCache.FileStore;

using hemopet.Core.Services.Remote.Example;
using hemopet.Core.Services.Remote.RequestProvider;

using System;
using System.Threading.Tasks;

namespace hemopet.Core.Services.Local.LocalRequestProvider
{
    public class LocalRequestProvider : ILocalRequestProvider
    {
        public LocalRequestProvider()
        {
            Barrel.ApplicationId = "com.sesau.package.endpoint";
        }

        public async Task<TResult> InsertAsync<TResult>(Endpoint endpoint, TResult data, TimeSpan expireIn, string token = "")
        {
            Barrel.Current.Add(endpoint.Value + token, data, expireIn);
            return await Task.Run(() => data);
        }

        public async Task<TResult> ReadAllAsync<TResult>(Endpoint endpoint, string token = "")
        {
            return await Task.Run(() => Barrel.Current.Get<TResult>(endpoint.Value + token));
        }
    }
}
