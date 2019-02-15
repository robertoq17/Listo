using Listo.Services;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Listo.ViewModels;
using System;
using System.Threading.Tasks;

namespace Listo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UbicationsPage : ContentPage
    {
        #region Services
        GeoLocatorService geoLocatorService;
        #endregion

        #region Constructor
        public UbicationsPage()
        {
            InitializeComponent();

            geoLocatorService = new GeoLocatorService();

            MoveMapToCurrentPosition();
        }
        #endregion

        #region Methods
        //Move the map to your location
        async void MoveMapToCurrentPosition()
        {
            await geoLocatorService.GetLocation();
            if (geoLocatorService.Latitud != 0 ||
                geoLocatorService.Longitud != 0)
            {
                var position = new Position(
                    geoLocatorService.Latitud,
                    geoLocatorService.Longitud);
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                    position,
                    Distance.FromKilometers(.5)));
            }

            await LoadPins();


        }

        //Load Pins on the map
        async Task LoadPins()
        {
            try
            {
                var ubicationViewModel = UbicationViewModel.GetInstance();

                await ubicationViewModel.LoadPins();

                foreach (var pin in ubicationViewModel.Pins)
                {
                    MyMap.Pins.Add(pin);
                }
            }
            catch (Exception e)
            {

                e.ToString();
            }

        }
        #endregion


    }
}