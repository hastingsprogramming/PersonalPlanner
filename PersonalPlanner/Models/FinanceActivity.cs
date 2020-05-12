using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlanner.Models
{
    public class FinanceActivity : IDataModel
    {
		private int _id;
		private User _user;
		private string _title;
		private string _description;
		private int _moneyIn;
		private int _moneyOut;
		private DateTime _activityDate;

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
		public int MoneyIn
		{
			get { return _moneyIn; }
			set { _moneyIn = value; }
		}
		public int MoneyOut
		{
			get { return _moneyOut; }
			set { _moneyOut = value; }
		}
		public DateTime ActivityDate
		{
			get { return _activityDate; }
			set { _activityDate = value; }
		}
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public DateTime Removed { get; set; }

		public void UpdateDataSet() { }
	}
}
