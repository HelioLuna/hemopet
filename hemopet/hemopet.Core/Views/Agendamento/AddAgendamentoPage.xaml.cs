using hemopet.Core.ViewModels.Agendamento;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hemopet.Core.Views.Agendamento
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddAgendamentoPage : ContentPage
	{
        private AddAgendamentoViewModel vm;
        private AddAgendamentoViewModel ViewModel => vm ?? (vm = BindingContext as AddAgendamentoViewModel);
        public AddAgendamentoPage ()
		{
			InitializeComponent ();
            BindingContext = vm = new AddAgendamentoViewModel(Navigation);
            DataDaDoacao.MinimumDate = DateTime.Today;

            salvarAgendamento.Clicked += delegate { OnSalvarAgendamentoClicked(); };
            vm.OnDoacaoSavedEvent += delegate { OnDoacaoSaved(); };
        }

        private void OnSalvarAgendamentoClicked()
        {
            if (vm.SaveDoacaoCommand.CanExecute(null))
                vm.SaveDoacaoCommand.Execute(null);
        }

        public void OnDoacaoSaved()
        {
            Navigation.RemovePage(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.StartHandlerCommand.Execute(true);
        }
    }
}