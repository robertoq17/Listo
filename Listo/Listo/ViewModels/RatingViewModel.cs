using GalaSoft.MvvmLight.Command;
using Listo.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Listo.ViewModels
{
    public class RatingViewModel:BaseViewModel
    {
        #region Attributes
        double rating;
        string nameContact;
        #endregion
        #region Properties
        public int IdContact { get; set; }

        public double Rating
        {
            get { return this.rating; }
            set { this.SetValue(ref this.rating, value); }
        }

        public string NameContact
        {
            get { return this.nameContact; }
            set { this.SetValue(ref this.nameContact, value); }
        }
        #endregion

        #region Constructor
        public RatingViewModel()
        {
            this.Rating = 5;
        }

        public RatingViewModel(string name)
        {
            NameContact = name;
            this.Rating = 0;
        }
        #endregion

        #region Methods
        async void BackToOfRating()
        {
            try
            {
                await App.Current.MainPage.DisplayAlert("Test Value Rating", "Contacto: "+ NameContact +" || "+ "Puntaje: "+Rating.ToString(), "ok");
                //MainViewModel.GetInstance().Categories = new CategoryViewModel();
                //await App.Current.MainPage.Navigation.PushAsync(new CategoryPage());                
            }
            catch (Exception e)
            {

                e.ToString();
            }
        }
        #endregion

        #region Commands
        public ICommand BackRatingCommand
        {
            get
            {
                return new RelayCommand(BackToOfRating);
            }
        }
        #endregion
    }
}
