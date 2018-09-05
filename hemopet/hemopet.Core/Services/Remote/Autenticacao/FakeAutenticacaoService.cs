using hemopet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace hemopet.Core.Services.Remote.Autenticacao
{
    public class FakeAutenticacaoService : IAutenticacaoService
    {
        private Credencial _fakeCredencial = new Credencial() { Login = "login", Senha = "senha" };
        private Usuario _fakeUsuario = new Usuario()
        {
            Cpf = "111.111.111-11",
            Nome = "Ágatha Cavalcante Rodrigues",
            DataNascimento = new DateTime(1985, 05, 12),
            Email = "agatha@gmail.com",
            Telefone = "(82)99987-2544",
            Token = "5dasdasdasd$%2224qw6e5qdasd4w654a4s6a54d"
        };

        public async Task<Usuario> Validar(Credencial credencial)
        {
            Usuario userValidated = null;

            await Task.Delay(100);

            if (_fakeCredencial.Login.Equals(credencial.Login)
                && _fakeCredencial.Senha.Equals(credencial.Senha))
                userValidated = _fakeUsuario;

            return userValidated;
        }
    }
}
