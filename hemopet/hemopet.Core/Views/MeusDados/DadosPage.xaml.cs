using FormsToolkit;
using hemopet.Core.Helpers;
using hemopet.Core.ViewModels.MeusDados;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hemopet.Core.Views.MeusDados
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DadosPage : ContentPage
	{
        private DadosViewModel vm;
        private DadosViewModel ViewModel => vm ?? (vm = BindingContext as DadosViewModel);

        public DadosPage(INavigation navigation)
		{
			InitializeComponent();
            BindingContext = vm = new DadosViewModel(Navigation);
            logout.Clicked += async delegate { await OnLogoutClicked(); };
        }

        private async Task OnLogoutClicked()
        {
            MessagingService.Current.SendMessage(Constants.MessageKeys.Logout);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}