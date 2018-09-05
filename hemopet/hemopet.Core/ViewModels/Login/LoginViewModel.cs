using hemopet.Core.Models;
using hemopet.Core.Services.Remote.RequestProvider;
using hemopet.Core.Validations.Objects;
using hemopet.Core.ViewModels.Base;
using hemopet.Core.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace hemopet.Core.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        protected const string TITLE_INVALID_CREDENCIAL = "Credenciais";
        protected const string MESSAGE_INVALID_CREDENCIAL = "O Login ou a senha está incorreto.";

        public LoginViewModel(INavigation navigation) : base(navigation)
        {
        }

        #region Properties

        private CredencialValidation _credencialValidation = new CredencialValidation();
        public CredencialValidation Credencial { get => _credencialValidation; set => SetProperty(ref _credencialValidation, value); }

        private EventHandler _onCredencialValidated;
        public EventHandler OnCredencialValidated
        {
            get => _onCredencialValidated;
            set => _onCredencialValidated = value;
        }

        #endregion

        #region Commands

        private ICommand _validarCredenciaisCommand;
        public ICommand ValidarCrendenciaisCommand =>
            _validarCredenciaisCommand ?? (_validarCredenciaisCommand = new Command(async () => await ValidarAsync(), () => CanExecuteValidarAsync()));

        private async Task ValidarAsync()
        {
            if (IsBusy)
                return;

            //if (!CrossConnectivity.Current.IsConnected)
            //{
            //ShowAlertMessage(TITLE_ERROR_CONEXAO, MESSAGE_ERROR_CONEXAO);
            //return;
            //}

            try
            {
                Usuario usuario = await ServiceManager.AutenticacaoService.Validar(BuildCredencial());

                if (usuario == null)
                {
                    ShowAlertMessage(TITLE_INVALID_CREDENCIAL, MESSAGE_INVALID_CREDENCIAL);
                    return;
                }

                Settings.Usuario = usuario;

                OnCredencialValidated.Invoke(this, EventArgs.Empty);
            }
            catch (Exception exception)
            {
                if (exception is HttpRequestExceptionEx httpException &&
                   httpException.HttpCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    ShowAlertMessage(TITLE_INVALID_CREDENCIAL, httpException.Message);
                    return;
                }

                CommonErrorHandler(exception);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool CanExecuteValidarAsync()
        {
            if (!Credencial.Validate())
            {
                ShowAlertMessage(TITLE_INVALID_CREDENCIAL, Credencial.Errors.First());
            }

            return Credencial.Validate();
        }

        #endregion

        private Credencial BuildCredencial()
        {
            Credencial credencial = new Credencial
            {
                Login = Credencial.Login.Value,
                Senha = Credencial.Senha.Value
            };

            return credencial;
        }
    }
}
