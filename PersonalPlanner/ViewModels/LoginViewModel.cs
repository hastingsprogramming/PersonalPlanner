using Caliburn.Micro;
using System;

namespace PersonalPlanner.ViewModels
{
    class LoginViewModel : Screen
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }


        public void CloseWindow() => this.TryClose();
        public bool CanSignIn(string username, string password)
        {
            return !(String.IsNullOrEmpty(username)) && !(String.IsNullOrEmpty(password));
        }
        public void SignIn()
        {
        }

    }
}
