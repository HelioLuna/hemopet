using hemopet.Core.ViewModels.Agendamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hemopet.Core.Views.Agendamento
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentosPage : ContentPage
    {
        private AgendamentosViewModel vm;
        private AgendamentosViewModel ViewModel => vm ?? (vm = BindingContext as AgendamentosViewModel);

        public AgendamentosPage(INavigation navigation)
        {
            InitializeComponent();
            BindingContext = vm = new AgendamentosViewModel(Navigation);
            doar.Clicked += delegate {  OnDoarClicked(); };
        }

        private async Task OnDoarClicked()
        {
            if (vm.IsThereModal)
                return;

            vm.ToggleIsThereModal();
            await Navigation.PushAsync(new AddAgendamentoPage());
            vm.ToggleIsThereModal();

        }

        public void OnDelete(object sender, EventArgs e)
        {
            var agendamento = ((sender as MenuItem).BindingContext as Models.Agendamento);
            if (agendamento == null)
                return;
            vm.RemoveAgendamentoCommand.Execute(agendamento);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.LoadAgendamentosCommand.Execute(true);
        }
    }
}