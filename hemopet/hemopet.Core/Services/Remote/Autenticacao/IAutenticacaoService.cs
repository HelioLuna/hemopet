using hemopet.Core.Models;
using System.Threading.Tasks;

namespace hemopet.Core.Services.Remote.Autenticacao
{
    public interface IAutenticacaoService
    {
        Task<Usuario> Validar(Credencial credencial);
    }
}
