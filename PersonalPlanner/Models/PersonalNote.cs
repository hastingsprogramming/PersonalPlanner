using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlanner.Models
{
    public class PersonalNote : IDataModel
    {
        private int _id;
        private User _user;
        private string _title;
        private string _content;

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
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Removed { get; set; }

        public void UpdateDataSet() { }
    }
}
