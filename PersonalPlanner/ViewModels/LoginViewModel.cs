using Caliburn.Micro;
using PersonalPlanner.Models;
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
            try
            {
                User user = User.GetUser(Username, App.GetSha256Hash(Password));
                if (user == null) throw new System.Exception();
                ((App)(App.Current)).currentUser = user;
                this.TryClose(true);
            }
            catch
            {
                System.Windows.MessageBox.Show("There was an issue with your data");
            }
        }
        public void AddUser()
        {
            WindowManager.ShowDialog(IoC.Get<AddUserViewModel>());
        }
        public void Cancel()
        {
            if (WindowManager.ShowDialog(new TwoButtonDialogViewModel("Quit", "Are you sure you want to quit:", "Yes", "No")) == true) this.TryClose(false);
            else return;
        }
    }
}
