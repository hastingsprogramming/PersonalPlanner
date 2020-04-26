using Caliburn.Micro;
using System.Linq;

namespace PersonalPlanner.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanSignIn);
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanSignIn);
            }
        }

        private IWindowManager WindowManager;

        public LoginViewModel(IWindowManager windowManager)
        {
            WindowManager = windowManager;
        }

        public bool CanSignIn
        {
            get
            {
                if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
                {
                    if (Password.Length >= 8)
                    {
                        if (Password.Any(x => char.IsUpper(x)))
                        {
                            if (Password.Any(x => char.IsLower(x)))
                            {
                                if (Password.Any(x => char.IsDigit(x))) return true;
                            }
                        }
                    }
                }
            return false;
            }
        }
        public void SignIn()
        {
            WindowManager.ShowWindow(new RootViewModel());
            this.TryClose();
        }

        public void AddUser()
        {
            bool? result = WindowManager.ShowDialog(new AddUserViewModel());
        }
        public void Cancel() => TryClose();
    }
}
