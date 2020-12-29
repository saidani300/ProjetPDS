using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using DemoProjectDesktopUI.EventModels;
using DemoProjectDesktopUI.Library.Api;
using DemoProjectDesktopUI.Library.Models;

namespace DemoProjectDesktopUI.ViewModels
{
    class ShellViewModel : Conductor<object> , IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private ILoggedInUserModel _user;
        private IAPIHelper _apiHelper;



        public ShellViewModel(IEventAggregator events , ILoggedInUserModel user , IAPIHelper apiHelper)
        {
            _events = events;
            _events.SubscribeOnPublishedThread(this);
            _user = user;
            _apiHelper = apiHelper;
            ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
        }

        public void ExitApplication()
        {
            TryCloseAsync();              
        }
        public bool IsAccountVisible
        {
            get
            {
                bool output = false;
                if (string.IsNullOrEmpty(_user.Token) == false)
                {
                    output = true;
                }
                return output;
            }

        }
        

        public async Task LogOut()
        {
            _user.LogOffUser();
            _apiHelper.LogOffUser();
           await ActivateItemAsync(IoC.Get<LoginViewModel>() , new CancellationToken());
            NotifyOfPropertyChange(() => IsAccountVisible);
        }


        public async Task UserManagement()
        {
            await ActivateItemAsync(IoC.Get<UserDisplayViewModel>(), new CancellationToken());
        }

        //public void HandleAsync(LogOnEvent message)
        //{
            
        //}

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(IoC.Get<SalesViewModel>(), cancellationToken);
            NotifyOfPropertyChange(() => IsAccountVisible);
        }
    }
}
