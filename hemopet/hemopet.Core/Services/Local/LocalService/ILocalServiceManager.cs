using hemopet.Core.Services.Local.Example;
using hemopet.Core.Services.Local.LocalService.Agendamento;
using System;
using System.Collections.Generic;
using System.Text;

namespace hemopet.Core.Services.Local
{
    public interface ILocalServiceManager
    {
        IExampleLocalService ExampleLocalService { get; }
        IAgendamentoLocalService AgendamentoLocalService { get; }
    }
}
