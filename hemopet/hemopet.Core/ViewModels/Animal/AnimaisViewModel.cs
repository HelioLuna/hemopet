using hemopet.Core.ViewModels.Base;
using MvvmHelpers;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace hemopet.Core.ViewModels.Animal
{
    public class AnimaisViewModel : ViewModelBase
    {
        public AnimaisViewModel(INavigation navigation) : base(navigation)
        {

        }

        #region Propertiers

        public ObservableRangeCollection<Models.Animal> Animais { get; } = new ObservableRangeCollection<Models.Animal>();

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

        #region Commands

        private ICommand _loadAnimaisCommand;
        public ICommand LoadAnimaisCommand =>
            _loadAnimaisCommand ?? (_loadAnimaisCommand = new Command(async () => await ExecuteLoadAnimaisAsync()));

        private async Task ExecuteLoadAnimaisAsync()
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

                //ObservableRangeCollection<Animal> cronograma = await ServiceManager.AnimalService.Get(Skip, Limit, Settings.Usuario.Token);
                //SetEtapaSituacaoColor(cronograma);
                //Animais.ReplaceRange(cronograma);

                if (Animais.Count <= 0)
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
        #endregion
    }
}
