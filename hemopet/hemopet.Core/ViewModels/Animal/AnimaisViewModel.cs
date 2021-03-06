﻿using hemopet.Core.Helpers;
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

        private bool _isThereModal = false;
        public bool IsThereModal
        {
            get => _isThereModal;
            set => SetProperty(ref _isThereModal, value);
        }

        public ObservableRangeCollection<Models.Animal> _animais;
        public ObservableRangeCollection<Models.Animal> Animais
        {
            get => _animais;
            set => SetProperty(ref _animais, value);
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

                Animais = await ServiceManager.AnimalService.Get(Skip, Limit, Settings.Usuario.Token);
                HandlerAnimal(Animais);

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
        private void HandlerAnimal(ObservableRangeCollection<Models.Animal> animais)
        {
            if(animais.Count > 0) { 
                foreach (Models.Animal animal in animais)
                {
                    animal.HandleInfo();                
                }
            }
        }

        private ICommand _removeAnimalCommand;
        public ICommand RemoveAnimalCommand =>
            _removeAnimalCommand ?? (_removeAnimalCommand = new Command<Models.Animal>(async (animal) => await ExecuteRemoveAnimalAsync(animal)));

        private async Task ExecuteRemoveAnimalAsync(Models.Animal animal)
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

                Models.Animal _animal = await ServiceManager.AnimalService.Remove(animal, Settings.Usuario.Token);

                if (Animais.Count <= 0)
                    IsListaVazia = true;
                else
                    IsListaVazia = false;

                if (_animal == null)
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
            await ExecuteLoadAnimaisAsync();
        }

        #endregion

        public void ToggleIsThereModal()
        {
            IsThereModal = !IsThereModal;
        }
    }
}
