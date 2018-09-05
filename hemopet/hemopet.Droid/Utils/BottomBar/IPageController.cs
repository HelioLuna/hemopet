using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace hemopet.Droid.Utils.BottomBar
{
    public interface IPageController
    {
        Rectangle ContainerArea { get; set; }

        bool IgnoresContainerArea { get; set; }

        ObservableCollection<Element> InternalChildren { get; }

        void SendAppearing();

        void SendDisappearing();
    }
}