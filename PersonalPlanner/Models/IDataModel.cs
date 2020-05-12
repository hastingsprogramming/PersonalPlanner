using System;

namespace PersonalPlanner.Models
{
    interface IDataModel
    {
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
        DateTime Removed { get; set; }

        void UpdateDataSet();
    }
}
