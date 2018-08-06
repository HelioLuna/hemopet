using hemopet.UITest.Core;
using Xamarin.UITest;

namespace hemopet.UITest.Pages
{
    public abstract class BasePage
    {
        protected IApp App => AppManager.App;
        protected bool OnAndroid => AppManager.Platform == Platform.Android;
        protected bool OniOS => AppManager.Platform == Platform.iOS;

        public BasePage()
        {
        }
    }
}
