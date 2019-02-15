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

        private ObservableCollection<GroupViewModel> _allGroups;
        private ObservableCollection<GroupViewModel> _expandedGroups;
        private ObservableCollection<GroupViewModel> itemSource;
        //private ApiService apiService;

        #endregion

        #region Properties
        public Category CategorySelected { get; set; }

        public ObservableCollection<GroupViewModel> AllGroups
        {
            get { return this._allGroups; }
            set { this.SetValue(ref this._allGroups, value); }
        }
        public ObservableCollection<GroupViewModel> ExpandedGroups
        {
            get { return this._expandedGroups; }
            set { this.SetValue(ref this._expandedGroups, value); }
        }

        public ObservableCollection<GroupViewModel> ItemSource
        {
            get { return this.itemSource; }
            set { this.SetValue(ref this.itemSource, value); }
        }

        #endregion

        #region Constructor
        public SubCategoryViewModel(Category itemSelect)
        {
            this.CategorySelected = itemSelect;

            if (CategorySelected.Name.ToLower() == "salud")
            {
                _allGroups = GroupViewModel.All;
                this.AllGroups = _allGroups;
                this.ExpandedGroups = _expandedGroups;
                UpdateListContent();
            }
            else if (CategorySelected.Name.ToLower() == "hogar")
            {
                _allGroups = GroupViewModel.AllH;
                this.AllGroups = _allGroups;
                this.ExpandedGroups = _expandedGroups;
                UpdateListContent();
            }
            else if (CategorySelected.Name.ToLower() == "profesional")
            {
                _allGroups = GroupViewModel.AllP;
                this.AllGroups = _allGroups;
                this.ExpandedGroups = _expandedGroups;
                UpdateListContent();
            }


        }

        public SubCategoryViewModel()
        {
            _allGroups = GroupViewModel.All;
            this.AllGroups = _allGroups;
            this.ExpandedGroups = _expandedGroups;
            UpdateListContent();
        }
        #endregion

        #region Methods

        private void HeaderTapped(GroupViewModel item)
        {
            try
            {   //Search for the position
                int selectedIndex = ExpandedGroups.IndexOf(item);


                AllGroups[selectedIndex].Expanded = !AllGroups[selectedIndex].Expanded;
                UpdateListContent();
            }
            catch (Exception e)
            {
                //Application.Current.MainPage.DisplayAlert("Error","Error:"+e,"OK");
            }
        }

        private void UpdateListContent()
        {
            ExpandedGroups = new ObservableCollection<GroupViewModel>();
            foreach (GroupViewModel group in AllGroups)
            {
                //Create new Groups so we do not alter original list
                GroupViewModel newGroup = new GroupViewModel(group.Title, group.ShortName, group.Expanded);
                //Add the count of contact items for Lits Header Titles to use
                newGroup.CCount = group.Count;
                if (group.Expanded)
                {
                    foreach (Contact contact in group)
                    {
                        newGroup.Add(contact);
                    }
                }
                ExpandedGroups.Add(newGroup);
            }
            this.ItemSource = ExpandedGroups;
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
                return new RelayCommand<GroupViewModel>(HeaderTapped);
            }
        }
        #endregion


    }
}
