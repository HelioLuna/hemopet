using hemopet.Core.Helpers;
using hemopet.Core.ViewModels.Base;
using MvvmHelpers;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace hemopet.Core.ViewModels.Agendamento
{
    public class AgendamentosViewModel : ViewModelBase
    {
        public AgendamentosViewModel(INavigation navigation) : base(navigation)
        {
        }

        #region Propertiers

        private bool _isThereModal = false;
        public bool IsThereModal
        {
            get => _isThereModal;
            set => SetProperty(ref _isThereModal, value);
        }

        public ObservableRangeCollection<Models.Agendamento> _agendamentos = new ObservableRangeCollection<Models.Agendamento>();
        public ObservableRangeCollection<Models.Agendamento> Agendamentos
        {
            get => _agendamentos;
            set => SetProperty(ref _agendamentos, value);
        }

        public bool _isListaVazia = false;
        public bool IsListaVazia
        {
            get => _isListaVazia;
            set => SetProperty(ref _isListaVazia, value);
        }

        private int _skip = 0;
        public int Skip
        {
            get => _skip;
            set => _skip = value;
        }

        private int _limit = 10;
        public int Limit
        {
            get => _limit;
            set => _limit = value;
        }

        #endregion

        #region Propertiers

        private ICommand _loadAgendamentosCommand;
        public ICommand LoadAgendamentosCommand =>
            _loadAgendamentosCommand ?? (_loadAgendamentosCommand = new Command(async () => await ExecuteLoadAgendamentosAsync()));

        private async Task ExecuteLoadAgendamentosAsync()
        {
            if (IsBusy)
                return;

            //TEST DEVICE
            //if (!CrossConnectivity.Current.IsConnected)
            //{
            //ShowAlertMessage(TITLE_ERROR_CONNECTION, MESSAGE_ERROR_CONNECTION);
            //return;
            //}

            try
            {
                IsBusy = true;

                int[] localAgendamentosId = await LocalServiceManager.AgendamentoLocalService.ReadAllIds() ?? new int[0];

                Agendamentos = await ServiceManager.AgendamentoService.Get(localAgendamentosId, Settings.Usuario.Token);

                if (Agendamentos.Count <= 0)
                    IsListaVazia = true;
                else
                    IsListaVazia = false;
            }
            catch (Exception exception)
            {
                CommonErrorHandler(exception);
            }
            finally
            {
                IsBusy = false;
            }

            return;
        }
        private ICommand _removeAgendamentoCommand;
        public ICommand RemoveAgendamentoCommand =>
            _removeAgendamentoCommand ?? (_removeAgendamentoCommand = new Command<Models.Agendamento>(async (agendamento) => await ExecuteRemoveAgendamentoAsync(agendamento)));

        private async Task ExecuteRemoveAgendamentoAsync(Models.Agendamento agendamento)
        {
            if (IsBusy)
                return;

            //TEST DEVICE
            //if (!CrossConnectivity.Current.IsConnected)
            //{
            //ShowAlertMessage(TITLE_ERROR_CONNECTION, MESSAGE_ERROR_CONNECTION);
            //return;
            //}

            try
            {
                IsBusy = true;

                Models.Agendamento _agendamento = await ServiceManager.AgendamentoService.Remove(agendamento, Settings.Usuario.Token);

                if (Agendamentos.Count <= 0)
                    IsListaVazia = true;
                else
                    IsListaVazia = false;

                if (_agendamento == null)
                    await ExecuteForceRefreshCommandAsync();
            }
            catch (Exception exception)
            {
                CommonErrorHandler(exception);
            }
            finally
            {
                IsBusy = false;
            }

            return;
        }

        ICommand forceRefreshCommand;
        public ICommand ForceRefreshCommand =>
            forceRefreshCommand ?? (forceRefreshCommand = new Command(async () => await ExecuteForceRefreshCommandAsync()));

        async Task ExecuteForceRefreshCommandAsync()
        {
            await ExecuteLoadAgendamentosAsync();
        }

        #endregion

        public void ToggleIsThereModal()
        {
            IsThereModal = !IsThereModal;
        }
    }
}
