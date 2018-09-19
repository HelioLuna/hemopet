using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace hemopet.Core.Services.Local.LocalService.Agendamento
{
    public class AgendamentoLocalService : IAgendamentoLocalService
    {
        public Task<int[]> InsertId(int id, TimeSpan expireIn, string token = "")
        {
            throw new NotImplementedException();
        }

        public Task<int[]> ReadAllIds(string token = "")
        {
            throw new NotImplementedException();
        }
    }
}
