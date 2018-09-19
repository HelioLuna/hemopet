using hemopet.Core.Services.Remote.Agendamento;
using hemopet.Core.Services.Remote.Animal;
using hemopet.Core.Services.Remote.Autenticacao;
using hemopet.Core.Services.Remote.Clinica;

namespace hemopet.Core.Services.Remote
{
    public interface IServiceManager
    {
        IAutenticacaoService AutenticacaoService { get; }
        IAnimalService AnimalService { get; }
        IAgendamentoService AgendamentoService { get; }
        IClinicaService ClinicaService { get; }
    }
}
