﻿using Listo.Models;
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
        private ObservableCollection<GroupViewModel> _allGroups;
        private ObservableCollection<GroupViewModel> _expandedGroups;

        public SaludPage ()
		{
			InitializeComponent ();
            _allGroups = GroupViewModel.All;
            UpdateListContent();
        }

        private void HeaderTapped(object sender, EventArgs args)
        {
            int selectedIndex = _expandedGroups.IndexOf(
                ((GroupViewModel)((Button)sender).CommandParameter));
            _allGroups[selectedIndex].Expanded = !_allGroups[selectedIndex].Expanded;
            UpdateListContent();
        }

        private void UpdateListContent()
        {
            _expandedGroups = new ObservableCollection<GroupViewModel>();
            foreach (GroupViewModel group in _allGroups)
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
                _expandedGroups.Add(newGroup);
            }
            GroupedView.ItemsSource = _expandedGroups;
        }
    }
}