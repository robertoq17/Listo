using GalaSoft.MvvmLight.Command;
using Listo.Models;
using Listo.Services;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Listo.ViewModels
{
    public class SaludViewModel : BaseViewModel
    {

        #region Attributes
        //private ObservableCollection<Contact> contact;
        //private ObservableCollection<Contact> contactSelected;
        //private ObservableCollection<CGroup> _allGroups;
        //private ObservableCollection<CGroup> _expandedGroups;
        private ApiService apiService;
        #endregion

        #region Properties

        //public ObservableCollection<Contact> Contact
        //{
        //    get { return this.contact; }
        //    set { this.SetValue(ref this.contact, value); }
        //}

        //public ObservableCollection<Contact> ContactSelected
        //{
        //    get { return this.contactSelected; }
        //    set { this.SetValue(ref this.contactSelected, value); }
        //}

        //public ObservableCollection<CGroup> AllGroups
        //{
        //    get { return this._allGroups; }
        //    set { this.SetValue(ref this._allGroups, value); }
        //}

        //public ObservableCollection<CGroup> ExpandedGroups
        //{
        //    get { return this._expandedGroups; }
        //    set { this.SetValue(ref this._expandedGroups, value); }
        //}
        #endregion

        #region Constructor
        public SaludViewModel()
        {
            //_allGroups = CGroup.All;

            //For the services
            //this.apiService = new ApiService();
            //this.LoadCGroup();

        }



        #endregion

        #region Methods
        //private async void LoadCGroup()
        //{
        //    var connection = await this.apiService.CheckConnection();

        //    if(!connection.IsSuccess)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("ERROR", connection.Message, "ok");
        //        await Application.Current.MainPage.Navigation.PopAsync();
        //        return;
        //    }



        //    var response = await this.apiService.GetList<Contact>(
        //        "",
        //        "",
        //        "");

        //    if (!response.IsSuccess)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("ERROR", response.Message, "ok");
        //        return;
        //    }

        //    var list = (List<Contact>)response.Result;
        //    this.Contact = new ObservableCollection<Contact>(list);

        //}


        //public ObservableCollection<CGroup> UpdateListContent()
        //{
        //    _expandedGroups = new ObservableCollection<CGroup>();
        //    foreach (CGroup group in _allGroups)
        //    {
        //        //Create new Groups so we do not alter original list
        //        CGroup newGroup = new CGroup(group.Title, group.ShortName, group.Expanded);
        //        //Add the count of contact items for Lits Header Titles to use
        //        newGroup.CCount = group.Count;
        //        if (group.Expanded)
        //        {
        //            foreach (Contact contact in group)
        //            {
        //                newGroup.Add(contact);
        //            }
        //        }
        //        _expandedGroups.Add(newGroup);
        //    }
        //    return _expandedGroups;
        //}

        //private void HeaderTapped(object sender, EventArgs args)
        //{
        //    int selectedIndex = _expandedGroups.IndexOf(
        //        ((CGroup)((Button)sender).CommandParameter));
        //    _allGroups[selectedIndex].Expanded = !_allGroups[selectedIndex].Expanded;
        //    GroupedView.ItemsSource = UpdateListContent();


        private void MakeACallNumber(string number)
        {
            //if (string.IsNullOrEmpty(number))
            //{
            //    await Application.Current.MainPage.DisplayAlert(
            //    "Error",
            //    "El contacto no tiene telefono...",
            //    "Accept");
            //    return;
            //}

            var call = CrossMessaging.Current.PhoneDialer;
            if (call.CanMakePhoneCall)
                call.MakePhoneCall(number);
        }

        private async void SendAWhatsapp(string number)
        {
            //if (string.IsNullOrEmpty(number))
            //{
            //    await Application.Current.MainPage.DisplayAlert(
            //    "Error",
            //    "El contacto no tiene Whatsapp...",
            //    "Accept");
            //    return;
            //}

            string msg = "Estoy%20interesado%20en%20su%20servicio";
            string uri = string.Format("https://wa.me/{0}?text={1}", number, msg);           

            try
            {
                Device.OpenUri(new Uri(uri));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Not Installed", "Whatsapp Not Installed", "ok");
                await App.Current.MainPage.DisplayAlert("", ex.Message, "ok");
            }
        }
        #endregion


        #region Commands

        public ICommand MakeACallCommand
        {
            get
            {
                return new RelayCommand<string>(MakeACallNumber);
            }
        }

        public ICommand SendAWhatsappCommand
        {
            get
            {
                return new RelayCommand<string>(SendAWhatsapp);
            }
        }
        #endregion

    }

}

