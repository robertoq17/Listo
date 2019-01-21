using Listo.Models;
using Plugin.Messaging;
using System;
using System.Collections.ObjectModel;
using Listo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Listo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SaludPage : ContentPage
	{
        private ObservableCollection<CGroup> _allGroups;
        private ObservableCollection<CGroup> _expandedGroups;

        public SaludPage ()
		{
			InitializeComponent ();
            _allGroups = CGroup.All;
            UpdateListContent();
        }

        private void HeaderTapped(object sender, EventArgs args)
        {
            int selectedIndex = _expandedGroups.IndexOf(
                ((CGroup)((Button)sender).CommandParameter));
            _allGroups[selectedIndex].Expanded = !_allGroups[selectedIndex].Expanded;
            UpdateListContent();
        }

        private void UpdateListContent()
        {
            _expandedGroups = new ObservableCollection<CGroup>();
            foreach (CGroup group in _allGroups)
            {
                //Create new Groups so we do not alter original list
                CGroup newGroup = new CGroup(group.Title, group.ShortName, group.Expanded);
                //Add the count of contact items for Lits Header Titles to use
                newGroup.CCount = group.Count;
                if (group.Expanded)
                {
                    foreach (Contact contact in group)
                    {
                        newGroup.Add(contact);
                    }
                }
                _expandedGroups.Add(newGroup);
            }
            GroupedView.ItemsSource = _expandedGroups;
        }

        //private void BtnCall_Clicked(object sender, EventArgs e)
        //{
            
        //    var item = GroupedView.SelectedItem as Contact;
        //    var call = CrossMessaging.Current.PhoneDialer;
        //    if (call.CanMakePhoneCall)
        //        call.MakePhoneCall("76021703");
        //}

        //private async void BtnWhatsapp_Clicked(object sender, EventArgs e)
        //{
        ////https://wa.me/15551234567?text=I'm%20interested%20in%20your%20car%20for%20sale
        //    string msg= "Estoy%20interesado%20en%20su%20servicio";
        //    string number="59176021703";
        //    string uri = string.Format("https://wa.me/{0}?text={1}", number, msg);

        //    try
        //    {
        //        Device.OpenUri(new Uri(uri));
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Not Installed", "Whatsapp Not Installed", "ok");
        //        await DisplayAlert("", ex.Message, "ok");
        //    }
        //}

        //private void BtnCall_Clicked(object sender, EventArgs e)
        //{
        //    private string _phonenumber;
        //    var call = CrossMessaging.Current.PhoneDialer;
        //    if (call.CanMakePhoneCall)
        //        call.MakePhoneCall(_phonenumber);
        //}
    }
}