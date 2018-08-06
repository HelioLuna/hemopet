using hemopet.Core.ViewModels;
using Xamarin.Forms;

namespace hemopet.Core.Views
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel vm;
        private MainViewModel ViewModel => vm ?? (vm = BindingContext as MainViewModel);

        public MainPage()
        {
            InitializeComponent();

            BindingContext = vm = new MainViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (vm.Examples.Count == 0)
                vm.LoadExamplesCommand.Execute(null);
        }
    }
}
