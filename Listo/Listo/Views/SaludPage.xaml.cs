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


    }
}