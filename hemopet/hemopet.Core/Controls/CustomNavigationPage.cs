using Xamarin.Forms;

namespace hemopet.Core.Controls
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage(Page root, string titulo) : base(root)
        {
            Init();
            Title = titulo;
            Icon = root.Icon;
        }

        public CustomNavigationPage()
        {
            Init();
        }

        void Init()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                BarBackgroundColor = Color.FromHex("FAFAFA");
            }
            else
            {
                BarBackgroundColor = Color.FromHex("FBB03B");
                BarTextColor = Color.FromHex("ffffff");
            }
        }
    }
}
