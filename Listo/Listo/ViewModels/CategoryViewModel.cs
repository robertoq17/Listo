using Listo.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Listo.ViewModels
{
    public class CategoryViewModel
    {
        #region Attributes
        private ApiService apiService;
        //private ObservableCollection<Lista> myList;
        #endregion


        #region Constructor
        public CategoryViewModel()
        {
            //FOR THE SERVICES
            //this.apiService = new ApiService();
            //this.LoadCategories();
        }

        #endregion

        #region Properties
        //public ObservableCollection<Lista> MyList
        //{
        //    get { return this.myList; }
        //    set { this.SetValue(ref this.myList, value); }
        //}
        #endregion


        #region Methods
        //private async void LoadCategories()
        //{
        //    var connection = await this.apiService.CheckConnection();

        //    if(!connection.IsSuccess)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("ERROR", connection.Message, "ok");
        //        await Application.Current.MainPage.Navigation.PopAsync();
        //        return;
        //    }


        // Here you put url of your service
        //    var response = await this.apiService.GetList<Lista>(
        //        "",
        //        "",
        //        "");

        //    if (!response.IsSuccess)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("ERROR", response.Message, "ok");
        //        return;
        //    }

        //    var list = (List<Lista>)response.Result;
        //    this.MyList = new ObservableCollection<Lista>(list);

        //}
        #endregion

        #region Commands

        #endregion

    }
}
