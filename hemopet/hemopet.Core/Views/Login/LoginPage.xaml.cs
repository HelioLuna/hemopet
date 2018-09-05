using hemopet.Core.ViewModels.Login;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hemopet.Core.Views.Login
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
    {
        private LoginViewModel vm;
        private LoginViewModel ViewModel => vm ?? (vm = BindingContext as LoginViewModel);

        public LoginPage ()
		{
			InitializeComponent ();

            BindingContext = vm = new LoginViewModel(Navigation);

            NavigationPage.SetHasNavigationBar(this, false);

            vm.OnCredencialValidated += delegate { OnCredencialValidatedAsync(); };
            entrar.Clicked += delegate { OnEntrarClicked(); };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void OnCredencialValidatedAsync()
        {
            Navigation.InsertPageBefore(new MainPage(), this);
            Navigation.PopAsync();
        }

        private void OnEntrarClicked()
        {
            if (vm.ValidarCrendenciaisCommand.CanExecute(null))
                vm.ValidarCrendenciaisCommand.Execute(null);
        }
    }
}