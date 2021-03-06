﻿using System;
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
            var adapter = new dataDataSetTableAdapters.ProjectTasksTableAdapter();
            var createdTime = DateTime.Now;
            adapter.Insert(project.ID, title, content, completed, createdTime, createdTime, default);
            return new ProjectTask((dataDataSet.ProjectTasksRow)adapter.GetData().Select("Created=" + createdTime.ToString())[0]);
        }

        public List<TaskNote> GetNotes() { return new List<TaskNote>(); }

        public void Update(string _title, string _content, bool _completed) 
        {
            Title = _title;
            Content = _content;
            Completed = _completed;
            Updated = DateTime.Now;

            var adapter = new dataDataSetTableAdapters.ProjectTasksTableAdapter();
            adapter.UpdateData(Title, Content, Completed, Updated, ID);
        }
    }
}
