using Listo.ViewModels;
using Listo.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Listo
{
    public partial class App : Application
    {
        string pushValue;

        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzA3NjFAMzEzNjJlMzQyZTMwb2JNVzZOQnBKdEIyRkorbmtxRVcwQWlKdnRHZXlzUDZONmtZY1o2WkVsMD0=");

            InitializeComponent();

            MainPage = new NavigationPage(new CategoryPage());


        }

        protected override void OnStart()
        {
            // This should come before AppCenter.Start() is called
            // Avoid duplicate event registration:
            ReceivedMessageWithAppCenter();



            // AppCenter.start after
            // Handle when your app starts
            AppCenter.Start("android=ba6eb727-fecd-4e0b-8935-623b67d57036;" +
                "uwp=d1f0d766-831d-4ded-9e34-5cca0d89bd3d;" +
                "ios={Your iOS App secret here}",
                typeof(Push),
                typeof(Analytics),
                typeof(Crashes)
                );
        }

        private void ReceivedMessageWithAppCenter()
        {
            if (!AppCenter.Configured)
            {
                Push.PushNotificationReceived += (sender, e) =>
                {
                    // Add the notification message and title to the message
                    var summary = $"Push notification received:" +
                                        $"\n\tNotification title: {e.Title}" +
                                        $"\n\tMessage: {e.Message}";

                    // If there is custom data associated with the notification,
                    // print the entries
                    if (e.CustomData != null)
                    {
                        summary += "\n\tCustom data:\n";
                        foreach (var key in e.CustomData.Keys)
                        {
                            summary += $"\t\t{key} : {e.CustomData[key]}\n";

                            //Here su caught the value
                            if (string.IsNullOrEmpty(pushValue))
                            {
                                pushValue = key;

                                if (!string.IsNullOrEmpty(pushValue) && pushValue.ToLower() == "sub")
                                {
                                    MainViewModel.GetInstance().Rating = new RatingViewModel();
                                    Current.MainPage.Navigation.PushAsync(new RatingPage());
                                }
                            }
                        }
                    }

                    // Send the notification summary to debug output
                    System.Diagnostics.Debug.WriteLine(summary);
                };
            }
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
