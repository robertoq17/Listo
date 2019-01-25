using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Listo.Views;
using Listo.Models;

namespace Listo.ViewModels
{
    public class CategoryItemViewModel: Category
    {
        #region Commands
        public ICommand SelectCategoryCommand
        {
            get
            {
                return new RelayCommand(SelectCategory);
            }
        }

        private async void SelectCategory()
        {
            //MainViewModel.GetInstance().Categories = new CategoryViewModel(this);
            //await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
        }
        #endregion
    }
}
