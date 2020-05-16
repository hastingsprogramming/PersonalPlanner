using Caliburn.Micro;
using PersonalPlanner.Models;
using System.Linq;

namespace PersonalPlanner.ViewModels
{
    public class AddUserViewModel : Screen
    {
        private string _username;
        private string _firstName;
        private string _lastName;
        private string _password;
        private string _confirmPassword;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanAddUser);
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => CanAddUser);
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => CanAddUser);
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanAddUser);
            }
        }
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                NotifyOfPropertyChange(() => ConfirmPassword);
                NotifyOfPropertyChange(() => CanAddUser);
            }
        }

        public IWindowManager WindowManager;
        public AddUserViewModel(IWindowManager wm)
        {
            WindowManager = wm;
        }

        public void Cancel()
        {
            if (WindowManager.ShowDialog(new TwoButtonDialogViewModel("Cancel", "Are you sure you want to cancel adding a new user. No details will be saved:", "Yes", "No")) == true) this.TryClose(false);
            else return;
        }

        public bool CanAddUser
        {
            get
            {
                if (!string.IsNullOrEmpty(Username)
                    && !string.IsNullOrEmpty(FirstName)
                    && !string.IsNullOrEmpty(LastName)
                    && !string.IsNullOrEmpty(Password)
                    && !string.IsNullOrEmpty(ConfirmPassword))
                {
                    if (Password.Length >= 8)
                    {
                        if (Password.Any(x => char.IsUpper(x)))
                        {
                            if (Password.Any(x => char.IsLower(x)))
                            {
                                if (Password.Any(x => char.IsDigit(x)))
                                {
                                    if (ConfirmPassword == Password)
                                    return true;
                                }
                            }
                        }
                    }
                }
                return false;
            }
        }
        public void AddUser()
        {

            User.CreateNew(Username, Password, FirstName, LastName);
            TryClose(true);
        }

    }
}
