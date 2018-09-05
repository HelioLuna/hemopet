using hemopet.Core.Helpers;
using hemopet.Core.Models;
using hemopet.Core.ViewModels.Base;
using Xamarin.Forms;

namespace hemopet.Core.ViewModels.MeusDados
{
    public class DadosViewModel : ViewModelBase
    {
        public DadosViewModel(INavigation navigation) : base(navigation)
        {
            Usuario = Settings.Usuario;
        }

        #region Propertiers

        public Usuario _usuario;
        public Usuario Usuario
        {
            get => _usuario;
            set => SetProperty(ref _usuario, value);
        }

        #endregion
    }
}
