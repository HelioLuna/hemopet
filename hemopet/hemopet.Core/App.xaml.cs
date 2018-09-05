using FormsToolkit;
using hemopet.Core.Helpers;
using hemopet.Core.Views.Login;
using MonkeyCache.FileStore;
using System.Linq;
using Xamarin.Forms;

namespace hemopet.Core
{
	public partial class App : Application
	{
        private bool registered;

        public App ()
		{
			InitializeComponent();

            Barrel.ApplicationId = "com.hemopet.Core.local";

            MainPage = new NavigationPage(new LoginPage());
		}

		protected override void OnStart ()
		{
            OnResume();
        }

        protected override void OnSleep ()
		{
            if (!registered)
                return;

            registered = false;

            MessagingService.Current.Unsubscribe<MessagingServiceAlert>(Constants.MessageKeys.Alert);
        }

		protected override void OnResume ()
		{
            if (registered)
                return;

            registered = true;

            MessagingService.Current.Subscribe<MessagingServiceAlert>(Constants.MessageKeys.Alert, async (m, info) =>
            {
                var task = Current?.MainPage?.DisplayAlert(info.Title, info.Message, info.Cancel);

                if (task == null)
                    return;

                await task;
                info?.OnCompleted?.Invoke();
            });

            MessagingService.Current.Subscribe(Constants.MessageKeys.Logout, async (s) =>
            {
                MainPage.Navigation.InsertPageBefore(new LoginPage(), MainPage.Navigation.NavigationStack.First());

                Settings.Usuario = new Models.Usuario();
                await MainPage.Navigation.PopToRootAsync();
            });
        }
	}
}
