using Caliburn.Micro;
using PersonalPlanner.Models;
using System;

namespace PersonalPlanner.ViewModels
{
    public class RootViewModel : Conductor<object>
    {
        private string _usersName;

        private User User
        {
            get { return App.currentUser; }
        }
        public string UsersName
        {
            get { return _usersName; }
            set { 
                _usersName = value;
                NotifyOfPropertyChange(() => UsersName);
            }
        }


        IWindowManager WindowManager;

        public RootViewModel(IWindowManager wm)
        {
            WindowManager = wm;
        }

        public void Loaded() => GetNewSignIn();

        public void DashboardShow() => ActivateItem(App.DashboardViewModel);
        public void FinanceShow() => ActivateItem(App.FinanceViewModel);
        public void NotesShow() => ActivateItem(App.NotesViewModel);
        public void EventsShow() => ActivateItem(App.EventsViewModel);
        public void ProjectsShow() => ActivateItem(App.ProjectsViewModel);

        public void SignOut()
        {
            if (WindowManager.ShowDialog(new TwoButtonDialogViewModel("Quit", "Are you sure you want to sign out:", "Yes", "No")) == true)
            {
                App.currentUser = null;
                GetNewSignIn();
            }
        }
        public void GetNewSignIn()
        {
            App.currentUser = null;
            Reset();
            var vm = IoC.Get<LoginViewModel>();
            var r = WindowManager.ShowDialog(vm, null, null);
            if (r.HasValue && r.Value == false)
            {
                TryClose();
                return; 
            }

            UpdateViews();
        }
        
        public void UpdateViews()
        {
            // Each of the cards must update with the relevant data, as well as updating the name on the nav
            UsersName = String.Format("{0} {1}", User.FirstName, User.LastName);
            App.DashboardViewModel.Update();
            App.FinanceViewModel.Update();
            App.EventsViewModel.Update();
            App.NotesViewModel.Update();
            App.ProjectsViewModel.Update();
        }

        void Reset()
        {
            DashboardShow();
            App.DashboardViewModel.Update();
        }
    }
}
