using Listo.Models;
using Listo.Services;
using Listo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Listo.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private ObservableCollection<Category> myList;
        private Category itemSelect;
        //private List<Lista> listCategories;
        #endregion

        #region Properties
        public ObservableCollection<Category> MyList
        {
            get { return this.myList; }
            set { this.SetValue(ref this.myList, value); }
        }

        public Category ItemSelect
        {
            get
            {
                return itemSelect;
            }
            set
            {
                itemSelect = value;
                NextPage();
                OnPropertyChanged();
                
            }
        }
        #endregion

        #region Constructor
        public CategoryViewModel()
        {
            // for SERVICES
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


        //for the charge of service
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

        public async void NextPage()
        {
            //for instance new page ->await Navigation.PushAsync(new MainPage());
            //MainViewModel.GetInstance().SubCategory = new SubCategoryViewModel();

            if (string.IsNullOrEmpty(ItemSelect.Name))
            {
                await Application.Current.MainPage.DisplayAlert("ERROR", "CATEGORY DOESN'T EXIST", "OK");
                return;
            }

            MainViewModel.GetInstance().SubCategory = new SubCategoryViewModel(this.ItemSelect);
            await Application.Current.MainPage.Navigation.PushAsync(new SubCategoryPage());
        }

        #endregion

        #region Commands

        public ICommand NextPageCommand
        {
            get
            {
                return new Command((item) =>
                {
                    ItemSelect = item as Category;
                });
            }
        }


        #endregion

    }
}
