using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using hemopet.Core.Models;
using MvvmHelpers;

namespace hemopet.Core.Services.Remote.Agendamento
{
    public class AgendamentoService : IAgendamentoService
    {
        public Task<ObservableRangeCollection<Models.Agendamento>> Get(int[] localAgendamentosId, string token = "")
        {
            throw new NotImplementedException();
        }

        public Task<Models.Agendamento> Post(Models.Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Agendamento> Remove(Models.Agendamento agendamento, string token = "")
        {
            throw new NotImplementedException();
        }
    }
}
