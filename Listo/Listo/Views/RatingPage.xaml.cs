using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listo.ViewModels;
using Syncfusion.SfRating;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Listo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RatingPage : ContentPage
	{
		public RatingPage ()
		{
			InitializeComponent ();
            Title = "Time to Rating!";

		}
	}
}