using Caliburn.Micro;
using DemoProjectDesktopUI.EventModels;
using DemoProjectDesktopUI.Helpers;
using DemoProjectDesktopUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DemoProjectDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName = "wael.saidani@sesame.com.tn";
        private string _password = "Password123@";
        private IAPIHelper _apiHelper;
        private IEventAggregator _events;

        public LoginViewModel(IAPIHelper apiHelper , IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }
        public string UserName
        {
            get { return _userName; }
            set {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }
        

        public string Password
        {
            get { return _password; }
            set { _password = value; NotifyOfPropertyChange(() => Password); NotifyOfPropertyChange(() => CanLogIn); }
        }


        public bool IsErrorvisible
        {
            get {
                bool output = false;
                if (ErrorMessage?.Length>0)
                {
                    output = true;
                }
                return output;
            }
            
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; NotifyOfPropertyChange(() => ErrorMessage); NotifyOfPropertyChange(() => IsErrorvisible); }
        }


        public bool CanLogIn
        {
            get
            {
                bool output = false;
                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
        }

        public async Task LogIn()
        {
            try
            {
                ErrorMessage = "";
                var result = await _apiHelper.AuthenticateAsync(UserName, Password);

                var userId = await _apiHelper.LoggedInUserId(result.Access_token);

                await _apiHelper.GetLoggedInUserInfo(userId.userId , result.Access_token);

                await _events.PublishOnUIThreadAsync(new LogOnEvent() , new CancellationToken());
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            }
    }
}
