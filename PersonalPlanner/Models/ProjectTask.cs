using System;
using System.Collections.Generic;

namespace PersonalPlanner.Models
{
    public class ProjectTask : IDataModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Completed { get; set; }
        public List<TaskNote> Notes {get; set;}
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Removed { get; set; }

        public ProjectTask(dataDataSet.ProjectTasksRow taskData)
        {
            ID = taskData.ID;
            Title = taskData.Title;
            Content = taskData.Title;
            Completed = taskData.Completed;
            Notes = GetNotes();
            Created = taskData.Created;
            Updated = taskData.Updated;
            Removed = taskData.Removed; 
        }

        public static ProjectTask CreateNew(Project project, string title, string content, bool completed)
        {
            // Create a new ProjectsTaskRow in the dataset, request the most recent, then use that to create the new ProjectTask.
            // Make sure to add the new TaskNote to the project.Tasks property
            return null;
        }

        public List<TaskNote> GetNotes() { return new List<TaskNote>(); }

        public void Update(string _title, string _content, bool _completed) 
        {
            Title = _title;
            Content = _content;
            Completed = _completed;
            Updated = DateTime.Now;
        }
    }
}
