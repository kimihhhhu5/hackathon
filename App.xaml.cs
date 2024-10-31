 using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HACKATHON
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (!Application.Current.Properties.ContainsKey("db"))
            {
                Application.Current.Properties["db"] = "Server=127.0.0.1;Database=hackathon;User ID=root;Password=kuro147,Pooling = false;";
            }

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
