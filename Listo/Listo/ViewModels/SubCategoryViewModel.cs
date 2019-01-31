using GalaSoft.MvvmLight.Command;
using Listo.Models;
using Listo.Services;
using Listo.Views;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Listo.ViewModels
{
    public class SubCategoryViewModel : BaseViewModel
    {
        #region Attributes
        ////private ObservableCollection<Contact> contact;
        ////private ObservableCollection<Contact> contactSelected;
        private ObservableCollection<CGroup> _allGroups;
        private ObservableCollection<CGroup> _expandedGroups;
        private ObservableCollection<CGroup> itemSource;
        //private ApiService apiService;
        #endregion

        #region Properties
        public Category CategorySelected { get; set; }

        public ObservableCollection<CGroup> ItemSource {
            get { return this.itemSource; }
            set { this.SetValue(ref this.itemSource, value); }
        }

        #endregion

        #region Constructor
        public SubCategoryViewModel(Category itemSelect)
        {
            this.CategorySelected = itemSelect;
            _allGroups = CGroup.All;
            UpdateListContent();
        }

        public SubCategoryViewModel()
        {

        }
        #endregion

        #region Methods

        private void HeaderTapped(object sender)
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

            ItemSource = _expandedGroups;
        }


        //Methods for the buttons Call and Send a Message
        private void MakeACallNumber(string number)
        {
            var call = CrossMessaging.Current.PhoneDialer;
            if (call.CanMakePhoneCall)
                call.MakePhoneCall(number);
        }

        private async void SendAWhatsapp(string number)
        {
            number = "591" + number;
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

        public ICommand HeadTappedCommand
        {
            get
            {
                return new RelayCommand<object>(HeaderTapped);
            }
        }
        #endregion


    }
}
