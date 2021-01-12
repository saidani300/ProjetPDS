using Caliburn.Micro;
using DemoProjectDesktopUI.Library.Api;
using DemoProjectDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DemoProjectDesktopUI.ViewModels
{
    public class UserDisplayViewModel : Screen
    {
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        private readonly IUserEndpoint _userEndpoint;

        BindingList<UserModel> _users;

        public BindingList<UserModel> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                NotifyOfPropertyChange(() => Users);
            }
        }
        /// <summary>
        /// /
        /// </summary>
        private UserModel _selectedUser;

        public UserModel SelectedUser
        {
            get { return _selectedUser; }
            set {
                _selectedUser = value;
                SelectedUserName = value.Email;
                UserRoles.Clear();
                UserRoles = new BindingList<string>(value.Roles.Select(x => x.Value).ToList());
                LoadRoles();
                NotifyOfPropertyChange(() => SelectedUser);
            }
        }
        /// <summary>
        /// /
        /// </summary>
        private string _selectedUserName;

        public string SelectedUserName
        {
            get { return _selectedUserName; }
            set {
                _selectedUserName = value;
                NotifyOfPropertyChange(() => SelectedUserName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _selectedUserRole;

        public string SelectedUserRole
        {
            get { return _selectedUserRole; }
            set { _selectedUserRole = value; NotifyOfPropertyChange(() => SelectedUserRole); }
        }
        /// <summary>
        /// /
        /// </summary>
        private string _selectedAvailableRole;

        public string SelectedAvailableRole
        {
            get { return _selectedAvailableRole; }
            set { _selectedAvailableRole = value; NotifyOfPropertyChange(() => SelectedAvailableRole); }
        }
        /// <summary>
        /// /
        /// </summary>

        private BindingList<string> _userRoles  = new BindingList<string>();

        public BindingList<string> UserRoles
        {
            get { return _userRoles; }
            set { 
                _userRoles= value;
                NotifyOfPropertyChange(() => UserRoles);
            }
        }

        /// <summary>
        /// ///
        /// </summary>
        private BindingList<string> _availableRoles = new BindingList<string>();

        public BindingList<string> AvailableRoles
        {
            get { return _availableRoles; }
            set
            {
                _availableRoles = value;
                NotifyOfPropertyChange(() => AvailableRoles);
            }
        }

        public UserDisplayViewModel(StatusInfoViewModel status , IWindowManager window , IUserEndpoint userEndpoint)
        {
            _status = status;
            _window = window;
            _userEndpoint = userEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            try
            {
                await LoadUsers();
            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";


                _status.UpdateMessage("Unauthorized Access", "You do not have permission to access this.");
                _window.ShowDialogAsync(_status, null, settings);
                TryCloseAsync();

            }



        }

        public async Task LoadUsers()
        {
            var userList = await _userEndpoint.GetAll();

            Users = new BindingList<UserModel>(userList);

        }

        private async Task LoadRoles()
        {
            var roles = await _userEndpoint.GetAllRoles();
            foreach(var role in roles)
            {
                if (UserRoles.IndexOf(role.Value) < 0)
                {
                    AvailableRoles.Add(role.Value);
                }
            }
        }

        public async Task AddSelectedRole()
        {
            
           await _userEndpoint.AddUserToRole(SelectedUser.Id, SelectedAvailableRole);

            UserRoles.Add(SelectedAvailableRole);
            AvailableRoles.Remove(SelectedAvailableRole);
            NotifyOfPropertyChange(() => SelectedUser);
            NotifyOfPropertyChange(() => AvailableRoles);
            NotifyOfPropertyChange(() => UserRoles);

        }

        public async Task RemoveSelectedRole()
        {
            await _userEndpoint.RemoveUserFromRole(SelectedUser.Id, SelectedUserRole);

            UserRoles.Remove(SelectedUserRole);
            AvailableRoles.Add(SelectedUserRole);
            NotifyOfPropertyChange(() => SelectedUser);
            NotifyOfPropertyChange(() => AvailableRoles);
            NotifyOfPropertyChange(() => UserRoles);
        }
    }
}
