using MvvmHelpers;
using hemopet.Core.Services.Local.LocalRequestProvider;
using hemopet.Core.Services.Remote.RequestProvider;
using System;

using System.Net;

using System.Threading.Tasks;
using Xamarin.Forms;

namespace hemopet.Core.Services.Remote.Example
{
    public class ExampleService : IExampleService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly ILocalRequestProvider _localRequestProvider;

        public ExampleService()
        {
            _requestProvider = DependencyService.Get<IRequestProvider>();
            _localRequestProvider = DependencyService.Get<ILocalRequestProvider>();
        }

        public async Task<ObservableRangeCollection<Models.Example>> Get(int skip, int limit = 50)
        {
            ObservableRangeCollection<Models.Example> examples = new ObservableRangeCollection<Models.Example>();

            Endpoint endpoint = Endpoint.Example()
                .AddParam("", "")
                .AddToUrl("");

            try
            {
                examples = await _requestProvider.GetAsync<ObservableRangeCollection<Models.Example>>(endpoint);
                await _localRequestProvider.InsertAsync(endpoint, examples, TimeSpan.FromDays(14));
            }
            catch (Exception exception)
            {
                if (exception.InnerException is WebException webException
                   && webException.Status == WebExceptionStatus.ConnectFailure)
                {
                    examples = await _localRequestProvider.ReadAllAsync<ObservableRangeCollection<Models.Example>>(endpoint);
                }

                throw exception;
            }
            return examples;
        }

        public async Task<Models.Example> Post(Models.Example example)
        {
            Endpoint endpoint = Endpoint.Example();

            try
            {
                example = await _requestProvider.PostAsync(endpoint, example);
            }
            catch (Exception exception)
            {
                if (exception.InnerException is WebException webException
                   && webException.Status == WebExceptionStatus.ConnectFailure)
                {
                    await _localRequestProvider.InsertAsync(endpoint, example, TimeSpan.FromDays(14));
                }

                throw exception;
            }

            return example;
        }
    }
}
