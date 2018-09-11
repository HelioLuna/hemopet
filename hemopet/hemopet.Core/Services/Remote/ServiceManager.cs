using hemopet.Core.Services.Remote.Animal;
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

        private IAnimalService _animalService;
        public IAnimalService AnimalService =>
            _animalService ?? (_animalService = DependencyService.Get<IAnimalService>());

    }
}
