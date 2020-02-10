using DateNight.Model;
using Xamarin.Forms;

namespace DateNight
{
    public partial class App : Application
    {
        public static DateCalculator dateCal;

        public App()
        {
            InitializeComponent();

            MainPage = new TabController();
            dateCal = new DateCalculator();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
