using hemopet.Core.Services.Remote.Agendamento;
using hemopet.Core.Services.Remote.Animal;
using hemopet.Core.Services.Remote.Autenticacao;
using hemopet.Core.Services.Remote.Clinica;
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

        private IAgendamentoService _agendamentoService;
        public IAgendamentoService AgendamentoService =>
            _agendamentoService ?? (_agendamentoService = DependencyService.Get<IAgendamentoService>());

        private IClinicaService _clinicaService;
        public IClinicaService ClinicaService =>
            _clinicaService ?? (_clinicaService = DependencyService.Get<IClinicaService>());
    }
}
