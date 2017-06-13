using AFPCapital.Movil.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AFPCapital.Movil.Storage;
using Xamarin.Forms;

namespace AFPCapital.Movil
{
    public partial class App : Application
    {
        public static AccountStorage UserProfile { get; set; }

        public App()
        {
            InitializeComponent();

            StorageManager db = new StorageManager();
            var user = db.GetCuentaAll().FirstOrDefault();
            if (user != null)
            {
                Perfilar(user);
            }
            else
            {
                MainPage = new NavigationPage(new LoginView())
                {
                    BarBackgroundColor = (Color)App.Current.Resources["BackgroundColorDark"],
                    BarTextColor = Color.White
                };
            }
        }

        public static void Perfilar(AccountStorage account)
        {
            UserProfile = account;
            Application.Current.MainPage = new NavigationPage(new PrincipalView())
            {
                BarBackgroundColor = (Color)App.Current.Resources["BackgroundColorDark"],
                BarTextColor = Color.White
            };
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
