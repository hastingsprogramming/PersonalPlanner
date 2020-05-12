using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlanner.Models
{
    public class TaskNote : IDataModel
	{
		private int _id;
		private ProjectTask _task;
		private string _title;
		private string _description;

		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}
		public ProjectTask Task
		{
			get { return _task; }
			set { _task = value; }
		}
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}
		public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Removed { get; set; }

        public void UpdateDataSet() { }
    }
}
