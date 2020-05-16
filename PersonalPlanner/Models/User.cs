using System;
using System.Collections.Generic;
using System.Windows.Navigation;

namespace PersonalPlanner.Models
{
    public class User : IDataModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<FinanceActivity> CashFlow { get; set; }
        public List<PersonalEvent> Events { get;  set; }
        public List<PersonalNote> Notes { get; set; }
        public List<Project> Projects { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Removed { get; set; }

        public User(dataDataSet.UsersRow userData)
        {
            Username = userData.Password;
            Password = userData.Password;
            FirstName = userData.FirstName;
            LastName = userData.LastName;
            CashFlow = GetCashFlow();
            Events = GetEvents();
            Notes = GetNotes();
            Projects = GetProjects();
            Created = userData.Created;
            Updated = userData.Updated;
            Removed = userData.Removed;
        }

        public static User CreateNew(string username, string password, string firstName, string lastName)
        {
            // Create a new UsersRow in the dataset, request the most recent, then use that to create the new User.
            var adapter = new dataDataSetTableAdapters.UsersTableAdapter();
            adapter.Insert(username, password, firstName, lastName, DateTime.Now, DateTime.Now, default);
            return new User((dataDataSet.UsersRow)adapter.GetData().Select($"Username=username")[0]);
        }

        public List<FinanceActivity> GetCashFlow() { return new List<FinanceActivity>(); }
        public List<PersonalEvent> GetEvents() { return new List<PersonalEvent>(); }
        public List<PersonalNote> GetNotes() { return new List<PersonalNote>(); }
        public List<Project> GetProjects() { return new List<Project>(); }

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
