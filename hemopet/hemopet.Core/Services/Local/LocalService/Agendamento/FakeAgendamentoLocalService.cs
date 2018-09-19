using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace hemopet.Core.Services.Local.LocalService.Agendamento
{
    public class FakeAgendamentoLocalService : IAgendamentoLocalService
    {
        List<int> ids = new List<int> { 1 };

        public async Task<int[]> InsertId(int id, TimeSpan expireIn, string token = "")
        {
            await Task.Delay(1);
            ids.Add(id);

            return ids.ToArray();
        }

        public async Task<int[]> ReadAllIds(string token = "")
        {
            await Task.Delay(10);

            return ids.ToArray();
        }
    }
}
