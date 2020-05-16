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
            // Create a new TaskNotesRow in the dataset, request the most recent, then use that to create the new TaskNote.
            // Make sure to add the new TaskNote to the task.Notes property
            return null;
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
