using Caliburn.Micro;
using PersonalPlanner.Models;
using System.Collections.Generic;
using System.Windows.Controls;

namespace PersonalPlanner.ViewModels
{
    public class DashboardViewModel : Screen
    {
        #region Properties
        private string _moneyIn = "£0.00";
        private string _moneyOut = "£0.00";

        public string MoneyIn
        {
            get { return _moneyIn; }
            set { _moneyIn = value; NotifyOfPropertyChange(() => MoneyIn); }
        }
        public string MoneyOut
        {
            get { return _moneyOut; }
            set { _moneyOut = value; NotifyOfPropertyChange(() => MoneyOut); }
        }
        private List<Control> _eventControls;

        public List<Control> EventControls
        {
            get { return _eventControls; }
            set { _eventControls = value; }
        }

        #endregion

        private User User
        {
            get { return App.currentUser; }
        }
        private WindowManager WindowManager;

        public DashboardViewModel()
        {
            WindowManager = new WindowManager();
        }

        #region Reset Functions
        public void Update()
        {
            ResetFinanceCard();
            ResetEventsCard();
            ResetNotesCard();
            ResetProjectsCard();
        }
        public void ResetFinanceCard()
        {
            var financeData = User != null ? User.LastMonthCashFlow : new int[] { 0, 0 };
            MoneyIn = string.Format("£{0:0.00}", financeData[0] / 100);
            MoneyOut = string.Format("£{0:0.00}", financeData[1] / 100);
        }
        public void ResetEventsCard()
        {

        }
        public void ResetNotesCard()
        {

        }
        public void ResetProjectsCard()
        {

        }
        #endregion

        #region Finance Functions
        public void GoToFinance() => (this.Parent as RootViewModel).FinanceShow();
        public void AddFinanceActivity()
        {
            if (WindowManager.ShowDialog(new AddFinanceActivityViewModel()) == true) ResetFinanceCard();
        }
        #endregion

        #region Events Functions
        public void GoToEvents() => (this.Parent as RootViewModel).EventsShow();
        public void AddEvent()
        {
            if (WindowManager.ShowDialog(new AddEventViewModel()) == true) ResetEventsCard();
        }
        #endregion

        #region Notes Functions
        public void GoToNotes() => (this.Parent as RootViewModel).NotesShow();
        public void AddNote()
        {
            if (WindowManager.ShowDialog(new AddNoteViewModel()) == true) ResetNotesCard();
        }
        #endregion

        #region Projects Functions
        public void GoToProjects() => (this.Parent as RootViewModel).ProjectsShow();
        public void AddProject()
        {
            if (WindowManager.ShowDialog(new AddProjectViewModel()) == true) ResetProjectsCard();
        }
        #endregion
    }
}
