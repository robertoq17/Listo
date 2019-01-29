using Listo.Models;
using Listo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Listo.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private ObservableCollection<Category> myList;
        //private List<Lista> listCategories;
        #endregion

        #region Properties
        public ObservableCollection<Category> MyList
        {
            get { return this.myList; }
            set { this.SetValue(ref this.myList, value); }
        }
        #endregion

        #region Constructor
        public CategoryViewModel()
        {
            //FOR THE SERVICES
            //this.apiService = new ApiService();
            this.LoadCategories();
        }



        #endregion

        #region Methods

        private void LoadCategories()
        {
            MyList = new ObservableCollection<Category>{
                new Category()
                {
                    Name = "HOGAR",
                    Detail = ""
                },
                new Category()
                {
                    Name = "SALUD",
                    Detail = ""
                },
                new Category()
                {
                    Name = "PROFESIONALES",
                    Detail = ""
                } };
        }

        //private async void LoadCategories()
        //{
        //    var connection = await this.apiService.CheckConnection();

        //    if (!connection.IsSuccess)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("ERROR", connection.Message, "ok");
        //        await Application.Current.MainPage.Navigation.PopAsync();
        //        return;
        //    }


        //    // Here you put url of your service
        //    //    var response = await this.apiService.GetList<Lista>(
        //    //        "",
        //    //        "",
        //    //        "");

        //    //    if (!response.IsSuccess)
        //    //    {
        //    //        await Application.Current.MainPage.DisplayAlert("ERROR", response.Message, "ok");
        //    //        return;
        //    //    }

        //    //    this.listCategories = (List<Lista>)response.Result;
        //    //    this.MyList = new ObservableCollection<Lista>(this.listCategories);
        //    //}

        //    //private IEnumerable<CategoryItemViewModel> ToCategoryItemViewModel()
        //    //{
        //    //    return MainViewModel.GetInstance().MyList.Select(l => new CategoryItemViewModel
        //    //    {
        //    //        Alpha2Code = l.Alpha2Code,
        //    //        Alpha3Code = l.Alpha3Code,
        //    //        AltSpellings = l.AltSpellings,
        //    //        Area = l.Area,
        //    //    });
        //    //}

        #endregion

        #region Commands

        #endregion

    }
}
