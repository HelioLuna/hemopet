using hemopet.Core.Services.Remote.Example;
using Xamarin.Forms;

namespace hemopet.Core.Services.Remote
{
    public class ServiceManager : IServiceManager
    {
        private IExampleService _exampleService;

        public IExampleService ExampleService =>
            _exampleService ?? (_exampleService = DependencyService.Get<IExampleService>());

    }
}
