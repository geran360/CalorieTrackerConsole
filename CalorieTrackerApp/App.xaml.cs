using Microsoft.Extensions.DependencyInjection;

namespace CalorieTrackerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }


    }
}