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
        IWindowManager WM;
        public RootViewModel(IWindowManager wm)
        {
            WM = wm;
            ActivateItem(new DashboardViewModel());
        }
    }
}
