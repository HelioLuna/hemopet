using System;
using System.Threading.Tasks;

namespace hemopet.Core.Services.Local.LocalService.Agendamento
{
    public interface IAgendamentoLocalService
    {
        Task<int[]> InsertId(int id, TimeSpan expireIn, string token = "");

        Task<int[]> ReadAllIds(string token = "");
    }
}
