using hemopet.Core.Services.Local.Example;
using Xamarin.Forms;

namespace hemopet.Core.Services.Local
{
    public class LocalServiceManager : ILocalServiceManager
    {
        private IExampleLocalService _exampleLocalService;
        public IExampleLocalService ExampleLocalService =>
            _exampleLocalService ?? (_exampleLocalService = DependencyService.Get<IExampleLocalService>());
    }
}
