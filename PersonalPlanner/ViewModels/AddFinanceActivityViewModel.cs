using PersonalPlanner.Models;
using Caliburn.Micro;
using System;

namespace PersonalPlanner.ViewModels
{
    public class AddFinanceActivityViewModel : Screen
    {
        #region Properties
        private string _title = "";
        private string _description = "";
        private string _moneyIn = "0.00";
        private string _moneyOut = "0.00";
        private DateTime _activityDate = DateTime.Now;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
                NotifyOfPropertyChange(() => CanAddActivity);
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
                NotifyOfPropertyChange(() => CanAddActivity);
            }
        }
        public string MoneyIn
        {
            get { return _moneyIn; }
            set
            {
                _moneyIn = (value == "" ? "0.00" : value);
                NotifyOfPropertyChange(() => MoneyIn);
                NotifyOfPropertyChange(() => CanAddActivity);
            }
        }
        public string MoneyOut
        {
            get { return _moneyOut; }
            set
            {
                _moneyOut = (value == "" ? "0.00" : value);
                NotifyOfPropertyChange(() => MoneyOut);
                NotifyOfPropertyChange(() => CanAddActivity);
            }
        }
        public DateTime ActivityDate
        {
            get { return _activityDate; }
            set
            {
                _activityDate = value;
                NotifyOfPropertyChange(() => ActivityDate);
                NotifyOfPropertyChange(() => CanAddActivity);
            }
        }
        #endregion

        public User User { get { return App.currentUser; } }
        public FinanceActivity Activity;

        public bool CanAddActivity
        {
            get
            {
                if (Title == "") return false;
                if (MoneyIn == "0.00" &&
                    MoneyOut == "0.00") return false;
                if (ActivityDate.Date > DateTime.Now) return false;

                return true;
            }
        }

        public void AddActivity()
        {
            try
            {
                Activity = FinanceActivity.CreateNew(User, Title, Description, (int)Math.Floor(Convert.ToDecimal(MoneyIn) * 100), (int)Math.Floor(Convert.ToDecimal(MoneyOut) * 100), ActivityDate);
                TryClose(true);
            }
            catch { return; }
        }

        public void Cancel()
        {
            if (new WindowManager().ShowDialog(new TwoButtonDialogViewModel("Quit", "Are you sure you want to cancel", "Yes", "No")) == true) this.TryClose(false);
            else return;
        }
    }
}
