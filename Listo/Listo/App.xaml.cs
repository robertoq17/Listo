using Listo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Listo
{
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzA3NjFAMzEzNjJlMzQyZTMwb2JNVzZOQnBKdEIyRkorbmtxRVcwQWlKdnRHZXlzUDZONmtZY1o2WkVsMD0=");

            InitializeComponent();

            MainPage = new NavigationPage(new CategoryPage());
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
