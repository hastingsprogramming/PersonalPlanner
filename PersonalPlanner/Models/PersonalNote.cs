using System;

namespace PersonalPlanner.Models
{
    public class PersonalNote : IDataModel
    { 
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Removed { get; set; }

        public PersonalNote(dataDataSet.PersonalNotesRow noteData)
        {
            ID = noteData.ID;
            Title = noteData.Title;
            Content = noteData.Content;
            Created = noteData.Created;
            Updated = noteData.Updated;
            Removed = noteData.Removed;
        }

        public static PersonalNote CreateNew(User user, string title, string content)
        {
            // Create a new PersonalNotesRow in the dataset, request the most recent, then use that to create the new PersonalNote.
            // Make sure to add the new PersonalNote to the user.Notes property
            var adapter = new dataDataSetTableAdapters.PersonalNotesTableAdapter();
            adapter.Insert(user.Username, title, content, DateTime.Now, DateTime.Now, default);
            return new PersonalNote((dataDataSet.PersonalNotesRow)adapter.GetData().Select("Created="+DateTime.Now.ToString())[0]);
        }

        public void Update(string _title, string _content)
        {
            Title = _title;
            Content = _content;
            Updated = DateTime.Now;

            var adapter = new dataDataSetTableAdapters.PersonalNotesTableAdapter();
            adapter.UpdateData(Title, Content, Updated, ID);
        }
    }
}
