using System;

namespace PersonalPlanner.Models
{
    public class PersonalEvent : IDataModel
    {
		public int ID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime When { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public DateTime Removed { get; set; }

		public PersonalEvent(dataDataSet.EventsRow eventData)
		{
			ID = eventData.ID;
			Title = eventData.Title;
			Description = eventData.Description;
			When = eventData.When;
			Created = eventData.Created;
			Updated = eventData.Updated;
			Removed = eventData.Removed;
		}

		public static PersonalEvent CreateNew(User user, string title, string description, DateTime when)
		{
			var adapter = new dataDataSetTableAdapters.EventsTableAdapter();
			var createdTime = DateTime.Now;
			adapter.Insert(user.Username, title, description, when, createdTime, createdTime, default);
			return new PersonalEvent((dataDataSet.EventsRow)adapter.GetData().Select("Created=" + createdTime.ToString())[0]);
		}

		public void Update(string _title, string _description, DateTime _when)
		{
			Title = _title;
			Description = _description;
			When = _when;
			Updated = DateTime.Now;

			var adapter = new dataDataSetTableAdapters.EventsTableAdapter();
			adapter.UpdateData(Title, Description, When, Updated, ID);
		}
	}
}
