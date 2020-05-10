using Caliburn.Micro;

namespace PersonalPlanner.ViewModels
{
    class TwoButtonDialogViewModel : Screen
    {
        private string _title;
        private string _message;
        private string _okayButtonText;
        private string _cancelButtonText;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public string OkayButtonText
        {
            get { return _okayButtonText; }
            set { _okayButtonText = value; }
        }
        public string CancelButtonText
        {
            get { return _cancelButtonText; }
            set { _cancelButtonText = value; }
        }



        public TwoButtonDialogViewModel(string message) => new TwoButtonDialogViewModel("", message, "Okay", "Cancel");
        public TwoButtonDialogViewModel(string title, string message) => new TwoButtonDialogViewModel(title, message, "Okay", "Cancel");
        public TwoButtonDialogViewModel(string title, string message, string button1) => new TwoButtonDialogViewModel(title, message, button1, "Cancel");
        public TwoButtonDialogViewModel(string title, string message, string button1, string button2)
        {
            Title = title;
            Message = message;
            OkayButtonText = button1;
            CancelButtonText = button2;
        }

        public void Okay() => TryClose(true);
        public void Cancel() => TryClose(false);
    }
}
