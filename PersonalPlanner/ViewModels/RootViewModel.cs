using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlanner.ViewModels
{
    class RootViewModel : Conductor<object>
    {
        IWindowManager WindowManager;

        public RootViewModel(IWindowManager wm)
        {
            WindowManager = wm;
        }

        public void Loaded() => GetNewSignIn();

        public void DashboardShow() => ActivateItem(IoC.Get<DashboardViewModel>());
        public void FinanceShow() => ActivateItem(IoC.Get<FinanceViewModel>());
        public void NotesShow() => ActivateItem(IoC.Get<NotesViewModel>());
        public void EventsShow() => ActivateItem(IoC.Get<EventsViewModel>());
        public void ProjectsShow() => ActivateItem(IoC.Get<ProjectsViewModel>());

        public void SignOut()
        {
            if (WindowManager.ShowDialog(new TwoButtonDialogViewModel("Quit", "Are you sure you want to sign out:", "Yes", "No")) == true)
            {
                GetNewSignIn();
            }
        }
        public void GetNewSignIn()
        {
            Reset();
            var vm = IoC.Get<LoginViewModel>();
            var r = WindowManager.ShowDialog(vm, null, null);

            if (r.HasValue && r.Value == false) TryClose();
        }

        void Reset()
        {
            DashboardShow();
        }
    }
}
