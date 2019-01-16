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
	public partial class CategoryPage : ContentPage
	{
		public CategoryPage ()
		{
			InitializeComponent ();

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Lista listElements = new Lista();
            ListCategory.ItemsSource = listElements.Elements;
            ListCategory.ItemSelected += ListCategory_ItemSelected;

        }

        private async void ListCategory_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //await Navigation.PushAsync(new MainPage());
            if (e.SelectedItem != null)
            {
                var item = e.SelectedItem as Category;
                if (item.Name.ToLower() == "hogar")
                {
                    DisplayAlert("HOGAR", "bienvenido a hogar", "ok");
                    await Navigation.PushAsync(new HogarPage());
                }
                else if (item.Name.ToLower() == "salud")
                {
                    DisplayAlert("SALUD", "bienvenido a salud", "ok");
                    await Navigation.PushAsync(new SaludPage());
                }
                else if (item.Name.ToLower() == "profesionales")
                {
                    DisplayAlert("PROFESIONALES", "bienvenido a profesionales", "ok");
                    await Navigation.PushAsync(new ProfesionalPage());
                }

            }

        }

        private void ButtonRequests_Clicked(object sender, EventArgs e)
        {

        }
    }
}