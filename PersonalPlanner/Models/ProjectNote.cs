using System;

namespace PersonalPlanner.Models
{
    public class ProjectNote : IDataModel
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Removed { get; set; }

		public ProjectNote(dataDataSet.ProjectNotesRow noteData)
		{
			ID = noteData.ID;
			Title = noteData.Title;
			Content = noteData.Content;
			Created = noteData.Created;
			Updated = noteData.Updated;
			Removed = noteData.Removed;
		}

		public static ProjectNote CreateNew(Project project, string title, string content)
		{
			var adapter = new dataDataSetTableAdapters.ProjectNotesTableAdapter();
			var createdTime = DateTime.Now;
			adapter.Insert(project.ID, title, content, createdTime, createdTime, default);
			return new ProjectNote((dataDataSet.ProjectNotesRow)adapter.GetData().Select("Created=" + createdTime.ToString())[0]);
		}

		public void Update(string _title, string _content)
		{
			Title = _title;
			Content = _content;
			Updated = DateTime.Now;

			var adapter = new dataDataSetTableAdapters.ProjectNotesTableAdapter();
			adapter.UpdateData(Title, Content, Updated, ID);
		}
	}
}
