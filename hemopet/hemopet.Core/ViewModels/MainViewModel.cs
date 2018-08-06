using MvvmHelpers;
using hemopet.Core.Models;
using hemopet.Core.Services.Local.Example;
using hemopet.Core.ViewModels.Base;
using System;

using System.Windows.Input;
using Xamarin.Forms;

namespace hemopet.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigation navigation) : base(navigation)
        {
        }

        #region Properties

        private ObservableRangeCollection<Example> _examples = new ObservableRangeCollection<Example>();
        public ObservableRangeCollection<Example> Examples
        {
            get => _examples;
            set => SetProperty(ref _examples, value);
        }

        #endregion

        #region Commands

        private ICommand _loadExamplesCommand;
        public ICommand LoadExamplesCommand => _loadExamplesCommand ?? (_loadExamplesCommand = new Command(async => LoadExamplesAsync()));

        #endregion

        private async void LoadExamplesAsync()
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
                Examples = await ServiceManager.ExampleService.Get(0);
                IExampleLocalService exampleLocalService = LocalServiceManager.ExampleLocalService;
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

    }
}
