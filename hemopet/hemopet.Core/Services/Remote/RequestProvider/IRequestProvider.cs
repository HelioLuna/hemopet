using System.Threading.Tasks;

namespace hemopet.Core.Services.Remote.RequestProvider
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(Endpoint endpoint, string token = "");

        Task<TResult> PostAsync<TResult>(Endpoint endpoint, TResult data, string token = "");

        Task<TResult> PutAsync<TResult>(Endpoint endpoint, TResult data, string token = "");

        Task<TResult> PatchAsync<TResult>(Endpoint endpoint, TResult data, string token = "");

        Task<TResult> DeleteAsync<TResult>(Endpoint endpoint, string token = "");

        Task<TResult> AuthAsync<TResult>(Endpoint endpoint, TResult data);

    }
}
