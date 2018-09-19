using MvvmHelpers;
using System.Threading.Tasks;

namespace hemopet.Core.Services.Remote.Clinica
{
    public interface IClinicaService
    {
        Task<ObservableRangeCollection<Models.Clinica>> Get();
    }
}
