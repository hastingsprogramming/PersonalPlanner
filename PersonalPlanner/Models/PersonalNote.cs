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
            var adapter = new dataDataSetTableAdapters.PersonalNotesTableAdapter();
            var createdTime = DateTime.Now;
            adapter.Insert(user.Username, title, content, createdTime, createdTime, default);
            return new PersonalNote((dataDataSet.PersonalNotesRow)adapter.GetData().Select("Created=" + createdTime.ToString())[0]);
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
