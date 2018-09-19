using hemopet.Core.Helpers;
using hemopet.Core.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace hemopet.Core.ViewModels.Agendamento
{
    public class AddAgendamentoViewModel : ViewModelBase
    {
        public AddAgendamentoViewModel(INavigation navigation) : base(navigation)
        {
            Agendamento = new Models.Agendamento();
        }

        #region Properties

        /*private DenunciaValidation _denunciaValidation;
        public DenunciaValidation Denuncia
        {
            get => _denunciaValidation;
            set => SetProperty(ref _denunciaValidation, value);
        }*/

        private Models.Agendamento _agendamento;
        public Models.Agendamento Agendamento
        {
            get => _agendamento;
            set => SetProperty(ref _agendamento, value);
        }

        private ObservableCollection<Models.Animal> _animais = new ObservableCollection<Models.Animal>();
        public ObservableCollection<Models.Animal> Animais
        {
            get => _animais;
            set => SetProperty(ref _animais, value);
        }

        private ObservableCollection<Models.Clinica> _clinicas = new ObservableCollection<Models.Clinica>();
        public ObservableCollection<Models.Clinica> Clinicas
        {
            get => _clinicas;
            set => SetProperty(ref _clinicas, value);
        }

        private EventHandler _onDoacaoSavedEvent;
        public EventHandler OnDoacaoSavedEvent
        {
            get => _onDoacaoSavedEvent;
            set => SetProperty(ref _onDoacaoSavedEvent, value);
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

        #region Commands

        private ICommand _loadAnimaisCommand;
        public ICommand LoadAnimaisCommand => _loadAnimaisCommand ?? (_loadAnimaisCommand = new Command(async => LoadAnimaisAsync()));

        private async void LoadAnimaisAsync()
        {
            try
            {
                Animais = await ServiceManager.AnimalService.Get(Skip, Limit, Settings.Usuario.Token);
            }
            catch (Exception exception)
            {
                CommonErrorHandler(exception);
            }

        }

        private ICommand _loadClinicasCommand;
        public ICommand LoadClinicasCommand => _loadClinicasCommand ?? (_loadClinicasCommand = new Command(async => LoadClinicasAsync()));

        private async void LoadClinicasAsync()
        {

            try
            {
                Clinicas = await ServiceManager.ClinicaService.Get();
            }
            catch (Exception exception)
            {
                CommonErrorHandler(exception);
            }

        }
        private ICommand _startHandlerCommand;
        public ICommand StartHandlerCommand => _startHandlerCommand ?? (_startHandlerCommand = new Command(async => StartHandlerAsync()));

        private void StartHandlerAsync()
        {
            IsBusy = true;

            LoadAnimaisAsync();
            LoadClinicasAsync();

            IsBusy = false;
        }

        private ICommand _saveDoacaoCommand;
        public ICommand SaveDoacaoCommand => _saveDoacaoCommand ?? (_saveDoacaoCommand = new Command(() => SaveDoacaoaAsync(), () => IsDoacaoValid()));

        private bool IsDoacaoValid()
        {
            /*  if (!Denuncia.Validate())
              {
                  ShowAlertMessage(TITLE_ERROR_VALIDATION, Denuncia.Errors.First());
              }

              return Denuncia.Validate();*/
            return true;
        }

        private async void SaveDoacaoaAsync()
        {
            if (IsBusy)
                return;

            //if (!CrossConnectivity.Current.IsConnected)
            //{
            //ShowAlertMessage(TITLE_ERROR_CONEXAO, MESSAGE_ERROR_CONEXAO);
            //return;
            //}

            try
            {
                IsBusy = true;

                Agendamento = await ServiceManager.AgendamentoService.Post(Agendamento);
                await LocalServiceManager.AgendamentoLocalService.InsertId(Agendamento.Id, TimeSpan.FromDays(14));

                OnDoacaoSavedEvent(this, EventArgs.Empty);
            }
            catch (Exception exception)
            {
                CommonErrorHandler(exception);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
