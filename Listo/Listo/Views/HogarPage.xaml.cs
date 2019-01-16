using Listo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Listo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HogarPage : ContentPage
	{
		public HogarPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListHogar listElements = new ListHogar();
            ListCategory.ItemsSource = listElements.Elements;
            ListCategory.ItemSelected += ListCategory_ItemSelected;
        }

        private void ListCategory_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                var item = e.SelectedItem as Category;
                if (item.Name.ToLower()== "plomeros")
                {

                }
                else if (item.Name.ToLower() == "electricistas")
                {

                }
                else if (item.Name.ToLower() == "jardineros")
                {

                }
                else if (item.Name.ToLower() == "albañiles")
                {

                }
            }
        }
    }
}