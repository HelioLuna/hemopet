using MonkeyCache.FileStore;

using Xamarin.Forms;

namespace hemopet.Core
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            Barrel.ApplicationId = "com.hemopet.Core.local";

            MainPage = new Views.Login.LoginPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
