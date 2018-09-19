using MvvmHelpers;
using System.Threading.Tasks;

namespace hemopet.Core.Services.Remote.Agendamento
{
    public interface IAgendamentoService
    {
        Task<ObservableRangeCollection<Models.Agendamento>> Get(int[] localAgendamentosId, string token = "");
        Task<Models.Agendamento> Remove(Models.Agendamento agendamento, string token = "");
        Task<Models.Agendamento> Post(Models.Agendamento agendamento);

    }
}
