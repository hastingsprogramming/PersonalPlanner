using System;

namespace PersonalPlanner.Models
{
	public class FinanceActivity : IDataModel
    {
		public int ID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int MoneyIn { get; set; }
		public int MoneyOut { get; set; }
		public DateTime ActivityDate { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public DateTime Removed { get; set; }

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
			// Create a new FinanceActivitiesRow in the dataset, request the most recent, then use that to create the new FinanceActivity.
			// Make sure to add the new FinanceActivity to the user.CashFlow property
			var adapter = new dataDataSetTableAdapters.FinanceActivitiesTableAdapter();
			adapter.Insert(user.Username, title, description, moneyIn, moneyOut, activityDate, DateTime.Now, DateTime.Now, default);
			return new FinanceActivity((dataDataSet.FinanceActivitiesRow)adapter.GetData().Select("Created="+DateTime.Now.ToString())[0]);
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
