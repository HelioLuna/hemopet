using hemopet.Core.Services.Remote.Autenticacao;
using hemopet.Core.Services.Remote.Example;
using Xamarin.Forms;

namespace hemopet.Core.Services.Remote
{
    public class ServiceManager : IServiceManager
    {
        private IAutenticacaoService _autenticacaoService;

        public IAutenticacaoService AutenticacaoService =>
            _autenticacaoService ?? (_autenticacaoService = DependencyService.Get<IAutenticacaoService>());

    }
}
