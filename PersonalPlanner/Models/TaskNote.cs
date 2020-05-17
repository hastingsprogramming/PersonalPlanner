using System;

namespace PersonalPlanner.Models
{
    public class TaskNote : IDataModel
	{
		public int ID { get; set; }
        public string Title { get; set; }
		public string Content { get; set; }
		public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Removed { get; set; }

        public TaskNote(dataDataSet.TaskNotesRow noteData)
        {
            ID = noteData.ID;
            Title = noteData.Title;
            Content = noteData.Content;
            Created = noteData.Created;
            Updated = noteData.Updated;
            Removed = noteData.Removed;
        }

        public static TaskNote CreateNew(ProjectTask task, string title, string content)
        {
            var adapter = new dataDataSetTableAdapters.TaskNotesTableAdapter();
            var createdTime = DateTime.Now;
            adapter.Insert(task.ID, title, content, createdTime, createdTime, default);
            return new TaskNote((dataDataSet.TaskNotesRow)adapter.GetData().Select("Created=" + createdTime.ToString())[0]);
        }

        public void Update(string _title, string _content) 
        {
            Title = _title;
            Content = _content;
            Updated = DateTime.Now;

            var adapter = new dataDataSetTableAdapters.TaskNotesTableAdapter();
            adapter.UpdateData(Title, Content, Updated, ID);
        }
    }
}
