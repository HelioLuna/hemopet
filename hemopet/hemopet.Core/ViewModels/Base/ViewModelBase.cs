using FormsToolkit;
using MvvmHelpers;
using hemopet.Core.Helpers;
using hemopet.Core.Services.Local;
using hemopet.Core.Services.Local.Example;
using hemopet.Core.Services.Local.LocalRequestProvider;
using hemopet.Core.Services.Remote;
using hemopet.Core.Services.Remote.Example;
using hemopet.Core.Services.Remote.RequestProvider;
using System;

using System.Net;
using System.Net.Http;

using Xamarin.Forms;

namespace hemopet.Core.ViewModels.Base
{
    public class ViewModelBase : BaseViewModel
    {
        protected const string TITLE_ERROR_CONNECTION = "Falha na conexão !!";
        protected const string TITLE_ERROR_COMMUNICATION = "Falha de comunicação !!";
        protected const string TITLE_ERROR_GERAL = "Algo de errado aconteceu !!";
        protected const string MESSAGE_ERROR_CONNECTION = "Houve uma falha na conexão, por favor verifique sua internet";

        private bool isToMock = true;

        protected INavigation Navigation { get; }

        public ViewModelBase(INavigation navigation)
        {
            Navigation = navigation;

            Init();
        }

        private void Init()
        {
            DependencyService.Register<IRequestProvider, RequestProvider>();
            DependencyService.Register<ILocalRequestProvider, LocalRequestProvider>();

            if (isToMock)
            {
                DependencyService.Register<IExampleService, FakeExampleService>();
                DependencyService.Register<IExampleLocalService, FakeExampleLocalService>();
            }
            else
            {
                DependencyService.Register<IExampleService, ExampleService>();
                DependencyService.Register<IExampleLocalService, ExampleLocalService>();
            }

            DependencyService.Register<IServiceManager, ServiceManager>();
            DependencyService.Register<ILocalServiceManager, LocalServiceManager>();
        }

        protected IServiceManager ServiceManager => DependencyService.Get<IServiceManager>();
        protected ILocalServiceManager LocalServiceManager => DependencyService.Get<ILocalServiceManager>();

        protected void CommonErrorHandler(Exception exception)
        {
            if (exception.InnerException is WebException webException
                   && webException.Status == WebExceptionStatus.ConnectFailure)
            {
                ShowAlertMessage(TITLE_ERROR_CONNECTION, MESSAGE_ERROR_CONNECTION);
                return;
            }
            else if (exception is HttpRequestException httpException
                && string.IsNullOrEmpty(httpException.Message))
            {
                ShowAlertMessage(TITLE_ERROR_COMMUNICATION, httpException.Message);
                return;
            }
            else
            {
                ShowAlertMessage(TITLE_ERROR_GERAL, exception.Message);
                return;
            }
        }

        protected void ShowAlertMessage(string title, string message)
        {
            MessagingService.Current.SendMessage(Constants.MessageKeys.Alert,
                new MessagingServiceAlert()
                {
                    Title = title,
                    Message = message,
                    Cancel = "Ok"
                });
        }
    }
}
