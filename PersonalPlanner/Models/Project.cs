using System;
using System.Collections.Generic;

namespace PersonalPlanner.Models
{
    public class Project : IDataModel
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public List<ProjectNote> Notes { get; set; }
		public List<ProjectTask> Tasks { get; set; }
		public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Removed { get; set; }

		public Project(dataDataSet.ProjectsRow projectData)
		{
			ID = projectData.ID;
			Title = projectData.Title;
			Description = projectData.Description;
			Notes = LoadNotes();
			Tasks = LoadTasks();
			Created = projectData.Created;
			Updated = projectData.Created;
			Removed = projectData.Removed;
		}
		public static Project CreateNew(User user, string title, string description)
		{
			// Create a new ProjectsRow in the dataset, request the most recent, then use that to create the new Project.
			// Make sure to add the new Project to the user.Projects property
			return null;
		}
		private List<ProjectNote> LoadNotes() 
		{ 
			return new List<ProjectNote>(); 
		}
		private List<ProjectTask> LoadTasks()
		{
			return new List<ProjectTask>();
		}
		public void Update(string _title, string _description)
		{
			Title = _title;
			Description = _description;
			Updated = DateTime.Now;
		}
	}
}
