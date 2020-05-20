using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace PersonalPlanner.ViewModels
{
    public class EventsViewModel : Screen
    {
        IWindowManager WindowManager;
        private List<Control> _eventControls = new List<Control>();

        public List<Control> EventControls
        {
            get { return _eventControls; }
            set { _eventControls = value; NotifyOfPropertyChange(() => EventControls); }
        }



        public EventsViewModel()
        {
            WindowManager = new WindowManager();
            EventControls.Add(new Label() { Content = "Hey there" });
        }
        public void Update()
        {

        }

        public void AddEvent()
        {
            var addEventWind = new AddEventViewModel();
            if (WindowManager.ShowDialog(addEventWind).Value == true)
            {
                EventControls.Add(new Label() { Content = "Hey there" });
            }
        }
    }
}
