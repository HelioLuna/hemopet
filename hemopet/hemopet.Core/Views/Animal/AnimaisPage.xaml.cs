using hemopet.Core.ViewModels.Animal;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hemopet.Core.Views.Animal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnimaisPage : ContentPage
    {
        private AnimaisViewModel vm;
        private AnimaisViewModel ViewModel => vm ?? (vm = BindingContext as AnimaisViewModel);
        public AnimaisPage (INavigation navigation)
		{
			InitializeComponent ();
            BindingContext = vm = new AnimaisViewModel(Navigation);
            SetupToolbar();
            addAnimal.Clicked += async delegate { await OnAddAnimalClickedAsync(); };
        }

        private void SetupToolbar()
        {
            addAnimal.Icon = "ic_add_white.png";
        }

        private async Task OnAddAnimalClickedAsync()
        {
            if (vm.IsThereModal)
                return;

            vm.ToggleIsThereModal();
           // await Navigation.PushAsync(new AddAnimal());

            vm.ToggleIsThereModal();

        }

        public void OnEdit(object sender, EventArgs e)
        {
            var animal = ((sender as MenuItem).BindingContext as Models.Animal);
            if (animal == null)
                return;
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var animal = ((sender as MenuItem).BindingContext as Models.Animal);
            if (animal == null)
                return;
            vm.RemoveAnimalCommand.Execute(animal);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.LoadAnimaisCommand.Execute(true);
        }
    }
}