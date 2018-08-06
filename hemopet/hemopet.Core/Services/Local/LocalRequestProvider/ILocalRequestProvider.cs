using hemopet.Core.Services.Remote.RequestProvider;
using System;
using System.Threading.Tasks;

namespace hemopet.Core.Services.Local.LocalRequestProvider
{
    public interface ILocalRequestProvider
    {
        Task<TResult> InsertAsync<TResult>(Endpoint endpoint, TResult data, TimeSpan expireIn, string token = "");

        Task<TResult> ReadAllAsync<TResult>(Endpoint endpoint, string token = "");
    }
}