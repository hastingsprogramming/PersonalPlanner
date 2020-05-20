using System;
using System.Linq;

namespace PersonalPlanner.Models
{
	public class FinanceActivity : IDataModel
    {
        #region Properties
        public int ID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int MoneyIn { get; set; }
		public int MoneyOut { get; set; }
		public DateTime ActivityDate { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public DateTime Removed { get; set; }
        #endregion

        public FinanceActivity(dataDataSet.FinanceActivitiesRow activityData)
		{
			ID = activityData.ID;
			Title = activityData.Title;
			Description = activityData.Description;
			MoneyIn = activityData.MoneyIn;
			MoneyOut = activityData.MoneyOut;
			ActivityDate = activityData.ActivityDate;
			Created = activityData.Created;
			Updated = activityData.Updated;
			Removed = activityData.Removed;
		}

		public static FinanceActivity CreateNew(User user, string title, string description, int moneyIn, int moneyOut, DateTime activityDate)
		{
			var adapter = new dataDataSetTableAdapters.FinanceActivitiesTableAdapter();
			var createdTime = DateTime.Now;
			adapter.Insert(user.Username, title, description, moneyIn, moneyOut, activityDate, createdTime, createdTime, DateTime.MinValue);
			FinanceActivity fa = new FinanceActivity(adapter.GetData().Last()); ;
			return fa;
		}

		public void Update(string _title, string _description, int _moneyIn, int _moneyOut, DateTime _activityDate)
		{
			Title = _title;
			Description = _description;
			MoneyIn = _moneyIn;
			MoneyOut = _moneyOut;
			ActivityDate = _activityDate;
			Updated = DateTime.Now;

			var adapter = new dataDataSetTableAdapters.FinanceActivitiesTableAdapter();
			adapter.UpdateData(Title, Description, MoneyIn, MoneyOut, ActivityDate, Updated, ID);
		}
	}
}
