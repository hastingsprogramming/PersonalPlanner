using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlanner.Models
{
    public class PersonalEvent : IDataModel
    {
		private int _id;
		private User _user;
		private string _title;
		private string _description;
		private DateTime _when;

		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}
		public User User
		{
			get { return _user; }
			set { _user = value; }
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
		public DateTime When
		{
			get { return _when; }
			set { _when = value; }
		}
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public DateTime Removed { get; set; }

		public void UpdateDataSet() { }
	}
}
