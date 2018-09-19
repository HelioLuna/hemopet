using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hemopet.Core.Models;
using MvvmHelpers;

namespace hemopet.Core.Services.Remote.Agendamento
{
    public class FakeAgendamentoService : IAgendamentoService
    {
        ObservableRangeCollection<Models.Agendamento> agendamentos = new ObservableRangeCollection<Models.Agendamento>()
        {
            new Models.Agendamento()
            {
                Id = 1,
                Animal = new Models.Animal{ Id = 1, Nome = "Max", DataNascimento = new DateTime(2016,04,01), Tipo = TipoAnimalEnum.Cachorro},
                Clinica = new Models.Clinica{Id=1, Nome="Quatro Patas"},
                DataDoacao = new DateTime(2018,10,10)
            }
        };
        public async Task<ObservableRangeCollection<Models.Agendamento>> Get(int[] ids, string token = "")
        {
            await Task.Delay(10);

            ObservableRangeCollection<Models.Agendamento> newAgendamentos = new ObservableRangeCollection<Models.Agendamento>();

            foreach (Models.Agendamento agendamento in agendamentos)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    if (agendamento.Id == ids[i])
                        newAgendamentos.Add(agendamento);
                }
            }

            return newAgendamentos;
        }

        public async Task<Models.Agendamento> Post(Models.Agendamento agendamento)
        {
            await Task.Delay(10);

            agendamento.Id = agendamentos.Last().Id + 1;

            agendamentos.Add(agendamento);

            return agendamento;
        }

        public async Task<Models.Agendamento> Remove(Models.Agendamento agendamento, string token = "")
        {
            await Task.Delay(10);

            agendamentos.Remove(agendamento);

            return null;
        }
    }
}
