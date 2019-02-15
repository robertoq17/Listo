using Listo.Models;
using Listo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Listo.ViewModels
{
    public class UbicationViewModel : BaseViewModel
    {
        #region Service
        ApiService apiService;
        #endregion

        #region Properties
        public ObservableCollection<Pin> Pins { get; set; }

        public List<Ubication> Ubications { get; set; }
        #endregion

        #region Contructor
        public UbicationViewModel()
        {
            instance = this;
            apiService = new ApiService();


            //News Pins
            Ubications = new List<Ubication>
            {
                // Ubications
                new Ubication
                {
                   Address = "Calle prueba 1" , Description="Punto1", Latitude=-17.773072, Longitude=-63.189235999999994
                },
                new Ubication
                {
                    Address = "Calle prueba 2" , Description="Punto2", Latitude=-17.785336, Longitude=-63.20070799999996
                },
                new Ubication
                {
                    Address = "Calle prueba 3" , Description="Punto3", Latitude=-17.792797, Longitude=-63.13459399999999
                },
                new Ubication
                {
                    Address = "Calle prueba 4" , Description="Punto4", Latitude=-17.82345, Longitude=-63.144000000000005
                }
            };
        }
        #endregion

        #region Methods


        #region Singleton
        private static UbicationViewModel instance;

        public static UbicationViewModel GetInstance()
        {
            if (instance == null)
            {
                return new UbicationViewModel();
            }

            return instance;
        }
        #endregion

        //For the Service
        //public async Task LoadPins()
        //{
        //    var connection = await apiService.CheckConnection();
        //    if(!connection.IsSuccess)
        //    {
        //        await Application.Current.MainPage.DisplayAlert(
        //            "Error", connection.Message, "OK");
        //        return;
        //    }

        //    //var mainViewModel = MainViewModel.GetInstance();

        //    var response = await apiService.GetList<Ubication>(
        //        "",
        //        "",
        //        "");

        //    if (!response.IsSuccess)
        //    {
        //        await Application.Current.MainPage.DisplayAlert(
        //            "Error", connection.Message, "OK");
        //        return;
        //    }

        //    var ubications = (List<Ubication>)response.Result;
        //    Pins = new ObservableCollection<Pin>();
        //    foreach (var ubication in ubications)
        //    {
        //        Pins.Add(new Pin
        //        {
        //            Address = ubication.Address,
        //            Label = ubication.Description,
        //            Position = new Position(ubication.Latitude, ubication.Longitude),
        //            Type = PinType.Place,
        //        });
        //    }

        public async Task LoadPins()
        {

            try
            {

                var connection = await apiService.CheckConnection();
                if (!connection.IsSuccess)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error", connection.Message, "OK");
                    return;
                }

                //Load Ubications in Pins
                Pins = new ObservableCollection<Pin>();
                foreach (var ubication in Ubications)
                {
                    Pins.Add(new Pin
                    {
                        Address = ubication.Address,
                        Label = ubication.Description,
                        Position = new Position(ubication.Latitude, ubication.Longitude),
                        Type = PinType.Place
                    }
                    );
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
