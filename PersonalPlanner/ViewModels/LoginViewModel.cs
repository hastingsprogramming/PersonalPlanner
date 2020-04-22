using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlanner.ViewModels
{
    class LoginViewModel : Screen
    {
        public void CloseWindow() => this.TryClose();
    }
}
