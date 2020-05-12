using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlanner.Models
{
    class ProjectNote
	{
		private int _id;
		private Project _project;
		private string _title;
		private string _content;

		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}
		public Project Project
		{
			get { return _project; }
			set { _project = value; }
		}
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}
		public string Content
		{
			get { return _content; }
			set { _content = value; }
		}
		public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Deleted { get; set; }

        public void UpdateDataSet() { }
    }
}
