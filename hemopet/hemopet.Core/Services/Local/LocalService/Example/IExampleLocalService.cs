using MvvmHelpers;
using System;
using System.Threading.Tasks;

namespace hemopet.Core.Services.Local.Example
{
    public interface IExampleLocalService
    {
        Task<ObservableRangeCollection<Models.Example>> ReadAll(string token = "");

        Task<Models.Example> Insert(Models.Example example, TimeSpan expireIn, string token = "");
    }
}
