using hemopet.Core.Services.Local.Example;
using hemopet.Core.Services.Local.LocalService.Agendamento;
using Xamarin.Forms;

namespace hemopet.Core.Services.Local
{
    public class LocalServiceManager : ILocalServiceManager
    {
        private IExampleLocalService _exampleLocalService;
        public IExampleLocalService ExampleLocalService =>
            _exampleLocalService ?? (_exampleLocalService = DependencyService.Get<IExampleLocalService>());

        private IAgendamentoLocalService _agendamentoLocalService;
        public IAgendamentoLocalService AgendamentoLocalService =>
            _agendamentoLocalService ?? (_agendamentoLocalService = DependencyService.Get<IAgendamentoLocalService>());
    }
}
