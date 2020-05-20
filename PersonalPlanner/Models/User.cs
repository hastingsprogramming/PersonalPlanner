using System;
using System.Collections.Generic;
using static PersonalPlanner.dataDataSet;

namespace PersonalPlanner.Models
{
    public class User : IDataModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<FinanceActivity> CashFlow
        {
            get
            {
                var allFinance = new List<FinanceActivity>();
                var adapter = new dataDataSetTableAdapters.FinanceActivitiesTableAdapter();
                foreach (var activity in adapter.GetData().Select(string.Format("User = '{0}'", this.Username)))
                {
                    allFinance.Add(new FinanceActivity(activity as FinanceActivitiesRow));
                }

                return allFinance;
            }
        }
        public List<PersonalEvent> Events
        {
            get
            {
                var allEvents = new List<PersonalEvent>();
                var adapter = new dataDataSetTableAdapters.EventsTableAdapter();
                foreach (var pEvent in adapter.GetData().Select(string.Format("User = '{0}'", this.Username)))
                {
                    allEvents.Add(new PersonalEvent(pEvent as EventsRow));
                }

                return allEvents;
            }
        }
        public List<PersonalNote> Notes {
            get
            {
                var allNotes = new List<PersonalNote>();
                var adapter = new dataDataSetTableAdapters.PersonalNotesTableAdapter();
                foreach (var note in adapter.GetData().Select(string.Format("User = '{0}'", this.Username)))
                {
                    allNotes.Add(new PersonalNote(note as PersonalNotesRow));
                }

                return allNotes;
            }
        }
        public List<Project> Projects { 
            get
            {
                var allProjects = new List<Project>();
                var adapter = new dataDataSetTableAdapters.ProjectsTableAdapter();
                foreach (var project in adapter.GetData().Select(string.Format("User = '{0}'", this.Username)))
                {
                    allProjects.Add(new Project(project as ProjectsRow));
                }

                return allProjects;
            } }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Removed { get; set; }

        public int[] LastMonthCashFlow
        {
            get
            {
                int[] sums = { 0, 0 };
                foreach (FinanceActivity activity in CashFlow)
                {
                    if (activity.ActivityDate < DateTime.Now.Subtract(new TimeSpan(28, 0, 0, 0))) continue;
                    sums[0] += activity.MoneyIn;
                    sums[1] += activity.MoneyOut;
                }
                return sums;
            }
        }

        public User(UsersRow userData)
        {
            Username = userData.Username;
            Password = userData.Password;
            FirstName = userData.FirstName;
            LastName = userData.LastName;
            Created = userData.Created;
            Updated = userData.Updated;
            Removed = userData.Removed;
        }

        public static User CreateNew(string username, string password, string firstName, string lastName)
        {
            // Create a new UsersRow in the dataset, request the most recent, then use that to create the new User.
            var adapter = new dataDataSetTableAdapters.UsersTableAdapter();
            var createdTime = DateTime.Now;
            adapter.Insert(username, App.GetSha256Hash(password), firstName, lastName, createdTime, createdTime, default);
            return new User((dataDataSet.UsersRow)adapter.GetData().Select($"Username=username")[0]);
        }
        public List<PersonalEvent> GetEvents() { return new List<PersonalEvent>(); }
        public List<PersonalNote> GetNotes() { return new List<PersonalNote>(); }
        public List<Project> GetProjects() { return new List<Project>(); }

        public static User GetUser(string username, string password)
        {
            var adapter = new dataDataSetTableAdapters.UsersTableAdapter();
            var result = adapter.GetData().FindByUsername(username);

            if (result == null) return null;
            if (result.Password == password) return new User(result);
            else return null;
        }

        public void Update(string _password, string _firstName, string _lastName)
        {
            Password = _password;
            FirstName = _firstName;
            LastName = _lastName;
            Updated = DateTime.Now;

            var adapter = new dataDataSetTableAdapters.UsersTableAdapter();
            adapter.UpdateData(Password, FirstName, LastName, Updated, Username);
        }
    }
}
