using Caliburn.Micro;
using PersonalPlanner.Models;
using PersonalPlanner.ViewModels;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace PersonalPlanner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static User currentUser = null;
        public static DashboardViewModel DashboardViewModel = new DashboardViewModel();
        public static FinanceViewModel FinanceViewModel = new FinanceViewModel();
        public static NotesViewModel NotesViewModel = new NotesViewModel();
        public static EventsViewModel EventsViewModel = new EventsViewModel();
        public static ProjectsViewModel ProjectsViewModel = new ProjectsViewModel();
        public static string GetSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
