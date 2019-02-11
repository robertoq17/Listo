using Listo.Models;
using Listo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Listo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfesionalPage : ContentPage
	{
        private ObservableCollection<GroupViewModel> _allGroups;
        private ObservableCollection<GroupViewModel> _expandedGroups;

        public ProfesionalPage ()
		{
			InitializeComponent ();
            _allGroups = GroupViewModel.AllP;
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