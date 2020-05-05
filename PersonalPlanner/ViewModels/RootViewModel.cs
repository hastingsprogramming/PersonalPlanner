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
            ActivateItem(IoC.Get<DashboardViewModel>());
        }

        public void Loaded()
        {
            var vm = IoC.Get<LoginViewModel>();
            var r = WindowManager.ShowDialog(vm, null, null);

            if (r.HasValue && r.Value == false)
            {
                TryClose();
            }
        }
    }
}
